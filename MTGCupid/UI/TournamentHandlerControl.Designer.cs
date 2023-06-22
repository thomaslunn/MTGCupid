using System.Windows.Forms;

namespace MTGCupid.UI
{
    partial class TournamentHandlerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            setupPage = new TabPage();
            tournamentInitialiserControl = new TournamentInitialiserControl();
            pairingsPage = new TabPage();
            pairingsListControl = new PairingsListControl();
            standingsPage = new TabPage();
            standingsViewControl = new StandingsViewControl();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadMostRecentToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            autoConfirmPairingsToolStripMenuItem = new ToolStripMenuItem();
            loadTournamentDialog = new OpenFileDialog();
            saveTournamentDialog = new SaveFileDialog();
            tabControl.SuspendLayout();
            setupPage.SuspendLayout();
            pairingsPage.SuspendLayout();
            standingsPage.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(setupPage);
            tabControl.Controls.Add(pairingsPage);
            tabControl.Controls.Add(standingsPage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 28);
            tabControl.Name = "tabControl";
            tabControl.RightToLeft = RightToLeft.No;
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 488);
            tabControl.TabIndex = 0;
            // 
            // setupPage
            // 
            setupPage.Controls.Add(tournamentInitialiserControl);
            setupPage.Location = new Point(4, 29);
            setupPage.Name = "setupPage";
            setupPage.Padding = new Padding(3);
            setupPage.Size = new Size(792, 455);
            setupPage.TabIndex = 0;
            setupPage.Text = "Tournament Setup";
            setupPage.UseVisualStyleBackColor = true;
            // 
            // tournamentInitialiserControl
            // 
            tournamentInitialiserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tournamentInitialiserControl.Location = new Point(3, 3);
            tournamentInitialiserControl.Name = "tournamentInitialiserControl";
            tournamentInitialiserControl.Size = new Size(786, 449);
            tournamentInitialiserControl.TabIndex = 0;
            tournamentInitialiserControl.BeginNextRoundButtonClicked += tournamentInitialiserControl_BeginNextRoundButtonClicked;
            // 
            // pairingsPage
            // 
            pairingsPage.Controls.Add(pairingsListControl);
            pairingsPage.Location = new Point(4, 29);
            pairingsPage.Name = "pairingsPage";
            pairingsPage.Padding = new Padding(3);
            pairingsPage.Size = new Size(792, 455);
            pairingsPage.TabIndex = 2;
            pairingsPage.Text = "Pairings";
            pairingsPage.UseVisualStyleBackColor = true;
            // 
            // pairingsListControl
            // 
            pairingsListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pairingsListControl.Location = new Point(0, 0);
            pairingsListControl.Margin = new Padding(3, 4, 3, 4);
            pairingsListControl.Name = "pairingsListControl";
            pairingsListControl.Size = new Size(792, 455);
            pairingsListControl.TabIndex = 0;
            pairingsListControl.MatchesConfirmed += pairingsListControl_MatchesConfirmed;
            // 
            // standingsPage
            // 
            standingsPage.Controls.Add(standingsViewControl);
            standingsPage.Location = new Point(4, 29);
            standingsPage.Name = "standingsPage";
            standingsPage.Padding = new Padding(3);
            standingsPage.Size = new Size(792, 455);
            standingsPage.TabIndex = 1;
            standingsPage.Text = "Standings";
            standingsPage.UseVisualStyleBackColor = true;
            // 
            // standingsViewControl
            // 
            standingsViewControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            standingsViewControl.Location = new Point(0, 0);
            standingsViewControl.Name = "standingsViewControl";
            standingsViewControl.Size = new Size(792, 455);
            standingsViewControl.TabIndex = 0;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 28);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadMostRecentToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadMostRecentToolStripMenuItem
            // 
            loadMostRecentToolStripMenuItem.Name = "loadMostRecentToolStripMenuItem";
            loadMostRecentToolStripMenuItem.Size = new Size(224, 26);
            loadMostRecentToolStripMenuItem.Text = "Load most recent";
            loadMostRecentToolStripMenuItem.Click += loadMostRecentToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(224, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { autoConfirmPairingsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // autoConfirmPairingsToolStripMenuItem
            // 
            autoConfirmPairingsToolStripMenuItem.CheckOnClick = true;
            autoConfirmPairingsToolStripMenuItem.Name = "autoConfirmPairingsToolStripMenuItem";
            autoConfirmPairingsToolStripMenuItem.Size = new Size(245, 26);
            autoConfirmPairingsToolStripMenuItem.Text = "Auto-confirm pairings?";
            autoConfirmPairingsToolStripMenuItem.ToolTipText = "Disable to allow pairings to be manually adjusted before a round is created";
            autoConfirmPairingsToolStripMenuItem.CheckedChanged += autoConfirmPairingsToolStripMenuItem_CheckedChanged;
            // 
            // loadTournamentDialog
            // 
            loadTournamentDialog.Filter = "JSON files|*.json|All files|*.*";
            // 
            // saveTournamentDialog
            // 
            saveTournamentDialog.DefaultExt = "json";
            saveTournamentDialog.Filter = "JSON files|*.json|All files|*.*";
            // 
            // TournamentHandlerControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(tabControl);
            Controls.Add(menuStrip);
            Name = "TournamentHandlerControl";
            Size = new Size(800, 516);
            tabControl.ResumeLayout(false);
            setupPage.ResumeLayout(false);
            pairingsPage.ResumeLayout(false);
            standingsPage.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage setupPage;
        private TournamentInitialiserControl tournamentInitialiserControl;
        private TabPage standingsPage;
        private StandingsViewControl standingsViewControl;
        private TabPage pairingsPage;
        private PairingsListControl pairingsListControl;
        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem autoConfirmPairingsToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadMostRecentToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private OpenFileDialog loadTournamentDialog;
        private SaveFileDialog saveTournamentDialog;
    }
}
