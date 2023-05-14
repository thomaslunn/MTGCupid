namespace MTGCupid.UI
{
    partial class PodsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PodsForm));
            okButton = new Button();
            cancelButton = new Button();
            dataGridView = new DataGridView();
            PodNumber = new DataGridViewTextBoxColumn();
            podsDescriptorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom;
            okButton.Location = new Point(245, 397);
            okButton.Name = "okButton";
            okButton.Size = new Size(116, 41);
            okButton.TabIndex = 0;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom;
            cancelButton.Location = new Point(367, 397);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(116, 41);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { PodNumber });
            dataGridView.Location = new Point(12, 32);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(703, 359);
            dataGridView.TabIndex = 2;
            // 
            // PodNumber
            // 
            PodNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PodNumber.HeaderText = "Pod";
            PodNumber.MinimumWidth = 6;
            PodNumber.Name = "PodNumber";
            PodNumber.ReadOnly = true;
            PodNumber.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // podsDescriptorLabel
            // 
            podsDescriptorLabel.AutoSize = true;
            podsDescriptorLabel.Location = new Point(12, 9);
            podsDescriptorLabel.Name = "podsDescriptorLabel";
            podsDescriptorLabel.Size = new Size(359, 20);
            podsDescriptorLabel.TabIndex = 3;
            podsDescriptorLabel.Text = "Sit players for the draft according to the below pods.";
            // 
            // PodsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 450);
            Controls.Add(podsDescriptorLabel);
            Controls.Add(dataGridView);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PodsForm";
            Text = "Pods";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn PodNumber;
        private Label podsDescriptorLabel;
    }
}