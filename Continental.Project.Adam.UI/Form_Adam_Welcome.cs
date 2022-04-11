using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Continental.Project.Adam.UI.Helper;
using System.Drawing;
using Continental.Project.Adam.UI.BLL;
using System.Linq;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Adam_Welcome : MetroForm
    {
        HelperApp _helperApp = new HelperApp();
        public Form_Adam_Welcome()
        {
            InitializeComponent();
        }

        private void Form_Adam_Welcome_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            grp_login.Visible = false;
        }

        private void picContinental_Click(object sender, EventArgs e)
        {
            try
            {
                if (!grp_login.Visible)
                {
                    picContinental.Location = new Point(765, 165);

                    grp_login.Visible = true;
                }
                else
                {
                    txtname.Text = string.Empty;
                    txtpass.Text = string.Empty;

                    picContinental.Location = new Point(765, 475);

                    grp_login.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

                        Itens_Hide();

                        HelperApp.IsLoggedIn = true;

                        this.Hide();

                        var formMain = new Form_Adam_Main();
                        formMain.Closed += (s, args) => this.Close();
                        formMain.Show();

                    }
                    else
                    {
                        Execute_Logout();

                        picContinental.Location = new Point(765, 475);

                        grp_login.Visible = false;

                        MessageBox.Show("Not Found LoginName OR Password !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Execute_Logout();
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error);
            }
        }
        private void Execute_Logout()
        {
            HelperApp.IsLoggedIn = false;

            txtname.Text = string.Empty;
            txtpass.Text = string.Empty;
        }

        private void Itens_Hide()
        {
            picContinental.Visible = false;
            picLogin.Visible = false;
            lbl_Info.Visible = false;
            grp_login.Visible = false;
        }

        #endregion
    }
}
