using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Rulesets
{
    public class MatchmakingSettings
    {
        public enum EMultiplayerMatchmakingPriority
        {
            PrioritiseEvenMatchups,
            PrioritiseVariedMatchups,
        }

        public enum ETiebreakerHandling
        {
            UseTiebreakersForEvenPairings,
            IgnoreTiebreakersForEvenPairings,
        }

        public EMultiplayerMatchmakingPriority MultiplayerMatchmakingPriority = EMultiplayerMatchmakingPriority.PrioritiseEvenMatchups;
        public ETiebreakerHandling TiebreakerHandling = ETiebreakerHandling.UseTiebreakersForEvenPairings;
    }
}
