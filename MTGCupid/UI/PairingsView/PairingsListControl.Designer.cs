namespace MTGCupid.UI
{
    partial class PairingsListControl
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
            flowLayoutPanel = new FlowLayoutPanel();
            confirmButton = new Button();
            submitAllButton = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = SystemColors.ControlLight;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(686, 392);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.Layout += flowLayoutPanel_Layout;
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmButton.Enabled = false;
            confirmButton.Location = new Point(528, 398);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(155, 34);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "Confirm Match Results";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // submitAllButton
            // 
            submitAllButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            submitAllButton.Location = new Point(367, 398);
            submitAllButton.Name = "submitAllButton";
            submitAllButton.Size = new Size(155, 34);
            submitAllButton.TabIndex = 1;
            submitAllButton.Text = "Submit all matches";
            submitAllButton.UseVisualStyleBackColor = true;
            submitAllButton.Click += submitAllButton_Click;
            // 
            // PairingsListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(submitAllButton);
            Controls.Add(confirmButton);
            Controls.Add(flowLayoutPanel);
            Name = "PairingsListControl";
            Size = new Size(686, 435);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Button confirmButton;
        private Button submitAllButton;
    }
}
