using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MTGCupid.UI.PairingsView.IPairingControl;

namespace MTGCupid.UI.PairingsView
{
    public partial class MultiplayerGamePairingControlSinglePlayerPanel : UserControl
    {

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the score is updated.")]
        public event EventHandler<EventArgs>? ScoreUpdated;

        public MultiplayerGamePairingControlSinglePlayerPanel(string playerName)
        {
            InitializeComponent();

            playerLabel.Text = playerName;
            this.BackColor = CONTROL_BACKGROUND;
        }

        public int Score => (int)numericUpDown.Value;

        public bool IsDrop => dropPlayerBox.Checked;

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ScoreUpdated?.Invoke(this, e);
        }

        public void SetScoreBackgroundColour(Color color)
        {
            numericUpDown.BackColor = color;
        }
    }
}
