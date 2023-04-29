namespace MTGCupid.UI
{
    partial class PlayerNameEntryContol
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
            nameBox = new TextBox();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameBox.Location = new Point(3, 3);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(241, 23);
            nameBox.TabIndex = 0;
            nameBox.TextChanged += nameBox_TextChanged;
            nameBox.KeyDown += nameBox_KeyDown;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteButton.BackColor = Color.Tomato;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Location = new Point(250, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(23, 23);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "X";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // PlayerNameEntryContol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteButton);
            Controls.Add(nameBox);
            Margin = new Padding(0);
            MaximumSize = new Size(1000, 29);
            MinimumSize = new Size(200, 29);
            Name = "PlayerNameEntryContol";
            Size = new Size(279, 29);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameBox;
        private Button deleteButton;
    }
}
