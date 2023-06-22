namespace MTGCupid.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tournamentHandlerControl = new TournamentHandlerControl();
            SuspendLayout();
            // 
            // tournamentHandlerControl
            // 
            tournamentHandlerControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tournamentHandlerControl.Location = new Point(-1, -1);
            tournamentHandlerControl.Name = "tournamentHandlerControl";
            tournamentHandlerControl.Size = new Size(799, 521);
            tournamentHandlerControl.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 516);
            Controls.Add(tournamentHandlerControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "MTG Cupid";
            FormClosing += MainForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private TournamentHandlerControl tournamentHandlerControl;
    }
}