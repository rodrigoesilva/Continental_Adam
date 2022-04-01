using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Models.Security;
using System;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Security_UserLevel : Form
    {
        #region Define

        HelperApp _helperApp = new HelperApp();

        bool isLoggedIn = false;

        BLL_Security_User _bll_Security_User = new BLL_Security_User();

        #endregion

        public Form_Security_UserLevel()
        {
            InitializeComponent();
        }

        private void mbtn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtn_Ok_Click(object sender, EventArgs e)
        {
            SaveUseLevelData(mtxt_EPassword.Text.Trim());
        }

        private void Form_Security_UserLevel_Load(object sender, EventArgs e)
        {
            mbtn_Ok.Enabled = false;
            GetUserInfoData();
        }

        private void GetUserInfoData()
        {
            Model_SecurityPassword userPassword = _bll_Security_User.GetUserPassword(HelperApp.UserId);

            if (userPassword != null)
            {
                isLoggedIn = true;
                mbtn_Ok.Enabled = true;

                HelperApp.UserId = userPassword.IdUser;
                mtxt_EUser.Text = userPassword.User.UName;

                switch (userPassword.User.IdProfile)
                {
                    case 1:
                        rad_RBAdmin.Checked = true;
                        break;
                    case 2:
                        rad_RBOperator.Checked = true;
                        break;
                    case 3:
                        rad_RBUser.Checked = true;
                        break;
                    default:
                        rad_RBAdmin.Checked = false;
                        rad_RBOperator.Checked = false;
                        rad_RBUser.Checked = false;
                        break;
                }
            }
            else
                _helperApp.Form_Open(new Form_Adam_Welcome());
        }

        private void SaveUseLevelData(string pass)
        {
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Invalid password !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool updateUserLevel = _bll_Security_User.UpdateUserLevel(pass, HelperApp.UserId);

            if (updateUserLevel)
                this.Close();
        }
    }
}
