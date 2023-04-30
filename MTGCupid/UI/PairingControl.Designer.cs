namespace MTGCupid.UI
{
    partial class PairingControl
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
            player1Label = new Label();
            player1ScoreButton = new Button();
            scoreDividerLabel = new Label();
            player2ScoreButton = new Button();
            player2Label = new Label();
            dropPlayer1Box = new CheckBox();
            dropPlayer2Box = new CheckBox();
            submitButton = new Button();
            SuspendLayout();
            // 
            // player1Label
            // 
            player1Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            player1Label.Location = new Point(20, 5);
            player1Label.Name = "player1Label";
            player1Label.Size = new Size(149, 50);
            player1Label.TabIndex = 0;
            player1Label.Text = "Player1";
            player1Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // player1ScoreButton
            // 
            player1ScoreButton.Anchor = AnchorStyles.Top;
            player1ScoreButton.BackColor = Color.FromArgb(255, 255, 128);
            player1ScoreButton.FlatStyle = FlatStyle.Flat;
            player1ScoreButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            player1ScoreButton.Location = new Point(174, 5);
            player1ScoreButton.Name = "player1ScoreButton";
            player1ScoreButton.Size = new Size(50, 50);
            player1ScoreButton.TabIndex = 1;
            player1ScoreButton.Text = "0";
            player1ScoreButton.UseVisualStyleBackColor = false;
            player1ScoreButton.Click += player1ScoreButton_Click;
            // 
            // scoreDividerLabel
            // 
            scoreDividerLabel.Anchor = AnchorStyles.Top;
            scoreDividerLabel.AutoSize = true;
            scoreDividerLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            scoreDividerLabel.Location = new Point(232, 15);
            scoreDividerLabel.Name = "scoreDividerLabel";
            scoreDividerLabel.Size = new Size(34, 30);
            scoreDividerLabel.TabIndex = 2;
            scoreDividerLabel.Text = "—";
            scoreDividerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // player2ScoreButton
            // 
            player2ScoreButton.Anchor = AnchorStyles.Top;
            player2ScoreButton.BackColor = Color.FromArgb(255, 255, 128);
            player2ScoreButton.FlatStyle = FlatStyle.Flat;
            player2ScoreButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            player2ScoreButton.Location = new Point(274, 5);
            player2ScoreButton.Name = "player2ScoreButton";
            player2ScoreButton.Size = new Size(50, 50);
            player2ScoreButton.TabIndex = 3;
            player2ScoreButton.Text = "0";
            player2ScoreButton.UseVisualStyleBackColor = false;
            player2ScoreButton.Click += player2ScoreButton_Click;
            // 
            // player2Label
            // 
            player2Label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            player2Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            player2Label.Location = new Point(329, 5);
            player2Label.Name = "player2Label";
            player2Label.Size = new Size(149, 50);
            player2Label.TabIndex = 4;
            player2Label.Text = "Player2";
            player2Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dropPlayer1Box
            // 
            dropPlayer1Box.AutoSize = true;
            dropPlayer1Box.Location = new Point(20, 58);
            dropPlayer1Box.Name = "dropPlayer1Box";
            dropPlayer1Box.Size = new Size(57, 19);
            dropPlayer1Box.TabIndex = 5;
            dropPlayer1Box.Text = "Drop?";
            dropPlayer1Box.UseVisualStyleBackColor = true;
            // 
            // dropPlayer2Box
            // 
            dropPlayer2Box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dropPlayer2Box.AutoSize = true;
            dropPlayer2Box.Location = new Point(421, 58);
            dropPlayer2Box.Name = "dropPlayer2Box";
            dropPlayer2Box.Size = new Size(57, 19);
            dropPlayer2Box.TabIndex = 6;
            dropPlayer2Box.Text = "Drop?";
            dropPlayer2Box.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            submitButton.Anchor = AnchorStyles.Top;
            submitButton.Location = new Point(174, 58);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(150, 29);
            submitButton.TabIndex = 7;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // PairingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(submitButton);
            Controls.Add(dropPlayer2Box);
            Controls.Add(dropPlayer1Box);
            Controls.Add(player2Label);
            Controls.Add(player2ScoreButton);
            Controls.Add(scoreDividerLabel);
            Controls.Add(player1ScoreButton);
            Controls.Add(player1Label);
            MaximumSize = new Size(2000, 90);
            MinimumSize = new Size(500, 90);
            Name = "PairingControl";
            Size = new Size(498, 88);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label player1Label;
        private Button player1ScoreButton;
        private Label scoreDividerLabel;
        private Button player2ScoreButton;
        private Label player2Label;
        private CheckBox dropPlayer1Box;
        private CheckBox dropPlayer2Box;
        private Button submitButton;
    }
}
