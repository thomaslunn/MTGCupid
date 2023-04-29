using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGCupid.UI
{
    internal partial class NameEntryListControl : UserControl
    {
        private List<PlayerNameEntryContol> nameEntries = new List<PlayerNameEntryContol>();

        [Browsable(true)]
        [Category("Data")]
        [Description("Invoked when the number of registered names changes")]
        public event EventHandler<RegisteredPlayersCountChangedEventArgs>? RegisteredPlayersCountChanged;

        public int RegisteredPlayersCount { get; private set; } = 0;

        public List<string> GetPlayerNames()
        {
            return nameEntries.Select(x => x.PlayerName).Where(x => x != "").ToList();
        }

        public NameEntryListControl()
        {
            InitializeComponent();

            // Add an initial name entry
            AddNewNameEntryAtBottom();
            flowLayoutPanel.Invalidate();
        }

        private PlayerNameEntryContol AddNewNameEntry(int index)
        {
            flowLayoutPanel.SuspendLayout();

            PlayerNameEntryContol nameEntry = new PlayerNameEntryContol();
            nameEntries.Insert(index, nameEntry);
            flowLayoutPanel.Controls.Add(nameEntry);
            flowLayoutPanel.Controls.SetChildIndex(nameEntry, index);

            nameEntry.EnterKeyPressed += EnterKeyPressedInNameEntry;
            nameEntry.UpArrowPressed += UpArrowPressedInNameEntry;
            nameEntry.DownArrowPressed += DownArrowPressedInNameEntry;
            nameEntry.DeleteRequested += NameEntryDeleteRequested;
            nameEntry.TextEmptyStateChanged += NameFieldEmptyStateChanged;

            flowLayoutPanel.ResumeLayout();


            return nameEntry;
        }

        private PlayerNameEntryContol AddNewNameEntryAtBottom()
        {
            return AddNewNameEntry(nameEntries.Count);
        }

        private void flowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            flowLayoutPanel.SuspendLayout();

            flowLayoutPanel.HorizontalScroll.Visible = false;

            // Resize all the name entries to fit the width of the flow layout panel
            foreach (var entry in nameEntries)
            {
                entry.Width = flowLayoutPanel.Width - SystemInformation.VerticalScrollBarWidth;
            }
            flowLayoutPanel.ResumeLayout();
        }

        private void EnterKeyPressedInNameEntry(object? sender, EventArgs e)
        {
            if (sender == null)
                return;

            PlayerNameEntryContol control = (PlayerNameEntryContol)sender;
            int controlIndex = nameEntries.IndexOf(control);

            if (controlIndex == nameEntries.Count - 1 // Last name entry
                || nameEntries[controlIndex + 1].PlayerName != "") // Next name entry is not empty
            {
                // Add a new name entry below this one
                AddNewNameEntry(controlIndex + 1);
            }

            // Focus the next name entry
            nameEntries[controlIndex + 1].SelectForEditing();
        }

        private void UpArrowPressedInNameEntry(object? sender, EventArgs e)
        {
            if (sender == null)
                return;

            PlayerNameEntryContol control = (PlayerNameEntryContol)sender;
            int controlIndex = nameEntries.IndexOf(control);

            // Focus on the previous name entry
            if (controlIndex != 0)
                nameEntries[controlIndex - 1].SelectForEditing();
        }

        private void DownArrowPressedInNameEntry(object? sender, EventArgs e)
        {
            if (sender == null)
                return;

            PlayerNameEntryContol control = (PlayerNameEntryContol)sender;
            int controlIndex = nameEntries.IndexOf(control);

            if (controlIndex != nameEntries.Count - 1)
            {
                // Focus on the next name entry
                nameEntries[controlIndex + 1].SelectForEditing();
            }
            else if (controlIndex == nameEntries.Count - 1 && control.PlayerName != "")
            {
                // Add a new name entry at the bottom
                AddNewNameEntryAtBottom().SelectForEditing();
            }
        }

        private void NameEntryDeleteRequested(object? sender, EventArgs e)
        {
            if (sender == null)
                return;

            PlayerNameEntryContol control = (PlayerNameEntryContol)sender;

            // Always delete the text - this will call the empty state changed event if necessary
            control.ClearText();

            int controlIndex = nameEntries.IndexOf(control);

            if (controlIndex == nameEntries.Count - 1)
            {
                if (controlIndex != 0)
                    nameEntries[controlIndex].SelectForEditing();

                // This is the last name entry, so just clear the text (already done)
            }
            else
            {
                nameEntries[controlIndex + 1].SelectForEditing();

                // Remove this name entry
                flowLayoutPanel.Controls.Remove(control);
                nameEntries.RemoveAt(controlIndex);
            }
        }

        private void NameFieldEmptyStateChanged(object? sender, TextEmptyStateChangedEventArgs e)
        {
            if (e.IsEmpty)
                RegisteredPlayersCount--;
            else
                RegisteredPlayersCount++;

            var args = new RegisteredPlayersCountChangedEventArgs()
            {
                PlayerCount = RegisteredPlayersCount
            };
            RegisteredPlayersCountChanged?.Invoke(this, args);
        }

        private void addNameButton_Click(object sender, EventArgs e)
        {
            // Add a new name entry at the bottom
            AddNewNameEntryAtBottom().SelectForEditing();
        }
    }

    internal class RegisteredPlayersCountChangedEventArgs : EventArgs
    {
        public int PlayerCount { get; set; }
    }
}
