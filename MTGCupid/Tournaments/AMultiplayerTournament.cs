﻿using MTGCupid.Matches;
using MTGCupid.Rulesets;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    internal abstract class AMultiplayerTournament : ATournament
    {
        /// <summary>
        /// Acceptable game sizes for a four-player tournament:
        /// Num players | Pod sizes
        /// 4           | 4
        /// 5           | 5
        /// 6           | 3,3
        /// 7           | 4,3
        /// 8           | 4,4
        /// 9           | 3,3,3
        /// 10          | 4,3,3
        /// 11          | 4,4,3
        /// 12          | 4,4,4
        /// 13          | 4,3,3,3
        /// 14          | 4,4,3,3
        /// 15          | 4,4,4,3
        /// 16          | 4,4,4,4
        /// ...         | ...
        /// 
        /// Numbers larger than 12 will begin with an arrangement for 9-12 players and complete the rest using 4-man games
        /// Higher seeded players will always be placed into the larger games
        /// 
        /// Each game cannot contain three players who have all played together already
        /// </summary>
        protected AMultiplayerTournament(List<string> players, ARuleset ruleset) : base(players, ruleset) { }
        protected AMultiplayerTournament(List<Player> players, ARuleset ruleset) : base(players, ruleset) { }

        protected override void UpdateWinPercentages()
        {
            // Update match win percentage + game win percentage (as they are equal)
            // Match win percentage is interpreted as the average number of points per game
            foreach (var player in Players)
            {
                if (player.CompletedMatches.Count() == 0)
                    player.MatchWinPercentage = 0;
                else
                    player.MatchWinPercentage = player.CompletedMatches.Average(m => m.MatchPointsOf(player));
                player.GameWinPercentage = player.MatchWinPercentage;
            }

            // Update opponent match win percentage + opponent game win percentage
            foreach (var player in Players)
            {
                var matches = player.CompletedMatches.Where(m => m is not Bye).Cast<MultiplayerGame>(); // Byes are discounted in OMW%
                if (matches.Count() == 0)
                    player.OpponentMatchWinPercentage = 100; // Max value
                else
                {
                    var opponents = matches.SelectMany(m => m.Players).Where(p => p != player); // Allow duplicates so that facing
                    // the same player multiple times influences the OMW% more
                    player.OpponentMatchWinPercentage = opponents.Sum(p => p.MatchWinPercentage) / opponents.Count();
                }
                player.OpponentGameWinPercentage = player.OpponentMatchWinPercentage;
            }
        }

        protected bool CreatePairings(List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<List<int>> matches)
        {
            return CreatePairings(Players, unpairedPlayers, out matches);
        }

        protected bool CreatePairings(IList<Player> playerSource, List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<List<int>> matches)
        {
            if (unpairedPlayers.Count == 0)
            {
                // Base case: all players have been paired
                matches = new List<List<int>>();
                return true;
            }

            int podSizeToCreate = 4;
            if (unpairedPlayers.Count == 5)
                podSizeToCreate = 5;
            else if (unpairedPlayers.Count == 9
                || unpairedPlayers.Count == 6
                || unpairedPlayers.Count == 3)
                podSizeToCreate = 3;

            // Try and create a match (and hence further matches) of the desired size
            List<int> match = new List<int>();
            if (CreateMatch(playerSource, unpairedPlayers, podSizeToCreate, match, out matches))
            {
                // Match created successfully
                return true;
            }

            // Pairing unsuccessful
            matches = null;
            return false;
        }
    
        private bool CreateMatch(IList<Player> playerSource, List<int> unpairedPlayers, int gameSizeToCreate, List<int> match, [MaybeNullWhen(false)] out List<List<int>> matches)
        {
            bool CanCreateMatchesWithRestriction(Func<IList<Player>, IEnumerable<int>, bool> playersSatisfyMatchRestriction, [MaybeNullWhen(false)] out List<List<int>> matches)
            {
                // Try adding each player in turn to the match
                for (int i = 0; i < unpairedPlayers.Count; i++)
                {
                    int player = unpairedPlayers[i];
                    unpairedPlayers.RemoveAt(i);
                    match.Add(player);

                    if (playersSatisfyMatchRestriction(playerSource, match))
                    {
                        if (match.Count == gameSizeToCreate)
                        {
                            // Full game created - try and create further matches
                            if (CreatePairings(playerSource, unpairedPlayers, out matches))
                            {
                                matches.Insert(0, match);
                                return true;
                            }
                        }
                        // Need to add another player to the match
                        else if (CreateMatch(playerSource, unpairedPlayers, gameSizeToCreate, match, out matches))
                        {
                            // Match added to matches set deeper in the recursion, so no need to add it here
                            return true;
                        }
                    }
                    // Matchmaking failed, remove player from match
                    match.RemoveAt(match.Count - 1);
                    unpairedPlayers.Insert(i, player);
                }
                matches = null;
                return false;
            }

            // If variety multiplayer pairing is preferred, first try to pair prioritising variety
            // If this fails, we will fall back to pairing evenly (with better performing players getting better variety where possible)
            if (Ruleset.MatchmakingSettings.MultiplayerMatchmakingPriority == MatchmakingSettings.EMultiplayerMatchmakingPriority.PrioritiseVariedMatchups)
            {
                if (CanCreateMatchesWithRestriction(CanPairVariety, out matches))
                    return true;
            }

            if (CanCreateMatchesWithRestriction(CanPairEvenly, out matches))
                return true;

            // Matchmaking failed
            return false;
        }

        private bool CanPairEvenly(IList<Player> playerSource, IEnumerable<int> players)
        {
            // Can pair if no trio of players have already played together
            return players.Count() < 3 || allMatches.All(m => players.Count(p => m.HasParticipant(playerSource[p])) < 3);
        }

        private bool CanPairVariety(IList<Player> playerSource, IEnumerable<int> players)
        {
            // Can pair if no pair of players have already played together
            return players.Count() < 2 || allMatches.All(m => players.Count(p => m.HasParticipant(playerSource[p])) < 2);
        }

        public override List<PlayerStandings> GetStandings()
        {
            return Players.OrderBy(p => p, Ruleset).Select(p => new PlayerStandings(p, false)).ToList();
        }
    }
}
