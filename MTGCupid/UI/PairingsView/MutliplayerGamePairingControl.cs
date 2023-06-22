using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTGCupid.Matches;
using MTGCupid.UI.PairingsView;
using static MTGCupid.UI.PairingsView.IPairingControl;

namespace MTGCupid.UI
{
    public partial class MultiplayerGamePairingControl : UserControl, IPairingControl
    {
        private List<int> scores = new List<int>();
        private Dictionary<MultiplayerGamePairingControlSinglePlayerPanel, Player> players = new Dictionary<MultiplayerGamePairingControlSinglePlayerPanel, Player>();

        private bool submitted = false;
        private readonly MultiplayerGame match;

        public event EventHandler<MatchSubmittedToggledEventArgs>? MatchSubmittedToggled;

        internal MultiplayerGamePairingControl(MultiplayerGame match)
        {
            InitializeComponent();
            this.match = match;
            this.BackColor = CONTROL_BACKGROUND;

            int tableColumn = 0;
            for (int i = 1; i < match.Players.Count(); i++) // Start at 1 since the table initially contains 1 column
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0));
            }
            tableLayoutPanel.ColumnCount = match.Players.Count();
            foreach (ColumnStyle column in tableLayoutPanel.ColumnStyles)
            {
                column.SizeType = SizeType.Percent;
                column.Width = 100 / tableLayoutPanel.ColumnCount;
            }
            foreach (var player in match.Players)
            {
                var playerPanel = new MultiplayerGamePairingControlSinglePlayerPanel(player.Name);
                playerPanel.SetScoreBackgroundColour(YELLOW);
                playerPanel.ScoreUpdated += OnScoreUpdate;

                tableLayoutPanel.Controls.Add(playerPanel, tableColumn++, 0);
                players.Add(playerPanel, player);
            }
        }

        private void OnScoreUpdate(object? sender, EventArgs e)
        {
            submitButton.Enabled = true;

            // Set the background colour of the winner(s) to green and the loser(s) to red, or all yellow if a draw
            var scores = players.Select(p => p.Key.Score);
            int max = scores.Max();
            int min = scores.Min();

            if (min == max)
            {
                foreach (var player in players.Keys)
                {
                    player.SetScoreBackgroundColour(YELLOW);
                }
            }
            else
            {
                foreach (var player in players.Keys)
                {
                    if (player.Score == max)
                    {
                        player.SetScoreBackgroundColour(GREEN);
                    }
                    else
                    {
                        player.SetScoreBackgroundColour(RED);
                    }
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!submitted)
            {
                submitButton.Text = "Edit";

                foreach (var kvp in players)
                {
                    kvp.Key.Enabled = false;
                    match.RecordResult(kvp.Value, kvp.Key.Score);
                }
                this.BackColor = LIGHT_GREEN_BACKGROUND;

                submitted = true;
            }
            else
            {
                submitButton.Text = "Submit";

                foreach (var panel in players.Keys)
                    panel.Enabled = true;

                this.BackColor = CONTROL_BACKGROUND;

                match.UndoResult();
                submitted = false;
            }

            var args = new MatchSubmittedToggledEventArgs()
            {
                Match = match,
                Submitted = submitted
            };

            MatchSubmittedToggled?.Invoke(this, args);
        }

        /// <summary>
        /// Drop all players that have selected to be dropped
        /// </summary>
        public void DropPlayers()
        {
            foreach (var kvp in players)
            {
                if (kvp.Key.IsDrop)
                {
                    kvp.Value.Drop();
                }
            }
        }

        public void Submit()
        {
            if (!submitted)
            {
                submitButton.PerformClick();
            }
        }
    }
}
