namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_BackupGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_BackupGuide));
            this.mlbl_About = new MetroFramework.Controls.MetroLabel();
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.BackupDirectory = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.mtxt_ECreateNewDir = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_BCreateNewDir = new MetroFramework.Controls.MetroButton();
            this.mbtn_Cancel = new MetroFramework.Controls.MetroButton();
            this.mbtn_DoBackup = new MetroFramework.Controls.MetroButton();
            this.mpnl_BackupAssistent = new MetroFramework.Controls.MetroPanel();
            this.DriveComboBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.mchk_CBDeleteBackupedFiles = new MetroFramework.Controls.MetroCheckBox();
            this.mpnl_BackupAssistent.SuspendLayout();
            this.SuspendLayout();
            // 
            // mlbl_About
            // 
            this.mlbl_About.AutoSize = true;
            this.mlbl_About.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlbl_About.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_About.Location = new System.Drawing.Point(15, 80);
            this.mlbl_About.Name = "mlbl_About";
            this.mlbl_About.Size = new System.Drawing.Size(351, 25);
            this.mlbl_About.TabIndex = 40;
            this.mlbl_About.Text = "Please select the destination directory...";
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(800, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 36;
            this.mTile.Text = "Backup Assistent";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // BackupDirectory
            // 
            this.BackupDirectory.FormattingEnabled = true;
            this.BackupDirectory.IntegralHeight = false;
            this.BackupDirectory.Location = new System.Drawing.Point(14, 21);
            this.BackupDirectory.Name = "BackupDirectory";
            this.BackupDirectory.Size = new System.Drawing.Size(337, 352);
            this.BackupDirectory.TabIndex = 41;
            // 
            // mtxt_ECreateNewDir
            // 
            // 
            // 
            // 
            this.mtxt_ECreateNewDir.CustomButton.Image = null;
            this.mtxt_ECreateNewDir.CustomButton.Location = new System.Drawing.Point(351, 1);
            this.mtxt_ECreateNewDir.CustomButton.Name = "";
            this.mtxt_ECreateNewDir.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_ECreateNewDir.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_ECreateNewDir.CustomButton.TabIndex = 1;
            this.mtxt_ECreateNewDir.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_ECreateNewDir.CustomButton.UseSelectable = true;
            this.mtxt_ECreateNewDir.CustomButton.Visible = false;
            this.mtxt_ECreateNewDir.Lines = new string[0];
            this.mtxt_ECreateNewDir.Location = new System.Drawing.Point(369, 69);
            this.mtxt_ECreateNewDir.MaxLength = 32767;
            this.mtxt_ECreateNewDir.Name = "mtxt_ECreateNewDir";
            this.mtxt_ECreateNewDir.PasswordChar = '\0';
            this.mtxt_ECreateNewDir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_ECreateNewDir.SelectedText = "";
            this.mtxt_ECreateNewDir.SelectionLength = 0;
            this.mtxt_ECreateNewDir.SelectionStart = 0;
            this.mtxt_ECreateNewDir.ShortcutsEnabled = true;
            this.mtxt_ECreateNewDir.Size = new System.Drawing.Size(375, 25);
            this.mtxt_ECreateNewDir.TabIndex = 42;
            this.mtxt_ECreateNewDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_ECreateNewDir.UseSelectable = true;
            this.mtxt_ECreateNewDir.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_ECreateNewDir.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_BCreateNewDir
            // 
            this.mbtn_BCreateNewDir.Location = new System.Drawing.Point(369, 124);
            this.mbtn_BCreateNewDir.Name = "mbtn_BCreateNewDir";
            this.mbtn_BCreateNewDir.Size = new System.Drawing.Size(375, 45);
            this.mbtn_BCreateNewDir.TabIndex = 43;
            this.mbtn_BCreateNewDir.Text = "&Create a new directory entered above...";
            this.mbtn_BCreateNewDir.UseSelectable = true;
            // 
            // mbtn_Cancel
            // 
            this.mbtn_Cancel.Location = new System.Drawing.Point(465, 510);
            this.mbtn_Cancel.Name = "mbtn_Cancel";
            this.mbtn_Cancel.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Cancel.TabIndex = 45;
            this.mbtn_Cancel.Text = "&Cancel";
            this.mbtn_Cancel.UseSelectable = true;
            this.mbtn_Cancel.Click += new System.EventHandler(this.mbtn_Cancel_Click);
            // 
            // mbtn_DoBackup
            // 
            this.mbtn_DoBackup.Location = new System.Drawing.Point(620, 510);
            this.mbtn_DoBackup.Name = "mbtn_DoBackup";
            this.mbtn_DoBackup.Size = new System.Drawing.Size(150, 45);
            this.mbtn_DoBackup.TabIndex = 44;
            this.mbtn_DoBackup.Text = "&Do Backup now...";
            this.mbtn_DoBackup.UseSelectable = true;
            this.mbtn_DoBackup.Click += new System.EventHandler(this.mbtn_DoBackup_Click);
            // 
            // mpnl_BackupAssistent
            // 
            this.mpnl_BackupAssistent.Controls.Add(this.DriveComboBox1);
            this.mpnl_BackupAssistent.Controls.Add(this.mchk_CBDeleteBackupedFiles);
            this.mpnl_BackupAssistent.Controls.Add(this.mtxt_ECreateNewDir);
            this.mpnl_BackupAssistent.Controls.Add(this.BackupDirectory);
            this.mpnl_BackupAssistent.Controls.Add(this.mbtn_BCreateNewDir);
            this.mpnl_BackupAssistent.HorizontalScrollbarBarColor = true;
            this.mpnl_BackupAssistent.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_BackupAssistent.HorizontalScrollbarSize = 10;
            this.mpnl_BackupAssistent.Location = new System.Drawing.Point(15, 109);
            this.mpnl_BackupAssistent.Name = "mpnl_BackupAssistent";
            this.mpnl_BackupAssistent.Size = new System.Drawing.Size(760, 391);
            this.mpnl_BackupAssistent.TabIndex = 46;
            this.mpnl_BackupAssistent.VerticalScrollbarBarColor = true;
            this.mpnl_BackupAssistent.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_BackupAssistent.VerticalScrollbarSize = 10;
            // 
            // DriveComboBox1
            // 
            this.DriveComboBox1.FormattingEnabled = true;
            this.DriveComboBox1.Location = new System.Drawing.Point(369, 21);
            this.DriveComboBox1.Name = "DriveComboBox1";
            this.DriveComboBox1.Size = new System.Drawing.Size(375, 21);
            this.DriveComboBox1.TabIndex = 45;
            // 
            // mchk_CBDeleteBackupedFiles
            // 
            this.mchk_CBDeleteBackupedFiles.AutoSize = true;
            this.mchk_CBDeleteBackupedFiles.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mchk_CBDeleteBackupedFiles.Location = new System.Drawing.Point(369, 262);
            this.mchk_CBDeleteBackupedFiles.Name = "mchk_CBDeleteBackupedFiles";
            this.mchk_CBDeleteBackupedFiles.Size = new System.Drawing.Size(255, 15);
            this.mchk_CBDeleteBackupedFiles.TabIndex = 44;
            this.mchk_CBDeleteBackupedFiles.Text = "Remove all backup\'ed files from database";
            this.mchk_CBDeleteBackupedFiles.UseSelectable = true;
            // 
            // Form_Adam_BackupGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.mbtn_Cancel);
            this.Controls.Add(this.mbtn_DoBackup);
            this.Controls.Add(this.mlbl_About);
            this.Controls.Add(this.mTile);
            this.Controls.Add(this.mpnl_BackupAssistent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Adam_BackupGuide";
            this.Text = "Continental - ADAM Functional Test Bench - Backup Assistent";
            this.mpnl_BackupAssistent.ResumeLayout(false);
            this.mpnl_BackupAssistent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel mlbl_About;
        private MetroFramework.Controls.MetroTile mTile;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox BackupDirectory;
        private MetroFramework.Controls.MetroTextBox mtxt_ECreateNewDir;
        private MetroFramework.Controls.MetroButton mbtn_BCreateNewDir;
        private MetroFramework.Controls.MetroButton mbtn_Cancel;
        private MetroFramework.Controls.MetroButton mbtn_DoBackup;
        private MetroFramework.Controls.MetroPanel mpnl_BackupAssistent;
        private MetroFramework.Controls.MetroCheckBox mchk_CBDeleteBackupedFiles;
        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox DriveComboBox1;
    }
}