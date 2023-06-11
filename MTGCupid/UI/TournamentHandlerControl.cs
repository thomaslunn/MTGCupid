using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTGCupid.Tournaments;

namespace MTGCupid.UI
{
    internal partial class TournamentHandlerControl : UserControl
    {
        private Tournament? tournament;

        public TournamentHandlerControl()
        {
            InitializeComponent();

            // Setup menu items to match the current setting
            autoConfirmPairingsToolStripMenuItem.Checked = Properties.Settings.Default.AutoConfirmPairings;
        }

        private void tournamentInitialiserControl_BeginNextRoundButtonClicked(object sender, BeginNextRoundButtonClickedEventArgs e)
        {
            if (tournament == null)
            {
                // Create a new tournament
                var tourneyType = tournamentInitialiserControl.GetSelectedTournamentType();
                switch (tourneyType)
                {
                    case TournamentInitialiserControl.TournamentType.SwissTournament:
                        tournament = new SwissTournament(e.PlayerNames);
                        break;
                    case TournamentInitialiserControl.TournamentType.SwissDraft:
                        tournament = new SwissDraftTournament(e.PlayerNames);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown tournament type");
                }

                if (tournament is IPoddedTournament poddedTournament)
                {
                    // Show draft pods dialog
                    var draftPodsForm = new PodsForm(poddedTournament.GetDraftSeating());
                    if (draftPodsForm.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            try
            {
                // Generate the next round
                var (pairings, byePlayers) = tournament.SuggestNextRoundPairings();
                if (!Properties.Settings.Default.AutoConfirmPairings)
                {
                    // Update pairings according to user input
                    var pairingsPreviewForm = new PairingsPreviewForm(pairings, byePlayers);
                    if (pairingsPreviewForm.ShowDialog() != DialogResult.OK)
                        return;

                    pairings = pairingsPreviewForm.Pairings;
                    byePlayers = pairingsPreviewForm.ByePlayers;
                }
                tournamentInitialiserControl.DisableNextRoundButton();

                var round = tournament.CreateRoundWithPairings(pairings, byePlayers);
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

        private void autoConfirmPairingsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoConfirmPairings = autoConfirmPairingsToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
