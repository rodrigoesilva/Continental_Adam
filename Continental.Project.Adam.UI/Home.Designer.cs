namespace Continental.Project.Adam.UI
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemToolStrip_Home = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Home_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Home_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Home_About = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStrip_Project = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Project_Project = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Project_PrintGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Project_PrintParamList = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Project_SetupPrinter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Project_ExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStrip_TestProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_SelectTestProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_STop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_CreateUserDefinedTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_ManualActuation = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_Calibration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_TestProg_Bleed = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_TestProg_SaveTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolStrip_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Settings_SoftwareMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Settings_Account = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_SelectAccessLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Account_NewPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.subMenu_Account_UserAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_UserEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_UserDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenu_Account_UserReport = new System.Windows.Forms.ToolStripMenuItem();
            this.picContinental = new System.Windows.Forms.PictureBox();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.grp_login = new System.Windows.Forms.GroupBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_LoginName = new System.Windows.Forms.Label();
            this.stsBar_STBMain = new System.Windows.Forms.StatusStrip();
            this.tStatusLabel01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusLabel02 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusLabel03 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStatusLabel04 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_Clock = new System.Windows.Forms.Timer(this.components);
            this.timer_GlobalBatch = new System.Windows.Forms.Timer(this.components);
            this.timer_GlobalPolling = new System.Windows.Forms.Timer(this.components);
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.grp_login.SuspendLayout();
            this.stsBar_STBMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemToolStrip_Home,
            this.menuItemToolStrip_Project,
            this.menuItemToolStrip_TestProgram,
            this.menuItemToolStrip_Settings});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(1920, 24);
            this.menuStrip.TabIndex = 38;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuItemToolStrip_Home
            // 
            this.menuItemToolStrip_Home.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Home_Logout,
            this.subMenu_Home_Exit,
            this.toolStripSeparator6,
            this.subMenu_Home_About});
            this.menuItemToolStrip_Home.Name = "menuItemToolStrip_Home";
            this.menuItemToolStrip_Home.Size = new System.Drawing.Size(54, 22);
            this.menuItemToolStrip_Home.Text = "HOME";
            // 
            // subMenu_Home_Logout
            // 
            this.subMenu_Home_Logout.Name = "subMenu_Home_Logout";
            this.subMenu_Home_Logout.Size = new System.Drawing.Size(112, 22);
            this.subMenu_Home_Logout.Text = "Logout";
            this.subMenu_Home_Logout.Visible = false;
            this.subMenu_Home_Logout.Click += new System.EventHandler(this.subMenu_Home_Logout_Click);
            // 
            // subMenu_Home_Exit
            // 
            this.subMenu_Home_Exit.Name = "subMenu_Home_Exit";
            this.subMenu_Home_Exit.Size = new System.Drawing.Size(112, 22);
            this.subMenu_Home_Exit.Text = "Exit";
            this.subMenu_Home_Exit.Click += new System.EventHandler(this.subMenu_Home_Exit_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(109, 6);
            // 
            // subMenu_Home_About
            // 
            this.subMenu_Home_About.Name = "subMenu_Home_About";
            this.subMenu_Home_About.Size = new System.Drawing.Size(112, 22);
            this.subMenu_Home_About.Text = "About";
            this.subMenu_Home_About.Click += new System.EventHandler(this.subMenu_Home_About_Click);
            // 
            // menuItemToolStrip_Project
            // 
            this.menuItemToolStrip_Project.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Project_Project,
            this.toolStripSeparator1,
            this.subMenu_Project_PrintGraphics,
            this.subMenu_Project_PrintParamList,
            this.subMenu_Project_SetupPrinter,
            this.toolStripSeparator2,
            this.subMenu_Project_ExportExcel});
            this.menuItemToolStrip_Project.Enabled = false;
            this.menuItemToolStrip_Project.Name = "menuItemToolStrip_Project";
            this.menuItemToolStrip_Project.ShortcutKeyDisplayString = "";
            this.menuItemToolStrip_Project.Size = new System.Drawing.Size(66, 22);
            this.menuItemToolStrip_Project.Text = "PROJECT";
            // 
            // subMenu_Project_Project
            // 
            this.subMenu_Project_Project.Name = "subMenu_Project_Project";
            this.subMenu_Project_Project.ShortcutKeyDisplayString = "";
            this.subMenu_Project_Project.Size = new System.Drawing.Size(182, 22);
            this.subMenu_Project_Project.Text = "Project";
            this.subMenu_Project_Project.Click += new System.EventHandler(this.subMenu_Project_Project_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // subMenu_Project_PrintGraphics
            // 
            this.subMenu_Project_PrintGraphics.Name = "subMenu_Project_PrintGraphics";
            this.subMenu_Project_PrintGraphics.Size = new System.Drawing.Size(182, 22);
            this.subMenu_Project_PrintGraphics.Text = "Print Graphics";
            this.subMenu_Project_PrintGraphics.Click += new System.EventHandler(this.subMenu_Project_PrintGraphics_Click);
            // 
            // subMenu_Project_PrintParamList
            // 
            this.subMenu_Project_PrintParamList.Name = "subMenu_Project_PrintParamList";
            this.subMenu_Project_PrintParamList.Size = new System.Drawing.Size(182, 22);
            this.subMenu_Project_PrintParamList.Text = "Print Parameters List";
            this.subMenu_Project_PrintParamList.Click += new System.EventHandler(this.subMenu_Project_PrintParamList_Click);
            // 
            // subMenu_Project_SetupPrinter
            // 
            this.subMenu_Project_SetupPrinter.Name = "subMenu_Project_SetupPrinter";
            this.subMenu_Project_SetupPrinter.Size = new System.Drawing.Size(182, 22);
            this.subMenu_Project_SetupPrinter.Text = "Setup Printer";
            this.subMenu_Project_SetupPrinter.Click += new System.EventHandler(this.subMenu_Project_SetupPrinter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // subMenu_Project_ExportExcel
            // 
            this.subMenu_Project_ExportExcel.Name = "subMenu_Project_ExportExcel";
            this.subMenu_Project_ExportExcel.Size = new System.Drawing.Size(182, 22);
            this.subMenu_Project_ExportExcel.Text = "Export -> MS Excel";
            this.subMenu_Project_ExportExcel.Click += new System.EventHandler(this.subMenu_Project_ExportExcel_Click);
            // 
            // menuItemToolStrip_TestProgram
            // 
            this.menuItemToolStrip_TestProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_TestProg_SelectTestProgram,
            this.toolStripSeparator3,
            this.subMenu_TestProg_Start,
            this.subMenu_TestProg_STop,
            this.toolStripSeparator4,
            this.subMenu_TestProg_CreateUserDefinedTest,
            this.toolStripSeparator5,
            this.subMenu_TestProg_ManualActuation,
            this.subMenu_TestProg_Calibration,
            this.toolStripSeparator8,
            this.subMenu_TestProg_Bleed,
            this.subMenu_TestProg_SaveTest});
            this.menuItemToolStrip_TestProgram.Enabled = false;
            this.menuItemToolStrip_TestProgram.Name = "menuItemToolStrip_TestProgram";
            this.menuItemToolStrip_TestProgram.Size = new System.Drawing.Size(103, 22);
            this.menuItemToolStrip_TestProgram.Text = "TEST PROGRAM";
            // 
            // subMenu_TestProg_SelectTestProgram
            // 
            this.subMenu_TestProg_SelectTestProgram.Name = "subMenu_TestProg_SelectTestProgram";
            this.subMenu_TestProg_SelectTestProgram.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_SelectTestProgram.Text = "Select Test Program";
            this.subMenu_TestProg_SelectTestProgram.Click += new System.EventHandler(this.subMenu_TestProg_SelectTestProgram_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // subMenu_TestProg_Start
            // 
            this.subMenu_TestProg_Start.Name = "subMenu_TestProg_Start";
            this.subMenu_TestProg_Start.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_Start.Text = "Start";
            this.subMenu_TestProg_Start.Click += new System.EventHandler(this.subMenu_TestProg_Start_Click);
            // 
            // subMenu_TestProg_STop
            // 
            this.subMenu_TestProg_STop.Name = "subMenu_TestProg_STop";
            this.subMenu_TestProg_STop.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_STop.Text = "Stop";
            this.subMenu_TestProg_STop.Click += new System.EventHandler(this.subMenu_TestProg_STop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(198, 6);
            // 
            // subMenu_TestProg_CreateUserDefinedTest
            // 
            this.subMenu_TestProg_CreateUserDefinedTest.Name = "subMenu_TestProg_CreateUserDefinedTest";
            this.subMenu_TestProg_CreateUserDefinedTest.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_CreateUserDefinedTest.Text = "Create User Defined Test";
            this.subMenu_TestProg_CreateUserDefinedTest.Click += new System.EventHandler(this.subMenu_TestProg_CreateUserDefinedTest_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(198, 6);
            // 
            // subMenu_TestProg_ManualActuation
            // 
            this.subMenu_TestProg_ManualActuation.Name = "subMenu_TestProg_ManualActuation";
            this.subMenu_TestProg_ManualActuation.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_ManualActuation.Text = "Manual Actuation";
            this.subMenu_TestProg_ManualActuation.Click += new System.EventHandler(this.subMenu_TestProg_ManualActuation_Click);
            // 
            // subMenu_TestProg_Calibration
            // 
            this.subMenu_TestProg_Calibration.Name = "subMenu_TestProg_Calibration";
            this.subMenu_TestProg_Calibration.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_Calibration.Text = "Calibration";
            this.subMenu_TestProg_Calibration.Click += new System.EventHandler(this.subMenu_TestProg_Calibration_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(198, 6);
            // 
            // subMenu_TestProg_Bleed
            // 
            this.subMenu_TestProg_Bleed.Name = "subMenu_TestProg_Bleed";
            this.subMenu_TestProg_Bleed.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_Bleed.Text = "Bleed (Fillup) / Drain";
            this.subMenu_TestProg_Bleed.Click += new System.EventHandler(this.subMenu_TestProg_Bleed_Click);
            // 
            // subMenu_TestProg_SaveTest
            // 
            this.subMenu_TestProg_SaveTest.Name = "subMenu_TestProg_SaveTest";
            this.subMenu_TestProg_SaveTest.Size = new System.Drawing.Size(201, 22);
            this.subMenu_TestProg_SaveTest.Text = "Save Test";
            this.subMenu_TestProg_SaveTest.Click += new System.EventHandler(this.subMenu_TestProg_SaveTest_Click);
            // 
            // menuItemToolStrip_Settings
            // 
            this.menuItemToolStrip_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Settings_SoftwareMaintenance,
            this.toolStripSeparator9,
            this.subMenu_Settings_Account});
            this.menuItemToolStrip_Settings.Enabled = false;
            this.menuItemToolStrip_Settings.Name = "menuItemToolStrip_Settings";
            this.menuItemToolStrip_Settings.Size = new System.Drawing.Size(69, 22);
            this.menuItemToolStrip_Settings.Text = "SETTINGS";
            // 
            // subMenu_Settings_SoftwareMaintenance
            // 
            this.subMenu_Settings_SoftwareMaintenance.Name = "subMenu_Settings_SoftwareMaintenance";
            this.subMenu_Settings_SoftwareMaintenance.Size = new System.Drawing.Size(192, 22);
            this.subMenu_Settings_SoftwareMaintenance.Text = "Software Maintenance";
            this.subMenu_Settings_SoftwareMaintenance.Click += new System.EventHandler(this.subMenu_Settings_SoftwareMaintenance_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(189, 6);
            // 
            // subMenu_Settings_Account
            // 
            this.subMenu_Settings_Account.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenu_Account_SelectAccessLevel,
            this.toolStripSeparator10,
            this.subMenu_Account_NewPassword,
            this.toolStripSeparator11,
            this.subMenu_Account_UserAdd,
            this.subMenu_Account_UserEdit,
            this.subMenu_Account_UserDelete,
            this.subMenu_Account_UserReport});
            this.subMenu_Settings_Account.Name = "subMenu_Settings_Account";
            this.subMenu_Settings_Account.Size = new System.Drawing.Size(192, 22);
            this.subMenu_Settings_Account.Text = "USER";
            // 
            // subMenu_Account_SelectAccessLevel
            // 
            this.subMenu_Account_SelectAccessLevel.Name = "subMenu_Account_SelectAccessLevel";
            this.subMenu_Account_SelectAccessLevel.Size = new System.Drawing.Size(180, 22);
            this.subMenu_Account_SelectAccessLevel.Text = "Select Access Level";
            this.subMenu_Account_SelectAccessLevel.Click += new System.EventHandler(this.subMenu_Account_SelectAccessLevel_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(177, 6);
            // 
            // subMenu_Account_NewPassword
            // 
            this.subMenu_Account_NewPassword.Name = "subMenu_Account_NewPassword";
            this.subMenu_Account_NewPassword.Size = new System.Drawing.Size(180, 22);
            this.subMenu_Account_NewPassword.Text = "New Password";
            this.subMenu_Account_NewPassword.Click += new System.EventHandler(this.subMenu_Account_NewPassword_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(177, 6);
            // 
            // subMenu_Account_UserAdd
            // 
            this.subMenu_Account_UserAdd.Name = "subMenu_Account_UserAdd";
            this.subMenu_Account_UserAdd.Size = new System.Drawing.Size(180, 22);
            this.subMenu_Account_UserAdd.Text = "toolStripMenuItem1";
            // 
            // subMenu_Account_UserEdit
            // 
            this.subMenu_Account_UserEdit.Name = "subMenu_Account_UserEdit";
            this.subMenu_Account_UserEdit.Size = new System.Drawing.Size(180, 22);
            this.subMenu_Account_UserEdit.Text = "toolStripMenuItem1";
            // 
            // subMenu_Account_UserDelete
            // 
            this.subMenu_Account_UserDelete.Name = "subMenu_Account_UserDelete";
            this.subMenu_Account_UserDelete.Size = new System.Drawing.Size(180, 22);
            this.subMenu_Account_UserDelete.Text = "toolStripMenuItem1";
            // 
            // subMenu_Account_UserReport
            // 
            this.subMenu_Account_UserReport.Name = "subMenu_Account_UserReport";
            this.subMenu_Account_UserReport.Size = new System.Drawing.Size(180, 22);
            this.subMenu_Account_UserReport.Text = "toolStripMenuItem1";
            // 
            // picContinental
            // 
            this.picContinental.Image = ((System.Drawing.Image)(resources.GetObject("picContinental.Image")));
            this.picContinental.Location = new System.Drawing.Point(765, 165);
            this.picContinental.Name = "picContinental";
            this.picContinental.Size = new System.Drawing.Size(405, 124);
            this.picContinental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picContinental.TabIndex = 40;
            this.picContinental.TabStop = false;
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
            this.grp_login.Location = new System.Drawing.Point(579, 373);
            this.grp_login.Name = "grp_login";
            this.grp_login.Size = new System.Drawing.Size(760, 400);
            this.grp_login.TabIndex = 43;
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
            this.lbl_LoginName.Size = new System.Drawing.Size(147, 26);
            this.lbl_LoginName.TabIndex = 0;
            this.lbl_LoginName.Text = "LoginName :";
            // 
            // stsBar_STBMain
            // 
            this.stsBar_STBMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsBar_STBMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStatusLabel01,
            this.tStatusLabel02,
            this.tStatusLabel03,
            this.tStatusLabel04});
            this.stsBar_STBMain.Location = new System.Drawing.Point(0, 1056);
            this.stsBar_STBMain.Name = "stsBar_STBMain";
            this.stsBar_STBMain.Size = new System.Drawing.Size(1920, 24);
            this.stsBar_STBMain.TabIndex = 49;
            this.stsBar_STBMain.Text = "statusStrip1";
            // 
            // tStatusLabel01
            // 
            this.tStatusLabel01.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel01.Name = "tStatusLabel01";
            this.tStatusLabel01.Size = new System.Drawing.Size(83, 19);
            this.tStatusLabel01.Text = "tStatusLabel01";
            // 
            // tStatusLabel02
            // 
            this.tStatusLabel02.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel02.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tStatusLabel02.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tStatusLabel02.Name = "tStatusLabel02";
            this.tStatusLabel02.Size = new System.Drawing.Size(115, 19);
            this.tStatusLabel02.Text = "tStatusLabel02_User";
            // 
            // tStatusLabel03
            // 
            this.tStatusLabel03.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel03.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tStatusLabel03.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tStatusLabel03.Name = "tStatusLabel03";
            this.tStatusLabel03.Size = new System.Drawing.Size(87, 19);
            this.tStatusLabel03.Text = "tStatusLabel03";
            // 
            // tStatusLabel04
            // 
            this.tStatusLabel04.BackColor = System.Drawing.Color.Transparent;
            this.tStatusLabel04.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tStatusLabel04.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tStatusLabel04.Name = "tStatusLabel04";
            this.tStatusLabel04.Size = new System.Drawing.Size(122, 19);
            this.tStatusLabel04.Text = "tStatusLabel04_Clock";
            // 
            // timer_Clock
            // 
            this.timer_Clock.Enabled = true;
            this.timer_Clock.Interval = 1000;
            this.timer_Clock.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.stsBar_STBMain);
            this.Controls.Add(this.grp_login);
            this.Controls.Add(this.picContinental);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1918, 1038);
            this.Name = "Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Continental - ADAM Functional Test Bench";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.grp_login.ResumeLayout(false);
            this.grp_login.PerformLayout();
            this.stsBar_STBMain.ResumeLayout(false);
            this.stsBar_STBMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_Home;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Home_Logout;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Home_Exit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Home_About;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_Project;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_Project;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_PrintGraphics;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_PrintParamList;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_SetupPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Project_ExportExcel;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_TestProgram;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_SelectTestProgram;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_Start;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_STop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_CreateUserDefinedTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_ManualActuation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_Bleed;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_SaveTest;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolStrip_Settings;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Settings_SoftwareMaintenance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Settings_Account;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_SelectAccessLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_NewPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserAdd;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserEdit;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserDelete;
        private System.Windows.Forms.ToolStripMenuItem subMenu_Account_UserReport;
        private System.Windows.Forms.PictureBox picContinental;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.GroupBox grp_login;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_LoginName;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.StatusStrip stsBar_STBMain;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel01;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel02;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel04;
        private System.Windows.Forms.Timer timer_Clock;
        private System.Windows.Forms.ToolStripStatusLabel tStatusLabel03;
        private System.Windows.Forms.Timer timer_GlobalBatch;
        private System.Windows.Forms.Timer timer_GlobalPolling;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripMenuItem subMenu_TestProg_Calibration;
    }
}