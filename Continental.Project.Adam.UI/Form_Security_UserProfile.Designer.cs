
namespace Continental.Project.Adam.UI
{
    partial class Form_Security_UserProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Security_UserProfile));
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.mlbl_LPassword = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rad_RBAdmin = new System.Windows.Forms.RadioButton();
            this.rad_RBOperator = new System.Windows.Forms.RadioButton();
            this.rad_RBUser = new System.Windows.Forms.RadioButton();
            this.mtxt_EPassword = new MetroFramework.Controls.MetroTextBox();
            this.mbtn_Ok = new MetroFramework.Controls.MetroButton();
            this.mbtn_Cancel = new MetroFramework.Controls.MetroButton();
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.mtxt_EUser = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.mlbl_LPassword);
            this.metroPanel2.Controls.Add(this.groupBox1);
            this.metroPanel2.Controls.Add(this.mtxt_EPassword);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(10, 110);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(465, 293);
            this.metroPanel2.TabIndex = 13;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(65, 255);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(316, 25);
            this.metroLabel2.TabIndex = 30;
            this.metroLabel2.Text = "(Note: All passwords are case sensitiv!)";
            // 
            // mlbl_LPassword
            // 
            this.mlbl_LPassword.AutoSize = true;
            this.mlbl_LPassword.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlbl_LPassword.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_LPassword.Location = new System.Drawing.Point(65, 191);
            this.mlbl_LPassword.Name = "mlbl_LPassword";
            this.mlbl_LPassword.Size = new System.Drawing.Size(245, 25);
            this.mlbl_LPassword.TabIndex = 29;
            this.mlbl_LPassword.Text = "Please enter your password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rad_RBAdmin);
            this.groupBox1.Controls.Add(this.rad_RBOperator);
            this.groupBox1.Controls.Add(this.rad_RBUser);
            this.groupBox1.Location = new System.Drawing.Point(65, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 156);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rad_RBAdmin
            // 
            this.rad_RBAdmin.AutoSize = true;
            this.rad_RBAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_RBAdmin.Location = new System.Drawing.Point(23, 121);
            this.rad_RBAdmin.Name = "rad_RBAdmin";
            this.rad_RBAdmin.Size = new System.Drawing.Size(109, 21);
            this.rad_RBAdmin.TabIndex = 28;
            this.rad_RBAdmin.TabStop = true;
            this.rad_RBAdmin.Text = "Administrator";
            this.rad_RBAdmin.UseVisualStyleBackColor = true;
            // 
            // rad_RBOperator
            // 
            this.rad_RBOperator.AutoSize = true;
            this.rad_RBOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_RBOperator.Location = new System.Drawing.Point(22, 69);
            this.rad_RBOperator.Name = "rad_RBOperator";
            this.rad_RBOperator.Size = new System.Drawing.Size(83, 21);
            this.rad_RBOperator.TabIndex = 27;
            this.rad_RBOperator.TabStop = true;
            this.rad_RBOperator.Text = "Operator";
            this.rad_RBOperator.UseVisualStyleBackColor = true;
            // 
            // rad_RBUser
            // 
            this.rad_RBUser.AutoSize = true;
            this.rad_RBUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_RBUser.Location = new System.Drawing.Point(23, 17);
            this.rad_RBUser.Name = "rad_RBUser";
            this.rad_RBUser.Size = new System.Drawing.Size(56, 21);
            this.rad_RBUser.TabIndex = 26;
            this.rad_RBUser.TabStop = true;
            this.rad_RBUser.Text = "User";
            this.rad_RBUser.UseVisualStyleBackColor = true;
            // 
            // mtxt_EPassword
            // 
            // 
            // 
            // 
            this.mtxt_EPassword.CustomButton.Image = null;
            this.mtxt_EPassword.CustomButton.Location = new System.Drawing.Point(314, 1);
            this.mtxt_EPassword.CustomButton.Name = "";
            this.mtxt_EPassword.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.mtxt_EPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_EPassword.CustomButton.TabIndex = 1;
            this.mtxt_EPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_EPassword.CustomButton.UseSelectable = true;
            this.mtxt_EPassword.CustomButton.Visible = false;
            this.mtxt_EPassword.Lines = new string[0];
            this.mtxt_EPassword.Location = new System.Drawing.Point(65, 219);
            this.mtxt_EPassword.MaxLength = 32767;
            this.mtxt_EPassword.Name = "mtxt_EPassword";
            this.mtxt_EPassword.PasswordChar = '*';
            this.mtxt_EPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_EPassword.SelectedText = "";
            this.mtxt_EPassword.SelectionLength = 0;
            this.mtxt_EPassword.SelectionStart = 0;
            this.mtxt_EPassword.ShortcutsEnabled = true;
            this.mtxt_EPassword.Size = new System.Drawing.Size(338, 25);
            this.mtxt_EPassword.TabIndex = 18;
            this.mtxt_EPassword.UseSelectable = true;
            this.mtxt_EPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_EPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtn_Ok
            // 
            this.mbtn_Ok.Location = new System.Drawing.Point(325, 410);
            this.mbtn_Ok.Name = "mbtn_Ok";
            this.mbtn_Ok.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Ok.TabIndex = 15;
            this.mbtn_Ok.Text = "&Ok";
            this.mbtn_Ok.UseSelectable = true;
            this.mbtn_Ok.Click += new System.EventHandler(this.mbtn_Ok_Click);
            // 
            // mbtn_Cancel
            // 
            this.mbtn_Cancel.Location = new System.Drawing.Point(165, 410);
            this.mbtn_Cancel.Name = "mbtn_Cancel";
            this.mbtn_Cancel.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Cancel.TabIndex = 14;
            this.mbtn_Cancel.Text = "&Cancel";
            this.mbtn_Cancel.UseSelectable = true;
            this.mbtn_Cancel.Click += new System.EventHandler(this.mbtn_Cancel_Click);
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(484, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 20;
            this.mTile.Text = "User Profile";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
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
            this.mtxt_EUser.TabIndex = 21;
            this.mtxt_EUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_EUser.UseSelectable = true;
            this.mtxt_EUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_EUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form_Security_UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.ControlBox = false;
            this.Controls.Add(this.mtxt_EUser);
            this.Controls.Add(this.mTile);
            this.Controls.Add(this.mbtn_Ok);
            this.Controls.Add(this.mbtn_Cancel);
            this.Controls.Add(this.metroPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Security_UserProfile";
            this.Text = "Continental - ADAM Functional Test Bench - User Profile";
            this.Load += new System.EventHandler(this.Form_Security_UserProfile_Load);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox mtxt_EPassword;
        private System.Windows.Forms.RadioButton rad_RBAdmin;
        private System.Windows.Forms.RadioButton rad_RBOperator;
        private System.Windows.Forms.RadioButton rad_RBUser;
        private MetroFramework.Controls.MetroLabel mlbl_LPassword;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton mbtn_Ok;
        private MetroFramework.Controls.MetroButton mbtn_Cancel;
        private MetroFramework.Controls.MetroTile mTile;
        private MetroFramework.Controls.MetroTextBox mtxt_EUser;
    }
}