using MTGCupid.Rulesets;
using MTGCupid.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    public class TournamentFactory
    {
        public enum TournamentRuleset
        {
            MagicTheGathering = 0,
            StarWarsUnlimited = 1
        }
        public enum TournamentType
        {
            SwissTournament = 0,
            SwissDraft = 1,
            SwissMultiplayerTournament = 2
        }

        private TournamentRuleset ruleset = TournamentRuleset.MagicTheGathering;
        private TournamentType type = TournamentType.SwissTournament;
        private readonly List<string> players = new List<string>();


        public TournamentFactory() { }

        public TournamentFactory WithRuleset(TournamentRuleset ruleset)
        {
            this.ruleset = ruleset;
            return this;
        }

        public TournamentFactory WithTournamentType(TournamentType type)
        {
            this.type = type;
            return this;
        }

        public TournamentFactory WithTournamentType(string type)
        {
            return WithTournamentType(type switch
            {
                SwissTournament.TournamentTypeString => TournamentType.SwissTournament,
                SwissDraftTournament.TournamentTypeString => TournamentType.SwissDraft,
                SwissMultiplayerTournament.TournamentTypeString => TournamentType.SwissMultiplayerTournament,
                _ => throw new FileFormatException("Unexpected tournament type encountered: " + type)
            });
        }

        public TournamentFactory WithPlayer(string playerName)
        {
            players.Add(playerName);
            return this;
        }

        public TournamentFactory WithPlayers(IEnumerable<string> playerNames)
        {
            players.AddRange(playerNames);
            return this;
        }

        public ATournament Create()
        {
            IRuleset ruleset = this.ruleset switch
            {
                TournamentRuleset.MagicTheGathering => new MTGRuleset(),
                TournamentRuleset.StarWarsUnlimited => new SWURuleset(),
                _ => throw new InvalidOperationException("Unknown ruleset: " + this.ruleset.ToString())
            };

            ATournament tournament = type switch
            {
                TournamentType.SwissTournament => new SwissTournament(players, ruleset),
                TournamentType.SwissDraft => new SwissDraftTournament(players, ruleset),
                TournamentType.SwissMultiplayerTournament => new SwissMultiplayerTournament(players, ruleset),
                _ => throw new InvalidOperationException("Unknown tournament type: " + type.ToString())
            };

            return tournament;
        }
    }
}
