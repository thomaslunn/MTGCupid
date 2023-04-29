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
            standingsPage = new TabPage();
            standingsViewControl = new StandingsViewControl();
            tabControl.SuspendLayout();
            setupPage.SuspendLayout();
            standingsPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(setupPage);
            tabControl.Controls.Add(standingsPage);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 492);
            tabControl.TabIndex = 0;
            // 
            // setupPage
            // 
            setupPage.Controls.Add(tournamentInitialiserControl);
            setupPage.Location = new Point(4, 24);
            setupPage.Name = "setupPage";
            setupPage.Padding = new Padding(3);
            setupPage.Size = new Size(768, 464);
            setupPage.TabIndex = 0;
            setupPage.Text = "Tournament Setup";
            setupPage.UseVisualStyleBackColor = true;
            // 
            // tournamentInitialiserControl
            // 
            tournamentInitialiserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tournamentInitialiserControl.Location = new Point(3, 3);
            tournamentInitialiserControl.Name = "tournamentInitialiserControl";
            tournamentInitialiserControl.Size = new Size(762, 458);
            tournamentInitialiserControl.TabIndex = 0;
            tournamentInitialiserControl.BeginNextRoundButtonClicked += tournamentInitialiserControl_BeginNextRoundButtonClicked;
            // 
            // standingsPage
            // 
            standingsPage.Controls.Add(standingsViewControl);
            standingsPage.Location = new Point(4, 24);
            standingsPage.Name = "standingsPage";
            standingsPage.Padding = new Padding(3);
            standingsPage.Size = new Size(768, 464);
            standingsPage.TabIndex = 1;
            standingsPage.Text = "Standings";
            standingsPage.UseVisualStyleBackColor = true;
            // 
            // standingsViewControl
            // 
            standingsViewControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            standingsViewControl.Location = new Point(0, 0);
            standingsViewControl.Name = "standingsViewControl";
            standingsViewControl.Size = new Size(768, 464);
            standingsViewControl.TabIndex = 0;
            // 
            // TournamentHandlerControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(tabControl);
            Name = "TournamentHandlerControl";
            Size = new Size(800, 516);
            tabControl.ResumeLayout(false);
            setupPage.ResumeLayout(false);
            standingsPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage setupPage;
        private TournamentInitialiserControl tournamentInitialiserControl;
        private TabPage standingsPage;
        private StandingsViewControl standingsViewControl;
    }
}
