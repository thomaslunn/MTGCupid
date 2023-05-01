namespace MTGCupid.UI
{
    partial class PairingsPreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PairingsPreviewForm));
            splitContainer = new SplitContainer();
            byesFlowLayout = new FlowLayoutPanel();
            byesLabel = new Label();
            pairingsFlowLayout = new FlowLayoutPanel();
            pairingsLabel = new Label();
            confirmButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.BorderStyle = BorderStyle.FixedSingle;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(byesFlowLayout);
            splitContainer.Panel1.Controls.Add(byesLabel);
            splitContainer.Panel1.Padding = new Padding(2);
            splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(pairingsFlowLayout);
            splitContainer.Panel2.Controls.Add(pairingsLabel);
            splitContainer.Panel2.Padding = new Padding(2);
            splitContainer.Panel2MinSize = 200;
            splitContainer.Size = new Size(457, 244);
            splitContainer.SplitterDistance = 150;
            splitContainer.TabIndex = 0;
            // 
            // byesFlowLayout
            // 
            byesFlowLayout.AutoScroll = true;
            byesFlowLayout.Dock = DockStyle.Fill;
            byesFlowLayout.Location = new Point(2, 17);
            byesFlowLayout.Name = "byesFlowLayout";
            byesFlowLayout.Size = new Size(144, 223);
            byesFlowLayout.TabIndex = 1;
            byesFlowLayout.Layout += OnFlowLayoutChange;
            // 
            // byesLabel
            // 
            byesLabel.Dock = DockStyle.Top;
            byesLabel.Location = new Point(2, 2);
            byesLabel.Name = "byesLabel";
            byesLabel.Size = new Size(144, 15);
            byesLabel.TabIndex = 0;
            byesLabel.Text = "Byes";
            // 
            // pairingsFlowLayout
            // 
            pairingsFlowLayout.AutoScroll = true;
            pairingsFlowLayout.Dock = DockStyle.Fill;
            pairingsFlowLayout.Location = new Point(2, 17);
            pairingsFlowLayout.Name = "pairingsFlowLayout";
            pairingsFlowLayout.Size = new Size(297, 223);
            pairingsFlowLayout.TabIndex = 1;
            pairingsFlowLayout.Layout += OnFlowLayoutChange;
            // 
            // pairingsLabel
            // 
            pairingsLabel.Dock = DockStyle.Top;
            pairingsLabel.Location = new Point(2, 2);
            pairingsLabel.Name = "pairingsLabel";
            pairingsLabel.Size = new Size(297, 15);
            pairingsLabel.TabIndex = 0;
            pairingsLabel.Text = "Suggested pairings";
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmButton.Location = new Point(327, 247);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(116, 38);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "Confirm pairings";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += confirmButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(205, 247);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(116, 38);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // PairingsPreviewForm
            // 
            AcceptButton = confirmButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(455, 289);
            Controls.Add(cancelButton);
            Controls.Add(confirmButton);
            Controls.Add(splitContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PairingsPreviewForm";
            Text = "Configure Pairings - MTG Cupid";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private FlowLayoutPanel byesFlowLayout;
        private Label byesLabel;
        private FlowLayoutPanel pairingsFlowLayout;
        private Label pairingsLabel;
        private Button confirmButton;
        private Button cancelButton;
    }
}