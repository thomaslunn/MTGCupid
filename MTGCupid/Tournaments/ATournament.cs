using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGCupid.Matches;
using MTGCupid.Pairings;

namespace MTGCupid.Tournaments
{
    internal abstract class ATournament
    {
        private readonly Random rand = new Random();
        protected List<Player> Players { get; }
        protected List<IMatch> matchesInProgress { get; } = new List<IMatch>();
        protected List<IMatch> allMatches { get; } = new List<IMatch>();
        public bool AwaitingMatchResults { get; protected set; } = false;
        public int CurrentRound { get; protected set; } = 1;

        public ATournament(List<string> players)
        {
            // Initially shuffle the players list to ensure first round pairings are random
            // Also set an initial seed for each player
            Players = players
                .OrderBy(_ => rand.Next())
                .Select((name, index) => new Player(name) { Seed = "=1" })
                .ToList();
        }

        public abstract (List<IPairing> pairings, List<Player> byePlayer) SuggestNextRoundPairings();

        public List<IMatch> CreateRoundWithPairings(List<IPairing> pairings, List<Player> byePlayers)
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
            allMatches.AddRange(matchesInProgress);

            return matchesInProgress;
        }

        protected abstract void UpdateStandings();

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
    }
}
