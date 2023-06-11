using MTGCupid.Pairings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    internal class SwissMultiplayerTournament : AMultiplayerTournament
    {
        public SwissMultiplayerTournament(List<string> players) : base(players) { }

        public override (List<IPairing> pairings, List<Player> byePlayer) SuggestNextRoundPairings()
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

            if (unpairedPlayers.Count < 3 || !CreatePairings(unpairedPlayers, out var matches))
                throw new InvalidOperationException("Unable to create pairings: no possible matchup.");
         
            List<IPairing> pairings = matches.Select(players => (IPairing)new MultiplayerPairing(players.Select(p => Players[p]))).ToList();
            // Byes list is empty: no byes in multiplayer!
            return (pairings, new List<Player>());
        }
    }
}
