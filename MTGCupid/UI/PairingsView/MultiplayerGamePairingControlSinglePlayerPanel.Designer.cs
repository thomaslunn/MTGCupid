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
            playerLabel.Location = new Point(3, 7);
            playerLabel.Name = "playerLabel";
            playerLabel.Size = new Size(126, 32);
            playerLabel.TabIndex = 1;
            playerLabel.Text = "Player";
            playerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // numericUpDown
            // 
            numericUpDown.Anchor = AnchorStyles.Top;
            numericUpDown.BackColor = Color.FromArgb(255, 255, 128);
            numericUpDown.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDown.Location = new Point(3, 40);
            numericUpDown.Margin = new Padding(3, 2, 3, 2);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(126, 50);
            numericUpDown.TabIndex = 2;
            numericUpDown.TextAlign = HorizontalAlignment.Center;
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            // 
            // dropPlayerBox
            // 
            dropPlayerBox.Anchor = AnchorStyles.Bottom;
            dropPlayerBox.Location = new Point(33, 92);
            dropPlayerBox.Name = "dropPlayerBox";
            dropPlayerBox.Size = new Size(57, 19);
            dropPlayerBox.TabIndex = 7;
            dropPlayerBox.Text = "Drop?";
            dropPlayerBox.TextAlign = ContentAlignment.BottomCenter;
            dropPlayerBox.UseVisualStyleBackColor = true;
            // 
            // MultiplayerGamePairingControlSinglePlayerPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(dropPlayerBox);
            Controls.Add(numericUpDown);
            Controls.Add(playerLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MultiplayerGamePairingControlSinglePlayerPanel";
            Size = new Size(131, 112);
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label playerLabel;
        private NumericUpDown numericUpDown;
        private CheckBox dropPlayerBox;
    }
}
