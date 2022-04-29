
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Enum;

namespace Continental.Project.Adam.UI
{
    public partial class Home : Form
    {
        #region Define

        HelperApp _helperApp = new HelperApp();

        Form_Adam_Main _formMain = new Form_Adam_Main();

        #endregion

        public Home()
        {
            InitializeComponent();

            UI_Setup();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            HelperApp.lblstsbar01 = _helperApp.AppMsg_Welcome;

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        #region UI
        private void UI_Setup()
        {

            //mchk_Hbm.Appearance = Appearance.Button;


            //MetroForm frm = new MetroForm();
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.FormBorderStyle = FormBorderStyle.None;

            //this.MdiParent.BackColor = Color.FromArgb(17, 17, 17);

            //UI_SetupMenu();

            UI_SetupForm();

            UI_SetupStatusBar();
        }
        private void UI_SetupMenu()
        {
            menuStrip.BackColor = Color.FromArgb(17, 17, 17);
            //menuStrip. = Color.FromArgb(17, 17, 17);
        }
        private void UI_SetupForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    //ctl.BackColor = Color.Black;
                    ctl.BackColor = Color.FromArgb(17, 17, 17);
                    ctl.Dock = DockStyle.Fill;

                    this.FormBorderStyle = FormBorderStyle.None;
                    break;
                }
            }

            if (!_helperApp.isLoggedIn)
                Itens_Show();

        }
        private void UI_SetupStatusBar()
        {
            Form_SetStatusBarPanelSize();

            if (!_helperApp.isLoggedIn)
            {
                stsBar_STBMain.Items[0].Text = _helperApp.appMsg_Name;

                for (int i = 1; i < 3; i++)
                {
                    stsBar_STBMain.Items[i].Text = string.Empty;
                    stsBar_STBMain.Items[i].AutoSize = false;
                    stsBar_STBMain.Items[i].Width = 475;
                }
            }
        }
        private void Form_SetStatusBarPanelSize()
        {
            stsBar_STBMain.AutoSize = false;

            for (int i = 0; i < 4; i++)
            {
                stsBar_STBMain.Items[i].AutoSize = false;
                stsBar_STBMain.Items[i].Width = 475;
            }
        }
        private void Form_SetBGImage()
        {
            this.BackgroundImage = null;

            if (_helperApp.isLoggedIn)
                this.BackgroundImage = Properties.Resources.carbon_wallpaper;
        }

        #endregion

        #region Methods
        private void Execute_Login()
        {
            try
            {
                if (txtname.Text.Trim().Length <= 0 || string.IsNullOrEmpty(txtname.Text.Trim()))
                    MessageBox.Show("Enter Login Name !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (txtpass.Text.Trim().Length <= 0 || string.IsNullOrEmpty(txtpass.Text.Trim()))
                    MessageBox.Show("Enter Login Password !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    BLL_Security_Login login = new BLL_Security_Login();

                    var _userDT = login.Login(txtname.Text, txtpass.Text);

                    if (_userDT?.Count > 0)
                    {
                        var uId = _userDT.ElementAt(0);
                        var uName = _userDT.ElementAt(2);

                        HelperApp.UserId = Convert.ToInt64(uId);
                        HelperApp.UserName = uName;

                        HelperApp.lblstsbar01 = _helperApp.AppMsg_Welcome + uName;


                        subMenu_Home_Logout.Visible = true;

                        Itens_Hide();

                        Form_SetBGImage();

                        Menu_Enable();

                        _helperApp.isLoggedIn = true;

                        _helperApp.Form_Open(_formMain, this);
                    }
                    else
                    {
                        txtname.Text = string.Empty;
                        txtpass.Text = string.Empty;

                        MessageBox.Show("Not Found LoginName OR Password !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            }
        }
        private void Execute_Logout()
        {
            _helperApp.isLoggedIn = false;

            txtname.Text = string.Empty;
            txtpass.Text = string.Empty;

            subMenu_Home_Logout.Visible = false;

            Itens_Show();

            Form_SetBGImage();

            Menu_Disable();
        }
        private void Menu_Enable()
        {
            menuItemToolStrip_Home.Enabled = true;
            menuItemToolStrip_Project.Enabled = true;
            menuItemToolStrip_TestProgram.Enabled = true;
            //menuItemToolStrip_Settings.Enabled = true;
        }
        private void Menu_Disable()
        {
            menuItemToolStrip_Project.Enabled = false;
            menuItemToolStrip_TestProgram.Enabled = false;
            menuItemToolStrip_Settings.Enabled = false;
        }
        private void Itens_Show()
        {
            picContinental.Visible = true;
            picLogin.Visible = true;
            lbl_Info.Visible = true;
            grp_login.Visible = true;
        }
        private void Itens_Hide()
        {
            picContinental.Visible = false;
            picLogin.Visible = false;
            lbl_Info.Visible = false;
            grp_login.Visible = false;
        }

        public void Form_CloseAll(object sender, EventArgs e)
        {

            foreach (Form mdiChildForm in MdiChildren)
            {
                mdiChildForm.Close();
            }
        }
        #endregion

        #region MENU

        #region Menu - Home
        private void subMenu_Home_Logout_Click(object sender, EventArgs e)
        {
            _helperApp.Form_Close(this);

            Execute_Logout();
        }

        private void subMenu_Home_Exit_Click(object sender, EventArgs e)
        {
            //helperAdam.SMQuitClick(sender);

            Execute_Logout();

            Application.Exit();
        }

        private void subMenu_Home_About_Click(object sender, EventArgs e)
        {
            //var tt = tStatusLabel04.Text;

            ////helperApp.Form_Open(new Form_Adam_About(), this);

            //Form_Adam_About newMDIChild = new Form_Adam_About();
            //newMDIChild.MdiParent = this;
            //newMDIChild.TransfEvent += frm_TransfEvent;
            //newMDIChild.Show();
        }

        public void frm_TransfEvent(string value)
        {
            stsBar_STBMain.Items[0].Text = value;
        }

        #endregion

        #region Menu - Project
        private void subMenu_Project_Project_Click(object sender, EventArgs e)
        {
            //helperAdam.SMProjectClick(sender);

            //MessageBox.Show("subMenu_Project_Project_Click !", helperApp.msgAppName);
            _helperApp.Form_Open(new Form_Operational_Project(eEXAMTYPE.ET_NONE, string.Empty));
        }

        private void subMenu_Project_PrintGraphics_Click(object sender, EventArgs e)
        {
            //_helperAdam.SMPrintGraphicsClick(sender);

            MessageBox.Show("subMenu_Project_PrintGraphics_Click !", _helperApp.appMsg_Name);
        }

        private void subMenu_Project_PrintParamList_Click(object sender, EventArgs e)
        {
            //_helperAdam.SMPrintParameterListClick(sender);

            MessageBox.Show("subMenu_Project_PrintParamList_Click !", _helperApp.appMsg_Name);
        }

        private void subMenu_Project_SetupPrinter_Click(object sender, EventArgs e)
        {
            //helperAdam.SMSetupPrinterClick(sender);
            printDialog.ShowDialog();
        }

        private void subMenu_Project_ExportExcel_Click(object sender, EventArgs e)
        {
            //_helperAdam.SMExportExcelClick(sender);

            MessageBox.Show("subMenu_Project_ExportExcel_Click !", _helperApp.appMsg_Name);
        }

        #endregion

        #region Menu - Test Program
        private void subMenu_TestProg_SelectTestProgram_Click(object sender, EventArgs e)
        {
            //helperAdam.SMSelectClick(sender);

            //MessageBox.Show("subMenu_TestProg_SelectTestProgram_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Manager_SelectEvalProgram());
        }

        private void subMenu_TestProg_Start_Click(object sender, EventArgs e)
        {
            //helperAdam.SMStartClick(sender);

            MessageBox.Show("subMenu_TestProg_Start_Click !", _helperApp.appMsg_Name);

            _formMain.TEST_Start_Command();
        }

        private void subMenu_TestProg_STop_Click(object sender, EventArgs e)
        {
            //helperAdam.SMStopClick(sender);

            MessageBox.Show("subMenu_TestProg_STop_Click !", _helperApp.appMsg_Name);

            _formMain.TEST_Stop_Command();
        }

        private void subMenu_TestProg_CreateUserDefinedTest_Click(object sender, EventArgs e)
        {
            //helperAdam.SMUserDefTestClick(sender);

            //MessageBox.Show("subMenu_TestProg_CreateUserDefinedTest_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Manager_CreateEvalGroup());
        }

        private void subMenu_TestProg_ManualActuation_Click(object sender, EventArgs e)
        {
            //helperAdam.SMManualActuationClick(sender);

            //MessageBox.Show("subMenu_TestProg_ManualActuation_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Operational_ManualActuation());
        }

        private void subMenu_TestProg_Calibration_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("subMenu_TestProg_Calibration_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Operational_Calibration());
        }

        private void subMenu_TestProg_Bleed_Click(object sender, EventArgs e)
        {
            //helperAdam.SMBleedDrainClick(sender);

            //MessageBox.Show("subMenu_TestProg_Bleed_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Operational_Bleed());
        }

        private void subMenu_TestProg_SaveTest_Click(object sender, EventArgs e)
        {
            //helperAdam.SaveTest1Click(sender);

            MessageBox.Show("subMenu_TestProg_SaveTest_Click !", _helperApp.appMsg_Name);
        }

        #endregion

        #region Menu - Settings
        private void subMenu_Settings_SoftwareMaintenance_Click(object sender, EventArgs e)
        {
            //helperAdam.SMPreferencesClick(sender);

            //MessageBox.Show("subMenu_Settings_SoftwareMaintenance_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Adam_Preferences(), this);
        }

        #endregion

        #region Menu - Account
        private void subMenu_Account_SelectAccessLevel_Click(object sender, EventArgs e)
        {
            //helperAdam.SMSelectAccessLevelClick(sender);

            //MessageBox.Show("subMenu_Account_SelectAccessLevel_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Security_UserLevel(), this);
        }

        private void subMenu_Account_NewPassword_Click(object sender, EventArgs e)
        {
            //helperAdam.SMNewPasswordClick(sender);

            //MessageBox.Show("subMenu_Account_NewPassword_Click !", helperApp.msgAppName);

            _helperApp.Form_Open(new Form_Security_NewPassword(), this);
        }

        #endregion

        #endregion

        #region Events
        private void btnlogin_Click(object sender, EventArgs e)
        {
            Execute_Login();
        }
        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Execute_Login();
        }
        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                Execute_Login();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            TaskBarUpdate();
        }

        #endregion

        #region TASK BAR
        private void TaskBarUpdate()
        {
            tStatusLabel01.Text = HelperApp.lblstsbar01;

            tStatusLabel02.Text = HelperApp.lblstsbar02;

            tStatusLabel03.Text = HelperApp.lblstsbar03;

            HelperApp.lblstsbar04 = DateTime.Now.ToString();
            tStatusLabel04.Text = HelperApp.lblstsbar04;
        }

        #endregion
    }
}
