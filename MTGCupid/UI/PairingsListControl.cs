using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGCupid.UI
{
    public partial class PairingsListControl : UserControl
    {
        private List<PairingControl> pairings = new List<PairingControl>();
        private List<Match> matches = new List<Match>();

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the results of all matches are submitted.")]
        public event EventHandler? MatchesConfirmed;

        public PairingsListControl()
        {
            InitializeComponent();
        }

        public void InitialiseWithMatches(List<Match> matches)
        {
            this.matches = matches;
            pairings.Clear();

            flowLayoutPanel.SuspendLayout();
            flowLayoutPanel.Controls.Clear();

            foreach (var match in matches)
            {
                var pairing = new PairingControl(match);
                pairing.MatchSubmittedToggled += OnMatchSubmittedToggled;
                pairings.Add(pairing);
                flowLayoutPanel.Controls.Add(pairing);
            }

            flowLayoutPanel.ResumeLayout();

            confirmButton.Enabled = false;
            flowLayoutPanel.Enabled = true;
        }

        private void flowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            flowLayoutPanel.SuspendLayout();

            flowLayoutPanel.HorizontalScroll.Visible = false;

            // Resize all the pairings controls to fit the width of the flow layout panel
            foreach (var entry in pairings)
            {
                entry.Width = flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth;
            }
            flowLayoutPanel.ResumeLayout();
        }

        private void OnMatchSubmittedToggled(object? sender, MatchSubmittedToggledEventArgs e)
        {
            if (matches.All(match => match.Completed))
            {
                confirmButton.Enabled = true;
            }
            else
            {
                confirmButton.Enabled = false;
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (matches.Any(match => !match.Completed))
                return; // Only allow confirmation if all matches are completed

            foreach (var pairing in pairings)
            {
                pairing.DropPlayers();
            }

            confirmButton.Enabled = false;
            flowLayoutPanel.Enabled = false; // Disable all pairing controls so they can't be edited

            MatchesConfirmed?.Invoke(this, e);
        }

        private void submitAllButton_Click(object sender, EventArgs e)
        {
            foreach (var pairing in pairings)
            {
                pairing.Submit();
            }
        }
    }
}
