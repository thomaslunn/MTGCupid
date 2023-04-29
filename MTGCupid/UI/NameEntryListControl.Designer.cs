﻿namespace MTGCupid.UI
{
    partial class NameEntryListControl
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
            addNameButton = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(0, 0);
            flowLayoutPanel.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(581, 441);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.Layout += flowLayoutPanel_Layout;
            // 
            // addNameButton
            // 
            addNameButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addNameButton.BackColor = Color.Lime;
            addNameButton.FlatStyle = FlatStyle.Flat;
            addNameButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addNameButton.Location = new Point(555, 446);
            addNameButton.Name = "addNameButton";
            addNameButton.Size = new Size(23, 23);
            addNameButton.TabIndex = 1;
            addNameButton.Text = "+";
            addNameButton.UseVisualStyleBackColor = false;
            addNameButton.Click += addNameButton_Click;
            // 
            // NameEntryListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(addNameButton);
            Controls.Add(flowLayoutPanel);
            Name = "NameEntryListControl";
            Size = new Size(581, 472);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Button addNameButton;
    }
}
