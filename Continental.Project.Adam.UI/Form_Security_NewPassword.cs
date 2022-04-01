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

        BLL_Security_User _bll_Security_User = new BLL_Security_User();

        #endregion


        public Form_Security_NewPassword()
        {
            InitializeComponent();
        }

        private void mbtn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtn_Ok_Click(object sender, EventArgs e)
        {
            SaveUsePassData(mtxt_ENewPassword.Text.Trim(), mtxt_EConfirm.Text.Trim());
        }

        private void Form_Security_NewPassword_Load(object sender, EventArgs e)
        {
            mbtn_Ok.Enabled = false;
            GetUserInfoData();
        }

        private void GetUserInfoData()
        {
            Model_SecurityPassword userPassword = _bll_Security_User.GetUserPassword(HelperApp.UserId);

            if (userPassword != null)
            {
                mbtn_Ok.Enabled = true;

                HelperApp.UserId = userPassword.IdUser;
                mtxt_EUser.Text = userPassword.User.UName;
            }
            else
                _helperApp.Form_Open(new Form_Adam_Welcome());
        }

        private void SaveUsePassData(string passNew, string passConfirm)
        {
            if (!passNew.Equals(passConfirm))
            {
                MessageBox.Show("Password and confirm password don't match !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool updateUserPassword = _bll_Security_User.UpdateUserPassword(passConfirm, HelperApp.UserId);

            if (updateUserPassword)
                this.Close();
        }
    }
}
