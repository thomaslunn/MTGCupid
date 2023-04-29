using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace MTGCupid.UI
{
    internal partial class PlayerNameEntryContol : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the user presses the enter key within the name entry textbox")]
        public event EventHandler? EnterKeyPressed;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the user presses the delete button for this name entry, or presses the escape key within the name entry textbox")]
        public event EventHandler? DeleteRequested;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the user presses the up arrow key within the name entry textbox")]
        public event EventHandler? UpArrowPressed;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the user presses the down arrow key within the name entry textbox")]
        public event EventHandler? DownArrowPressed;

        [Browsable (true)]
        [Category("Action")]
        [Description("Invoked when the text in the name entry textbox becomes empty or nonempty")]
        public event EventHandler<TextEmptyStateChangedEventArgs>? TextEmptyStateChanged;


        public string PlayerName { get => nameBox.Text; }
        public bool HasActiveCursor { get => nameBox.Focused; }

        private bool textWasEmpty { get; set; } = true;

        public PlayerNameEntryContol()
        {
            InitializeComponent();
        }

        private void nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EnterKeyPressed?.Invoke(this, e);
            }
            else if (e.KeyData == Keys.Escape)
            {
                DeleteRequested?.Invoke(this, e);
            }
            else if (e.KeyData == Keys.Up)
            {
                UpArrowPressed?.Invoke(this, e);
            }
            else if (e.KeyData == Keys.Down)
            {
                DownArrowPressed?.Invoke(this, e);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteRequested?.Invoke(this, e);
        }

        public void ClearText()
        {
            nameBox.Clear();
        }

        public void SelectForEditing()
        {
            nameBox.Focus();
            nameBox.SelectionStart = nameBox.Text.Length;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            bool textIsEmpty = nameBox.Text.Length == 0;

            if (textIsEmpty ^ textWasEmpty)
            {
                TextEmptyStateChangedEventArgs args = new TextEmptyStateChangedEventArgs()
                {
                    IsEmpty = textIsEmpty
                };
                TextEmptyStateChanged?.Invoke(this, args);

                textWasEmpty = textIsEmpty;
            }
        }
    }
    internal class TextEmptyStateChangedEventArgs : EventArgs
    {
        public bool IsEmpty { get; set; }
    }

}
