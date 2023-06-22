using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCupid
{
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
        public PlayerStandings(Player player, bool percentageFormat = true)
        {
            Seed = player.Seed.ToString();
            Name = player.Name;
            Points = player.Points.ToString();
            HasDropped = player.HasDropped;

            if (percentageFormat)
            {
                OpponentMatchWinPercentage = player.OpponentMatchWinPercentage.ToString("P1");
                GameWinPercentage = player.GameWinPercentage.ToString("P1");
                OpponentGameWinPercentage = player.OpponentGameWinPercentage.ToString("P1");
            }
            else
            {
                OpponentMatchWinPercentage = player.OpponentMatchWinPercentage.ToString("0.##");
                GameWinPercentage = player.GameWinPercentage.ToString("0.##");
                OpponentGameWinPercentage = player.OpponentGameWinPercentage.ToString("0.##");
            }

            Player = player;
        }
    }
}
