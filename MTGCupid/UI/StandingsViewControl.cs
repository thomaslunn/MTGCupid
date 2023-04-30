using System;
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

        public StandingsViewControl()
        {
            InitializeComponent();
        }

        public void UpdateStandings(List<PlayerStandings> standings)
        {
            playerStandingsBindingSource.DataSource = standings;
            this.standings = standings;
            playerHistoryViewerControl.Clear();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) // header row
                return;

            Player selectedPlayer = standings[e.RowIndex].Player;
            playerHistoryViewerControl.ViewPlayerHistory(selectedPlayer);
        }
    }
}
