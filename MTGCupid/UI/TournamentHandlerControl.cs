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
        private ATournament? tournament;

        public TournamentHandlerControl()
        {
            InitializeComponent();

            // Setup menu items to match the current setting
            autoConfirmPairingsToolStripMenuItem.Checked = Properties.Settings.Default.AutoConfirmPairings;

            if (string.IsNullOrEmpty(Properties.Settings.Default.TournamentSaveLocation))
            {
                Properties.Settings.Default.TournamentSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MTGCupid", "tournaments");
                Directory.CreateDirectory(Properties.Settings.Default.TournamentSaveLocation);
            }

            loadTournamentDialog.InitialDirectory = Properties.Settings.Default.TournamentSaveLocation;
            saveTournamentDialog.InitialDirectory = Properties.Settings.Default.TournamentSaveLocation;
        }

        private void tournamentInitialiserControl_BeginNextRoundButtonClicked(object sender, BeginNextRoundButtonClickedEventArgs e)
        {
            if (tournament == null)
            {
                // Create a new tournament
                TournamentFactory tf = new TournamentFactory()
                    .WithTournamentType(tournamentInitialiserControl.GetSelectedTournamentType())
                    .WithRuleset(tournamentInitialiserControl.GetSelectedTournamentRuleset())
                    .WithPlayers(e.PlayerNames);

                if (e.MatchmakingSettings != null)
                    tf = tf.WithMatchmakingSettings(e.MatchmakingSettings);

                tournament = tf.Create();

                if (tournament is IPoddedTournament poddedTournament)
                {
                    // Show draft pods dialog
                    var draftPodsForm = new PodsForm(poddedTournament.GetDraftSeating());
                    if (draftPodsForm.ShowDialog() != DialogResult.OK)
                    {
                        tournament = null;
                        return;
                    }
                }
            }

            try
            {
                // Generate the next round
                var (pairings, byePlayers) = tournament.SuggestNextRoundPairings();
                if (!Properties.Settings.Default.AutoConfirmPairings)
                {
                    if (tournament is AMultiplayerTournament)
                    {
                        // TODO: Implement manual pairing adjustment for multiplayer tournaments
                        MessageBox.Show("Manual pairing adjustment for multiplayer tournaments is not yet supported. Coming soon!", "Manual pairing adjustment not supported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Update pairings according to user input
                        var pairingsPreviewForm = new PairingsPreviewForm(pairings, byePlayers);
                        if (pairingsPreviewForm.ShowDialog() != DialogResult.OK)
                            return;

                        pairings = pairingsPreviewForm.Pairings;
                        byePlayers = pairingsPreviewForm.ByePlayers;
                    }
                }
                tournamentInitialiserControl.DisableNextRoundButton();

                var round = tournament.CreateRoundWithPairings(pairings, byePlayers);
                pairingsListControl.InitialiseWithMatches(round);
                tabControl.SelectedTab = pairingsPage;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("A new round could not be created. There are no possible new pairings for the remaining players. Please refer to the standings tab for the final standings.", "Failed to create round", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void loadMostRecentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tournament != null)
            {
                if (MessageBox.Show("The current in-progress tournament will be lost. Are you sure you want to continue?", "Load most recent tournament", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            string directory = Properties.Settings.Default.TournamentSaveLocation;
            var sortedFiles = new DirectoryInfo(directory).GetFiles("*.json").OrderByDescending(f => f.LastWriteTime);
            var mostRecentFile = sortedFiles.FirstOrDefault();
            if (mostRecentFile == default)
            {
                MessageBox.Show("No tournaments have been saved.", "No tournaments saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadTournamentFromPath(mostRecentFile.FullName);
        }

        private void LoadTournamentFromPath(string path)
        {
            try
            {
                tournament = ATournament.LoadTournament(path);
            }
            catch (FileFormatException ex)
            {
                MessageBox.Show("Exception occurred whilst reading file: \r\n" + ex.ToString(), "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tournamentInitialiserControl.HasTournamentBegun = true;
            standingsViewControl.UpdateStandings(tournament.GetStandings());
            pairingsListControl.InitialiseWithMatches(tournament.MatchesInProgress);
            if (tournament.AwaitingMatchResults)
            {
                tournamentInitialiserControl.DisableNextRoundButton();
            }
            else
            {
                tournamentInitialiserControl.EnableNextRoundButton(tournament.CurrentRound);
            }

            MessageBox.Show("Tournament load successful.", "Tournament loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tournament != null)
            {
                if (MessageBox.Show("The current in-progress tournament will be lost. Are you sure you want to continue?", "Load most recent tournament", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            if (loadTournamentDialog.ShowDialog() != DialogResult.OK)
                return;

            LoadTournamentFromPath(loadTournamentDialog.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tournament == null)
            {
                MessageBox.Show("No tournament has been started.", "No tournament started", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (saveTournamentDialog.ShowDialog() != DialogResult.OK)
                return;

            tournament.SaveTournamentProgress(saveTournamentDialog.FileName);

            MessageBox.Show("Tournament saved successfully.", "Tournament saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
