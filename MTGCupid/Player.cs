using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTGCupid.Matches;
using MTGCupid.Rulesets;

namespace MTGCupid
{
    public class Player : IComparable<Player>
    {
        public string Name { get; private set; }
        public int Points => CompletedMatches.Sum(m => m.MatchPointsOf(this));
        public HashSet<IMatch> Matches { get; } = new HashSet<IMatch>();
        public IEnumerable<IMatch> CompletedMatches => Matches.Where(m => m.Completed);
        public int ByesReceived { get; internal set; } = 0;
        public bool HasDropped { get; private set; } = false;

        // The following properties are updated by the tournament manager when calculating standings //
        public double MatchWinPercentage { get; internal set; } = 1;
        public double OpponentMatchWinPercentage { get; internal set; } = 0;
        public double OpponentOpponentMatchWinPercentage { get; internal set; } = 1;
        public double GameWinPercentage { get; internal set; } = 1;
        public double OpponentGameWinPercentage { get; internal set; } = 1;
        public string Seed { get; internal set; } = "0"; // Dummy value
        ///////////////////

        private readonly ARuleset ruleset;

        public Player(string name, ARuleset ruleset)
        {
            Name = name;
            this.ruleset = ruleset;
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
            return ruleset.Compare(this, other);
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
