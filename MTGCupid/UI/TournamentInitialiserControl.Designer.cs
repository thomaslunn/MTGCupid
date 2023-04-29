namespace MTGCupid.UI
{
    partial class TournamentInitialiserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentInitialiserControl));
            nameList = new NameEntryListControl();
            SuspendLayout();
            // 
            // nameList
            // 
            resources.ApplyResources(nameList, "nameList");
            nameList.BackColor = SystemColors.ControlLight;
            nameList.BorderStyle = BorderStyle.FixedSingle;
            nameList.Name = "nameList";
            // 
            // TournamentInitialiserControl
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(nameList);
            Name = "TournamentInitialiserControl";
            resources.ApplyResources(this, "$this");
            ResumeLayout(false);
        }

        #endregion

        private NameEntryListControl nameList;
    }
}
