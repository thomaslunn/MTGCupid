namespace MTGCupid.UI
{
    partial class PlayerHistoryViewerControl
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
            dataGridView = new DataGridView();
            ThisPlayerNameColumn = new DataGridViewTextBoxColumn();
            ScoreColumn = new DataGridViewTextBoxColumn();
            ThatPlayerNameColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ThisPlayerNameColumn, ScoreColumn, ThatPlayerNameColumn });
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.Size = new Size(239, 150);
            dataGridView.TabIndex = 0;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // ThisPlayerNameColumn
            // 
            ThisPlayerNameColumn.HeaderText = "Player";
            ThisPlayerNameColumn.Name = "ThisPlayerNameColumn";
            ThisPlayerNameColumn.ReadOnly = true;
            // 
            // ScoreColumn
            // 
            ScoreColumn.HeaderText = "Score";
            ScoreColumn.Name = "ScoreColumn";
            ScoreColumn.ReadOnly = true;
            // 
            // ThatPlayerNameColumn
            // 
            ThatPlayerNameColumn.HeaderText = "Opponent";
            ThatPlayerNameColumn.Name = "ThatPlayerNameColumn";
            ThatPlayerNameColumn.ReadOnly = true;
            // 
            // PlayerHistoryViewerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Name = "PlayerHistoryViewerControl";
            Size = new Size(239, 150);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ThisPlayerNameColumn;
        private DataGridViewTextBoxColumn ScoreColumn;
        private DataGridViewTextBoxColumn ThatPlayerNameColumn;
    }
}
