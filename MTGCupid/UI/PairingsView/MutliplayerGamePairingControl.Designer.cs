namespace MTGCupid.UI
{
    partial class MultiplayerGamePairingControl
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
            submitButton = new Button();
            tableLayoutPanel = new TableLayoutPanel();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Dock = DockStyle.Right;
            submitButton.Location = new Point(398, 0);
            submitButton.Margin = new Padding(3, 4, 3, 4);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(171, 117);
            submitButton.TabIndex = 7;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(569, 117);
            tableLayoutPanel.TabIndex = 8;
            // 
            // MultiplayerGamePairingControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(submitButton);
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(2285, 119);
            MinimumSize = new Size(571, 119);
            Name = "MultiplayerGamePairingControl";
            Size = new Size(569, 117);
            ResumeLayout(false);
        }

        #endregion

        private Button submitButton;
        private TableLayoutPanel tableLayoutPanel;
    }
}
