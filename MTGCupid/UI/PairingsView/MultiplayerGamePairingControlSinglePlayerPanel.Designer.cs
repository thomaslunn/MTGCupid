namespace MTGCupid.UI.PairingsView
{
    partial class MultiplayerGamePairingControlSinglePlayerPanel
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
            playerLabel = new Label();
            numericUpDown = new NumericUpDown();
            dropPlayerBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // playerLabel
            // 
            playerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            playerLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            playerLabel.Location = new Point(3, 9);
            playerLabel.Name = "playerLabel";
            playerLabel.Size = new Size(144, 42);
            playerLabel.TabIndex = 1;
            playerLabel.Text = "Player";
            playerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // numericUpDown
            // 
            numericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown.BackColor = Color.FromArgb(255, 255, 128);
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDown.Location = new Point(3, 54);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(144, 61);
            numericUpDown.TabIndex = 2;
            numericUpDown.TextAlign = HorizontalAlignment.Center;
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            // 
            // dropPlayerBox
            // 
            dropPlayerBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dropPlayerBox.AutoSize = true;
            dropPlayerBox.Location = new Point(38, 122);
            dropPlayerBox.Margin = new Padding(3, 4, 3, 4);
            dropPlayerBox.Name = "dropPlayerBox";
            dropPlayerBox.Size = new Size(72, 24);
            dropPlayerBox.TabIndex = 7;
            dropPlayerBox.Text = "Drop?";
            dropPlayerBox.TextAlign = ContentAlignment.BottomCenter;
            dropPlayerBox.UseVisualStyleBackColor = true;
            // 
            // MultiplayerGamePairingControlSinglePlayerPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dropPlayerBox);
            Controls.Add(numericUpDown);
            Controls.Add(playerLabel);
            Name = "MultiplayerGamePairingControlSinglePlayerPanel";
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label playerLabel;
        private NumericUpDown numericUpDown;
        private CheckBox dropPlayerBox;
    }
}
