namespace MTGCupid.UI
{
    partial class StandingsViewControl
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
            components = new System.ComponentModel.Container();
            dataGridView = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pointsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            matchWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opponentMatchWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gameWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opponentGameWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            playerBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, pointsDataGridViewTextBoxColumn, matchWinPercentageDataGridViewTextBoxColumn, opponentMatchWinPercentageDataGridViewTextBoxColumn, gameWinPercentageDataGridViewTextBoxColumn, opponentGameWinPercentageDataGridViewTextBoxColumn });
            dataGridView.DataSource = playerBindingSource;
            dataGridView.Location = new Point(3, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(810, 445);
            dataGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            pointsDataGridViewTextBoxColumn.HeaderText = "Points";
            pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            pointsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // matchWinPercentageDataGridViewTextBoxColumn
            // 
            matchWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "MatchWinPercentage";
            matchWinPercentageDataGridViewTextBoxColumn.HeaderText = "MW%";
            matchWinPercentageDataGridViewTextBoxColumn.Name = "matchWinPercentageDataGridViewTextBoxColumn";
            matchWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // opponentMatchWinPercentageDataGridViewTextBoxColumn
            // 
            opponentMatchWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "OpponentMatchWinPercentage";
            opponentMatchWinPercentageDataGridViewTextBoxColumn.HeaderText = "OMW%";
            opponentMatchWinPercentageDataGridViewTextBoxColumn.Name = "opponentMatchWinPercentageDataGridViewTextBoxColumn";
            opponentMatchWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gameWinPercentageDataGridViewTextBoxColumn
            // 
            gameWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "GameWinPercentage";
            gameWinPercentageDataGridViewTextBoxColumn.HeaderText = "GW%";
            gameWinPercentageDataGridViewTextBoxColumn.Name = "gameWinPercentageDataGridViewTextBoxColumn";
            gameWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // opponentGameWinPercentageDataGridViewTextBoxColumn
            // 
            opponentGameWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "OpponentGameWinPercentage";
            opponentGameWinPercentageDataGridViewTextBoxColumn.HeaderText = "OGW%";
            opponentGameWinPercentageDataGridViewTextBoxColumn.Name = "opponentGameWinPercentageDataGridViewTextBoxColumn";
            opponentGameWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerBindingSource
            // 
            playerBindingSource.AllowNew = false;
            playerBindingSource.DataSource = typeof(Player);
            // 
            // StandingsViewControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(dataGridView);
            Name = "StandingsViewControl";
            Size = new Size(816, 451);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn matchWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentMatchWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gameWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentGameWinPercentageDataGridViewTextBoxColumn;
        private BindingSource playerBindingSource;
    }
}
