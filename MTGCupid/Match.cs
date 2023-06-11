using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid
{
    public class Match
    {
        public Player Player1 { get; protected set; }
        public Player Player2 { get; protected set; }
        public int Player1GameWins { get; protected set; } = 0;
        public int Player2GameWins { get; protected set; } = 0;
        public int GamesPlayed => Player1GameWins + Player2GameWins;
        public bool Completed { get; protected set; } = false;

        public Match(Pairing pairing)
        {
            Player1 = pairing.player1;
            Player2 = pairing.player2;

            pairing.player1.Matches.Add(this);
            pairing.player2.Matches.Add(this); // In a bye, p1 == p2, but the match collection is a set so this is fine
        }

        public virtual void RecordResult(int p1Wins, int p2Wins)
        {
            Player1GameWins = p1Wins;
            Player2GameWins = p2Wins;

            Completed = true;
        }

        public virtual void UndoResult()
        {
            Completed = false;
        }

        public virtual bool WasWonBy(Player player)
        {
            return (player == Player1 && Player1GameWins > Player2GameWins) || (player == Player2 && Player2GameWins > Player1GameWins);
        }

        public virtual int MatchPointsOf(Player player)
        {
            if (player == Player1)
            {
                if (Player1GameWins > Player2GameWins)
                    return 3;
                if (Player1GameWins == Player2GameWins)
                    return 1;
                // Player 1 lost
                return 0;
            }
            if (player == Player2)
            {
                if (Player2GameWins > Player1GameWins)
                    return 3;
                if (Player2GameWins == Player1GameWins)
                    return 1;
                // Player 2 lost
                return 0;
            }
            throw new ArgumentException("Player is not in this match.");
        }

        public virtual int GamePointsOf(Player player)
        {
            if (player == Player1)
                return Player1GameWins * 3;
            if (player == Player2)
                return Player2GameWins * 3;
            throw new ArgumentException("Player is not in this match.");
        }

        public Player OpponentOf(Player player)
        {
            if (player == Player1)
                return Player2;
            if (player == Player2)
                return Player1;
            throw new ArgumentException("Player is not in this match.");
        }

        public int WinsOf(Player player)
        {
            if (player == Player1)
                return Player1GameWins;
            if (player == Player2)
                return Player2GameWins;
            throw new ArgumentException("Player is not in this match.");
        }
    }

    public class Bye : Match
    {
        public Bye(Player player) : base(new Pairing(player, player))
        {
            Completed = true;
            Player1GameWins = 2;
        }

        public override void RecordResult(int p1Wins, int p2Wins)
        {
            throw new InvalidOperationException("Cannot record results for a bye.");
        }

        public override bool WasWonBy(Player player)
        {
            return player == Player1;
        }

        public override int MatchPointsOf(Player player)
        {
            if (player == Player1)
                return 3;
            throw new ArgumentException("Player is not in this match.");
        }

        public override int GamePointsOf(Player player)
        {
            if (player == Player1)
                return 6;
            throw new ArgumentException("Player is not in this match.");
        }

        public override void UndoResult()
        {
            throw new InvalidOperationException("Cannot undo results for a bye.");
        }
    }
}
