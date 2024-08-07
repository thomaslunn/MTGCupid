﻿namespace MTGCupid.UI
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
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gameWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opponentGameWinPercentageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            HasDropped = new DataGridViewCheckBoxColumn();
            playerStandingsBindingSource = new BindingSource(components);
            bottomPanel = new Panel();
            bottomSplitContainer = new SplitContainer();
            playerHistoryViewerControl = new PlayerHistoryViewerControl();
            currentRoundLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerStandingsBindingSource).BeginInit();
            bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bottomSplitContainer).BeginInit();
            bottomSplitContainer.Panel1.SuspendLayout();
            bottomSplitContainer.Panel2.SuspendLayout();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Position, nameDataGridViewTextBoxColumn, pointsDataGridViewTextBoxColumn, opponentMatchWinPercentageDataGridViewTextBoxColumn, opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn, gameWinPercentageDataGridViewTextBoxColumn, opponentGameWinPercentageDataGridViewTextBoxColumn, HasDropped });
            dataGridView.DataSource = playerStandingsBindingSource;
            dataGridView.Location = new Point(0, 0);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(810, 265);
            dataGridView.TabIndex = 0;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // Position
            // 
            Position.DataPropertyName = "Seed";
            Position.HeaderText = "Position";
            Position.MinimumWidth = 6;
            Position.Name = "Position";
            Position.ReadOnly = true;
            Position.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            pointsDataGridViewTextBoxColumn.HeaderText = "Points";
            pointsDataGridViewTextBoxColumn.MinimumWidth = 6;
            pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            pointsDataGridViewTextBoxColumn.ReadOnly = true;
            pointsDataGridViewTextBoxColumn.Width = 125;
            // 
            // opponentMatchWinPercentageDataGridViewTextBoxColumn
            // 
            opponentMatchWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "OpponentMatchWinPercentage";
            opponentMatchWinPercentageDataGridViewTextBoxColumn.HeaderText = "OMW%";
            opponentMatchWinPercentageDataGridViewTextBoxColumn.MinimumWidth = 6;
            opponentMatchWinPercentageDataGridViewTextBoxColumn.Name = "opponentMatchWinPercentageDataGridViewTextBoxColumn";
            opponentMatchWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            opponentMatchWinPercentageDataGridViewTextBoxColumn.Width = 125;
            // 
            // opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn
            // 
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "OpponentOpponentMatchWinPercentage";
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn.HeaderText = "OOMW%";
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn.MinimumWidth = 6;
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn.Name = "opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn";
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn.Width = 125;
            // 
            // gameWinPercentageDataGridViewTextBoxColumn
            // 
            gameWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "GameWinPercentage";
            gameWinPercentageDataGridViewTextBoxColumn.HeaderText = "GW%";
            gameWinPercentageDataGridViewTextBoxColumn.MinimumWidth = 6;
            gameWinPercentageDataGridViewTextBoxColumn.Name = "gameWinPercentageDataGridViewTextBoxColumn";
            gameWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            gameWinPercentageDataGridViewTextBoxColumn.Width = 125;
            // 
            // opponentGameWinPercentageDataGridViewTextBoxColumn
            // 
            opponentGameWinPercentageDataGridViewTextBoxColumn.DataPropertyName = "OpponentGameWinPercentage";
            opponentGameWinPercentageDataGridViewTextBoxColumn.HeaderText = "OGW%";
            opponentGameWinPercentageDataGridViewTextBoxColumn.MinimumWidth = 6;
            opponentGameWinPercentageDataGridViewTextBoxColumn.Name = "opponentGameWinPercentageDataGridViewTextBoxColumn";
            opponentGameWinPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            opponentGameWinPercentageDataGridViewTextBoxColumn.Width = 125;
            // 
            // HasDropped
            // 
            HasDropped.DataPropertyName = "HasDropped";
            HasDropped.HeaderText = "Dropped?";
            HasDropped.MinimumWidth = 6;
            HasDropped.Name = "HasDropped";
            HasDropped.ReadOnly = true;
            HasDropped.Width = 125;
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
            bottomSplitContainer.Panel1.Padding = new Padding(2);
            bottomSplitContainer.Panel1MinSize = 200;
            // 
            // bottomSplitContainer.Panel2
            // 
            bottomSplitContainer.Panel2.Controls.Add(currentRoundLabel);
            bottomSplitContainer.Panel2.Padding = new Padding(2);
            bottomSplitContainer.Size = new Size(810, 174);
            bottomSplitContainer.SplitterDistance = 270;
            bottomSplitContainer.SplitterWidth = 10;
            bottomSplitContainer.TabIndex = 0;
            // 
            // playerHistoryViewerControl
            // 
            playerHistoryViewerControl.Dock = DockStyle.Fill;
            playerHistoryViewerControl.Location = new Point(2, 2);
            playerHistoryViewerControl.Margin = new Padding(3, 4, 3, 4);
            playerHistoryViewerControl.Name = "playerHistoryViewerControl";
            playerHistoryViewerControl.Size = new Size(266, 170);
            playerHistoryViewerControl.TabIndex = 0;
            // 
            // currentRoundLabel
            // 
            currentRoundLabel.AutoSize = true;
            currentRoundLabel.Location = new Point(5, 2);
            currentRoundLabel.Name = "currentRoundLabel";
            currentRoundLabel.Size = new Size(0, 20);
            currentRoundLabel.TabIndex = 0;
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
            bottomSplitContainer.Panel2.ResumeLayout(false);
            bottomSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bottomSplitContainer).EndInit();
            bottomSplitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private BindingSource playerStandingsBindingSource;
        private Panel bottomPanel;
        private SplitContainer bottomSplitContainer;
        private PlayerHistoryViewerControl playerHistoryViewerControl;
        private DataGridViewTextBoxColumn Position;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentMatchWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentOpponentMatchWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gameWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opponentGameWinPercentageDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn HasDropped;
        private Label currentRoundLabel;
    }
}
