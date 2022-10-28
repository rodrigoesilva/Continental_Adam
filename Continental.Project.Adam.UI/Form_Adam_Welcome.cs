using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Continental.Project.Adam.UI.Helper;
using System.Drawing;
using Continental.Project.Adam.UI.BLL;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Continental.Project.Adam.UI.Models.Security;

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
            Execute_Logout();

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
                    DataTable dtUser = new BLL_Security().Login(txtname.Text.Trim(), txtpass.Text.Trim());

                    if (dtUser?.Rows.Count > 0)
                    {
                        DataRow row = dtUser.Rows[0];

                        HelperApp.UserApp = new Model_SecurityUser()
                        {
                            IdUser = row.Field<long>("IdUser"),
                            ULogin = row.Field<string>("ULogin")?.ToString()?.Trim(),
                            UName = row.Field<string>("UName")?.ToString()?.Trim(),
                            ChangePassword = row.Field<bool>("ChangePassword"),
                            Status = row.Field<bool>("Status"),
                            IdProfile = row.Field<long>("IdProfile")
                        };

                        if (!HelperApp.UserApp.Status)
                        {
                            MessageBox.Show("User Deactivated !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (HelperApp.UserApp.ChangePassword)
                        {
                            MessageBox.Show("User need Change Password !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            _helperApp.Form_Open(new Form_Security_NewPassword());
                        }
                        else
                        {
                            HelperApp.lblstsbar01 = _helperApp.AppMsg_Welcome;

                            Itens_Hide();

                            HelperApp.IsLoggedIn = true;

                            this.Hide();

                            var formMain = new Form_Adam_Main();
                            formMain.Closed += (s, args) => this.Close();
                            formMain.Show();
                        }
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
