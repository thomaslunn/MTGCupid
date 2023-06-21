using MTGCupid.Pairings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Matches
{
    internal class MultiplayerGame : IMatch
    {
        public IEnumerable<Player> Players { get; private set; }
        private Dictionary<Player, int> matchPoints = new Dictionary<Player, int>();
        private int _numPlayers;

        public MultiplayerGame(MultiplayerPairing pairing)
        {
            Players = pairing.Players;

            foreach (Player player in Players)
            {
                player.Matches.Add(this);
            }

            _numPlayers = Players.Count();
        }

        public int GamesPlayed => 1;
        public bool Completed { get; private set; } = false;
        
        public void RecordResult(Player player, int points)
        {
            if (!HasParticipant(player))
                throw new ArgumentException("Player is not in this match.");
            matchPoints[player] = points;
            if (matchPoints.Count == _numPlayers)
                Completed = true;
        }

        public int GamePointsOf(Player player)
        {
            // Synonymous with match points in multiplayer
            return MatchPointsOf(player);
        }
        public bool HasParticipant(Player player)
        {
            return Players.Contains(player);
        }
        public int MatchPointsOf(Player player)
        {
            if (!HasParticipant(player))
                throw new ArgumentException("Player is not in this match.");
            return matchPoints.GetValueOrDefault(player, 0);
        }
        public void UndoResult()
        {
            matchPoints.Clear();
            Completed = false;
        }
        public bool WasWonBy(Player player)
        {
            throw new InvalidOperationException("Winner is irrelevent for multiplayer games");
        }
    }
}
