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
    public partial class PairingsPreviewPairingControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the pairing is requested to be unpaired")]
        public event EventHandler<UnpairRequestedEventArgs>? UnpairRequested;

        private readonly Player p1;
        private readonly Player p2;

        public PairingsPreviewPairingControl(Player p1, Player p2)
        {
            InitializeComponent();

            this.p1 = p1;
            this.p2 = p2;

            pairingButton.Text = string.Format("{0}. {1} vs {2}. {3}", p1.Seed, p1.Name, p2.Seed, p2.Name);
        }

        private void pairingButton_Click(object sender, EventArgs e)
        {
            var args = new UnpairRequestedEventArgs()
            {
                Player1 = p1,
                Player2 = p2
            };
            UnpairRequested?.Invoke(this, args);
        }
    }

    public class UnpairRequestedEventArgs : EventArgs
    {
        public Player? Player1 { get; internal set; }
        public Player? Player2 { get; internal set; }
    }
}
