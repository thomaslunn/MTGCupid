using MTGCupid.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Pairings
{
    public interface IPairing
    {
        public PairingsPreviewPairingControl GetPairingControl();

        public IEnumerable<Player> Players { get; }

        public Match CreateMatch();
    }
}
