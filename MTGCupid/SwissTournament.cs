using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGCupid
{
    internal class SwissTournament : Tournament
    {
        public SwissTournament(List<string> players) : base(players) { }

        public override (List<(Player p1, Player p2)> pairings, Player? byePlayer) SuggestNextRoundPairings()
        {
            if (AwaitingMatchResults)
                throw new InvalidOperationException("Cannot create next round pairings while matches are in progress.");

            // Recieved all match results, so all tiebreakers in players are already updated and sorted correctly
            // Filter out players that have dropped
            List<int> unpairedPlayers = Players
                .Select((p, index) => (p, index))
                .Where(p => !p.p.HasDropped)
                .Select(p => p.index).ToList();

            matchesInProgress.Clear();

            Player? byePlayer = null;
            if (unpairedPlayers.Count % 2 != 0)
            {
                // Decide byes first
                for (int i = unpairedPlayers.Count - 1; i >= 0; i--)
                {
                    int playerIndex = unpairedPlayers[i];

                    if (Players[playerIndex].ByesReceived == 0)
                    {
                        unpairedPlayers.RemoveAt(i);
                        byePlayer = Players[playerIndex];
                        break;
                    }
                }
                if (byePlayer == null)
                    throw new InvalidOperationException("Unable to create pairings.");
            }

            // Recursively create pairings
            if (unpairedPlayers.Count == 0 || !CreatePairings(unpairedPlayers, out var matches))
                throw new InvalidOperationException("Unable to create pairings.");

            List<(Player p1, Player p2)> pairings = matches.Select(m => (Players[m.p1], Players[m.p2])).ToList();

            return (pairings, byePlayer);
        }

        private bool CreatePairings(List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<(int p1, int p2)> matches)
        {
            // Try to match the first unpaired player with the closest new opponent
            int p1 = unpairedPlayers[0];
            unpairedPlayers.RemoveAt(0);

            for (int i = 0; i < unpairedPlayers.Count; i++)
            {
                int p2 = unpairedPlayers[i];

                if (Players[p1].HasPlayed(Players[p2]))
                    continue; // Player already played this opponent

                unpairedPlayers.RemoveAt(i);

                if (unpairedPlayers.Count == 0) // Pairing is complete
                {
                    matches = new List<(int p1, int p2)>() { (p1, p2) };
                    return true;
                }
                if (CreatePairings(unpairedPlayers, out matches))
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
