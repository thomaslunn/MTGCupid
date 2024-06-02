using MTGCupid.Matches;
using MTGCupid.Rulesets;
using MTGCupid.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Pairings
{
    public class MultiplayerPairing : IPairing
    {
        private readonly List<Player> players = new List<Player>();

        public MultiplayerPairing(IEnumerable<Player> players)
        {
            this.players.AddRange(players);
        }

        public IEnumerable<Player> Players => players;

        public IMatch CreateMatch(IRuleset ruleset)
        {
            return new MultiplayerGame(this, ruleset);
        }

        public PairingsPreviewPairingControl GetPairingControl()
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
