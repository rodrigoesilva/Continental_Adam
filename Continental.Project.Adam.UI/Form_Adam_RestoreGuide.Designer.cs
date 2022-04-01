namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_RestoreGuide
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_RestoreGuide));
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.mtxt_ERestoreAsIdent = new MetroFramework.Controls.MetroTextBox();
            this.BackupDirectory = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.mbtn_Cancel = new MetroFramework.Controls.MetroButton();
            this.mbtn_DoBackup = new MetroFramework.Controls.MetroButton();
            this.mpnl_AvailableProjects = new MetroFramework.Controls.MetroPanel();
            this.lst_LBIdent = new System.Windows.Forms.ListBox();
            this.CoBDrive = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.mlbl_About = new MetroFramework.Controls.MetroLabel();
            this.mpnl_AvailableProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(800, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 47;
            this.mTile.Text = "Restore Assistent";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // mtxt_ERestoreAsIdent
            // 
            // 
            // 
            // 
            this.mtxt_ERestoreAsIdent.CustomButton.Image = null;
            this.mtxt_ERestoreAsIdent.CustomButton.Location = new System.Drawing.Point(351, 1);
            this.mtxt_ERestoreAsIdent.CustomButton.Name = "";
            this.mtxt_ERestoreAsIdent.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_ERestoreAsIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_ERestoreAsIdent.CustomButton.TabIndex = 1;
            this.mtxt_ERestoreAsIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_ERestoreAsIdent.CustomButton.UseSelectable = true;
            this.mtxt_ERestoreAsIdent.CustomButton.Visible = false;
            this.mtxt_ERestoreAsIdent.Lines = new string[0];
            this.mtxt_ERestoreAsIdent.Location = new System.Drawing.Point(19, 532);
            this.mtxt_ERestoreAsIdent.MaxLength = 32767;
            this.mtxt_ERestoreAsIdent.Name = "mtxt_ERestoreAsIdent";
            this.mtxt_ERestoreAsIdent.PasswordChar = '\0';
            this.mtxt_ERestoreAsIdent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_ERestoreAsIdent.SelectedText = "";
            this.mtxt_ERestoreAsIdent.SelectionLength = 0;
            this.mtxt_ERestoreAsIdent.SelectionStart = 0;
            this.mtxt_ERestoreAsIdent.ShortcutsEnabled = true;
            this.mtxt_ERestoreAsIdent.Size = new System.Drawing.Size(375, 25);
            this.mtxt_ERestoreAsIdent.TabIndex = 42;
            this.mtxt_ERestoreAsIdent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_ERestoreAsIdent.UseSelectable = true;
            this.mtxt_ERestoreAsIdent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_ERestoreAsIdent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BackupDirectory
            // 
            this.BackupDirectory.FormattingEnabled = true;
            this.BackupDirectory.IntegralHeight = false;
            this.BackupDirectory.Location = new System.Drawing.Point(14, 51);
            this.BackupDirectory.Name = "BackupDirectory";
            this.BackupDirectory.Size = new System.Drawing.Size(375, 315);
            this.BackupDirectory.TabIndex = 41;
            // 
            // mbtn_Cancel
            // 
            this.mbtn_Cancel.Location = new System.Drawing.Point(455, 512);
            this.mbtn_Cancel.Name = "mbtn_Cancel";
            this.mbtn_Cancel.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Cancel.TabIndex = 50;
            this.mbtn_Cancel.Text = "&Cancel";
            this.mbtn_Cancel.UseSelectable = true;
            this.mbtn_Cancel.Click += new System.EventHandler(this.mbtn_Cancel_Click);
            // 
            // mbtn_DoBackup
            // 
            this.mbtn_DoBackup.Location = new System.Drawing.Point(610, 512);
            this.mbtn_DoBackup.Name = "mbtn_DoBackup";
            this.mbtn_DoBackup.Size = new System.Drawing.Size(150, 45);
            this.mbtn_DoBackup.TabIndex = 49;
            this.mbtn_DoBackup.Text = "&Do Backup now...";
            this.mbtn_DoBackup.UseSelectable = true;
            this.mbtn_DoBackup.Click += new System.EventHandler(this.mbtn_DoBackup_Click);
            // 
            // mpnl_AvailableProjects
            // 
            this.mpnl_AvailableProjects.Controls.Add(this.lst_LBIdent);
            this.mpnl_AvailableProjects.Controls.Add(this.CoBDrive);
            this.mpnl_AvailableProjects.Controls.Add(this.BackupDirectory);
            this.mpnl_AvailableProjects.HorizontalScrollbarBarColor = true;
            this.mpnl_AvailableProjects.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_AvailableProjects.HorizontalScrollbarSize = 10;
            this.mpnl_AvailableProjects.Location = new System.Drawing.Point(5, 85);
            this.mpnl_AvailableProjects.Name = "mpnl_AvailableProjects";
            this.mpnl_AvailableProjects.Size = new System.Drawing.Size(760, 391);
            this.mpnl_AvailableProjects.TabIndex = 51;
            this.mpnl_AvailableProjects.VerticalScrollbarBarColor = true;
            this.mpnl_AvailableProjects.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_AvailableProjects.VerticalScrollbarSize = 10;
            // 
            // lst_LBIdent
            // 
            this.lst_LBIdent.FormattingEnabled = true;
            this.lst_LBIdent.Location = new System.Drawing.Point(405, 24);
            this.lst_LBIdent.Name = "lst_LBIdent";
            this.lst_LBIdent.Size = new System.Drawing.Size(336, 342);
            this.lst_LBIdent.TabIndex = 46;
            // 
            // CoBDrive
            // 
            this.CoBDrive.FormattingEnabled = true;
            this.CoBDrive.Location = new System.Drawing.Point(14, 24);
            this.CoBDrive.Name = "CoBDrive";
            this.CoBDrive.Size = new System.Drawing.Size(375, 21);
            this.CoBDrive.TabIndex = 45;
            // 
            // mlbl_About
            // 
            this.mlbl_About.AutoSize = true;
            this.mlbl_About.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_About.Location = new System.Drawing.Point(19, 504);
            this.mlbl_About.Name = "mlbl_About";
            this.mlbl_About.Size = new System.Drawing.Size(128, 19);
            this.mlbl_About.TabIndex = 52;
            this.mlbl_About.Text = "Restore as Ident #";
            // 
            // Form_Adam_RestoreGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.mlbl_About);
            this.Controls.Add(this.mTile);
            this.Controls.Add(this.mbtn_Cancel);
            this.Controls.Add(this.mbtn_DoBackup);
            this.Controls.Add(this.mpnl_AvailableProjects);
            this.Controls.Add(this.mtxt_ERestoreAsIdent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Adam_RestoreGuide";
            this.Text = "Continental - ADAM Functional Test Bench - Restore Assistent";
            this.mpnl_AvailableProjects.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile mTile;
        private MetroFramework.Controls.MetroTextBox mtxt_ERestoreAsIdent;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox BackupDirectory;
        private MetroFramework.Controls.MetroButton mbtn_Cancel;
        private MetroFramework.Controls.MetroButton mbtn_DoBackup;
        private MetroFramework.Controls.MetroPanel mpnl_AvailableProjects;
        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox CoBDrive;
        private System.Windows.Forms.ListBox lst_LBIdent;
        private MetroFramework.Controls.MetroLabel mlbl_About;
    }
}