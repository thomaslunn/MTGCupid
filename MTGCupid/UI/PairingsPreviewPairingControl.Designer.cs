namespace MTGCupid.UI
{
    partial class PairingsPreviewPairingControl
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
            pairingButton = new Button();
            SuspendLayout();
            // 
            // pairingButton
            // 
            pairingButton.Dock = DockStyle.Fill;
            pairingButton.Location = new Point(0, 0);
            pairingButton.Margin = new Padding(0);
            pairingButton.Name = "pairingButton";
            pairingButton.Size = new Size(200, 30);
            pairingButton.TabIndex = 0;
            pairingButton.Text = "button";
            pairingButton.UseVisualStyleBackColor = true;
            pairingButton.Click += pairingButton_Click;
            // 
            // PairingsPreviewPairingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pairingButton);
            MaximumSize = new Size(2000, 30);
            MinimumSize = new Size(100, 30);
            Name = "PairingsPreviewPairingControl";
            Size = new Size(200, 30);
            ResumeLayout(false);
        }

        #endregion

        private Button pairingButton;
    }
}
