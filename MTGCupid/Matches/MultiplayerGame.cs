using MTGCupid.Pairings;
using MTGCupid.Rulesets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid.Matches
{
    public class MultiplayerGame : IMatch
    {
        public IEnumerable<Player> Players { get; private set; }
        private Dictionary<Player, int> gamePoints = new Dictionary<Player, int>();
        private readonly int _numPlayers;
        public const string MatchType = "Multiplayer";

        private readonly ARuleset ruleset;

        public MultiplayerGame(MultiplayerPairing pairing, ARuleset ruleset)
        {
            this.ruleset = ruleset;
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
            gamePoints[player] = points;
            if (gamePoints.Count == _numPlayers)
                Completed = true;
        }

        public int GamePointsOf(Player player)
        {
            if (!HasParticipant(player))
                throw new ArgumentException("Player is not in this match.");
            return gamePoints.GetValueOrDefault(player, 0);
        }
        public bool HasParticipant(Player player)
        {
            return Players.Contains(player);
        }
        public int MatchPointsOf(Player player)
        {
            return ruleset.MatchPointsOf(player, this);
        }
        public void UndoResult()
        {
            gamePoints.Clear();
            Completed = false;
        }
        public bool WasWonBy(Player player)
        {
            throw new InvalidOperationException("Winner is irrelevent for multiplayer games");
        }

        public MatchExport GetMatchExport(bool includeScores = true)
        {
            var me = new MatchExport()
            {
                MatchType = MatchType,
                Players = Players.Select(p => p.Name).ToList()
            };
            if (includeScores)
                me.Scores = gamePoints.Values.ToList();
            return me;
        }
    }
}
