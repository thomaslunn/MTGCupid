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
    public partial class PairingsPreviewForm : Form
    {
        private List<IPairing> pairings = new List<IPairing>();
        private List<Player> byePlayers = new List<Player>();

        private Player? selectedByePlayer;
        private PairingsPreviewByeControl? selectedByePlayerControl;

        public List<IPairing> Pairings
        {
            get
            {
                if (DialogResult != DialogResult.OK)
                    throw new InvalidOperationException("Pairings were not confirmed.");
                return pairings;
            }
        }

        public List<Player> ByePlayers
        {
            get
            {
                if (DialogResult != DialogResult.OK)
                    throw new InvalidOperationException("Pairings were not confirmed.");
                return byePlayers;
            }
        }

        public PairingsPreviewForm(List<IPairing> pairings, List<Player> byePlayers)
        {
            InitializeComponent();

            foreach (var pairing in pairings)
            {
                AddPairing(pairing);
            }

            foreach (var player in byePlayers)
            {
                AddBye(player);
            }
        }

        private void AddBye(Player player)
        {
            byePlayers.Add(player);
            var byeControl = new PairingsPreviewByeControl(player);
            byeControl.ByePlayerSelected += OnByePlayerSelected;
            byesFlowLayout.Controls.Add(byeControl);
        }

        private void AddPairing(IPairing pairing)
        {
            pairings.Add(pairing);
            var pairingControl = pairing.GetPairingControl();
            pairingControl.UnpairRequested += OnUnpairRequested;
            pairingsFlowLayout.Controls.Add(pairingControl);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (byePlayers.Count > 1)
            {
                if (MessageBox.Show("More than one player is currently selected to have a bye. Are you sure you want to continue?", "Too many players with a bye", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                    return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnUnpairRequested(object? sender, UnpairRequestedEventArgs e)
        {
            if (sender == null)
                return;

            var pairingControl = (PairingsPreviewPairingControl)sender;
            var pairing = e.Pairing;
            if (pairing == null)
            {
                throw new InvalidOperationException("Attempting to unpair a pairing that does not exist.");
            }
            pairings.Remove(pairing);
            pairingsFlowLayout.Controls.Remove(pairingControl);

            foreach (var player in pairing.Players)
            {
                AddBye(player);
            }
        }

        private void OnByePlayerSelected(object? sender, ByePlayerSelectedEventArgs e)
        {
            if (sender == null || e.Player == null)
                return;

            var byeControl = (PairingsPreviewByeControl)sender;
            var player = e.Player;

            if (selectedByePlayer == null)
            {
                byeControl.SetSelected(true);
                selectedByePlayer = player;
                selectedByePlayerControl = byeControl;

                foreach (var otherByeControl in byesFlowLayout.Controls)
                {
                    if (otherByeControl != byeControl)
                    {
                        ((PairingsPreviewByeControl)otherByeControl).UpdateWithCanPair(player);
                    }
                }
            }
            else if (selectedByePlayer == player)
            {
                byeControl.ResetSelectionStatus();
                selectedByePlayer = null;

                foreach (var otherByeControl in byesFlowLayout.Controls)
                {
                    ((PairingsPreviewByeControl)otherByeControl).ResetSelectionStatus();
                }
            }
            else
            {
                // Create pairing
                AddPairing(new Pairing(selectedByePlayer, player));

                byePlayers.Remove(selectedByePlayer);
                byePlayers.Remove(player);

                byesFlowLayout.Controls.Remove(byeControl);
                byesFlowLayout.Controls.Remove(selectedByePlayerControl);

                selectedByePlayer = null;
                selectedByePlayerControl = null;

                foreach (var otherByeControl in byesFlowLayout.Controls)
                {
                    ((PairingsPreviewByeControl)otherByeControl).ResetSelectionStatus();
                }
            }
        }

        private void OnFlowLayoutChange(object sender, LayoutEventArgs e)
        {
            var flowPanel = (FlowLayoutPanel)sender;

            flowPanel.SuspendLayout();
            flowPanel.HorizontalScroll.Visible = false;

            // Resize all the pairings controls to fit the width of the flow layout panel
            foreach (var entry in flowPanel.Controls)
            {
                ((Control)entry).Width = flowPanel.Width - SystemInformation.VerticalScrollBarWidth;
            }

            flowPanel.ResumeLayout();
        }
    }
}
