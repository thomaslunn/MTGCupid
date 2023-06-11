using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTGCupid.Pairings;

namespace MTGCupid.UI
{
    public partial class PairingsPreviewPairingControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the pairing is requested to be unpaired")]
        public event EventHandler<UnpairRequestedEventArgs>? UnpairRequested;

        private readonly Pairing pairing;

        public PairingsPreviewPairingControl(Pairing pairing)
        {
            InitializeComponent();

            this.pairing = pairing;

            pairingButton.Text = pairing.ToString();
        }

        private void pairingButton_Click(object sender, EventArgs e)
        {
            var args = new UnpairRequestedEventArgs()
            {
                Pairing = pairing
            };
            UnpairRequested?.Invoke(this, args);
        }
    }

    public class UnpairRequestedEventArgs : EventArgs
    {
        public Pairing? Pairing { get; internal set; }
    }
}
