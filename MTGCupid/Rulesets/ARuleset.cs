using MTGCupid.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Rulesets
{
    public abstract class ARuleset : IComparer<Player>
    {
        public ARuleset(MatchmakingSettings? matchmakingSettings = null)
        {
            MatchmakingSettings = matchmakingSettings ?? new MatchmakingSettings();
        }

        protected const double COMPARISON_DOUBLE_EQUALITY_THRESHOLD = 0.0001;
        
        public abstract string Ruleset { get; }

        public abstract int Compare(Player? x, Player? y);

        public abstract int MatchPointsOf(Player player, Match match);

        public abstract int MatchPointsOf(Player player, MultiplayerGame match);

        public readonly MatchmakingSettings MatchmakingSettings;

        private class IgnoreTiebreakersComparer : IComparer<Player>
        {
            public int Compare(Player? x, Player? y)
            {
                if (x == null || y == null)
                    return 0; // Degenerate case

                if (x.Points.CompareTo(y.Points) != 0)
                    return -x.Points.CompareTo(y.Points); // Negative so that higher points appear first

                // Ignore all other tiebreakers
                return 0;
            }
        }

        private readonly static IgnoreTiebreakersComparer ignoreTiebreakersComparer = new IgnoreTiebreakersComparer();

        public IComparer<Player> PairingsComparer
        {
            get
            {
                switch (MatchmakingSettings.TiebreakerHandling)
                {
                    case MatchmakingSettings.ETiebreakerHandling.UseTiebreakersForEvenPairings:
                        return this;
                    case MatchmakingSettings.ETiebreakerHandling.IgnoreTiebreakersForEvenPairings:
                        return ignoreTiebreakersComparer;
                    default:
                        throw new InvalidOperationException($"Unexpected tiebreaker handling setting: {MatchmakingSettings.TiebreakerHandling}.");
                }
            }
        }
    }
}
