namespace MTGCupid.UI
{
    partial class PairingsPreviewByeControl
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
            button = new Button();
            SuspendLayout();
            // 
            // button
            // 
            button.BackColor = SystemColors.ControlDark;
            button.Dock = DockStyle.Fill;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(0, 0);
            button.Name = "button";
            button.Size = new Size(200, 30);
            button.TabIndex = 0;
            button.Text = "button";
            button.UseVisualStyleBackColor = false;
            button.Click += button_Click;
            // 
            // PairingsPreviewByeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button);
            MaximumSize = new Size(2000, 30);
            MinimumSize = new Size(100, 30);
            Name = "PairingsPreviewByeControl";
            Size = new Size(200, 30);
            ResumeLayout(false);
        }

        #endregion

        private Button button;
    }
}
