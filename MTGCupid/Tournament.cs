using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MTGCupid
{
    internal class Tournament
    {
        private readonly Random rand = new Random();
        private List<Player> Players { get; set; }
        private List<Match> matchesInProgress { get; } = new List<Match>();

        public bool AwaitingMatchResults { get; private set; } = false;

        public int CurrentRound { get; private set; } = 1;

        public Tournament(List<string> players)
        {
            // Initially shuffle the players list to ensure first round pairings are random
            // Also set an initial seed for each player
            Players = players
                .OrderBy(_ => rand.Next())
                .Select((name, index) => new Player(name) { Seed = index + 1 })
                .ToList();
        }

        public (List<(Player p1, Player p2)> pairings, Player? byePlayer) SuggestNextRoundPairings()
        {
            if (AwaitingMatchResults)
                throw new InvalidOperationException("Cannot create next round pairings while matches are in progress.");

            // Recieved all match results, so all tiebreakers in players are already updated and sorted correctly
            // Filter out players that have dropped
            List<int> unpairedPlayers = Players
                .Select((p, index) => (p, index))
                .Where(p => !p.p.HasDropped)
                .Select(p => p.index).ToList();

            matchesInProgress.Clear();

            Player? byePlayer = null;
            if (unpairedPlayers.Count % 2 != 0)
            {
                // Decide byes first
                for (int i = unpairedPlayers.Count - 1; i >= 0; i--)
                {
                    int playerIndex = unpairedPlayers[i];

                    if (Players[playerIndex].ByesReceived == 0)
                    {
                        unpairedPlayers.RemoveAt(i);
                        byePlayer = Players[playerIndex];
                        break;
                    }
                }
                if (byePlayer == null)
                    throw new InvalidOperationException("Unable to create pairings.");
            }

            // Recursively create pairings
            if (unpairedPlayers.Count == 0 || !CreatePairings(unpairedPlayers, out var matches))
                throw new InvalidOperationException("Unable to create pairings.");

            List<(Player p1, Player p2)> pairings = matches.Select(m => (Players[m.p1], Players[m.p2])).ToList();

            return (pairings, byePlayer);
        }

        public List<Match> CreateRoundWithPairings(List<(Player p1, Player p2)> pairings, Player? byePlayer)
        {
            matchesInProgress.Clear();
            foreach (var (p1, p2) in pairings)
            {
                matchesInProgress.Add(new Match(p1, p2));
            }
            if (byePlayer != null)
            {
                byePlayer.ByesReceived++;
                matchesInProgress.Add(new Bye(byePlayer));
            }
            return matchesInProgress;
        }

        private bool CreatePairings(List<int> unpairedPlayers, [MaybeNullWhen(false)] out List<(int p1, int p2)> matches)
        {
            // Try to match the first unpaired player with the closest new opponent
            int p1 = unpairedPlayers[0];
            unpairedPlayers.RemoveAt(0);

            for (int i = 0; i < unpairedPlayers.Count; i++)
            {
                int p2 = unpairedPlayers[i];

                if (Players[p1].HasPlayed(Players[p2]))
                    continue; // Player already played this opponent

                unpairedPlayers.RemoveAt(i);

                if (unpairedPlayers.Count == 0) // Pairing is complete
                {
                    matches = new List<(int p1, int p2)>() { (p1, p2) };
                    return true;
                }
                if (CreatePairings(unpairedPlayers, out matches))
                {
                    // Insert at beginning so that higher ranked players are at the top of the list
                    matches.Insert(0, (p1, p2));
                    return true;
                }
                unpairedPlayers.Insert(i, p2);
            }

            // Pairing unsuccessful
            unpairedPlayers.Insert(0, p1);
            matches = null;
            return false;
        }

        private void UpdateStandings()
        {
            // Update match win percentage
            foreach (var player in Players)
            {
                player.MatchWinPercentage = player.Matches.Sum(m => m.MatchPointsOf(player)) / (3.0 * player.Matches.Count);
                if (player.MatchWinPercentage < 0.33) // Enforced lower bound of 33% match win percentage
                    player.MatchWinPercentage = 0.33;
            }

            // Update opponent match win percentage
            foreach (var player in Players)
            {
                var matches = player.Matches.Where(m => m is not Bye); // Byes are discounted in OMW%
                if (matches.Count() == 0)
                    player.OpponentMatchWinPercentage = 1; 
                else
                    player.OpponentMatchWinPercentage = matches.Sum(m => m.OpponentOf(player).MatchWinPercentage) / matches.Count();
            }

            // Update game win percentage
            foreach (var player in Players)
            {
                player.GameWinPercentage = player.Matches.Sum(m => m.GamePointsOf(player)) / (3.0 * player.Matches.Sum(m => m.GamesPlayed));
                if (player.GameWinPercentage < 0.33) // Enforced lower bound of 33% game win percentage
                    player.GameWinPercentage = 0.33;
            }

            // Update opponent game win percentage
            foreach (var player in Players)
            {
                var matches = player.Matches.Where(m => m is not Bye); // Bytes are discounted in OGW%
                if (matches.Count() == 0)
                    player.OpponentGameWinPercentage = 1;
                else
                    player.OpponentGameWinPercentage = matches.Sum(m => m.OpponentOf(player).GameWinPercentage) / matches.Count();
            }

            // Sort players by tiebreakers
            Players.Sort();

            // Update player positions
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Seed = i + 1;
            }

            // Increment round number
            CurrentRound++;
        }

        /// <summary>
        /// Confirms that all matches have been completed and updates standings
        /// </summary>
        /// <returns>True if all matches successfully received a match result and standings have been updated; false otherwise</returns>
        public bool SubmitMatchResults()
        {
            if (matchesInProgress.Any(m => !m.Completed))
                return false;

            matchesInProgress.Clear();
            UpdateStandings();
            return true;
        }

        public List<PlayerStandings> GetStandings()
        {
            return Players.Select(p => new PlayerStandings(p)).ToList();
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; private set; }
        public int Points { get => Matches.Sum(m => m.Completed ? m.MatchPointsOf(this) : 0); }
        public HashSet<Match> Matches { get; } = new HashSet<Match>();
        public int ByesReceived { get; internal set; } = 0;
        public bool HasDropped { get; private set; } = false;

        // The following properties are updated by the tournament manager when calculating standings //
        public double MatchWinPercentage { get; internal set; } = 1;
        public double OpponentMatchWinPercentage { get; internal set; } = 0;
        public double GameWinPercentage { get; internal set; } = 1;
        public double OpponentGameWinPercentage { get; internal set; } = 0;
        public int Seed { get; internal set; }
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
            return Matches.Any(m => m.OpponentOf(this) == player);
        }

        public int CompareTo(Player? other)
        {
            if (other == null)
                return 0; // Degenerate case

            if (Points.CompareTo(other.Points) != 0)
                return -Points.CompareTo(other.Points); // Negative so that higher points appear first
            if (OpponentMatchWinPercentage.CompareTo(other.OpponentMatchWinPercentage) != 0)
                return -OpponentMatchWinPercentage.CompareTo(other.OpponentMatchWinPercentage);
            if (GameWinPercentage.CompareTo(other.GameWinPercentage) != 0)
                return -GameWinPercentage.CompareTo(other.GameWinPercentage);
            if (OpponentGameWinPercentage.CompareTo(other.OpponentGameWinPercentage) != 0)
                return -OpponentGameWinPercentage.CompareTo(other.OpponentGameWinPercentage);

            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} points", Name, Points);
        }
    }

    public class PlayerStandings
    {
        public string Seed { get; private set; }
        public string Name { get; private set; }
        public string Points { get; private set; }
        public string OpponentMatchWinPercentage { get; private set; }
        public string GameWinPercentage { get; private set; }
        public string OpponentGameWinPercentage { get; private set; }
        public bool HasDropped { get; private set; }
        public Player Player { get; private set; }
        public PlayerStandings(Player player)
        {
            Seed = player.Seed.ToString();
            Name = player.Name;
            Points = player.Points.ToString();
            OpponentMatchWinPercentage = string.Format("{0:P1}", player.OpponentMatchWinPercentage);
            GameWinPercentage = string.Format("{0:P1}", player.GameWinPercentage);
            OpponentGameWinPercentage = string.Format("{0:P1}", player.OpponentGameWinPercentage);
            HasDropped = player.HasDropped;

            Player = player;
        }
    }

    public class Match
    {
        public Player Player1 { get; protected set; }
        public Player Player2 { get; protected set; }
        public int Player1GameWins { get; protected set; } = 0;
        public int Player2GameWins { get; protected set; } = 0;
        public int GamesPlayed => Player1GameWins + Player2GameWins; 
        public bool Completed { get; protected set; } = false;

        public Match(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;

            p1.Matches.Add(this);
            p2.Matches.Add(this); // In a bye, p1 == p2, but the match collection is a set so this is fine
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
        public Bye(Player player) : base(player, player)
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
