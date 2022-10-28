using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Models.Security;
using System;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Security_NewPassword : Form
    {
        #region Define

        HelperApp _helperApp = new HelperApp();

        BLL_Security _bll_Security_User = new BLL_Security();

        #endregion


        public Form_Security_NewPassword()
        {
            InitializeComponent();
        }

        private void mbtn_Cancel_Click(object sender, EventArgs e)
        {
            Execute_Logout();

            this.Close();
        }

        private void mbtn_Ok_Click(object sender, EventArgs e)
        {
           if(!SaveUsePassData(mtxt_ENewPassword.Text.Trim(), mtxt_EConfirm.Text.Trim()))
            {
                MessageBox.Show("Fail save New Password!!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("New Password Success!!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Execute_Logout();

                this.Close();
            }
        }

        private void Form_Security_NewPassword_Load(object sender, EventArgs e)
        {
            mbtn_Ok.Enabled = false;
            GetUserInfoData();
        }

        private void GetUserInfoData()
        {
            Model_SecurityPassword userPassword = _bll_Security_User.GetUserPassword(HelperApp.UserApp.IdUser);

            if (userPassword != null)
            {
                mbtn_Ok.Enabled = true;

                HelperApp.UserApp = new Model_SecurityUser();

                HelperApp.UserApp.IdUser = userPassword.IdUser;
                mtxt_EUser.Text = userPassword.User.UName;
            }
            else
                _helperApp.Form_Open(new Form_Adam_Welcome());
        }

        private bool SaveUsePassData(string passNew, string passConfirm)
        {
            if (!passNew.Equals(passConfirm))
            {
                MessageBox.Show("Password and confirm password don't match !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return _bll_Security_User.UpdateUserPassword(passConfirm, HelperApp.UserApp.IdUser);
        }

        private void Execute_Logout()
        {
            HelperApp.IsLoggedIn = false;

            var formWelcome = new Form_Adam_Welcome();
            formWelcome.Closed += (s, args) => this.Close();
            formWelcome.Show();

            this.Close();
        }
    }
}
