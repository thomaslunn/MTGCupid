﻿using System;
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

        private List<Player> players { get; } = new List<Player>();
        private List<Match> matchesInProgress { get; } = new List<Match>();

        public bool AwaitingMatchResults { get; private set; } = false;

        public Tournament(List<string> players)
        {
            this.players.AddRange(players.Select(str => new Player(str)));

            // Initially shuffle the players list to ensure first round pairings are random
            this.players.OrderBy(_ => rand.Next()).ToList();
        }

        public List<Match> CreateNextRound()
        {
            if (AwaitingMatchResults)
                throw new InvalidOperationException("Cannot create next round while matches are in progress.");

            // Recieved all match results, so all tiebreakers in players are already updated and sorted correctly
            HashSet<int> pairedPlayers = new HashSet<int>();
            List<int> unpairedPlayers = new List<int>(Enumerable.Range(0, players.Count));
            matchesInProgress.Clear();

            if (players.Count % 2 != 0)
            {
                // Decide byes first
                for (int i = unpairedPlayers.Count - 1; i >= 0; i--)
                {
                    if (players[i].ByesReceived == 0)
                    {
                        players[i].ByesReceived++;
                        unpairedPlayers.RemoveAt(i);
                        pairedPlayers.Add(i);
                        matchesInProgress.Add(new Bye(players[i]));
                        break;
                    }
                }
            }

            // Recursively create pairings
            if (!CreatePairings(pairedPlayers, unpairedPlayers, out var matches))
                throw new InvalidOperationException("Unable to create pairings.");

            foreach (var (p1, p2) in matches)
            {
                matchesInProgress.Add(new Match(players[p1], players[p2]));
            }

            return matchesInProgress;
        }

        private bool CreatePairings(HashSet<int> pairedPlayers, List<int> unpairedPlayers, [MaybeNullWhen(false)] out HashSet<(int p1, int p2)> matches)
        {
            // Try to match the first unpaired player with the closest new opponent
            int p1 = unpairedPlayers[0];
            pairedPlayers.Add(p1);
            unpairedPlayers.RemoveAt(0);

            for (int i = 0; i < unpairedPlayers.Count; i++)
            {
                int p2 = unpairedPlayers[i];

                if (players[p1].HasPlayed(players[p2]))
                    continue; // Player already played this opponent

                pairedPlayers.Add(p2);
                unpairedPlayers.RemoveAt(i);

                if (unpairedPlayers.Count == 0) // Pairing is complete
                {
                    matches = new HashSet<(int p1, int p2)>() { (p1, p2) };
                    return true;
                }
                if (CreatePairings(pairedPlayers, unpairedPlayers, out matches))
                {
                    matches.Add((p1, p2));
                    return true;
                }
                pairedPlayers.Remove(p2);
                unpairedPlayers.Insert(i, p2);
            }

            // Pairing unsuccessful
            pairedPlayers.Remove(p1);
            unpairedPlayers.Insert(0, p1);
            matches = null;
            return false;
        }

        private void UpdateStandings()
        {
            // Update match win percentage
            foreach (var player in players)
            {
                player.MatchWinPercentage = player.Matches.Sum(m => m.MatchPointsOf(player)) / (3.0 * player.Matches.Count);
                if (player.MatchWinPercentage < 0.33) // Enforced lower bound of 33% match win percentage
                    player.MatchWinPercentage = 0.33;
            }

            // Update opponent match win percentage
            foreach (var player in players)
            {
                var matches = player.Matches.Where(m => m is not Bye); // Byes are discounted in OMW%
                if (matches.Count() == 0)
                    player.OpponentMatchWinPercentage = 1; 
                else
                    player.OpponentMatchWinPercentage = matches.Sum(m => m.OpponentOf(player).MatchWinPercentage) / matches.Count();
            }

            // Update game win percentage
            foreach (var player in players)
            {
                player.GameWinPercentage = player.Matches.Sum(m => m.GamePointsOf(player)) / (3.0 * player.Matches.Sum(m => m.GamesPlayed));
                if (player.GameWinPercentage < 0.33) // Enforced lower bound of 33% game win percentage
                    player.GameWinPercentage = 0.33;
            }

            // Update opponent game win percentage
            foreach (var player in players)
            {
                var matches = player.Matches.Where(m => m is not Bye); // Bytes are discounted in OGW%
                if (matches.Count() == 0)
                    player.OpponentGameWinPercentage = 1;
                else
                    player.OpponentGameWinPercentage = matches.Sum(m => m.OpponentOf(player).GameWinPercentage) / matches.Count();
            }

            // Sort players by tiebreakers
            players.Sort((p1, p2) =>
            {
                if (p1.Points > p2.Points)
                    return -1;
                else if (p1.Points < p2.Points)
                    return 1;
                else if (p1.MatchWinPercentage > p2.MatchWinPercentage)
                    return -1;
                else if (p1.MatchWinPercentage < p2.MatchWinPercentage)
                    return 1;
                else if (p1.OpponentMatchWinPercentage > p2.OpponentMatchWinPercentage)
                    return -1;
                else if (p1.OpponentMatchWinPercentage < p2.OpponentMatchWinPercentage)
                    return 1;
                else if (p1.GameWinPercentage > p2.GameWinPercentage)
                    return -1;
                else if (p1.GameWinPercentage < p2.GameWinPercentage)
                    return 1;
                else if (p1.OpponentGameWinPercentage > p2.OpponentGameWinPercentage)
                    return -1;
                else if (p1.OpponentGameWinPercentage < p2.OpponentGameWinPercentage)
                    return 1;
                else
                    return 0;
            });
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
    }

    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int Points { get => Matches.Sum(m => m.MatchPointsOf(this)); }
        public HashSet<Match> Matches { get; } = new HashSet<Match>();

        public double MatchWinPercentage { get; internal set; } = 1;
        public double OpponentMatchWinPercentage { get; internal set; } = 0;
        public double GameWinPercentage { get; internal set; } = 1;
        public double OpponentGameWinPercentage { get; internal set; } = 0;
        public int ByesReceived { get; internal set; } = 0;
        public bool HasPlayed(Player player)
        {
            return Matches.Any(m => m.OpponentOf(this) == player);
        }
    }

    public class Match
    {
        public Player Player1 { get; protected set; }
        public Player Player2 { get; protected set; }
        public int Player1GameWins { get; protected set; } = 0;
        public int Player2GameWins { get; protected set; } = 0;
        public int GamesPlayed { get => Player1GameWins + Player2GameWins; }
        public bool Completed { get; protected set; } = false;

        public Match(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;

            p1.Matches.Add(this);
            p2.Matches.Add(this);
        }

        public virtual void RecordResult(int p1Wins, int p2Wins)
        {
            Player1GameWins = p1Wins;
            Player2GameWins = p2Wins;

            Completed = true;
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
    }

    public class Bye : Match
    {
        public Bye(Player player) : base(player, player)
        {
            Completed = true;
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
                return 3;
            throw new ArgumentException("Player is not in this match.");
        }
    }
}
