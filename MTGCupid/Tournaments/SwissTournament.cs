using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MTGCupid.Pairings;
using MTGCupid.Rulesets;

namespace MTGCupid.Tournaments
{
    internal class SwissTournament : ATwoPlayerTournament
    {
        public override string TournamentType => TournamentTypeString;
        public const string TournamentTypeString = "Swiss Tournament";
        public SwissTournament(List<string> players, ARuleset ruleset) : base(players, ruleset) { }
        public SwissTournament(List<Player> players, ARuleset ruleset) : base(players, ruleset) { }

        public override (List<IPairing> pairings, List<Player> byePlayer) SuggestNextRoundPairings()
        {
            if (AwaitingMatchResults)
                throw new InvalidOperationException("Cannot create next round pairings while matches are in progress.");

            // Recieved all match results, so all tiebreakers in players are already updated
            // Filter out players that have dropped
            List<int> unpairedPlayers = Players
                .Select((p, index) => (p, index))
                .Where(p => !p.p.HasDropped)
                .OrderBy(tup => tup.p, Ruleset.PairingsComparer)
                .Select(p => p.index).ToList();

            MatchesInProgress.Clear();

            List<Player> byePlayers = new List<Player>();
            if (unpairedPlayers.Count % 2 != 0)
            {
                // Decide byes first
                for (int i = unpairedPlayers.Count - 1; i >= 0; i--)
                {
                    int playerIndex = unpairedPlayers[i];

                    if (Players[playerIndex].ByesReceived == 0)
                    {
                        unpairedPlayers.RemoveAt(i);
                        byePlayers.Add(Players[playerIndex]);
                        break;
                    }
                }
                if (byePlayers.Count == 0)
                    throw new InvalidOperationException("Unable to create pairings: all players have received a bye.");
            }

            // Recursively create pairings
            if (unpairedPlayers.Count == 0 || !CreatePairings(unpairedPlayers, out var matches))
                throw new InvalidOperationException("Unable to create pairings: no possible matchup.");

            List<IPairing> pairings = matches.Select(m => (IPairing)new Pairing(Players[m.p1], Players[m.p2])).ToList();

            return (pairings, byePlayers);
        }
    }
}
