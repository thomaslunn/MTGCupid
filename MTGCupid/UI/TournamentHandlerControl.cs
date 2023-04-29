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
                standingsViewControl.RegisterStandingsList(tournament.Players);
            }
        }
    }
}
