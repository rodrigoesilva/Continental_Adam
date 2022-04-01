namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_About));
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.mbtn_Close = new MetroFramework.Controls.MetroButton();
            this.picContinental = new System.Windows.Forms.PictureBox();
            this.mtxt_About = new MetroFramework.Controls.MetroTextBox();
            this.lbl_About = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).BeginInit();
            this.SuspendLayout();
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(800, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 23;
            this.mTile.Text = "Continental Brazil Automotive Products";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // mbtn_Close
            // 
            this.mbtn_Close.Location = new System.Drawing.Point(300, 510);
            this.mbtn_Close.Name = "mbtn_Close";
            this.mbtn_Close.Size = new System.Drawing.Size(200, 45);
            this.mbtn_Close.TabIndex = 25;
            this.mbtn_Close.Text = "&Close";
            this.mbtn_Close.UseSelectable = true;
            this.mbtn_Close.Click += new System.EventHandler(this.mbtn_Close_Click);
            // 
            // picContinental
            // 
            this.picContinental.Image = global::Continental.Project.Adam.UI.Properties.Resources.img_LogoContinenal;
            this.picContinental.Location = new System.Drawing.Point(200, 90);
            this.picContinental.Name = "picContinental";
            this.picContinental.Size = new System.Drawing.Size(405, 124);
            this.picContinental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picContinental.TabIndex = 27;
            this.picContinental.TabStop = false;
            // 
            // mtxt_About
            // 
            // 
            // 
            // 
            this.mtxt_About.CustomButton.Image = null;
            this.mtxt_About.CustomButton.Location = new System.Drawing.Point(542, 2);
            this.mtxt_About.CustomButton.Name = "";
            this.mtxt_About.CustomButton.Size = new System.Drawing.Size(181, 181);
            this.mtxt_About.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_About.CustomButton.TabIndex = 1;
            this.mtxt_About.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_About.CustomButton.UseSelectable = true;
            this.mtxt_About.CustomButton.Visible = false;
            this.mtxt_About.Enabled = false;
            this.mtxt_About.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_About.Lines = new string[] {
        "",
        "(c) Copyright 2021 - Fanuel Automação",
        "",
        "Continental Brazil Automotive Products",
        "Av. Duque de Caxias, 2422",
        "Jardim Santa Lucia, Várzea Paulista - SP",
        "13223-025",
        "",
        "All rights reserved."};
            this.mtxt_About.Location = new System.Drawing.Point(25, 298);
            this.mtxt_About.MaxLength = 32767;
            this.mtxt_About.Multiline = true;
            this.mtxt_About.Name = "mtxt_About";
            this.mtxt_About.PasswordChar = '\0';
            this.mtxt_About.ReadOnly = true;
            this.mtxt_About.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_About.SelectedText = "";
            this.mtxt_About.SelectionLength = 0;
            this.mtxt_About.SelectionStart = 0;
            this.mtxt_About.ShortcutsEnabled = true;
            this.mtxt_About.Size = new System.Drawing.Size(726, 186);
            this.mtxt_About.TabIndex = 34;
            this.mtxt_About.Text = "\r\n(c) Copyright 2021 - Fanuel Automação\r\n\r\nContinental Brazil Automotive Products" +
    "\r\nAv. Duque de Caxias, 2422\r\nJardim Santa Lucia, Várzea Paulista - SP\r\n13223-025" +
    "\r\n\r\nAll rights reserved.";
            this.mtxt_About.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_About.UseSelectable = true;
            this.mtxt_About.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_About.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbl_About
            // 
            this.lbl_About.AutoSize = true;
            this.lbl_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_About.Location = new System.Drawing.Point(186, 241);
            this.lbl_About.Name = "lbl_About";
            this.lbl_About.Size = new System.Drawing.Size(437, 25);
            this.lbl_About.TabIndex = 36;
            this.lbl_About.Text = "Brake Assist / ADAM Functional Test Bench";
            this.lbl_About.Click += new System.EventHandler(this.btfetch_Click);
            // 
            // Form_Adam_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_About);
            this.Controls.Add(this.mtxt_About);
            this.Controls.Add(this.picContinental);
            this.Controls.Add(this.mTile);
            this.Controls.Add(this.mbtn_Close);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Adam_About";
            this.Text = "Continental - ADAM Functional Test Bench";
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile mTile;
        private MetroFramework.Controls.MetroButton mbtn_Close;
        private System.Windows.Forms.PictureBox picContinental;
        private MetroFramework.Controls.MetroTextBox mtxt_About;
        private System.Windows.Forms.Label lbl_About;
    }
}