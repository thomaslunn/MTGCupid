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
    public partial class TournamentInitialiserControl : UserControl
    {
        public TournamentInitialiserControl()
        {
            InitializeComponent();
        }

        private void nameList_RegisteredPlayersCountChanged(object sender, RegisteredPlayersCountChangedEventArgs e)
        {
            playerCountLabel.Text = string.Format("Players: {0}", e.PlayerCount);
        }
    }
}
