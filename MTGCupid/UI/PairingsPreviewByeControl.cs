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
    public partial class PairingsPreviewByeControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the bye player is selected to be paired")]
        public event EventHandler<ByePlayerSelectedEventArgs>? ByePlayerSelected;

        private readonly Color DEFAULT = SystemColors.ControlDark;
        private readonly Color SELECTED = Color.Yellow;
        private readonly Color CANNOT_SELECT = Color.Red;

        private readonly Player player;

        public PairingsPreviewByeControl(Player player)
        {
            InitializeComponent();

            this.player = player;
            button.Text = string.Format("{0}. {1}{2}", player.Seed, player.Name, player.ByesReceived == 0 ? "" : " (has byed)");
        }

        private void button_Click(object sender, EventArgs e)
        {
            var args = new ByePlayerSelectedEventArgs()
            {
                Player = player
            };
            ByePlayerSelected?.Invoke(this, args);
        }

        public void SetSelected(bool selected)
        {
            button.BackColor = selected ? SELECTED : DEFAULT;
        }

        public void UpdateWithCanPair(Player otherPlayer)
        {
            if (player.HasPlayed(otherPlayer))
            {
                button.BackColor = CANNOT_SELECT;
                button.Enabled = false;
            }
            else
            {
                button.BackColor = DEFAULT;
            }
        }

        public void ResetSelectionStatus()
        {
            button.BackColor = DEFAULT;
            button.Enabled = true;
        }
    }

    public class ByePlayerSelectedEventArgs : EventArgs
    {
        public Player? Player { get; internal set; }
    }
}
