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
    public partial class TwoPlayerMatchPairingControl : UserControl, IPairingControl
    {
        private int player1Score = 0;
        private int player2Score = 0;

        private bool submitted = false;
        private readonly Match match;

        public event EventHandler<MatchSubmittedToggledEventArgs>? MatchSubmittedToggled;

        public TwoPlayerMatchPairingControl(Match match)
        {
            InitializeComponent();

            player1ScoreButton.BackColor = YELLOW;
            player2ScoreButton.BackColor = YELLOW;
            this.BackColor = CONTROL_BACKGROUND;

            this.match = match;
            player1Label.Text = match.Player1.Name;
            player2Label.Text = match.Player2.Name;
        }

        private void player1ScoreButton_Click(object sender, EventArgs e)
        {
            player1Score++;
            if (player1Score == 3) player1Score = 0;
            player1ScoreButton.Text = player1Score.ToString();

            OnScoreUpdate();
        }

        private void player2ScoreButton_Click(object sender, EventArgs e)
        {
            player2Score++;
            if (player2Score == 3) player2Score = 0;
            player2ScoreButton.Text = player2Score.ToString();

            OnScoreUpdate();
        }

        private void OnScoreUpdate()
        {
            submitButton.Enabled = true;

            if (player1Score > player2Score)
            {
                player1ScoreButton.BackColor = GREEN;
                player2ScoreButton.BackColor = RED;
            }
            else if (player1Score < player2Score)
            {
                player1ScoreButton.BackColor = RED;
                player2ScoreButton.BackColor = GREEN;
            }
            else if (player1Score == 2)
            {
                // Current recorded score is 2-2 which is invalid
                player1ScoreButton.BackColor = YELLOW_GREEN;
                player2ScoreButton.BackColor = YELLOW_GREEN;
                submitButton.Enabled = false;
            }
            else
            {
                player1ScoreButton.BackColor = YELLOW;
                player2ScoreButton.BackColor = YELLOW;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!submitted)
            {
                submitButton.Text = "Edit";

                player1ScoreButton.Enabled = false;
                player2ScoreButton.Enabled = false;
                this.BackColor = LIGHT_GREEN_BACKGROUND;

                match.RecordResult(player1Score, player2Score);
                submitted = true;
            }
            else
            {
                submitButton.Text = "Submit";

                player1ScoreButton.Enabled = true;
                player2ScoreButton.Enabled = true;
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
            if (dropPlayer1Box.Checked)
                match.Player1.Drop();
            if (dropPlayer2Box.Checked)
                match.Player2.Drop();
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
