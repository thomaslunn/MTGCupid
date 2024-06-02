using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGCupid.Pairings;
using MTGCupid.Rulesets;

namespace MTGCupid.Tournaments
{
    internal class SwissDraftTournament : ATwoPlayerTournament, IPoddedTournament
    {
        /// <summary>
        /// Acceptable pod sizes for a Swiss Draft tournament:
        /// 
        /// Num players | Pod sizes
        /// 4           | 4
        /// 5           | 5
        /// 6           | 6
        /// 7           | 7
        /// 8           | 8
        /// 9           | 9
        /// 10          | 10
        /// 11          | 11 * this is the worst case scenario
        /// 12          | 6,6
        /// 13          | 7,6
        /// 14          | 8,6
        /// 15          | 8,7
        /// 16          | 8,8
        /// 17          | 9,8
        /// 18          | 10,8
        /// 19          | 10,9
        /// 20          | 8,6,6
        /// 21          | 8,7,6
        /// 22          | 8,8,6
        /// 23          | 8,8,7
        /// 24          | 8,8,8
        /// 25          | 9,8,8
        /// 26          | 10,8,8
        /// 27          | 10,9,8
        /// 28          | 8,8,6,6
        /// 29          | 8,8,7,6
        /// 30          | 8,8,8,6
        /// 31          | 8,8,8,7
        /// 32          | 8,8,8,8
        /// ...         | ...
        /// 
        /// Numbers larger than 19 will begin with an arrangement for 12 - 19 players and complete the rest using 8-man pods.
        /// </summary>

        private List<Player[]> Pods { get; } = new List<Player[]>();
        public override string TournamentType => TournamentTypeString;
        public const string TournamentTypeString = "Swiss Draft";
        public SwissDraftTournament(List<string> players, ARuleset ruleset) : base(players, ruleset)
        {
            // Initialise pods
            int poddedPlayers = 0;

            void AddPod(int size)
            {
                Player[] pod = new Player[size];
                for (int i = 0; i < size; i++)
                {
                    pod[i] = Players[poddedPlayers + i];
                }
                poddedPlayers += size;
                Pods.Add(pod);
            }

            while (poddedPlayers < players.Count)
            {
                // Can create an 8 player pod if at least 20 players remain
                if (players.Count - poddedPlayers >= 20)
                {
                    AddPod(8);
                }
                // Otherwise use table above
                else if (players.Count - poddedPlayers >= 18)
                {
                    AddPod(10);
                }
                //else if (players.Count - poddedPlayers >= 16)
                //{
                //    AddPod(8);
                //}
                else if (players.Count - poddedPlayers >= 14)
                {
                    AddPod(8);
                }
                else if (players.Count - poddedPlayers >= 12)
                {
                    AddPod(6);
                }
                else
                {
                    AddPod(players.Count - poddedPlayers);
                }
            }
        }
        public SwissDraftTournament(List<Player> players, ARuleset ruleset, List<Player[]> pods) : base(players, ruleset)
        {
            Pods = pods;
        }
        public List<Player[]> GetDraftSeating()
        {
            List<Player[]> seating = new List<Player[]>();

            foreach (var pod in Pods)
            {
                Player[] podSeating = new Player[pod.Length];
                seating.Add(podSeating);

                // Adjust seating so that first round pairings are across-pod
                int half = (pod.Length + 1) / 2;
                for (int i = 0; i < half; i++)
                {
                    podSeating[i] = pod[2 * i];
                    if (i * 2 + 1 < pod.Length)
                        podSeating[i + half] = pod[2 * i + 1];
                }
            }

            return seating;
        }
        public List<Player[]> GetPods()
        {
            return Pods;
        }

        public override (List<IPairing> pairings, List<Player> byePlayer) SuggestNextRoundPairings()
        {
            if (AwaitingMatchResults)
                throw new InvalidOperationException("Cannot create next round pairings while matches are in progress.");

            MatchesInProgress.Clear();
            List<Player> byePlayers = new List<Player>();
            List<IPairing> pairings = new List<IPairing>();

            var sortedPlayers = Players.OrderBy(p => p, Ruleset.PairingsComparer).ToList();

            foreach (var pod in Pods)
            {
                // Filter out players that have dropped
                List<int> unpairedPlayers = pod
                    .Select((p, index) => (p, index))
                    .Where(pair => !pair.p.HasDropped)
                    .OrderBy(pair => sortedPlayers.IndexOf(pair.p)) // Ensure players are in seed order
                    .Select(p => p.index).ToList();

                if (unpairedPlayers.Count % 2 != 0)
                {
                    bool hasAddedBye = false;
                    // Decide byes first
                    for (int i = unpairedPlayers.Count - 1; i >= 0; i--)
                    {
                        int playerIndex = unpairedPlayers[i];

                        if (pod[playerIndex].ByesReceived == 0)
                        {
                            unpairedPlayers.RemoveAt(i);
                            byePlayers.Add(pod[playerIndex]);
                            hasAddedBye = true;
                            break;
                        }
                    }
                    if (!hasAddedBye)
                        throw new InvalidOperationException("Unable to create pairings: all players have received a bye.");
                }

                // Recursively create pairings
                if (unpairedPlayers.Count == 0 || !CreatePairings(pod, unpairedPlayers, out var matches))
                    throw new InvalidOperationException("Unable to create pairings: no possible matchup.");

                pairings.AddRange(matches.Select(m => new Pairing(pod[m.p1], pod[m.p2])));
            }

            return (pairings, byePlayers);
        }
    }
}
