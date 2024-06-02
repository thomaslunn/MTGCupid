using MTGCupid.Pairings;
using MTGCupid.Rulesets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    internal class SwissMultiplayerTournament : AMultiplayerTournament
    {
        public override string TournamentType => TournamentTypeString;
        public const string TournamentTypeString = "Multiplayer Tournament";

        public SwissMultiplayerTournament(List<string> players, IRuleset ruleset) : base(players, ruleset) { }
        internal SwissMultiplayerTournament(List<Player> players, IRuleset ruleset) : base(players, ruleset) { }

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

            MatchesInProgress.Clear();

            if (unpairedPlayers.Count < 3 || !CreatePairings(unpairedPlayers, out var matches))
                throw new InvalidOperationException("Unable to create pairings: no possible matchup.");
         
            List<IPairing> pairings = matches.Select(players => (IPairing)new MultiplayerPairing(players.Select(p => Players[p]))).ToList();
            // Byes list is empty: no byes in multiplayer!
            return (pairings, new List<Player>());
        }
    }
}
