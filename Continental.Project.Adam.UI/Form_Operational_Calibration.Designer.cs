namespace Continental.Project.Adam.UI
{
    partial class Form_Operational_Calibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Operational_Calibration));
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mTile_Calibration = new MetroFramework.Controls.MetroTile();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.mTile_Calibration);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(2, 2);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1900, 45);
            this.metroPanel2.TabIndex = 49;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // mTile_Calibration
            // 
            this.mTile_Calibration.ActiveControl = null;
            this.mTile_Calibration.Location = new System.Drawing.Point(0, 0);
            this.mTile_Calibration.Name = "mTile_Calibration";
            this.mTile_Calibration.Size = new System.Drawing.Size(1900, 45);
            this.mTile_Calibration.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_Calibration.TabIndex = 21;
            this.mTile_Calibration.Text = "Calibration";
            this.mTile_Calibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_Calibration.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_Calibration.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_Calibration.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_Calibration.UseSelectable = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(2, 53);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1900, 976);
            this.webBrowser1.TabIndex = 50;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Form_Operational_Calibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.metroPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Operational_Calibration";
            this.Text = "Continental - ADAM Functional Test Bench - Calibration";
            this.Load += new System.EventHandler(this.Form_Operational_Calibration_Load);
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTile mTile_Calibration;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}