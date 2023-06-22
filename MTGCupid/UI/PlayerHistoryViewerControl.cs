using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTGCupid.Matches;

namespace MTGCupid.UI
{
    public partial class PlayerHistoryViewerControl : UserControl
    {
        public PlayerHistoryViewerControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            dataGridView.Rows.Clear();
        }

        public void ViewPlayerHistory(Player player)
        {
            dataGridView.SuspendLayout();

            dataGridView.Rows.Clear();

            foreach (var match in player.CompletedMatches)
            {
                string score;
                string opponentName;
                if (match is Bye)
                {
                    score = "2 - 0";
                    opponentName = "BYE";
                }
                else if (match is Match twoPlayerMatch)
                {
                    score = string.Format("{0} - {1}", twoPlayerMatch.WinsOf(player), twoPlayerMatch.WinsOf(twoPlayerMatch.OpponentOf(player)));
                    opponentName = twoPlayerMatch.OpponentOf(player).Name;
                }
                else if (match is MultiplayerGame multiplayerMatch)
                {
                    var otherPlayers = multiplayerMatch.Players.Where(p => p != player);
                    score = string.Format("{0} - {1}", multiplayerMatch.MatchPointsOf(player), string.Join(", ", otherPlayers.Select(p => match.MatchPointsOf(p))));
                    opponentName = string.Join(", ", otherPlayers.Select(p => p.Name));
                }
                else 
                    throw new InvalidOperationException("Unknown match type: " + match.GetType().ToString());

                dataGridView.Rows.Add(player.Name, score, opponentName);
            }

            dataGridView.ResumeLayout();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Disable selection
            dataGridView.ClearSelection();
        }
    }
}
