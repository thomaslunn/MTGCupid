using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Tournaments
{
    internal interface IPoddedTournament
    {
        public List<Player[]> GetPods();
        public List<Player[]> GetDraftSeating();
    }
}
