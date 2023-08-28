namespace MTGCupid.UI
{
    partial class TwoPlayerMatchPairingControl
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
            tableLayoutPanel = new TableLayoutPanel();
            leftPanel = new Panel();
            centerPanel = new Panel();
            rightPanel = new Panel();
            tableLayoutPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            centerPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // player1Label
            // 
            player1Label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            player1Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            player1Label.Location = new Point(0, 19);
            player1Label.Name = "player1Label";
            player1Label.Size = new Size(200, 52);
            player1Label.TabIndex = 0;
            player1Label.Text = "Player1";
            // 
            // player1ScoreButton
            // 
            player1ScoreButton.Anchor = AnchorStyles.Top;
            player1ScoreButton.BackColor = Color.FromArgb(255, 255, 128);
            player1ScoreButton.FlatStyle = FlatStyle.Flat;
            player1ScoreButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            player1ScoreButton.Location = new Point(0, 5);
            player1ScoreButton.Margin = new Padding(3, 4, 3, 4);
            player1ScoreButton.Name = "player1ScoreButton";
            player1ScoreButton.Size = new Size(57, 67);
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
            scoreDividerLabel.Location = new Point(69, 19);
            scoreDividerLabel.Name = "scoreDividerLabel";
            scoreDividerLabel.Size = new Size(44, 37);
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
            player2ScoreButton.Location = new Point(114, 5);
            player2ScoreButton.Margin = new Padding(3, 4, 3, 4);
            player2ScoreButton.Name = "player2ScoreButton";
            player2ScoreButton.Size = new Size(57, 67);
            player2ScoreButton.TabIndex = 3;
            player2ScoreButton.Text = "0";
            player2ScoreButton.UseVisualStyleBackColor = false;
            player2ScoreButton.Click += player2ScoreButton_Click;
            // 
            // player2Label
            // 
            player2Label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            player2Label.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            player2Label.Location = new Point(0, 19);
            player2Label.Name = "player2Label";
            player2Label.Size = new Size(200, 52);
            player2Label.TabIndex = 4;
            player2Label.Text = "Player2";
            player2Label.TextAlign = ContentAlignment.TopRight;
            // 
            // dropPlayer1Box
            // 
            dropPlayer1Box.AutoSize = true;
            dropPlayer1Box.Location = new Point(5, 76);
            dropPlayer1Box.Margin = new Padding(3, 4, 3, 4);
            dropPlayer1Box.Name = "dropPlayer1Box";
            dropPlayer1Box.Size = new Size(72, 24);
            dropPlayer1Box.TabIndex = 5;
            dropPlayer1Box.Text = "Drop?";
            dropPlayer1Box.UseVisualStyleBackColor = true;
            // 
            // dropPlayer2Box
            // 
            dropPlayer2Box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dropPlayer2Box.AutoSize = true;
            dropPlayer2Box.Location = new Point(123, 76);
            dropPlayer2Box.Margin = new Padding(3, 4, 3, 4);
            dropPlayer2Box.Name = "dropPlayer2Box";
            dropPlayer2Box.Size = new Size(72, 24);
            dropPlayer2Box.TabIndex = 6;
            dropPlayer2Box.Text = "Drop?";
            dropPlayer2Box.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            submitButton.Anchor = AnchorStyles.Top;
            submitButton.Location = new Point(0, 76);
            submitButton.Margin = new Padding(3, 4, 3, 4);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(171, 39);
            submitButton.TabIndex = 7;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 171F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(leftPanel, 0, 0);
            tableLayoutPanel.Controls.Add(centerPanel, 1, 0);
            tableLayoutPanel.Controls.Add(rightPanel, 2, 0);
            tableLayoutPanel.Location = new Point(-1, -1);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(571, 120);
            tableLayoutPanel.TabIndex = 8;
            // 
            // leftPanel
            // 
            leftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            leftPanel.Controls.Add(player1Label);
            leftPanel.Controls.Add(dropPlayer1Box);
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(200, 120);
            leftPanel.TabIndex = 0;
            // 
            // centerPanel
            // 
            centerPanel.Controls.Add(player2ScoreButton);
            centerPanel.Controls.Add(submitButton);
            centerPanel.Controls.Add(player1ScoreButton);
            centerPanel.Controls.Add(scoreDividerLabel);
            centerPanel.Location = new Point(200, 0);
            centerPanel.Margin = new Padding(0);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(171, 120);
            centerPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rightPanel.Controls.Add(player2Label);
            rightPanel.Controls.Add(dropPlayer2Box);
            rightPanel.Location = new Point(371, 0);
            rightPanel.Margin = new Padding(0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(200, 120);
            rightPanel.TabIndex = 2;
            // 
            // TwoPlayerMatchPairingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(2285, 119);
            MinimumSize = new Size(571, 119);
            Name = "TwoPlayerMatchPairingControl";
            Size = new Size(569, 117);
            tableLayoutPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            centerPanel.ResumeLayout(false);
            centerPanel.PerformLayout();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel;
        private Panel leftPanel;
        private Panel centerPanel;
        private Panel rightPanel;
    }
}
