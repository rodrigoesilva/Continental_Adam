using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Models.Security;
using System;
using System.Data;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Security_UserProfile : Form
    {
        #region Define

        HelperApp _helperApp = new HelperApp();

        bool isLoggedIn = false;

        BLL_Security _bll_Security_User = new BLL_Security();

        #endregion

        public Form_Security_UserProfile()
        {
            InitializeComponent();
        }

        private void mbtn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtn_Ok_Click(object sender, EventArgs e)
        {
            if (SaveUseLevelData(mtxt_EPassword.Text.Trim()))
            {
                MessageBox.Show("Fail change Profile User!!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Change Profile User Success!!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Execute_Logout();

                this.Close();
            }
        }

        private void Form_Security_UserProfile_Load(object sender, EventArgs e)
        {
            mbtn_Ok.Enabled = false;
            GetUserInfoData();
        }

        private void GetUserInfoData()
        {
            DataTable dt = _bll_Security_User.GetUserById(HelperApp.UserApp.IdUser);

            if (dt?.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                HelperApp.UserApp = new Model_SecurityUser()
                {
                    IdUser = row.Field<long>("IdUser"),
                    ULogin = row.Field<string>("ULogin")?.ToString()?.Trim(),
                    UName = row.Field<string>("UName")?.ToString()?.Trim(),
                    ChangePassword = row.Field<bool>("ChangePassword"),
                    Status = row.Field<bool>("Status"),
                    IdProfile = row.Field<long>("IdProfile")
                };

                switch (HelperApp.UserApp.IdProfile)
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
                Execute_Logout();
        }

        private bool SaveUseLevelData(string pass)
        {
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Invalid password !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return _bll_Security_User.UpdateUserProfile( HelperApp.UserApp.IdUser, HelperApp.UserApp.IdProfile);
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
