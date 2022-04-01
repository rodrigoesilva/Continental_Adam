namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_Preferences));
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.mbtn_BCreateTableTests = new MetroFramework.Controls.MetroButton();
            this.mbtn_Ok = new MetroFramework.Controls.MetroButton();
            this.mpnl_AvailableProjects = new MetroFramework.Controls.MetroPanel();
            this.mchk_CBProtectiveCoverWatchdog = new MetroFramework.Controls.MetroCheckBox();
            this.mbtn_BUpgrade00020001 = new MetroFramework.Controls.MetroButton();
            this.mpnl_AvailableProjects.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(500, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 47;
            this.mTile.Text = "For developer´s use only!";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // mbtn_BCreateTableTests
            // 
            this.mbtn_BCreateTableTests.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BCreateTableTests.Location = new System.Drawing.Point(45, 105);
            this.mbtn_BCreateTableTests.Name = "mbtn_BCreateTableTests";
            this.mbtn_BCreateTableTests.Size = new System.Drawing.Size(375, 45);
            this.mbtn_BCreateTableTests.TabIndex = 43;
            this.mbtn_BCreateTableTests.Text = "Create New Database Main Table";
            this.mbtn_BCreateTableTests.UseSelectable = true;
            // 
            // mbtn_Ok
            // 
            this.mbtn_Ok.Location = new System.Drawing.Point(325, 410);
            this.mbtn_Ok.Name = "mbtn_Ok";
            this.mbtn_Ok.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Ok.TabIndex = 49;
            this.mbtn_Ok.Text = "&Ok";
            this.mbtn_Ok.UseSelectable = true;
            this.mbtn_Ok.Click += new System.EventHandler(this.mbtn_Ok_Click);
            // 
            // mpnl_AvailableProjects
            // 
            this.mpnl_AvailableProjects.Controls.Add(this.mchk_CBProtectiveCoverWatchdog);
            this.mpnl_AvailableProjects.Controls.Add(this.mbtn_BUpgrade00020001);
            this.mpnl_AvailableProjects.Controls.Add(this.mbtn_BCreateTableTests);
            this.mpnl_AvailableProjects.HorizontalScrollbarBarColor = true;
            this.mpnl_AvailableProjects.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_AvailableProjects.HorizontalScrollbarSize = 10;
            this.mpnl_AvailableProjects.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.mpnl_AvailableProjects.Location = new System.Drawing.Point(10, 70);
            this.mpnl_AvailableProjects.Name = "mpnl_AvailableProjects";
            this.mpnl_AvailableProjects.Size = new System.Drawing.Size(465, 330);
            this.mpnl_AvailableProjects.TabIndex = 51;
            this.mpnl_AvailableProjects.VerticalScrollbarBarColor = true;
            this.mpnl_AvailableProjects.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_AvailableProjects.VerticalScrollbarSize = 10;
            // 
            // mchk_CBProtectiveCoverWatchdog
            // 
            this.mchk_CBProtectiveCoverWatchdog.AutoSize = true;
            this.mchk_CBProtectiveCoverWatchdog.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mchk_CBProtectiveCoverWatchdog.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mchk_CBProtectiveCoverWatchdog.Location = new System.Drawing.Point(78, 30);
            this.mchk_CBProtectiveCoverWatchdog.Name = "mchk_CBProtectiveCoverWatchdog";
            this.mchk_CBProtectiveCoverWatchdog.Size = new System.Drawing.Size(319, 25);
            this.mchk_CBProtectiveCoverWatchdog.TabIndex = 44;
            this.mchk_CBProtectiveCoverWatchdog.Text = "Protection Cover Watchdog active";
            this.mchk_CBProtectiveCoverWatchdog.UseSelectable = true;
            // 
            // mbtn_BUpgrade00020001
            // 
            this.mbtn_BUpgrade00020001.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BUpgrade00020001.Location = new System.Drawing.Point(45, 236);
            this.mbtn_BUpgrade00020001.Name = "mbtn_BUpgrade00020001";
            this.mbtn_BUpgrade00020001.Size = new System.Drawing.Size(375, 45);
            this.mbtn_BUpgrade00020001.TabIndex = 43;
            this.mbtn_BUpgrade00020001.Text = "Upgrade => 0x00020001";
            this.mbtn_BUpgrade00020001.UseSelectable = true;
            // 
            // Form_Adam_Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.ControlBox = false;
            this.Controls.Add(this.mTile);
            this.Controls.Add(this.mbtn_Ok);
            this.Controls.Add(this.mpnl_AvailableProjects);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Adam_Preferences";
            this.Text = "Continental - ADAM Functional Test Bench - For developer´s";
            this.mpnl_AvailableProjects.ResumeLayout(false);
            this.mpnl_AvailableProjects.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile mTile;
        private MetroFramework.Controls.MetroButton mbtn_BCreateTableTests;
        private MetroFramework.Controls.MetroButton mbtn_Ok;
        private MetroFramework.Controls.MetroPanel mpnl_AvailableProjects;
        private MetroFramework.Controls.MetroCheckBox mchk_CBProtectiveCoverWatchdog;
        private MetroFramework.Controls.MetroButton mbtn_BUpgrade00020001;
    }
}