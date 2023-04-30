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
    internal partial class TournamentHandlerControl : UserControl
    {
        private Tournament? tournament;

        public TournamentHandlerControl()
        {
            InitializeComponent();
        }

        private void tournamentInitialiserControl_BeginNextRoundButtonClicked(object sender, BeginNextRoundButtonClickedEventArgs e)
        {
            if (tournament == null)
            {
                // Create a new tournament
                tournament = new Tournament(e.PlayerNames);
            }

            try
            {
                // Generate the next round
                var round = tournament.CreateNextRound();
                pairingsListControl.InitialiseWithMatches(round);
                tabControl.SelectedTab = pairingsPage;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("A new round could not be created. There are no possible new pairings for the remaining players. Please refer to the standings tab for the final standings.", "Failed to create round", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                tabControl.SelectedTab = standingsPage;
            }
        }

        private void pairingsListControl_MatchesConfirmed(object sender, EventArgs e)
        {
            if (tournament == null)
                throw new InvalidOperationException("Tournament has not been started.");
            
            if (!tournament.SubmitMatchResults())
                throw new InvalidOperationException("Not all matches have been submitted.");

            tournamentInitialiserControl.EnableNextRoundButton(tournament.CurrentRound);

            // Update standings
            standingsViewControl.UpdateStandings(tournament.GetStandings());
        }
    }
}
