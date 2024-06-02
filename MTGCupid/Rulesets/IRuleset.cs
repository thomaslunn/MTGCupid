using MTGCupid.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Rulesets
{
    public interface IRuleset : IComparer<Player>
    {
        protected const double COMPARISON_DOUBLE_EQUALITY_THRESHOLD = 0.0001;
        
        public string Ruleset { get; }

        public int MatchPointsOf(Player player, Match match);

        public int MatchPointsOf(Player player, MultiplayerGame match);
    }
}
