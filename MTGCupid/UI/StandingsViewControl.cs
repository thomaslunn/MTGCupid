﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGCupid.UI
{
    public partial class StandingsViewControl : UserControl
    {
        private List<PlayerStandings> standings = new List<PlayerStandings>();
        private bool updatingTableContents = false;

        public StandingsViewControl()
        {
            InitializeComponent();
        }

        public void UpdateStandings(List<PlayerStandings> standings)
        {
            updatingTableContents = true; // Ignore selection changes while we update the table
            dataGridView.SuspendLayout();

            playerStandingsBindingSource.DataSource = standings;
            this.standings = standings;
            playerHistoryViewerControl.Clear();

            dataGridView.ResumeLayout();
            updatingTableContents = false;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1) // header row
            //    return;

            //Player selectedPlayer = standings[e.RowIndex].Player;
            //playerHistoryViewerControl.ViewPlayerHistory(selectedPlayer);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (updatingTableContents || dataGridView.SelectedRows.Count == 0)
                return;

            int selctedRowIndex = dataGridView.SelectedRows[0].Index;
            if (selctedRowIndex == -1) // header row
                return;

            Player selectedPlayer = standings[selctedRowIndex].Player;
            playerHistoryViewerControl.ViewPlayerHistory(selectedPlayer);
        }
    }
}
