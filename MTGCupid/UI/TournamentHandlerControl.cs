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

            // Generate the next round
            var round = tournament.CreateNextRound();
            pairingsListControl.InitialiseWithMatches(round);
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
