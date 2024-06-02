using MTGCupid.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Rulesets
{
    public class SWURuleset : ARuleset
    {
        public SWURuleset(MatchmakingSettings? matchmakingSettings) : base(matchmakingSettings) { }

        public override string Ruleset => RulesetString;
        public const string RulesetString = "Star Wars: Unlimited";

        public override int Compare(Player? x, Player? y)
        {
            if (x == null || y == null)
                return 0; // Degenerate case

            if (x.Points.CompareTo(y.Points) != 0)
                return -x.Points.CompareTo(y.Points); // Negative so that higher points appear first

            if (Math.Abs(x.OpponentMatchWinPercentage - y.OpponentMatchWinPercentage) > ARuleset.COMPARISON_DOUBLE_EQUALITY_THRESHOLD)
                return -x.OpponentMatchWinPercentage.CompareTo(y.OpponentMatchWinPercentage);

            if (Math.Abs(x.OpponentOpponentMatchWinPercentage - y.OpponentOpponentMatchWinPercentage) > ARuleset.COMPARISON_DOUBLE_EQUALITY_THRESHOLD)
                return -x.OpponentOpponentMatchWinPercentage.CompareTo(y.OpponentOpponentMatchWinPercentage);

            return 0;
        }

        public override int MatchPointsOf(Player player, Match match)
        {
            if (player == match.Player1)
            {
                if (match.Player1GameWins > match.Player2GameWins)
                    return 3;
                // Player 1 lost/drew
                return 0;
            }
            if (player == match.Player2)
            {
                if (match.Player2GameWins > match.Player1GameWins)
                    return 3;
                // Player 2 lost/drew
                return 0;
            }
            throw new ArgumentException("Player is not in this match.");
        }

        public override int MatchPointsOf(Player player, MultiplayerGame match)
        {
            return match.GamePointsOf(player);
        }
    }
}
