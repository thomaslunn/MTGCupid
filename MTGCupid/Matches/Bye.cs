using MTGCupid.Pairings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Matches
{
    public class Bye : IMatch
    {
        public bool Completed => true;
        public int GamesPlayed => 2;
        public Player player { get; private set; }
        public const string MatchType = "Bye";

        public Bye(Player player)
        {
            this.player = player;
            player.Matches.Add(this);
        }

        public bool WasWonBy(Player player)
        {
            return player == this.player;
        }

        public int MatchPointsOf(Player player)
        {
            if (player == this.player)
                return 3;
            throw new ArgumentException("Player is not in this match.");
        }

        public int GamePointsOf(Player player)
        {
            if (player == this.player)
                return 6;
            throw new ArgumentException("Player is not in this match.");
        }

        public void UndoResult()
        {
            throw new InvalidOperationException("Cannot undo results for a bye.");
        }

        public bool HasParticipant(Player player)
        {
            return player == this.player;
        }

        public MatchExport GetMatchExport(bool _ = true)
        {
            return new MatchExport()
            {
                MatchType = MatchType,
                Players = new List<string>() { player.Name }
            };
        }
    }
}
