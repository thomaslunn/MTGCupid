﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid
{
    internal abstract class Tournament
    {
        private readonly Random rand = new Random();
        protected List<Player> Players { get; }
        protected List<Match> matchesInProgress { get; } = new List<Match>();
        public bool AwaitingMatchResults { get; protected set; } = false;
        public int CurrentRound { get; protected set; } = 1;
        
        public Tournament(List<string> players)
        {
            // Initially shuffle the players list to ensure first round pairings are random
            // Also set an initial seed for each player
            Players = players
                .OrderBy(_ => rand.Next())
                .Select((name, index) => new Player(name) { Seed = "=1" })
                .ToList();
        }

        public abstract (List<IPairing> pairings, List<Player> byePlayer) SuggestNextRoundPairings();

        public List<Match> CreateRoundWithPairings(List<IPairing> pairings, List<Player> byePlayers)
        {
            matchesInProgress.Clear();
            foreach (var pairing in pairings)
            {
                matchesInProgress.Add(pairing.CreateMatch());
            }
            foreach (var byePlayer in byePlayers)
            {
                byePlayer.ByesReceived++;
                matchesInProgress.Add(new Bye(byePlayer));
            }

            AwaitingMatchResults = true;

            return matchesInProgress;
        }

        private void UpdateStandings()
        {
            // Update match win percentage
            foreach (var player in Players)
            {
                player.MatchWinPercentage = player.Matches.Sum(m => m.MatchPointsOf(player)) / (3.0 * player.Matches.Count);
                if (player.MatchWinPercentage < 0.33) // Enforced lower bound of 33% match win percentage
                    player.MatchWinPercentage = 0.33;
            }

            // Update opponent match win percentage
            foreach (var player in Players)
            {
                var matches = player.Matches.Where(m => m is not Bye); // Byes are discounted in OMW%
                if (matches.Count() == 0)
                    player.OpponentMatchWinPercentage = 1;
                else
                    player.OpponentMatchWinPercentage = matches.Sum(m => m.OpponentOf(player).MatchWinPercentage) / matches.Count();
            }

            // Update game win percentage
            foreach (var player in Players)
            {
                var gamesPlayed = player.Matches.Sum(m => m.GamesPlayed);
                if (gamesPlayed == 0)
                {
                    player.GameWinPercentage = 1; // Default to 100% game win percentage if no games played
                    continue;
                }
                player.GameWinPercentage = player.Matches.Sum(m => m.GamePointsOf(player)) / (3.0 * player.Matches.Sum(m => m.GamesPlayed));
                if (player.GameWinPercentage < 0.33) // Enforced lower bound of 33% game win percentage
                    player.GameWinPercentage = 0.33;
            }

            // Update opponent game win percentage
            foreach (var player in Players)
            {
                var gamesPlayed = player.Matches.Sum(m => m.GamesPlayed);
                if (gamesPlayed == 0)
                {
                    player.OpponentGameWinPercentage = 0; // Default to 0% opponent game win percentage if no games played
                    continue;
                }
                var matches = player.Matches.Where(m => m is not Bye); // Bytes are discounted in OGW%
                if (matches.Count() == 0)
                    player.OpponentGameWinPercentage = 1;
                else
                    player.OpponentGameWinPercentage = matches.Sum(m => m.OpponentOf(player).GameWinPercentage) / matches.Count();
            }

            // Sort players by tiebreakers
            Players.Sort();

            // Update player positions, tracking players on equal seed
            string lastEqualSeed = "=1";
            for (int i = 0; i < Players.Count; i++)
            {
                if (i != 0 && Players[i].HasEquivalentScoreTo(Players[i - 1]))
                {
                    Players[i].Seed = lastEqualSeed;
                    Players[i - 1].Seed = lastEqualSeed; // Ensure previous player has the "=" marker if it's a draw
                }
                else
                {
                    Players[i].Seed = (i + 1).ToString();
                    lastEqualSeed = string.Format("={0}", i + 1);
                }
            }

            // Increment round number
            CurrentRound++;
        }

        /// <summary>
        /// Confirms that all matches have been completed and updates standings
        /// </summary>
        /// <returns>True if all matches successfully received a match result and standings have been updated; false otherwise</returns>
        public bool SubmitMatchResults()
        {
            if (matchesInProgress.Any(m => !m.Completed))
                return false;

            matchesInProgress.Clear();
            AwaitingMatchResults = false;
            UpdateStandings();
            return true;
        }

        public List<PlayerStandings> GetStandings()
        {
            return Players.Select(p => new PlayerStandings(p)).ToList();
        }
        
        protected bool CreatePairings(List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<(int p1, int p2)> matches)
        {
            return CreatePairings(Players, unpairedPlayers, out matches);
        }

        protected bool CreatePairings(IList<Player> playerSource, List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<(int p1, int p2)> matches)
        {
            // Try to match the first unpaired player with the closest new opponent
            int p1 = unpairedPlayers[0];
            unpairedPlayers.RemoveAt(0);

            for (int i = 0; i < unpairedPlayers.Count; i++)
            {
                int p2 = unpairedPlayers[i];

                if (playerSource[p1].HasPlayed(playerSource[p2]))
                    continue; // Player already played this opponent

                unpairedPlayers.RemoveAt(i);

                if (unpairedPlayers.Count == 0) // Pairing is complete
                {
                    matches = new List<(int p1, int p2)>() { (p1, p2) };
                    return true;
                }
                if (CreatePairings(playerSource, unpairedPlayers, out matches))
                {
                    // Insert at beginning so that higher ranked players are at the top of the list
                    matches.Insert(0, (p1, p2));
                    return true;
                }
                unpairedPlayers.Insert(i, p2);
            }

            // Pairing unsuccessful
            unpairedPlayers.Insert(0, p1);
            matches = null;
            return false;
        }
    }
}
