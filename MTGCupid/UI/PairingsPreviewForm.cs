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
        private List<(Player p1, Player p2)> pairings = new List<(Player p1, Player p2)>();
        private List<Player> byePlayers = new List<Player>();

        private Player? selectedByePlayer;
        private PairingsPreviewByeControl? selectedByePlayerControl;

        public List<(Player p1, Player p2)> Pairings
        {
            get
            {
                if (DialogResult != DialogResult.OK)
                    throw new InvalidOperationException("Pairings were not confirmed.");
                return pairings;
            }
        }

        public Player? ByePlayer
        {
            get
            {
                if (DialogResult != DialogResult.OK)
                    throw new InvalidOperationException("Pairings were not confirmed.");
                return byePlayers.FirstOrDefault();
            }
        }

        public PairingsPreviewForm(List<(Player p1, Player p2)> pairings, Player? byePlayer)
        {
            InitializeComponent();

            foreach (var (p1, p2) in pairings)
            {
                AddPairing(p1, p2);
            }

            if (byePlayer != null)
            {
                AddBye(byePlayer);
            }
        }

        private void AddBye(Player player)
        {
            byePlayers.Add(player);
            var byeControl = new PairingsPreviewByeControl(player);
            byeControl.ByePlayerSelected += OnByePlayerSelected;
            byesFlowLayout.Controls.Add(byeControl);
        }

        private void AddPairing(Player p1, Player p2)
        {
            pairings.Add((p1, p2));
            var pairingControl = new PairingsPreviewPairingControl(p1, p2);
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
                MessageBox.Show("More than one player is currently selected to have a bye. Please unpair all but one player to continue.", "Too many players with a bye", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var pairing = pairings.First(p => p.p1 == e.Player1 && p.p2 == e.Player2);
            pairings.Remove(pairing);
            pairingsFlowLayout.Controls.Remove(pairingControl);

            AddBye(pairing.p1);
            AddBye(pairing.p2);
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
                AddPairing(selectedByePlayer, player);

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
