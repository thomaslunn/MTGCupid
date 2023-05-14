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
    public partial class PodsForm : Form
    {
        public PodsForm(List<Player[]> pods)
        {
            InitializeComponent();

            // Add a number of columns equal to the max number of players in a pod
            int maxPodSize = pods.Max(pod => pod.Length);
            for (int i = 0; i < maxPodSize; i++)
            {
                var column = new DataGridViewTextBoxColumn();
                column.HeaderText = $"Player {i + 1}";
                column.Name = $"player{i + 1}Column";
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Columns.Add(column);
            }

            // Populate the rows with the players in each pod
            for (int i = 0; i < pods.Count; i++)
            {
                var pod = pods[i];
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = $"Pod {i + 1}" });
                foreach (var player in pod)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = player.Name });
                }
                dataGridView.Rows.Add(row);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
