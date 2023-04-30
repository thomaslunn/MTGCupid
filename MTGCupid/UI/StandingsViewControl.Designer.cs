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
            Position = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pointsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opponentMatchWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gameWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opponentGameWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            playerStandingsBindingSource = new BindingSource(components);
            bottomPanel = new Panel();
            bottomSplitContainer = new SplitContainer();
            playerHistoryViewerControl = new PlayerHistoryViewerControl();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerStandingsBindingSource).BeginInit();
            bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bottomSplitContainer).BeginInit();
            bottomSplitContainer.Panel1.SuspendLayout();
            bottomSplitContainer.SuspendLayout();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Position, nameDataGridViewTextBoxColumn, pointsDataGridViewTextBoxColumn, opponentMatchWinPercentageDataGridViewTextBoxColumn, gameWinPercentageDataGridViewTextBoxColumn, opponentGameWinPercentageDataGridViewTextBoxColumn });
            dataGridView.DataSource = playerStandingsBindingSource;
            dataGridView.Location = new Point(0, 0);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(810, 265);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // Position
            // 
            Position.DataPropertyName = "Position";
            Position.HeaderText = "Position";
            Position.Name = "Position";
            Position.ReadOnly = true;
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
            // playerStandingsBindingSource
            // 
            playerStandingsBindingSource.DataSource = typeof(PlayerStandings);
            // 
            // bottomPanel
            // 
            bottomPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bottomPanel.Controls.Add(bottomSplitContainer);
            bottomPanel.Location = new Point(3, 274);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(810, 174);
            bottomPanel.TabIndex = 1;
            // 
            // bottomSplitContainer
            // 
            bottomSplitContainer.Dock = DockStyle.Fill;
            bottomSplitContainer.Location = new Point(0, 0);
            bottomSplitContainer.Name = "bottomSplitContainer";
            // 
            // bottomSplitContainer.Panel1
            // 
            bottomSplitContainer.Panel1.Controls.Add(playerHistoryViewerControl);
            bottomSplitContainer.Panel1MinSize = 200;
            bottomSplitContainer.Size = new Size(810, 174);
            bottomSplitContainer.SplitterDistance = 270;
            bottomSplitContainer.TabIndex = 0;
            // 
            // playerHistoryViewerControl
            // 
            playerHistoryViewerControl.Dock = DockStyle.Fill;
            playerHistoryViewerControl.Location = new Point(0, 0);
            playerHistoryViewerControl.Name = "playerHistoryViewerControl";
            playerHistoryViewerControl.Size = new Size(270, 174);
            playerHistoryViewerControl.TabIndex = 0;
            // 
            // StandingsViewControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(bottomPanel);
            Controls.Add(dataGridView);
            Name = "StandingsViewControl";
            Size = new Size(816, 451);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerStandingsBindingSource).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bottomSplitContainer).EndInit();
            bottomSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn Position;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentMatchWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gameWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentGameWinPercentageDataGridViewTextBoxColumn;
        private BindingSource playerStandingsBindingSource;
        private Panel bottomPanel;
        private SplitContainer bottomSplitContainer;
        private PlayerHistoryViewerControl playerHistoryViewerControl;
    }
}
