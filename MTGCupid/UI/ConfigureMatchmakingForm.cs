using MTGCupid.Rulesets;
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
    public partial class ConfigureMatchmakingForm : Form
    {
        public ConfigureMatchmakingForm()
        {
            InitializeComponent();
        }

        public void Setup(MatchmakingSettings settings)
        {
            MultiplayerMatchmakingPrioritySetting = settings.MultiplayerMatchmakingPriority;
            TiebreakerHandlingSetting = settings.TiebreakerHandling;
        }

        public void UpdateSettings(MatchmakingSettings settings)
        {
            settings.MultiplayerMatchmakingPriority = MultiplayerMatchmakingPrioritySetting;
            settings.TiebreakerHandling = TiebreakerHandlingSetting;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public MatchmakingSettings.EMultiplayerMatchmakingPriority MultiplayerMatchmakingPrioritySetting
        {
            get
            {
                return prioritiseEvenMatchupsButton.Checked
                    ? MatchmakingSettings.EMultiplayerMatchmakingPriority.PrioritiseEvenMatchups
                    : MatchmakingSettings.EMultiplayerMatchmakingPriority.PrioritiseVariedMatchups;
            }
            set
            {
                switch (value)
                {
                    case MatchmakingSettings.EMultiplayerMatchmakingPriority.PrioritiseEvenMatchups:
                        prioritiseEvenMatchupsButton.Checked = true;
                        break;
                    case MatchmakingSettings.EMultiplayerMatchmakingPriority.PrioritiseVariedMatchups:
                        prioritiseVariedMatchupsButton.Checked = true;
                        break;
                }
            }
        }

        public MatchmakingSettings.ETiebreakerHandling TiebreakerHandlingSetting
        {
            get
            {
                return considerTiebreakersButton.Checked
                    ? MatchmakingSettings.ETiebreakerHandling.UseTiebreakersForEvenPairings
                    : MatchmakingSettings.ETiebreakerHandling.IgnoreTiebreakersForEvenPairings;
            }
            set
            {
                switch (value)
                {
                    case MatchmakingSettings.ETiebreakerHandling.UseTiebreakersForEvenPairings:
                        considerTiebreakersButton.Checked = true;
                        break;
                    case MatchmakingSettings.ETiebreakerHandling.IgnoreTiebreakersForEvenPairings:
                        ignoreTiebreakersButton.Checked = true;
                        break;
                }
            }
        }
    }
}
