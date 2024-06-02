using MTGCupid.Rulesets;
using MTGCupid.Tournaments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MTGCupid.Tournaments.TournamentFactory;

namespace MTGCupid.UI
{
    internal partial class TournamentInitialiserControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the begin next round button is clicked")]
        public event EventHandler<BeginNextRoundButtonClickedEventArgs>? BeginNextRoundButtonClicked;

        public bool HasTournamentBegun { get; set; } = false;

        private readonly OrderedDictionary TournamentTypeReadableName = new OrderedDictionary() 
        {
            { TournamentType.SwissTournament, SwissTournament.TournamentTypeString },
            { TournamentType.SwissDraft, SwissDraftTournament.TournamentTypeString },
            { TournamentType.SwissMultiplayerTournament, SwissMultiplayerTournament.TournamentTypeString }
        };



        private readonly OrderedDictionary TournamentRulesetReadableName = new OrderedDictionary()
        {
            { TournamentRuleset.MagicTheGathering, MTGRuleset.RulesetString },
            { TournamentRuleset.StarWarsUnlimited, SWURuleset.RulesetString }
        };

        public TournamentInitialiserControl()
        {
            InitializeComponent();

            // Setup tournament combo boxes
            foreach (TournamentType type in Enum.GetValues(typeof(TournamentType)))
            {
                tournamentTypeComboBox.Items.Add(TournamentTypeReadableName[type]);
            }
            tournamentTypeComboBox.SelectedIndex = 0;

            foreach (TournamentRuleset ruleset in Enum.GetValues(typeof(TournamentRuleset)))
            {
                tournamentRulesetComboBox.Items.Add(TournamentRulesetReadableName[ruleset]);
            }
            tournamentRulesetComboBox.SelectedIndex = 0;
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
            return (TournamentType)TournamentTypeReadableName.Cast<DictionaryEntry>().ElementAt(tournamentTypeComboBox.SelectedIndex).Key;
        }

        public TournamentRuleset GetSelectedTournamentRuleset()
        {
            return (TournamentRuleset)TournamentRulesetReadableName.Cast<DictionaryEntry>().ElementAt(tournamentRulesetComboBox.SelectedIndex).Key;
        }
    }

    internal class BeginNextRoundButtonClickedEventArgs : EventArgs
    {
        public List<string> PlayerNames { get; set; } = new List<string>();
    }
}
