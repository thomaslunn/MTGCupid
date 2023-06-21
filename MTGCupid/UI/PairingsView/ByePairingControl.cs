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
    public partial class ByePairingControl : UserControl, IPairingControl
    {
        private readonly Bye match;

        public event EventHandler<MatchSubmittedToggledEventArgs>? MatchSubmittedToggled;

        public ByePairingControl(Bye match)
        {
            InitializeComponent();

            this.match = match;

            // Simulate as an already-completed match
            player1Label.Text = match.player.Name;
            player2Label.Text = "--- BYE ---";
            dropPlayer2Box.Enabled = false;

            player1ScoreButton.Text = 2.ToString();
            player1ScoreButton.BackColor = GREEN;
            player2ScoreButton.BackColor = RED;

            this.BackColor = LIGHT_GREEN_BACKGROUND;
            submitButton.Enabled = false;

            var args = new MatchSubmittedToggledEventArgs()
            {
                Match = match,
                Submitted = true
            };

            MatchSubmittedToggled?.Invoke(this, args);

            return;
        }


        /// <summary>
        /// Drop all players that have selected to be dropped
        /// </summary>
        public void DropPlayers()
        {
            if (dropPlayer1Box.Checked)
                match.player.Drop();
        }

        public void Submit()
        {
            // Nothing to do
        }
    }
}
