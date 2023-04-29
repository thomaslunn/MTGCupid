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
        public StandingsViewControl()
        {
            InitializeComponent();
        }

        public void RegisterStandingsList(List<Player> standings)
        {
            playerBindingSource.DataSource = standings;
        }
    }
}
