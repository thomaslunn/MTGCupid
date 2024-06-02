using MTGCupid.Matches;
using MTGCupid.Rulesets;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    internal abstract class ATwoPlayerTournament : ATournament
    {
        protected ATwoPlayerTournament(List<string> players, IRuleset ruleset) : base(players, ruleset) { }
        protected ATwoPlayerTournament(List<Player> players, IRuleset ruleset) : base(players, ruleset) { }

        protected override void UpdateWinPercentages()
        {
            // Update match win percentage
            foreach (var player in Players)
            {
                player.MatchWinPercentage = player.CompletedMatches.Sum(m => m.MatchPointsOf(player)) / (3.0 * player.CompletedMatches.Count());
                if (player.MatchWinPercentage < 0.33) // Enforced lower bound of 33% match win percentage
                    player.MatchWinPercentage = 0.33;
            }

            // Update opponent match win percentage
            foreach (var player in Players)
            {
                var matches = player.CompletedMatches.Where(m => m is not Bye).Cast<Match>(); // Byes are discounted in OMW%
                if (matches.Count() == 0)
                    player.OpponentMatchWinPercentage = 1;
                else
                    player.OpponentMatchWinPercentage = matches.Sum(m => m.OpponentOf(player).MatchWinPercentage) / matches.Count();
            }

            // Update opponent opponent match win percentage
            foreach (var player in Players)
            {
                var matches = player.CompletedMatches.Where(m => m is not Bye).Cast<Match>(); // Byes are discounted in OOMW%
                if (matches.Count() == 0)
                    player.OpponentOpponentMatchWinPercentage = 1;
                else
                    player.OpponentOpponentMatchWinPercentage = matches.Sum(m => m.OpponentOf(player).OpponentMatchWinPercentage) / matches.Count();
            }

            // Update game win percentage
            foreach (var player in Players)
            {
                var gamesPlayed = player.CompletedMatches.Sum(m => m.GamesPlayed);
                if (gamesPlayed == 0)
                {
                    player.GameWinPercentage = 1; // Default to 100% game win percentage if no games played
                    continue;
                }
                player.GameWinPercentage = player.CompletedMatches.Sum(m => m.GamePointsOf(player)) / (3.0 * player.CompletedMatches.Sum(m => m.GamesPlayed));
                if (player.GameWinPercentage < 0.33) // Enforced lower bound of 33% game win percentage
                    player.GameWinPercentage = 0.33;
            }

            // Update opponent game win percentage
            foreach (var player in Players)
            {
                var gamesPlayed = player.CompletedMatches.Sum(m => m.GamesPlayed);
                if (gamesPlayed == 0)
                {
                    player.OpponentGameWinPercentage = 0; // Default to 0% opponent game win percentage if no games played
                    continue;
                }
                var matches = player.CompletedMatches.Where(m => m is not Bye).Cast<Match>(); // Byes are discounted in OGW%
                if (matches.Count() == 0)
                    player.OpponentGameWinPercentage = 1;
                else
                    player.OpponentGameWinPercentage = matches.Sum(m => m.OpponentOf(player).GameWinPercentage) / matches.Count();
            }
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
