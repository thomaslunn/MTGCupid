using Microsoft.VisualBasic.ApplicationServices;

namespace MTGCupid.UI
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Setup custom icon
            Icon = Properties.Resources.MTGCupidIcon;
        }
    }
}