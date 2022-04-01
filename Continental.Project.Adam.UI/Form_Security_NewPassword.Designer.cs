
namespace Continental.Project.Adam.UI
{
    partial class Form_Security_NewPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Security_NewPassword));
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.mbtn_Cancel = new MetroFramework.Controls.MetroButton();
            this.mbtn_Ok = new MetroFramework.Controls.MetroButton();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.mlblConfirmPassword = new MetroFramework.Controls.MetroLabel();
            this.mtxt_EConfirm = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_ENewPassword = new MetroFramework.Controls.MetroTextBox();
            this.mlblNote = new MetroFramework.Controls.MetroLabel();
            this.mlblPassword = new MetroFramework.Controls.MetroLabel();
            this.mtxt_EUser = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(500, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 20;
            this.mTile.Text = "New Password";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // mbtn_Cancel
            // 
            this.mbtn_Cancel.Location = new System.Drawing.Point(165, 410);
            this.mbtn_Cancel.Name = "mbtn_Cancel";
            this.mbtn_Cancel.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Cancel.TabIndex = 23;
            this.mbtn_Cancel.Text = "&Cancel";
            this.mbtn_Cancel.UseSelectable = true;
            this.mbtn_Cancel.Click += new System.EventHandler(this.mbtn_Cancel_Click);
            // 
            // mbtn_Ok
            // 
            this.mbtn_Ok.Location = new System.Drawing.Point(325, 410);
            this.mbtn_Ok.Name = "mbtn_Ok";
            this.mbtn_Ok.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Ok.TabIndex = 22;
            this.mbtn_Ok.Text = "&Ok";
            this.mbtn_Ok.UseSelectable = true;
            this.mbtn_Ok.Click += new System.EventHandler(this.mbtn_Ok_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.mlblConfirmPassword);
            this.metroPanel2.Controls.Add(this.mtxt_EConfirm);
            this.metroPanel2.Controls.Add(this.mtxt_ENewPassword);
            this.metroPanel2.Controls.Add(this.mlblNote);
            this.metroPanel2.Controls.Add(this.mlblPassword);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(10, 110);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(465, 295);
            this.metroPanel2.TabIndex = 24;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // mlblConfirmPassword
            // 
            this.mlblConfirmPassword.AutoSize = true;
            this.mlblConfirmPassword.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlblConfirmPassword.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlblConfirmPassword.Location = new System.Drawing.Point(45, 141);
            this.mlblConfirmPassword.Name = "mlblConfirmPassword";
            this.mlblConfirmPassword.Size = new System.Drawing.Size(279, 25);
            this.mlblConfirmPassword.TabIndex = 24;
            this.mlblConfirmPassword.Text = "...and confirm it by re-entering.";
            // 
            // mtxt_EConfirm
            // 
            // 
            // 
            // 
            this.mtxt_EConfirm.CustomButton.Image = null;
            this.mtxt_EConfirm.CustomButton.Location = new System.Drawing.Point(331, 1);
            this.mtxt_EConfirm.CustomButton.Name = "";
            this.mtxt_EConfirm.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_EConfirm.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_EConfirm.CustomButton.TabIndex = 1;
            this.mtxt_EConfirm.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_EConfirm.CustomButton.UseSelectable = true;
            this.mtxt_EConfirm.CustomButton.Visible = false;
            this.mtxt_EConfirm.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_EConfirm.Lines = new string[0];
            this.mtxt_EConfirm.Location = new System.Drawing.Point(45, 171);
            this.mtxt_EConfirm.MaxLength = 32767;
            this.mtxt_EConfirm.Name = "mtxt_EConfirm";
            this.mtxt_EConfirm.PasswordChar = '\0';
            this.mtxt_EConfirm.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_EConfirm.SelectedText = "";
            this.mtxt_EConfirm.SelectionLength = 0;
            this.mtxt_EConfirm.SelectionStart = 0;
            this.mtxt_EConfirm.ShortcutsEnabled = true;
            this.mtxt_EConfirm.Size = new System.Drawing.Size(365, 35);
            this.mtxt_EConfirm.TabIndex = 17;
            this.mtxt_EConfirm.UseSelectable = true;
            this.mtxt_EConfirm.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_EConfirm.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_ENewPassword
            // 
            // 
            // 
            // 
            this.mtxt_ENewPassword.CustomButton.Image = null;
            this.mtxt_ENewPassword.CustomButton.Location = new System.Drawing.Point(331, 1);
            this.mtxt_ENewPassword.CustomButton.Name = "";
            this.mtxt_ENewPassword.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_ENewPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_ENewPassword.CustomButton.TabIndex = 1;
            this.mtxt_ENewPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_ENewPassword.CustomButton.UseSelectable = true;
            this.mtxt_ENewPassword.CustomButton.Visible = false;
            this.mtxt_ENewPassword.Lines = new string[0];
            this.mtxt_ENewPassword.Location = new System.Drawing.Point(45, 60);
            this.mtxt_ENewPassword.MaxLength = 32767;
            this.mtxt_ENewPassword.Name = "mtxt_ENewPassword";
            this.mtxt_ENewPassword.PasswordChar = '\0';
            this.mtxt_ENewPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_ENewPassword.SelectedText = "";
            this.mtxt_ENewPassword.SelectionLength = 0;
            this.mtxt_ENewPassword.SelectionStart = 0;
            this.mtxt_ENewPassword.ShortcutsEnabled = true;
            this.mtxt_ENewPassword.Size = new System.Drawing.Size(365, 35);
            this.mtxt_ENewPassword.TabIndex = 11;
            this.mtxt_ENewPassword.UseSelectable = true;
            this.mtxt_ENewPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_ENewPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlblNote
            // 
            this.mlblNote.AutoSize = true;
            this.mlblNote.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlblNote.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mlblNote.Location = new System.Drawing.Point(75, 251);
            this.mlblNote.Name = "mlblNote";
            this.mlblNote.Size = new System.Drawing.Size(316, 25);
            this.mlblNote.TabIndex = 21;
            this.mlblNote.Text = "(Note: All passwords are case sensitiv!)";
            // 
            // mlblPassword
            // 
            this.mlblPassword.AutoSize = true;
            this.mlblPassword.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlblPassword.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlblPassword.Location = new System.Drawing.Point(45, 30);
            this.mlblPassword.Name = "mlblPassword";
            this.mlblPassword.Size = new System.Drawing.Size(279, 25);
            this.mlblPassword.TabIndex = 13;
            this.mlblPassword.Text = "Please enter the new password.";
            // 
            // mtxt_EUser
            // 
            // 
            // 
            // 
            this.mtxt_EUser.CustomButton.Image = null;
            this.mtxt_EUser.CustomButton.Location = new System.Drawing.Point(431, 1);
            this.mtxt_EUser.CustomButton.Name = "";
            this.mtxt_EUser.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtxt_EUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_EUser.CustomButton.TabIndex = 1;
            this.mtxt_EUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_EUser.CustomButton.UseSelectable = true;
            this.mtxt_EUser.CustomButton.Visible = false;
            this.mtxt_EUser.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_EUser.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mtxt_EUser.Lines = new string[0];
            this.mtxt_EUser.Location = new System.Drawing.Point(10, 70);
            this.mtxt_EUser.MaxLength = 32767;
            this.mtxt_EUser.Name = "mtxt_EUser";
            this.mtxt_EUser.PasswordChar = '\0';
            this.mtxt_EUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_EUser.SelectedText = "";
            this.mtxt_EUser.SelectionLength = 0;
            this.mtxt_EUser.SelectionStart = 0;
            this.mtxt_EUser.ShortcutsEnabled = true;
            this.mtxt_EUser.Size = new System.Drawing.Size(465, 35);
            this.mtxt_EUser.TabIndex = 25;
            this.mtxt_EUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_EUser.UseSelectable = true;
            this.mtxt_EUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_EUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form_Security_NewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.ControlBox = false;
            this.Controls.Add(this.mtxt_EUser);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.mbtn_Cancel);
            this.Controls.Add(this.mbtn_Ok);
            this.Controls.Add(this.mTile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Security_NewPassword";
            this.Text = "Continental - ADAM Functional Test Bench - New Password";
            this.Load += new System.EventHandler(this.Form_Security_NewPassword_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile mTile;
        private MetroFramework.Controls.MetroButton mbtn_Cancel;
        private MetroFramework.Controls.MetroButton mbtn_Ok;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel mlblConfirmPassword;
        private MetroFramework.Controls.MetroTextBox mtxt_EConfirm;
        private MetroFramework.Controls.MetroTextBox mtxt_ENewPassword;
        private MetroFramework.Controls.MetroLabel mlblNote;
        private MetroFramework.Controls.MetroLabel mlblPassword;
        private MetroFramework.Controls.MetroTextBox mtxt_EUser;
    }
}