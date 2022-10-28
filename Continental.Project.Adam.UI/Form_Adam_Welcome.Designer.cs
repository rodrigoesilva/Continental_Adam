
namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_Welcome));
            this.picContinental = new System.Windows.Forms.PictureBox();
            this.grp_login = new System.Windows.Forms.GroupBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_LoginName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).BeginInit();
            this.grp_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // picContinental
            // 
            this.picContinental.Image = ((System.Drawing.Image)(resources.GetObject("picContinental.Image")));
            this.picContinental.Location = new System.Drawing.Point(765, 475);
            this.picContinental.Name = "picContinental";
            this.picContinental.Size = new System.Drawing.Size(405, 124);
            this.picContinental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picContinental.TabIndex = 0;
            this.picContinental.TabStop = false;
            this.picContinental.Click += new System.EventHandler(this.picContinental_Click);
            // 
            // grp_login
            // 
            this.grp_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.grp_login.Controls.Add(this.btnlogin);
            this.grp_login.Controls.Add(this.picLogin);
            this.grp_login.Controls.Add(this.lbl_Info);
            this.grp_login.Controls.Add(this.txtpass);
            this.grp_login.Controls.Add(this.txtname);
            this.grp_login.Controls.Add(this.lbl_Password);
            this.grp_login.Controls.Add(this.lbl_LoginName);
            this.grp_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_login.ForeColor = System.Drawing.Color.DarkOrange;
            this.grp_login.Location = new System.Drawing.Point(580, 340);
            this.grp_login.Name = "grp_login";
            this.grp_login.Size = new System.Drawing.Size(760, 400);
            this.grp_login.TabIndex = 44;
            this.grp_login.TabStop = false;
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.DarkOrange;
            this.btnlogin.ForeColor = System.Drawing.Color.Black;
            this.btnlogin.Location = new System.Drawing.Point(197, 322);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(370, 45);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // picLogin
            // 
            this.picLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.picLogin.Image = ((System.Drawing.Image)(resources.GetObject("picLogin.Image")));
            this.picLogin.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogin.InitialImage")));
            this.picLogin.Location = new System.Drawing.Point(362, 80);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(60, 63);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogin.TabIndex = 45;
            this.picLogin.TabStop = false;
            // 
            // lbl_Info
            // 
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lbl_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Info.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_Info.Location = new System.Drawing.Point(275, 35);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(227, 26);
            this.lbl_Info.TabIndex = 44;
            this.lbl_Info.Text = "LOGIN TO SYSTEM";
            // 
            // txtpass
            // 
            this.txtpass.BackColor = System.Drawing.Color.White;
            this.txtpass.Location = new System.Drawing.Point(345, 247);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(222, 23);
            this.txtpass.TabIndex = 3;
            this.txtpass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpass_KeyPress);
            // 
            // txtname
            // 
            this.txtname.BackColor = System.Drawing.Color.White;
            this.txtname.Location = new System.Drawing.Point(345, 179);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(222, 23);
            this.txtname.TabIndex = 2;
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtname_KeyPress);
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_Password.Location = new System.Drawing.Point(192, 243);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(130, 26);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Password :";
            // 
            // lbl_LoginName
            // 
            this.lbl_LoginName.AutoSize = true;
            this.lbl_LoginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoginName.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbl_LoginName.Location = new System.Drawing.Point(192, 175);
            this.lbl_LoginName.Name = "lbl_LoginName";
            this.lbl_LoginName.Size = new System.Drawing.Size(84, 26);
            this.lbl_LoginName.TabIndex = 0;
            this.lbl_LoginName.Text = "Login :";
            // 
            // Form_Adam_Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.picContinental);
            this.Controls.Add(this.grp_login);
            this.DoubleBuffered = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Movable = false;
            this.Name = "Form_Adam_Welcome";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Continental - ADAM Functional Test Bench";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Adam_Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).EndInit();
            this.grp_login.ResumeLayout(false);
            this.grp_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picContinental;
        private System.Windows.Forms.GroupBox grp_login;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_LoginName;
    }
}