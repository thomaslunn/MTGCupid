using MTGCupid.Matches;
using MTGCupid.Pairings;
using MTGCupid.Rulesets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid
{
    public class TournamentExport
    {
        public string TournamentType { get; set; } = "";
        public string? TournamentRuleset { get; set; } = "";
        public RulesetSettingsExport RulesetSettings { get; set; } = new RulesetSettingsExport();
        public int CurrentRound { get; set; }
        public bool RoundCompleted { get; set; }
        public List<PlayerExport> Players { get; set; } = new List<PlayerExport>();
        public List<MatchExport> CompletedMatches { get; set; } = new List<MatchExport>();
        public List<MatchExport> InProgressMatches { get; set; } = new List<MatchExport>();
        public List<string[]>? Pods { get; set; }
    }

    public class MatchExport
    {
        public string MatchType { get; set; } = "";
        public List<string> Players { get; set; } = new List<string>();
        public List<int>? Scores { get; set; }

        public IMatch GetMatch(Dictionary<string, Player> playerMap, ARuleset ruleset)
        {
            switch (MatchType)
            {
                case Bye.MatchType:
                    var byePlayer = playerMap[Players.First()];
                    return new Bye(byePlayer);

                case Match.MatchType:
                    var p1 = playerMap[Players.First()];
                    var p2 = playerMap[Players.Last()];
                    var pairing = new Pairing(p1, p2);
                    var match = new Match(pairing, ruleset);
                    if (Scores != null)
                        match.RecordResult(Scores.First(), Scores.Last());
                    return match;

                case MultiplayerGame.MatchType:
                    var playersInMatch = Players.Select(p => playerMap[p]).ToList();
                    var multiplayerPairing = new MultiplayerPairing(playersInMatch);
                    var multiplayerGame = new MultiplayerGame(multiplayerPairing, ruleset);
                    if (Scores != null)
                        for (int i = 0; i < Scores.Count; i++)
                        {
                            multiplayerGame.RecordResult(playersInMatch[i], Scores[i]);
                        }
                    return multiplayerGame;

                default:
                    throw new FileFormatException("Unexpected match type encountered: " + MatchType);
            }
        }
    }

    public class PlayerExport
    {
        public string Name { get; set; } = "";
        public bool HasDropped { get; set; }
    }

    public class RulesetSettingsExport
    {
        public string MultiplayerMatchmakingPriority { get; set; } = "";
        public string TiebreakerHandling { get; set; } = "";
    }
}
