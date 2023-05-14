namespace MTGCupid.UI
{
    partial class TournamentInitialiserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentInitialiserControl));
            nameList = new NameEntryListControl();
            playerCountLabel = new Label();
            beginNextRoundButton = new Button();
            tournamentTypeLabel = new Label();
            tournamentTypeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // nameList
            // 
            resources.ApplyResources(nameList, "nameList");
            nameList.BackColor = SystemColors.ControlLight;
            nameList.BorderStyle = BorderStyle.FixedSingle;
            nameList.Name = "nameList";
            nameList.RegisteredPlayersCountChanged += nameList_RegisteredPlayersCountChanged;
            // 
            // playerCountLabel
            // 
            resources.ApplyResources(playerCountLabel, "playerCountLabel");
            playerCountLabel.Name = "playerCountLabel";
            // 
            // beginNextRoundButton
            // 
            resources.ApplyResources(beginNextRoundButton, "beginNextRoundButton");
            beginNextRoundButton.Name = "beginNextRoundButton";
            beginNextRoundButton.UseVisualStyleBackColor = true;
            beginNextRoundButton.Click += beginNextRoundButton_Click;
            // 
            // tournamentTypeLabel
            // 
            resources.ApplyResources(tournamentTypeLabel, "tournamentTypeLabel");
            tournamentTypeLabel.Name = "tournamentTypeLabel";
            // 
            // tournamentTypeComboBox
            // 
            tournamentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tournamentTypeComboBox.FormattingEnabled = true;
            resources.ApplyResources(tournamentTypeComboBox, "tournamentTypeComboBox");
            tournamentTypeComboBox.Name = "tournamentTypeComboBox";
            // 
            // TournamentInitialiserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(tournamentTypeComboBox);
            Controls.Add(tournamentTypeLabel);
            Controls.Add(beginNextRoundButton);
            Controls.Add(playerCountLabel);
            Controls.Add(nameList);
            Name = "TournamentInitialiserControl";
            resources.ApplyResources(this, "$this");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NameEntryListControl nameList;
        private Label playerCountLabel;
        private Button beginNextRoundButton;
        private Label tournamentTypeLabel;
        private ComboBox tournamentTypeComboBox;
    }
}
