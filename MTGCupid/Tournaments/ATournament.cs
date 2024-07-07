using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MTGCupid.Matches;
using MTGCupid.Pairings;
using MTGCupid.Rulesets;

namespace MTGCupid.Tournaments
{
    public abstract class ATournament
    {
        private readonly Random rand = new Random();
        protected List<Player> Players { get; }
        public List<IMatch> MatchesInProgress { get; } = new List<IMatch>();
        protected List<IMatch> allMatches { get; } = new List<IMatch>();
        public bool AwaitingMatchResults { get; protected set; } = false;
        public int CurrentRound { get; protected set; } = 0;
        public abstract string TournamentType { get; }

        public ARuleset Ruleset { get; }

        internal ATournament(List<string> players, ARuleset ruleset)
        {
            Ruleset = ruleset;

            // Initially shuffle the players list to ensure first round pairings are random
            // Also set an initial seed for each player
            Players = players
                .OrderBy(_ => rand.Next())
                .Select(name => new Player(name, ruleset) { Seed = "=1" })
                .ToList();
        }
        internal ATournament(List<Player> players, ARuleset ruleset)
        {
            Ruleset = ruleset;

            Players = players;
        }

        public abstract (List<IPairing> pairings, List<Player> byePlayer) SuggestNextRoundPairings();

        public List<IMatch> CreateRoundWithPairings(List<IPairing> pairings, List<Player> byePlayers)
        {
            CurrentRound++;

            MatchesInProgress.Clear();
            foreach (var pairing in pairings)
            {
                MatchesInProgress.Add(pairing.CreateMatch(Ruleset));
            }
            foreach (var byePlayer in byePlayers)
            {
                byePlayer.ByesReceived++;
                MatchesInProgress.Add(new Bye(byePlayer));
            }

            AwaitingMatchResults = true;
            allMatches.AddRange(MatchesInProgress);

            SaveTournamentProgress();

            return MatchesInProgress;
        }

        protected abstract void UpdateWinPercentages();

        /// <summary>
        /// Confirms that all matches have been completed and updates standings
        /// </summary>
        /// <returns>True if all matches successfully received a match result and standings have been updated; false otherwise</returns>
        public bool SubmitMatchResults()
        {
            if (MatchesInProgress.Any(m => !m.Completed))
                return false;

            MatchesInProgress.Clear();
            AwaitingMatchResults = false;
            UpdateWinPercentages();
            UpdatePlayerSeeds();
            SaveTournamentProgress();
            return true;
        }

        private void UpdatePlayerSeeds()
        {
            // Sort players by tiebreakers
            var sortedPlayers = Players.OrderBy(p => p, Ruleset).ToList();

            // Update player positions, tracking players on equal seed
            string lastEqualSeed = "=1";
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                if (i != 0 && sortedPlayers[i].HasEquivalentScoreTo(sortedPlayers[i - 1]))
                {
                    sortedPlayers[i].Seed = lastEqualSeed;
                    sortedPlayers[i - 1].Seed = lastEqualSeed; // Ensure previous player has the "=" marker if it's a draw
                }
                else
                {
                    sortedPlayers[i].Seed = (i + 1).ToString();
                    lastEqualSeed = string.Format("={0}", i + 1);
                }
            }
        }

        public virtual List<PlayerStandings> GetStandings()
        {
            return Players.OrderBy(p => p, Ruleset).Select(p => new PlayerStandings(p)).ToList();
        }

        public static ATournament LoadTournament(string path)
        {
            string json = File.ReadAllText(path);
            var export = JsonSerializer.Deserialize<TournamentExport>(json);
            if (export == null)
                throw new FileFormatException("Provided file is not a valid tournament export.");

            MatchmakingSettings settings = new MatchmakingSettings();
            settings.MultiplayerMatchmakingPriority = GetEnumValueFromString<MatchmakingSettings.EMultiplayerMatchmakingPriority>(export.RulesetSettings.MultiplayerMatchmakingPriority);
            settings.TiebreakerHandling = GetEnumValueFromString<MatchmakingSettings.ETiebreakerHandling>(export.RulesetSettings.TiebreakerHandling);

            ARuleset ruleset = export.TournamentRuleset switch
            {
                MTGRuleset.RulesetString => new MTGRuleset(settings),
                SWURuleset.RulesetString => new SWURuleset(settings),
                _ => new MTGRuleset(settings), // Default to MTG for legacy compatability
            };

            List<Player> players = new List<Player>();
            Dictionary<string, Player> playerMap = new Dictionary<string, Player>();
            foreach (var playerExport in export.Players)
            {
                var player = new Player(playerExport.Name, ruleset);
                players.Add(player);
                if (playerExport.HasDropped)
                    player.Drop();
                playerMap.Add(playerExport.Name, player);
            }

            List<IMatch> matches = new List<IMatch>();
            foreach (var matchExport in export.CompletedMatches)
            {
                matches.Add(matchExport.GetMatch(playerMap, ruleset));
            }

            List<IMatch> matchesInProgress = new List<IMatch>();
            foreach (var matchExport in export.InProgressMatches)
            {
                var match = matchExport.GetMatch(playerMap, ruleset);
                matchesInProgress.Add(match);
                matches.Add(match);
            }

            List<Player[]> pods = new List<Player[]>();
            if (export.Pods != null)
            {
                foreach (var pod in export.Pods)
                {
                    pods.Add(pod.Select(name => playerMap[name]).ToArray());
                }
            }

            ATournament tournament = export.TournamentType switch
            {
                SwissTournament.TournamentTypeString => new SwissTournament(players, ruleset),
                SwissDraftTournament.TournamentTypeString => new SwissDraftTournament(players, ruleset, pods),
                SwissMultiplayerTournament.TournamentTypeString => new SwissMultiplayerTournament(players, ruleset),
                _ => throw new FileFormatException("Unexpected tournament type encountered: " + export.TournamentType)
            };

            tournament.CurrentRound = export.CurrentRound;
            tournament.allMatches.AddRange(matches);
            tournament.MatchesInProgress.AddRange(matchesInProgress);
            tournament.UpdateWinPercentages();
            tournament.UpdatePlayerSeeds();

            if (!export.RoundCompleted)
            {
                tournament.AwaitingMatchResults = true;
            }

            return tournament;
        }

        private static T GetEnumValueFromString<T>(string value) where T : Enum
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString().Equals(value)) return item;
            }
            throw new ArgumentException(value + " is not a valid value for " + typeof(T).Name, nameof(value));
        }

        public void SaveTournamentProgress(string path = "")
        {
            TournamentExport export = GetTournamentExport();

            if (path == "")
            {
                string filename = GetDefaultExportFilename();
                path = Path.Combine(Properties.Settings.Default.TournamentSaveLocation, filename);
            }

            File.WriteAllText(path, JsonSerializer.Serialize(export));
        }

        public string GetDefaultExportFilename()
        {
            string date = DateTime.Now.ToString("yyyy-MMM-dd");
            return string.Format("{0}_{1}.json", date, TournamentType);
        }

        private TournamentExport GetTournamentExport()
        {
            var tournamentExport = new TournamentExport
            {
                Players = Players.Select(p => new PlayerExport() { Name = p.Name, HasDropped = p.HasDropped }).ToList(),
                RoundCompleted = !AwaitingMatchResults,
                InProgressMatches = MatchesInProgress.Select(m => m.GetMatchExport(false)).ToList(),
                CompletedMatches = allMatches.Where(m => !MatchesInProgress.Contains(m)).Select(m => m.GetMatchExport()).ToList(),
                CurrentRound = CurrentRound,
                TournamentType = TournamentType,
                TournamentRuleset = Ruleset.Ruleset,
                RulesetSettings = new RulesetSettingsExport() 
                { 
                    MultiplayerMatchmakingPriority = Ruleset.MatchmakingSettings.MultiplayerMatchmakingPriority.ToString(), 
                    TiebreakerHandling = Ruleset.MatchmakingSettings.TiebreakerHandling.ToString()
                }
            };
            if (this is IPoddedTournament poddedTournament)
            {
                tournamentExport.Pods = poddedTournament.GetPods().Select(pod => pod.Select(player => player.Name).ToArray()).ToList();
            }
            return tournamentExport;
        }
    }
}
