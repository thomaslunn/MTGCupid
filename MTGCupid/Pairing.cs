using MTGCupid.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid
{
    public class Pairing
    {
        public Player player1;
        public Player player2;

        public Pairing(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public Pairing((Player p1, Player p2) players) : this(players.p1, players.p2)
        {
        }

        public PairingsPreviewPairingControl GetPairingControl()
        {
            return new PairingsPreviewPairingControl(this);
        }

        public IEnumerable<Player> Players { get {
                yield return player1;
                yield return player2;
            } 
        }

        override public string ToString()
        {
            return string.Format("{0}. {1} vs {2}. {3}", player1.Seed, player1.Name, player2.Seed, player2.Name);
        }
    }
}
