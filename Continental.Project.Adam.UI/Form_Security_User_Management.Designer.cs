
namespace Continental.Project.Adam.UI
{
    partial class Form_Security_User_Management
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Security_User_Management));
            this.ILExplorer = new System.Windows.Forms.ImageList(this.components);
            this.DlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.DlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.mbtn_Close = new MetroFramework.Controls.MetroButton();
            this.tbc_UsersManagement = new System.Windows.Forms.TabControl();
            this.tab_UserView = new System.Windows.Forms.TabPage();
            this.tab_UserAdd_grpUserView = new System.Windows.Forms.GroupBox();
            this.tab_UserAdd = new System.Windows.Forms.TabPage();
            this.tab_UserAdd_grpUserAdd = new System.Windows.Forms.GroupBox();
            this.tab_UserAdd_mcbo_Profile = new MetroFramework.Controls.MetroComboBox();
            this.tab_UserAdd_mlbl_Password = new MetroFramework.Controls.MetroLabel();
            this.tab_UserAdd_mlbl_Name = new MetroFramework.Controls.MetroLabel();
            this.tab_UserAdd_mlbl_Profile = new MetroFramework.Controls.MetroLabel();
            this.tab_UserAdd_mtxt_ULogin = new MetroFramework.Controls.MetroTextBox();
            this.tab_UserAdd_mlbl_UserName = new MetroFramework.Controls.MetroLabel();
            this.tab_UserAdd_mtxt_UPass = new MetroFramework.Controls.MetroTextBox();
            this.tab_UserAdd_mtxt_UName = new MetroFramework.Controls.MetroTextBox();
            this.tab_UserAdd_mbtn_UserAdd = new MetroFramework.Controls.MetroButton();
            this.tab_UserUpdate = new System.Windows.Forms.TabPage();
            this.tab_UserAdd_grpUserEdit = new System.Windows.Forms.GroupBox();
            this.tab_UserEdit_mcbo_UserName = new MetroFramework.Controls.MetroComboBox();
            this.tab_UserEdit_mlbl_UserName = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.tab_UserEdit_mlbl_Name = new MetroFramework.Controls.MetroLabel();
            this.mbtn_UserEdit = new MetroFramework.Controls.MetroButton();
            this.mbtn_UserEditEnable = new MetroFramework.Controls.MetroButton();
            this.tab_UserDelete = new System.Windows.Forms.TabPage();
            this.tab_UserAdd_grpUserDelete = new System.Windows.Forms.GroupBox();
            this.tab_UserDelete_mcbo_UserName = new MetroFramework.Controls.MetroComboBox();
            this.tab_UserDelete_mlbl_UserName = new MetroFramework.Controls.MetroLabel();
            this.mbtn_UserDelete = new MetroFramework.Controls.MetroButton();
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.mtxt_Information = new MetroFramework.Controls.MetroTextBox();
            this.grid_Users = new System.Windows.Forms.DataGridView();
            this.tbc_UsersManagement.SuspendLayout();
            this.tab_UserView.SuspendLayout();
            this.tab_UserAdd_grpUserView.SuspendLayout();
            this.tab_UserAdd.SuspendLayout();
            this.tab_UserAdd_grpUserAdd.SuspendLayout();
            this.tab_UserUpdate.SuspendLayout();
            this.tab_UserAdd_grpUserEdit.SuspendLayout();
            this.tab_UserDelete.SuspendLayout();
            this.tab_UserAdd_grpUserDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // ILExplorer
            // 
            this.ILExplorer.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ILExplorer.ImageSize = new System.Drawing.Size(16, 16);
            this.ILExplorer.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DlgOpenFile
            // 
            this.DlgOpenFile.FileName = "openFileDialog1";
            // 
            // mbtn_Close
            // 
            this.mbtn_Close.Location = new System.Drawing.Point(635, 510);
            this.mbtn_Close.Name = "mbtn_Close";
            this.mbtn_Close.Size = new System.Drawing.Size(135, 45);
            this.mbtn_Close.TabIndex = 26;
            this.mbtn_Close.Text = "&Close";
            this.mbtn_Close.UseSelectable = true;
            this.mbtn_Close.Click += new System.EventHandler(this.mbtn_Close_Click);
            // 
            // tbc_UsersManagement
            // 
            this.tbc_UsersManagement.Controls.Add(this.tab_UserView);
            this.tbc_UsersManagement.Controls.Add(this.tab_UserAdd);
            this.tbc_UsersManagement.Controls.Add(this.tab_UserUpdate);
            this.tbc_UsersManagement.Controls.Add(this.tab_UserDelete);
            this.tbc_UsersManagement.Location = new System.Drawing.Point(10, 110);
            this.tbc_UsersManagement.Name = "tbc_UsersManagement";
            this.tbc_UsersManagement.SelectedIndex = 0;
            this.tbc_UsersManagement.Size = new System.Drawing.Size(765, 392);
            this.tbc_UsersManagement.TabIndex = 25;
            // 
            // tab_UserView
            // 
            this.tab_UserView.Controls.Add(this.tab_UserAdd_grpUserView);
            this.tab_UserView.Location = new System.Drawing.Point(4, 22);
            this.tab_UserView.Name = "tab_UserView";
            this.tab_UserView.Size = new System.Drawing.Size(757, 366);
            this.tab_UserView.TabIndex = 3;
            this.tab_UserView.Text = "User View";
            this.tab_UserView.UseVisualStyleBackColor = true;
            // 
            // tab_UserAdd_grpUserView
            // 
            this.tab_UserAdd_grpUserView.Controls.Add(this.grid_Users);
            this.tab_UserAdd_grpUserView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserAdd_grpUserView.Location = new System.Drawing.Point(2, 15);
            this.tab_UserAdd_grpUserView.Name = "tab_UserAdd_grpUserView";
            this.tab_UserAdd_grpUserView.Size = new System.Drawing.Size(750, 350);
            this.tab_UserAdd_grpUserView.TabIndex = 13;
            this.tab_UserAdd_grpUserView.TabStop = false;
            this.tab_UserAdd_grpUserView.Text = "VIEW USER";
            // 
            // tab_UserAdd
            // 
            this.tab_UserAdd.Controls.Add(this.tab_UserAdd_grpUserAdd);
            this.tab_UserAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserAdd.Location = new System.Drawing.Point(4, 22);
            this.tab_UserAdd.Name = "tab_UserAdd";
            this.tab_UserAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tab_UserAdd.Size = new System.Drawing.Size(757, 366);
            this.tab_UserAdd.TabIndex = 0;
            this.tab_UserAdd.Text = "User Add";
            this.tab_UserAdd.UseVisualStyleBackColor = true;
            // 
            // tab_UserAdd_grpUserAdd
            // 
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mcbo_Profile);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mlbl_Password);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mlbl_Name);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mlbl_Profile);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mtxt_ULogin);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mlbl_UserName);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mtxt_UPass);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mtxt_UName);
            this.tab_UserAdd_grpUserAdd.Controls.Add(this.tab_UserAdd_mbtn_UserAdd);
            this.tab_UserAdd_grpUserAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserAdd_grpUserAdd.Location = new System.Drawing.Point(2, 15);
            this.tab_UserAdd_grpUserAdd.Name = "tab_UserAdd_grpUserAdd";
            this.tab_UserAdd_grpUserAdd.Size = new System.Drawing.Size(750, 350);
            this.tab_UserAdd_grpUserAdd.TabIndex = 1;
            this.tab_UserAdd_grpUserAdd.TabStop = false;
            this.tab_UserAdd_grpUserAdd.Text = "ADD USER";
            // 
            // tab_UserAdd_mcbo_Profile
            // 
            this.tab_UserAdd_mcbo_Profile.FormattingEnabled = true;
            this.tab_UserAdd_mcbo_Profile.ItemHeight = 23;
            this.tab_UserAdd_mcbo_Profile.Location = new System.Drawing.Point(265, 120);
            this.tab_UserAdd_mcbo_Profile.Margin = new System.Windows.Forms.Padding(2);
            this.tab_UserAdd_mcbo_Profile.Name = "tab_UserAdd_mcbo_Profile";
            this.tab_UserAdd_mcbo_Profile.Size = new System.Drawing.Size(200, 29);
            this.tab_UserAdd_mcbo_Profile.Style = MetroFramework.MetroColorStyle.Orange;
            this.tab_UserAdd_mcbo_Profile.TabIndex = 123;
            this.tab_UserAdd_mcbo_Profile.UseSelectable = true;
            // 
            // tab_UserAdd_mlbl_Password
            // 
            this.tab_UserAdd_mlbl_Password.AutoSize = true;
            this.tab_UserAdd_mlbl_Password.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserAdd_mlbl_Password.Location = new System.Drawing.Point(130, 210);
            this.tab_UserAdd_mlbl_Password.Name = "tab_UserAdd_mlbl_Password";
            this.tab_UserAdd_mlbl_Password.Size = new System.Drawing.Size(81, 19);
            this.tab_UserAdd_mlbl_Password.TabIndex = 36;
            this.tab_UserAdd_mlbl_Password.Text = "Password :";
            // 
            // tab_UserAdd_mlbl_Name
            // 
            this.tab_UserAdd_mlbl_Name.AutoSize = true;
            this.tab_UserAdd_mlbl_Name.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserAdd_mlbl_Name.Location = new System.Drawing.Point(130, 90);
            this.tab_UserAdd_mlbl_Name.Name = "tab_UserAdd_mlbl_Name";
            this.tab_UserAdd_mlbl_Name.Size = new System.Drawing.Size(57, 19);
            this.tab_UserAdd_mlbl_Name.TabIndex = 35;
            this.tab_UserAdd_mlbl_Name.Text = "Name :";
            // 
            // tab_UserAdd_mlbl_Profile
            // 
            this.tab_UserAdd_mlbl_Profile.AutoSize = true;
            this.tab_UserAdd_mlbl_Profile.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserAdd_mlbl_Profile.Location = new System.Drawing.Point(130, 130);
            this.tab_UserAdd_mlbl_Profile.Name = "tab_UserAdd_mlbl_Profile";
            this.tab_UserAdd_mlbl_Profile.Size = new System.Drawing.Size(62, 19);
            this.tab_UserAdd_mlbl_Profile.TabIndex = 34;
            this.tab_UserAdd_mlbl_Profile.Text = "Profile :";
            // 
            // tab_UserAdd_mtxt_ULogin
            // 
            // 
            // 
            // 
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Image = null;
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Name = "";
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tab_UserAdd_mtxt_ULogin.CustomButton.TabIndex = 1;
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tab_UserAdd_mtxt_ULogin.CustomButton.UseSelectable = true;
            this.tab_UserAdd_mtxt_ULogin.CustomButton.Visible = false;
            this.tab_UserAdd_mtxt_ULogin.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tab_UserAdd_mtxt_ULogin.Lines = new string[0];
            this.tab_UserAdd_mtxt_ULogin.Location = new System.Drawing.Point(265, 160);
            this.tab_UserAdd_mtxt_ULogin.MaxLength = 32767;
            this.tab_UserAdd_mtxt_ULogin.Name = "tab_UserAdd_mtxt_ULogin";
            this.tab_UserAdd_mtxt_ULogin.PasswordChar = '\0';
            this.tab_UserAdd_mtxt_ULogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tab_UserAdd_mtxt_ULogin.SelectedText = "";
            this.tab_UserAdd_mtxt_ULogin.SelectionLength = 0;
            this.tab_UserAdd_mtxt_ULogin.SelectionStart = 0;
            this.tab_UserAdd_mtxt_ULogin.ShortcutsEnabled = true;
            this.tab_UserAdd_mtxt_ULogin.Size = new System.Drawing.Size(200, 30);
            this.tab_UserAdd_mtxt_ULogin.TabIndex = 31;
            this.tab_UserAdd_mtxt_ULogin.UseSelectable = true;
            this.tab_UserAdd_mtxt_ULogin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tab_UserAdd_mtxt_ULogin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tab_UserAdd_mlbl_UserName
            // 
            this.tab_UserAdd_mlbl_UserName.AutoSize = true;
            this.tab_UserAdd_mlbl_UserName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserAdd_mlbl_UserName.Location = new System.Drawing.Point(130, 170);
            this.tab_UserAdd_mlbl_UserName.Name = "tab_UserAdd_mlbl_UserName";
            this.tab_UserAdd_mlbl_UserName.Size = new System.Drawing.Size(87, 19);
            this.tab_UserAdd_mlbl_UserName.TabIndex = 33;
            this.tab_UserAdd_mlbl_UserName.Text = "UserName :";
            // 
            // tab_UserAdd_mtxt_UPass
            // 
            // 
            // 
            // 
            this.tab_UserAdd_mtxt_UPass.CustomButton.Image = null;
            this.tab_UserAdd_mtxt_UPass.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.tab_UserAdd_mtxt_UPass.CustomButton.Name = "";
            this.tab_UserAdd_mtxt_UPass.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tab_UserAdd_mtxt_UPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tab_UserAdd_mtxt_UPass.CustomButton.TabIndex = 1;
            this.tab_UserAdd_mtxt_UPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tab_UserAdd_mtxt_UPass.CustomButton.UseSelectable = true;
            this.tab_UserAdd_mtxt_UPass.CustomButton.Visible = false;
            this.tab_UserAdd_mtxt_UPass.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tab_UserAdd_mtxt_UPass.Lines = new string[0];
            this.tab_UserAdd_mtxt_UPass.Location = new System.Drawing.Point(265, 200);
            this.tab_UserAdd_mtxt_UPass.MaxLength = 32767;
            this.tab_UserAdd_mtxt_UPass.Name = "tab_UserAdd_mtxt_UPass";
            this.tab_UserAdd_mtxt_UPass.PasswordChar = '\0';
            this.tab_UserAdd_mtxt_UPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tab_UserAdd_mtxt_UPass.SelectedText = "";
            this.tab_UserAdd_mtxt_UPass.SelectionLength = 0;
            this.tab_UserAdd_mtxt_UPass.SelectionStart = 0;
            this.tab_UserAdd_mtxt_UPass.ShortcutsEnabled = true;
            this.tab_UserAdd_mtxt_UPass.Size = new System.Drawing.Size(200, 30);
            this.tab_UserAdd_mtxt_UPass.TabIndex = 32;
            this.tab_UserAdd_mtxt_UPass.UseSelectable = true;
            this.tab_UserAdd_mtxt_UPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tab_UserAdd_mtxt_UPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tab_UserAdd_mtxt_UName
            // 
            // 
            // 
            // 
            this.tab_UserAdd_mtxt_UName.CustomButton.Image = null;
            this.tab_UserAdd_mtxt_UName.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.tab_UserAdd_mtxt_UName.CustomButton.Name = "";
            this.tab_UserAdd_mtxt_UName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tab_UserAdd_mtxt_UName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tab_UserAdd_mtxt_UName.CustomButton.TabIndex = 1;
            this.tab_UserAdd_mtxt_UName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tab_UserAdd_mtxt_UName.CustomButton.UseSelectable = true;
            this.tab_UserAdd_mtxt_UName.CustomButton.Visible = false;
            this.tab_UserAdd_mtxt_UName.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tab_UserAdd_mtxt_UName.Lines = new string[0];
            this.tab_UserAdd_mtxt_UName.Location = new System.Drawing.Point(265, 80);
            this.tab_UserAdd_mtxt_UName.MaxLength = 32767;
            this.tab_UserAdd_mtxt_UName.Name = "tab_UserAdd_mtxt_UName";
            this.tab_UserAdd_mtxt_UName.PasswordChar = '\0';
            this.tab_UserAdd_mtxt_UName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tab_UserAdd_mtxt_UName.SelectedText = "";
            this.tab_UserAdd_mtxt_UName.SelectionLength = 0;
            this.tab_UserAdd_mtxt_UName.SelectionStart = 0;
            this.tab_UserAdd_mtxt_UName.ShortcutsEnabled = true;
            this.tab_UserAdd_mtxt_UName.Size = new System.Drawing.Size(200, 30);
            this.tab_UserAdd_mtxt_UName.TabIndex = 29;
            this.tab_UserAdd_mtxt_UName.UseSelectable = true;
            this.tab_UserAdd_mtxt_UName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tab_UserAdd_mtxt_UName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tab_UserAdd_mbtn_UserAdd
            // 
            this.tab_UserAdd_mbtn_UserAdd.Location = new System.Drawing.Point(300, 270);
            this.tab_UserAdd_mbtn_UserAdd.Name = "tab_UserAdd_mbtn_UserAdd";
            this.tab_UserAdd_mbtn_UserAdd.Size = new System.Drawing.Size(135, 45);
            this.tab_UserAdd_mbtn_UserAdd.TabIndex = 28;
            this.tab_UserAdd_mbtn_UserAdd.Text = "&Add User";
            this.tab_UserAdd_mbtn_UserAdd.UseSelectable = true;
            this.tab_UserAdd_mbtn_UserAdd.Click += new System.EventHandler(this.tab_UserAdd_mbtn_UserAdd_Click);
            // 
            // tab_UserUpdate
            // 
            this.tab_UserUpdate.Controls.Add(this.tab_UserAdd_grpUserEdit);
            this.tab_UserUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserUpdate.Location = new System.Drawing.Point(4, 22);
            this.tab_UserUpdate.Name = "tab_UserUpdate";
            this.tab_UserUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tab_UserUpdate.Size = new System.Drawing.Size(757, 366);
            this.tab_UserUpdate.TabIndex = 1;
            this.tab_UserUpdate.Text = "User Update";
            this.tab_UserUpdate.UseVisualStyleBackColor = true;
            // 
            // tab_UserAdd_grpUserEdit
            // 
            this.tab_UserAdd_grpUserEdit.Controls.Add(this.tab_UserEdit_mcbo_UserName);
            this.tab_UserAdd_grpUserEdit.Controls.Add(this.tab_UserEdit_mlbl_UserName);
            this.tab_UserAdd_grpUserEdit.Controls.Add(this.metroTextBox1);
            this.tab_UserAdd_grpUserEdit.Controls.Add(this.tab_UserEdit_mlbl_Name);
            this.tab_UserAdd_grpUserEdit.Controls.Add(this.mbtn_UserEdit);
            this.tab_UserAdd_grpUserEdit.Controls.Add(this.mbtn_UserEditEnable);
            this.tab_UserAdd_grpUserEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserAdd_grpUserEdit.Location = new System.Drawing.Point(2, 15);
            this.tab_UserAdd_grpUserEdit.Name = "tab_UserAdd_grpUserEdit";
            this.tab_UserAdd_grpUserEdit.Size = new System.Drawing.Size(750, 350);
            this.tab_UserAdd_grpUserEdit.TabIndex = 9;
            this.tab_UserAdd_grpUserEdit.TabStop = false;
            this.tab_UserAdd_grpUserEdit.Text = "EDIT USER";
            // 
            // tab_UserEdit_mcbo_UserName
            // 
            this.tab_UserEdit_mcbo_UserName.FormattingEnabled = true;
            this.tab_UserEdit_mcbo_UserName.ItemHeight = 23;
            this.tab_UserEdit_mcbo_UserName.Location = new System.Drawing.Point(265, 80);
            this.tab_UserEdit_mcbo_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.tab_UserEdit_mcbo_UserName.Name = "tab_UserEdit_mcbo_UserName";
            this.tab_UserEdit_mcbo_UserName.Size = new System.Drawing.Size(200, 29);
            this.tab_UserEdit_mcbo_UserName.Style = MetroFramework.MetroColorStyle.Orange;
            this.tab_UserEdit_mcbo_UserName.TabIndex = 127;
            this.tab_UserEdit_mcbo_UserName.UseSelectable = true;
            // 
            // tab_UserEdit_mlbl_UserName
            // 
            this.tab_UserEdit_mlbl_UserName.AutoSize = true;
            this.tab_UserEdit_mlbl_UserName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserEdit_mlbl_UserName.Location = new System.Drawing.Point(130, 90);
            this.tab_UserEdit_mlbl_UserName.Name = "tab_UserEdit_mlbl_UserName";
            this.tab_UserEdit_mlbl_UserName.Size = new System.Drawing.Size(87, 19);
            this.tab_UserEdit_mlbl_UserName.TabIndex = 126;
            this.tab_UserEdit_mlbl_UserName.Text = "UserName :";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(265, 120);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(200, 30);
            this.metroTextBox1.TabIndex = 124;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tab_UserEdit_mlbl_Name
            // 
            this.tab_UserEdit_mlbl_Name.AutoSize = true;
            this.tab_UserEdit_mlbl_Name.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserEdit_mlbl_Name.Location = new System.Drawing.Point(130, 130);
            this.tab_UserEdit_mlbl_Name.Name = "tab_UserEdit_mlbl_Name";
            this.tab_UserEdit_mlbl_Name.Size = new System.Drawing.Size(57, 19);
            this.tab_UserEdit_mlbl_Name.TabIndex = 125;
            this.tab_UserEdit_mlbl_Name.Text = "Name :";
            // 
            // mbtn_UserEdit
            // 
            this.mbtn_UserEdit.Location = new System.Drawing.Point(300, 270);
            this.mbtn_UserEdit.Name = "mbtn_UserEdit";
            this.mbtn_UserEdit.Size = new System.Drawing.Size(135, 45);
            this.mbtn_UserEdit.TabIndex = 27;
            this.mbtn_UserEdit.Text = "&Update User";
            this.mbtn_UserEdit.UseSelectable = true;
            this.mbtn_UserEdit.Click += new System.EventHandler(this.mbtn_UserEdit_Click);
            // 
            // mbtn_UserEditEnable
            // 
            this.mbtn_UserEditEnable.Location = new System.Drawing.Point(471, 90);
            this.mbtn_UserEditEnable.Name = "mbtn_UserEditEnable";
            this.mbtn_UserEditEnable.Size = new System.Drawing.Size(135, 45);
            this.mbtn_UserEditEnable.TabIndex = 27;
            this.mbtn_UserEditEnable.Text = "&Edit";
            this.mbtn_UserEditEnable.UseSelectable = true;
            this.mbtn_UserEditEnable.Click += new System.EventHandler(this.mbtn_UserEditEnable_Click);
            // 
            // tab_UserDelete
            // 
            this.tab_UserDelete.Controls.Add(this.tab_UserAdd_grpUserDelete);
            this.tab_UserDelete.Location = new System.Drawing.Point(4, 22);
            this.tab_UserDelete.Name = "tab_UserDelete";
            this.tab_UserDelete.Size = new System.Drawing.Size(757, 366);
            this.tab_UserDelete.TabIndex = 2;
            this.tab_UserDelete.Text = "User Delete";
            this.tab_UserDelete.UseVisualStyleBackColor = true;
            // 
            // tab_UserAdd_grpUserDelete
            // 
            this.tab_UserAdd_grpUserDelete.Controls.Add(this.tab_UserDelete_mcbo_UserName);
            this.tab_UserAdd_grpUserDelete.Controls.Add(this.tab_UserDelete_mlbl_UserName);
            this.tab_UserAdd_grpUserDelete.Controls.Add(this.mbtn_UserDelete);
            this.tab_UserAdd_grpUserDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserAdd_grpUserDelete.Location = new System.Drawing.Point(2, 15);
            this.tab_UserAdd_grpUserDelete.Name = "tab_UserAdd_grpUserDelete";
            this.tab_UserAdd_grpUserDelete.Size = new System.Drawing.Size(750, 350);
            this.tab_UserAdd_grpUserDelete.TabIndex = 11;
            this.tab_UserAdd_grpUserDelete.TabStop = false;
            this.tab_UserAdd_grpUserDelete.Text = "DELETE USER";
            // 
            // tab_UserDelete_mcbo_UserName
            // 
            this.tab_UserDelete_mcbo_UserName.FormattingEnabled = true;
            this.tab_UserDelete_mcbo_UserName.ItemHeight = 23;
            this.tab_UserDelete_mcbo_UserName.Location = new System.Drawing.Point(265, 80);
            this.tab_UserDelete_mcbo_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.tab_UserDelete_mcbo_UserName.Name = "tab_UserDelete_mcbo_UserName";
            this.tab_UserDelete_mcbo_UserName.Size = new System.Drawing.Size(200, 29);
            this.tab_UserDelete_mcbo_UserName.Style = MetroFramework.MetroColorStyle.Orange;
            this.tab_UserDelete_mcbo_UserName.TabIndex = 129;
            this.tab_UserDelete_mcbo_UserName.UseSelectable = true;
            // 
            // tab_UserDelete_mlbl_UserName
            // 
            this.tab_UserDelete_mlbl_UserName.AutoSize = true;
            this.tab_UserDelete_mlbl_UserName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.tab_UserDelete_mlbl_UserName.Location = new System.Drawing.Point(130, 90);
            this.tab_UserDelete_mlbl_UserName.Name = "tab_UserDelete_mlbl_UserName";
            this.tab_UserDelete_mlbl_UserName.Size = new System.Drawing.Size(87, 19);
            this.tab_UserDelete_mlbl_UserName.TabIndex = 128;
            this.tab_UserDelete_mlbl_UserName.Text = "UserName :";
            // 
            // mbtn_UserDelete
            // 
            this.mbtn_UserDelete.Location = new System.Drawing.Point(300, 270);
            this.mbtn_UserDelete.Name = "mbtn_UserDelete";
            this.mbtn_UserDelete.Size = new System.Drawing.Size(135, 45);
            this.mbtn_UserDelete.TabIndex = 27;
            this.mbtn_UserDelete.Text = "&Delete User";
            this.mbtn_UserDelete.UseSelectable = true;
            this.mbtn_UserDelete.Click += new System.EventHandler(this.mbtn_UserDelete_Click);
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(785, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 24;
            this.mTile.Text = "Users Management";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // mtxt_Information
            // 
            // 
            // 
            // 
            this.mtxt_Information.CustomButton.Image = null;
            this.mtxt_Information.CustomButton.Location = new System.Drawing.Point(737, 2);
            this.mtxt_Information.CustomButton.Name = "";
            this.mtxt_Information.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_Information.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Information.CustomButton.TabIndex = 1;
            this.mtxt_Information.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Information.CustomButton.UseSelectable = true;
            this.mtxt_Information.CustomButton.Visible = false;
            this.mtxt_Information.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Information.Lines = new string[0];
            this.mtxt_Information.Location = new System.Drawing.Point(10, 70);
            this.mtxt_Information.MaxLength = 32767;
            this.mtxt_Information.Name = "mtxt_Information";
            this.mtxt_Information.PasswordChar = '\0';
            this.mtxt_Information.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Information.SelectedText = "";
            this.mtxt_Information.SelectionLength = 0;
            this.mtxt_Information.SelectionStart = 0;
            this.mtxt_Information.ShortcutsEnabled = true;
            this.mtxt_Information.Size = new System.Drawing.Size(765, 30);
            this.mtxt_Information.Style = MetroFramework.MetroColorStyle.Orange;
            this.mtxt_Information.TabIndex = 29;
            this.mtxt_Information.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_Information.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mtxt_Information.UseSelectable = true;
            this.mtxt_Information.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Information.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // grid_Users
            // 
            this.grid_Users.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Users.Location = new System.Drawing.Point(7, 30);
            this.grid_Users.MultiSelect = false;
            this.grid_Users.Name = "grid_Users";
            this.grid_Users.ReadOnly = true;
            this.grid_Users.RowHeadersWidth = 51;
            this.grid_Users.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grid_Users.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Users.Size = new System.Drawing.Size(735, 300);
            this.grid_Users.TabIndex = 95;
            // 
            // Form_Security_User_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.mtxt_Information);
            this.Controls.Add(this.mbtn_Close);
            this.Controls.Add(this.tbc_UsersManagement);
            this.Controls.Add(this.mTile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Security_User_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Continental - ADAM Functional Test Bench - Management User";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Operational_Project_FormClosed);
            this.Load += new System.EventHandler(this.Form_Operational_Project_Load);
            this.tbc_UsersManagement.ResumeLayout(false);
            this.tab_UserView.ResumeLayout(false);
            this.tab_UserAdd_grpUserView.ResumeLayout(false);
            this.tab_UserAdd.ResumeLayout(false);
            this.tab_UserAdd_grpUserAdd.ResumeLayout(false);
            this.tab_UserAdd_grpUserAdd.PerformLayout();
            this.tab_UserUpdate.ResumeLayout(false);
            this.tab_UserAdd_grpUserEdit.ResumeLayout(false);
            this.tab_UserAdd_grpUserEdit.PerformLayout();
            this.tab_UserDelete.ResumeLayout(false);
            this.tab_UserAdd_grpUserDelete.ResumeLayout(false);
            this.tab_UserAdd_grpUserDelete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Users)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ILExplorer;
        private System.Windows.Forms.OpenFileDialog DlgOpenFile;
        private System.Windows.Forms.SaveFileDialog DlgSaveFile;
        private MetroFramework.Controls.MetroButton mbtn_Close;
        private System.Windows.Forms.TabControl tbc_UsersManagement;
        private System.Windows.Forms.TabPage tab_UserAdd;
        private System.Windows.Forms.TabPage tab_UserUpdate;
        private MetroFramework.Controls.MetroTile mTile;
        private System.Windows.Forms.TabPage tab_UserDelete;
        private System.Windows.Forms.TabPage tab_UserView;
        private System.Windows.Forms.GroupBox tab_UserAdd_grpUserAdd;
        private System.Windows.Forms.GroupBox tab_UserAdd_grpUserEdit;
        private System.Windows.Forms.GroupBox tab_UserAdd_grpUserDelete;
        private System.Windows.Forms.GroupBox tab_UserAdd_grpUserView;
        private MetroFramework.Controls.MetroButton mbtn_UserDelete;
        private MetroFramework.Controls.MetroButton tab_UserAdd_mbtn_UserAdd;
        private MetroFramework.Controls.MetroButton mbtn_UserEdit;
        private MetroFramework.Controls.MetroLabel tab_UserAdd_mlbl_Password;
        private MetroFramework.Controls.MetroLabel tab_UserAdd_mlbl_Name;
        private MetroFramework.Controls.MetroLabel tab_UserAdd_mlbl_Profile;
        private MetroFramework.Controls.MetroTextBox tab_UserAdd_mtxt_ULogin;
        private MetroFramework.Controls.MetroLabel tab_UserAdd_mlbl_UserName;
        private MetroFramework.Controls.MetroTextBox tab_UserAdd_mtxt_UPass;
        private MetroFramework.Controls.MetroTextBox tab_UserAdd_mtxt_UName;
        private MetroFramework.Controls.MetroComboBox tab_UserAdd_mcbo_Profile;
        private MetroFramework.Controls.MetroTextBox mtxt_Information;
        private MetroFramework.Controls.MetroComboBox tab_UserEdit_mcbo_UserName;
        private MetroFramework.Controls.MetroLabel tab_UserEdit_mlbl_UserName;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel tab_UserEdit_mlbl_Name;
        private MetroFramework.Controls.MetroButton mbtn_UserEditEnable;
        private MetroFramework.Controls.MetroComboBox tab_UserDelete_mcbo_UserName;
        private MetroFramework.Controls.MetroLabel tab_UserDelete_mlbl_UserName;
        private System.Windows.Forms.DataGridView grid_Users;
    }
}