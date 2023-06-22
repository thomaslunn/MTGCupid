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

        public bool HasTournamentBegun { get; set; } = false;

        public enum TournamentType
        {
            // Ensure these values increment by 1 so that they match up with the index of the combo box
            SwissTournament = 0,
            SwissDraft = 1,
            SwissMultiplayerTournament = 2
        }

        private readonly Dictionary<TournamentType, string> TournamentTypeReadableName = new Dictionary<TournamentType, string>() {
            { TournamentType.SwissTournament, "Swiss Tournament" },
            { TournamentType.SwissDraft, "Swiss Draft" },
            { TournamentType.SwissMultiplayerTournament, "Multiplayer Tournament" }
        };

        public TournamentInitialiserControl()
        {
            InitializeComponent();

            // Setup tournament type combo box
            foreach (TournamentType type in Enum.GetValues(typeof(TournamentType)))
            {
                tournamentTypeComboBox.Items.Add(TournamentTypeReadableName[type]);
            }
            tournamentTypeComboBox.SelectedIndex = 0;
        }

        private void nameList_RegisteredPlayersCountChanged(object sender, RegisteredPlayersCountChangedEventArgs e)
        {
            playerCountLabel.Text = string.Format("Players: {0}", e.PlayerCount);
        }

        private void beginNextRoundButton_Click(object sender, EventArgs e)
        {
            List<string> playerNames;
            if (!HasTournamentBegun)
            {
                // Ensure there are at least 4 players to begin a tournament
                playerNames = nameList.GetPlayerNames();
                if (playerNames.Count < 4)
                {
                    MessageBox.Show("You need at least 4 players to begin a tournament", "Not enough players", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (playerNames.Distinct().Count() < playerNames.Count)
                {
                    HashSet<string> dupeNames = new HashSet<string>();
                    foreach (var playerName in playerNames)
                    {
                        if (playerNames.Count(s => s == playerName) > 1)
                            dupeNames.Add(playerName);
                    }
                    MessageBox.Show("The following player names have been entered more than once: \r\n\r\n" + string.Join("\r\n", dupeNames), "Duplicate player names", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                playerNames = new List<string>(); // Value not used if tournament has already begun

            HasTournamentBegun = true;
            // Invoke the BeginNextRoundButtonClicked event
            BeginNextRoundButtonClicked?.Invoke(this, new BeginNextRoundButtonClickedEventArgs() { PlayerNames = playerNames });
        }

        public void EnableNextRoundButton(int roundNumber)
        {
            beginNextRoundButton.Enabled = true;
            beginNextRoundButton.Text = string.Format("Create Pairings for Round {0}", roundNumber);
        }

        public void DisableNextRoundButton()
        {
            beginNextRoundButton.Enabled = false;
            nameList.Enabled = false;
        }

        public TournamentType GetSelectedTournamentType()
        {
            return (TournamentType)tournamentTypeComboBox.SelectedIndex;
        }
    }

    internal class BeginNextRoundButtonClickedEventArgs : EventArgs
    {
        public List<string> PlayerNames { get; set; } = new List<string>();
    }
}
