using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGCupid.Matches;

namespace MTGCupid
{
    public class Player : IComparable<Player>
    {
        public const double COMPARISON_DOUBLE_EQUALITY_THRESHOLD = 0.0001;
        public string Name { get; private set; }
        public int Points { get => Matches.Sum(m => m.Completed ? m.MatchPointsOf(this) : 0); }
        public HashSet<IMatch> Matches { get; } = new HashSet<IMatch>();
        public int ByesReceived { get; internal set; } = 0;
        public bool HasDropped { get; private set; } = false;

        // The following properties are updated by the tournament manager when calculating standings //
        public double MatchWinPercentage { get; internal set; } = 1;
        public double OpponentMatchWinPercentage { get; internal set; } = 0;
        public double GameWinPercentage { get; internal set; } = 1;
        public double OpponentGameWinPercentage { get; internal set; } = 0;
        public string Seed { get; internal set; } = "0"; // Dummy value
        ///////////////////

        public Player(string name)
        {
            Name = name;
        }

        public void Drop()
        {
            HasDropped = true;
        }
        public bool HasPlayed(Player player)
        {
            return this != player && Matches.Any(m => m.HasParticipant(player));
        }

        public int CompareTo(Player? other)
        {
            if (other == null)
                return 0; // Degenerate case

            if (Points.CompareTo(other.Points) != 0)
                return -Points.CompareTo(other.Points); // Negative so that higher points appear first

            if (Math.Abs(OpponentMatchWinPercentage - other.OpponentMatchWinPercentage) > COMPARISON_DOUBLE_EQUALITY_THRESHOLD)
                return -OpponentMatchWinPercentage.CompareTo(other.OpponentMatchWinPercentage);

            if (Math.Abs(GameWinPercentage - other.GameWinPercentage) > COMPARISON_DOUBLE_EQUALITY_THRESHOLD)
                return -GameWinPercentage.CompareTo(other.GameWinPercentage);

            if (Math.Abs(OpponentGameWinPercentage - other.OpponentGameWinPercentage) > COMPARISON_DOUBLE_EQUALITY_THRESHOLD)
                return -OpponentGameWinPercentage.CompareTo(other.OpponentGameWinPercentage);

            return 0;
        }

        public bool HasEquivalentScoreTo(Player other)
        {
            return CompareTo(other) == 0;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} points", Name, Points);
        }
    }
}
