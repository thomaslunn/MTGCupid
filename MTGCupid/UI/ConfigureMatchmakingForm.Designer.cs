namespace MTGCupid.UI
{
    partial class ConfigureMatchmakingForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureMatchmakingForm));
            multiplayerPriorityGroupBox = new GroupBox();
            prioritiseVariedMatchupsButton = new RadioButton();
            prioritiseEvenMatchupsButton = new RadioButton();
            tiebreakerHandlingGroupBox = new GroupBox();
            ignoreTiebreakersButton = new RadioButton();
            considerTiebreakersButton = new RadioButton();
            okButton = new Button();
            cancelButton = new Button();
            multiplayerPriorityGroupBox.SuspendLayout();
            tiebreakerHandlingGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // multiplayerPriorityGroupBox
            // 
            multiplayerPriorityGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            multiplayerPriorityGroupBox.Controls.Add(prioritiseVariedMatchupsButton);
            multiplayerPriorityGroupBox.Controls.Add(prioritiseEvenMatchupsButton);
            multiplayerPriorityGroupBox.Location = new Point(12, 12);
            multiplayerPriorityGroupBox.Name = "multiplayerPriorityGroupBox";
            multiplayerPriorityGroupBox.Size = new Size(776, 64);
            multiplayerPriorityGroupBox.TabIndex = 0;
            multiplayerPriorityGroupBox.TabStop = false;
            multiplayerPriorityGroupBox.Text = "Multiplayer pairing priority";
            // 
            // prioritiseVariedMatchupsButton
            // 
            prioritiseVariedMatchupsButton.AutoSize = true;
            prioritiseVariedMatchupsButton.Location = new Point(375, 26);
            prioritiseVariedMatchupsButton.Name = "prioritiseVariedMatchupsButton";
            prioritiseVariedMatchupsButton.Size = new Size(205, 24);
            prioritiseVariedMatchupsButton.TabIndex = 1;
            prioritiseVariedMatchupsButton.Text = "Prioritise opponent variety";
            prioritiseVariedMatchupsButton.UseVisualStyleBackColor = true;
            // 
            // prioritiseEvenMatchesButton
            // 
            prioritiseEvenMatchupsButton.AutoSize = true;
            prioritiseEvenMatchupsButton.Checked = true;
            prioritiseEvenMatchupsButton.Location = new Point(6, 26);
            prioritiseEvenMatchupsButton.Name = "prioritiseEvenMatchesButton";
            prioritiseEvenMatchupsButton.Size = new Size(191, 24);
            prioritiseEvenMatchupsButton.TabIndex = 0;
            prioritiseEvenMatchupsButton.TabStop = true;
            prioritiseEvenMatchupsButton.Text = "Prioritise even matchups";
            prioritiseEvenMatchupsButton.UseVisualStyleBackColor = true;
            // 
            // tiebreakerHandlingGroupBox
            // 
            tiebreakerHandlingGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tiebreakerHandlingGroupBox.Controls.Add(ignoreTiebreakersButton);
            tiebreakerHandlingGroupBox.Controls.Add(considerTiebreakersButton);
            tiebreakerHandlingGroupBox.Location = new Point(12, 82);
            tiebreakerHandlingGroupBox.Name = "tiebreakerHandlingGroupBox";
            tiebreakerHandlingGroupBox.Size = new Size(776, 64);
            tiebreakerHandlingGroupBox.TabIndex = 1;
            tiebreakerHandlingGroupBox.TabStop = false;
            tiebreakerHandlingGroupBox.Text = "Tiebreaker handling";
            // 
            // ignoreTiebreakersButton
            // 
            ignoreTiebreakersButton.AutoSize = true;
            ignoreTiebreakersButton.Location = new Point(375, 26);
            ignoreTiebreakersButton.Name = "ignoreTiebreakersButton";
            ignoreTiebreakersButton.Size = new Size(322, 24);
            ignoreTiebreakersButton.TabIndex = 1;
            ignoreTiebreakersButton.Text = "Ignore tiebreakers when generating pairings";
            ignoreTiebreakersButton.UseVisualStyleBackColor = true;
            // 
            // considerTiebreakersButton
            // 
            considerTiebreakersButton.AutoSize = true;
            considerTiebreakersButton.Checked = true;
            considerTiebreakersButton.Location = new Point(6, 26);
            considerTiebreakersButton.Name = "considerTiebreakersButton";
            considerTiebreakersButton.Size = new Size(358, 24);
            considerTiebreakersButton.TabIndex = 0;
            considerTiebreakersButton.TabStop = true;
            considerTiebreakersButton.Text = "Use tiebreakers to determine same-score pairings";
            considerTiebreakersButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            okButton.Location = new Point(287, 153);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 37);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(387, 153);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 37);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // ConfigureMatchmakingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 194);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(tiebreakerHandlingGroupBox);
            Controls.Add(multiplayerPriorityGroupBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigureMatchmakingForm";
            Text = "Matchmaking Settings";
            multiplayerPriorityGroupBox.ResumeLayout(false);
            multiplayerPriorityGroupBox.PerformLayout();
            tiebreakerHandlingGroupBox.ResumeLayout(false);
            tiebreakerHandlingGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox multiplayerPriorityGroupBox;
        private RadioButton prioritiseVariedMatchupsButton;
        private RadioButton prioritiseEvenMatchupsButton;
        private GroupBox tiebreakerHandlingGroupBox;
        private RadioButton ignoreTiebreakersButton;
        private RadioButton considerTiebreakersButton;
        private Button okButton;
        private Button cancelButton;
    }
}