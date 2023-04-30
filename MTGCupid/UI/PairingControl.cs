using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGCupid.UI
{
    public partial class PairingControl : UserControl
    {
        private readonly Color RED = Color.FromArgb(0xff, 0x80, 0x80);
        private readonly Color YELLOW = Color.FromArgb(0xff, 0xff, 0x80);
        private readonly Color GREEN = Color.FromArgb(0x80, 0xff, 0x80);
        private readonly Color YELLOW_GREEN = Color.FromArgb(0xc0, 0xc0, 0x00);

        private readonly Color CONTROL_BACKGROUND = SystemColors.Control;
        private readonly Color LIGHT_GREEN_BACKGROUND = Color.FromArgb(0xc0, 0xff, 0xc0);

        private int player1Score = 0;
        private int player2Score = 0;

        private bool submitted = false;
        private readonly Match match;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the score of the match is submitted or unsubmitted")]
        public event EventHandler<MatchSubmittedToggledEventArgs>? MatchSubmittedToggled;

        public PairingControl(Match match)
        {
            InitializeComponent();

            player1ScoreButton.BackColor = YELLOW;
            player2ScoreButton.BackColor = YELLOW;
            this.BackColor = CONTROL_BACKGROUND;

            this.match = match;
            if (match is Bye)
            {
                // Simulate as an already-completed match
                player1Label.Text = match.Player1.Name;
                player2Label.Text = "--- BYE ---";
                dropPlayer2Box.Enabled = false;

                player1Score = 2;
                player1ScoreButton.Text = 2.ToString();
                OnScoreUpdate();

                submitButton.PerformClick();
                submitButton.Enabled = false;

                return;
            }
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

                if (match is not Bye)
                    match.RecordResult(player1Score, player2Score);
                submitted = true;
            }
            else
            {
                submitButton.Text = "Submit";

                player1ScoreButton.Enabled = true;
                player2ScoreButton.Enabled = true;
                this.BackColor = CONTROL_BACKGROUND;

                if (match is not Bye)
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
    }

    public class MatchSubmittedToggledEventArgs : EventArgs
    {
        public Match? Match { get; set; }
        public bool Submitted { get; set; }
    }
}
