using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Matches
{
    public interface IMatch
    {
        public int GamesPlayed { get; }
        public bool Completed { get; }

        public void UndoResult();

        public bool WasWonBy(Player player);

        public int MatchPointsOf(Player player);

        public int GamePointsOf(Player player);

        public bool HasParticipant(Player player);
        internal MatchExport GetMatchExport(bool includeScores = true);
    }
}
