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
    internal partial class TournamentInitialiserControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the begin next round button is clicked")]
        public event EventHandler<BeginNextRoundButtonClickedEventArgs>? BeginNextRoundButtonClicked;

        public TournamentInitialiserControl()
        {
            InitializeComponent();
        }

        private void nameList_RegisteredPlayersCountChanged(object sender, RegisteredPlayersCountChangedEventArgs e)
        {
            playerCountLabel.Text = string.Format("Players: {0}", e.PlayerCount);
        }

        private void beginNextRoundButton_Click(object sender, EventArgs e)
        {
            // Ensure there are at least 4 players to begin a tournament
            List<string> playerNames = nameList.GetPlayerNames();
            if (playerNames.Count < 4)
            {
                MessageBox.Show("You need at least 4 players to begin a tournament", "Not enough players", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Disable the begin next round button and player name entry controls
            beginNextRoundButton.Enabled = false;
            nameList.Enabled = false;

            // Invoke the BeginNextRoundButtonClicked event
            BeginNextRoundButtonClicked?.Invoke(this, new BeginNextRoundButtonClickedEventArgs() { PlayerNames = playerNames });
        }

        public void EnableNextRoundButton(int roundNumber)
        {
            beginNextRoundButton.Enabled = true;
            beginNextRoundButton.Text = string.Format("Create Pairings for Round {0}", roundNumber);
        }
    }

    internal class BeginNextRoundButtonClickedEventArgs : EventArgs
    {
        public List<string> PlayerNames { get; set; } = new List<string>();
    } 
}
