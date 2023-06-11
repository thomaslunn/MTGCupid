using MTGCupid.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Pairings
{
    internal class FourPlayerPairing : IPairing
    {
        private readonly List<Player> players = new List<Player>();

        public FourPlayerPairing(Player player1, Player player2, Player? player3 = null, Player? player4 = null)
        {
            players.Add(player1);
            players.Add(player2);
            if (player3 != null)
                players.Add(player3);
            if (player4 != null)
                players.Add(player4);
        }

        IEnumerable<Player> IPairing.Players => players;

        Match IPairing.CreateMatch()
        {
            throw new NotImplementedException();
        }

        PairingsPreviewPairingControl IPairing.GetPairingControl()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}. {1}", players[0].Seed, players[0].Name));

            for (int i = 1; i < players.Count; i++)
            {
                sb.Append(string.Format(" vs {0}. {1}", players[i].Seed, players[i].Name));
            }

            return sb.ToString();
        }
    }
}
