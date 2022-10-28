using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Models.Security;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Security_User_Management : Form
    {

        #region Define

        HelperApp _helperApp = new HelperApp();

        BLL_Security bll_User = new BLL_Security();
        Model_SecurityUser User = new Model_SecurityUser();

        bool bPassBlank = false;
        long idUsertSelect = 0;
        long idUserProfileSelect = 0;

        #endregion

        #region Construtor
        public Form_Security_User_Management()
        {
            InitializeComponent();
        }

        #endregion

        #region Form
        ///---------------------------------------------------------------------------
        private void Form_Operational_Project_Load(object sender, EventArgs e)
        {
            try
            {
                if (HelperApp.IsLoggedIn)
                {
                    Load_StartInfoData();
                }
                else
                {
                    HelperApp.IsLoggedIn = false;

                    MessageBox.Show("Not Found LoginName OR Password !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _helperApp.Form_Close(this);

                    var formWelcome = new Form_Adam_Welcome();
                    formWelcome.Closed += (s, args) => this.Close();
                    formWelcome.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private void Form_Operational_Project_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        ///---------------------------------------------------------------------------
        ///
        #endregion

        #region Methods
        ///--------------------------------------------------------------------------
        private void Load_StartInfoData()
        {
            try
            {
                TAB_UsersManagement_ActivePage(0, _helperApp.GetMethodName());

                mtxt_Information.ReadOnly = true;

                mtxt_Information.Text = string.Concat("Actual User  - ", HelperApp.UserApp.UName.ToUpper());

                grid_Users.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private bool CheckUserExists(string userName)
        {
            try
            {
                var dt = new BLL_Security().GetUserByName(tab_UserAdd_mtxt_UName.Text.Trim());

                return dt.Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString(), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        ///---------------------------------------------------------------------------
        ///
        #endregion

        #region TABS

        #region TABS Methods Common
        public bool TAB_LoadUserName(string origin)
        {
            try
            {
                DataTable dt = bll_User.GetAllUserLogin();

                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "-- No Selection User --" };
                dt.Rows.InsertAt(dr, 0);

                if (origin.Equals("TAB_UserUpdate_SetData"))
                {
                    tab_UserEdit_mcbo_UserName.ValueMember = "Id";

                    tab_UserEdit_mcbo_UserName.DisplayMember = "Name";
                    tab_UserEdit_mcbo_UserName.DataSource = dt;
                }
                else
                {
                    tab_UserDelete_mcbo_UserName.ValueMember = "Id";

                    tab_UserDelete_mcbo_UserName.DisplayMember = "Name";
                    tab_UserDelete_mcbo_UserName.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region TAB - UsersManagement
        private void TAB_UsersManagement_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bool bTabAccessOk = false;

            var strTabSelected = e.TabPage.Name.ToString();

            switch (strTabSelected)
            {
                case "tab_UserAdd":
                    bTabAccessOk = true;
                    break;
                case "tab_UserUpdate":
                    bTabAccessOk = true;
                    break;
                case "tab_UserDelete":
                    bTabAccessOk = true;
                    break;
                default:
                    bTabAccessOk = false;
                    break;
            }

            if (!bTabAccessOk)
                e.Cancel = true;
        }
        private void TAB_UsersManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            TAB_UsersManagement_ActivePage(TAB_UsersManagement.SelectedIndex, _helperApp.GetMethodName());
        }
        public void TAB_UsersManagement_ActivePage(int tabIdx, string origin)
        {
            try
            {
                switch (tabIdx)
                {
                    case 0://tab_UserView
                        {
                            TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];

                            TAB_UserView_SetData(_helperApp.GetMethodName());
                            break;
                        }
                    case 1://tab_UserAdd
                        {
                            TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserAdd"];

                            if (!TAB_UserAdd_SetData(_helperApp.GetMethodName()))
                            {
                                MessageBox.Show("Failed, TAB_UserAdd_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];
                            }

                            break;
                        }
                    case 2://tab_UserUpdate
                        {
                            TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserUpdate"];

                            if (!TAB_UserUpdate_SetData(_helperApp.GetMethodName()))
                            {
                                MessageBox.Show("Failed, TAB_UserUpdate_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];

                            }

                            break;
                        }
                    case 3://tab_UserDelete
                        {
                            TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserDelete"];

                            if (!TAB_UserDelete_SetData(_helperApp.GetMethodName()))
                            {
                                MessageBox.Show("Failed, TAB_UserDelete_SetData !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];
                            }

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        #endregion

        #region TAB - UserView

        #region TAB - UserView - Common
        private bool TAB_UserView_SetData(string origin)
        {
            try
            {
                grid_Users.DataSource = new DataTable();

                DataTable dt = bll_User.GetAllUserInfo();

                if (!TAB_UserView_Grid_GetData(dt))
                {
                    MessageBox.Show("Error, failed load user data!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    _helperApp.Form_Close(this);

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];

                return false;
            }

            return true;
        }

        #endregion

        #region TAB - UserView - Grid
        private bool TAB_UserView_Grid_GetData(DataTable dt)
        {
            try
            {
                grid_Users.AllowUserToAddRows = false;

                grid_Users.DataSource = dt;

                ////columns
                for (int i = 0; i < grid_Users.Columns.Count; i++)
                {
                    grid_Users.Columns[i].Visible = false;
                    grid_Users.Columns[i].ReadOnly = true;
                    grid_Users.Columns[i].HeaderCell.Value = String.Empty;
                    grid_Users.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grid_Users.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grid_Users.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    grid_Users.Columns[i].Resizable = DataGridViewTriState.False;
                }

                ////hide default grid's column's
                grid_Users.RowHeadersVisible = false;
                grid_Users.ColumnHeadersVisible = true;

                //show grid's column's

                grid_Users.Columns["UName"].HeaderText = "Name";
                grid_Users.Columns["UName"].Visible = true;
                grid_Users.Columns["UName"].Width = 150;
                grid_Users.Columns["UName"].DisplayIndex = 0;

                grid_Users.Columns["ULogin"].HeaderText = "Login";
                grid_Users.Columns["ULogin"].Visible = true;
                grid_Users.Columns["ULogin"].Width = 125;
                grid_Users.Columns["ULogin"].DisplayIndex = 1;

                grid_Users.Columns["UProfile"].HeaderText = "Profile";
                grid_Users.Columns["UProfile"].Visible = true;
                grid_Users.Columns["UProfile"].Width = 120;
                grid_Users.Columns["UProfile"].DisplayIndex = 2;

                grid_Users.Columns["Status"].HeaderText = "Active";
                grid_Users.Columns["Status"].Visible = true;
                grid_Users.Columns["Status"].Width = 80;
                grid_Users.Columns["Status"].DisplayIndex = 3;

                grid_Users.Columns["ChangePassword"].HeaderText = "Need Change Password";
                grid_Users.Columns["ChangePassword"].Visible = true;
                grid_Users.Columns["ChangePassword"].Width = 125;
                grid_Users.Columns["ChangePassword"].DisplayIndex = 4;

                grid_Users.Columns["LastUpdatePass"].HeaderText = "Last Update Password";
                grid_Users.Columns["LastUpdatePass"].Visible = true;
                grid_Users.Columns["LastUpdatePass"].Width = 125;
                grid_Users.Columns["LastUpdatePass"].DisplayIndex = 5;

                grid_Users.Columns["IdUser"].Visible = true;
                grid_Users.Columns["IdUser"].Width = 0;
                grid_Users.Columns["IdUser"].DefaultCellStyle.BackColor = Color.White;
                grid_Users.Columns["IdUser"].DefaultCellStyle.ForeColor = Color.White;
                grid_Users.Columns["IdUser"].DisplayIndex = 6;

                ////Changes grid's column's header's font size to 10.
                grid_Users.ColumnHeadersDefaultCellStyle.Font = new Font("", 10.0f, FontStyle.Bold);

                ////Changes grid's data's font size to 8.
                grid_Users.Font = new Font("", 8.0f);

                //selection
                grid_Users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                grid_Users.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                grid_Users.DefaultCellStyle.SelectionForeColor = Color.Black;

                if (dt.Rows.Count < grid_Users.Rows.Count)
                    grid_Users.Rows.RemoveAt(grid_Users.Rows.Count - 1);

                grid_Users.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return true;
        }

        #endregion

        #endregion

        #region TAB - UserAdd
        private bool TAB_UserAdd_SetData(string origin)
        {
            try
            {
                if (!TAB_UserAdd_LoadProfile())
                {
                    MessageBox.Show("Failed, TAB_UserAdd_LoadProfile !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];
                }
                else
                {
                    tab_UserAdd_mtxt_UName.Text = string.Empty;

                    tab_UserAdd_mcbo_Profile.SelectedIndex = 0;

                    tab_UserAdd_mtxt_ULogin.Text = string.Empty;

                    tab_UserAdd_mtxt_UPass.Text = string.Empty;

                    tab_UserAdd_mbtn_UserAdd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool TAB_UserAdd_LoadProfile()
        {
            try
            {
                DataTable dt = bll_User.GetAllUserProfile();

                DataRow dr = dt.NewRow();
                dr.ItemArray = new object[] { 0, "-- No Selection Profile --" };
                dt.Rows.InsertAt(dr, 0);

                tab_UserAdd_mcbo_Profile.ValueMember = "Id";

                tab_UserAdd_mcbo_Profile.DisplayMember = "Name";
                tab_UserAdd_mcbo_Profile.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void tab_UserAdd_mcbo_Profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_UserAdd_mcbo_Profile.SelectedIndex > 0)
            {
                idUserProfileSelect = tab_UserAdd_mcbo_Profile.SelectedIndex;

                tab_UserAdd_mbtn_UserAdd.Enabled = true;
            }
            else
            {
                idUserProfileSelect = 0;

                tab_UserAdd_mtxt_UName.Text = string.Empty;

                tab_UserAdd_mcbo_Profile.SelectedIndex = 0;

                tab_UserAdd_mtxt_ULogin.Text = string.Empty;

                tab_UserAdd_mtxt_UPass.Text = string.Empty;

                tab_UserAdd_mbtn_UserAdd.Enabled = false;
            }
        }
        private bool TAB_UserAdd_Validate()
        {
            try
            {
                #region User Name

                if (string.IsNullOrEmpty(tab_UserAdd_mtxt_UName.Text))
                {
                    MessageBox.Show("Error no valid User Name!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    //stroe the every caharter u enter in the textbox
                    char[] testarr = tab_UserAdd_mtxt_UName.Text.ToCharArray();
                    //to check the symbols in the given input through for loop

                    for (int i = 0; i < testarr.Length; i++)
                    {
                        //Isletter property of char is using to chek the special charcters

                        if (!char.IsLetter(testarr[i]))
                        {
                            MessageBox.Show("Error no valid User Name - Symbols are not allowed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (char.IsWhiteSpace(testarr[i]))
                        {
                            MessageBox.Show("Error no valid User Name - space in the end of the text is not allowed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                #endregion

                #region User Profile

                if (tab_UserAdd_mcbo_Profile.SelectedIndex <= 0)
                {
                    MessageBox.Show("Error no valid User Login!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                #endregion

                #region User Login

                if (string.IsNullOrEmpty(tab_UserAdd_mtxt_ULogin.Text))
                {
                    MessageBox.Show("Error no valid User Login!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    //stroe the every caharter u enter in the textbox
                    char[] testarr = tab_UserAdd_mtxt_ULogin.Text.ToCharArray();
                    //to check the symbols in the given input through for loop

                    for (int i = 0; i < testarr.Length; i++)
                    {
                        //Isletter property of char is using to chek the special charcters

                        if (!char.IsLetter(testarr[i]))
                        {
                            MessageBox.Show("Error no valid User Login - Symbols are not allowed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (char.IsWhiteSpace(testarr[i]))
                        {
                            MessageBox.Show("Error no valid User Login - space in the end of the text is not allowed!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                #endregion

                #region User Password

                if (string.IsNullOrEmpty(tab_UserAdd_mtxt_UPass.Text))
                {
                    if (DialogResult.Yes == MessageBox.Show("\t Password not provided\n\n Want to use system default password?\n\n", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        bPassBlank = true;
                    else
                    {
                        MessageBox.Show("Error no valid User Password!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_UserAdd_Validate : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool TAB_UserAdd_Save()
        {
            try
            {
                if (!TAB_UserAdd_Validate())
                {
                    tab_UserAdd_mtxt_UName.Text = string.Empty;

                    tab_UserAdd_mcbo_Profile.SelectedIndex = 0;

                    tab_UserAdd_mtxt_ULogin.Text = string.Empty;

                    tab_UserAdd_mtxt_UPass.Text = string.Empty;

                    tab_UserAdd_mbtn_UserAdd.Enabled = false;

                    return false;
                }
                else
                {
                    User = new Model_SecurityUser()
                    {
                        ULogin = tab_UserAdd_mtxt_ULogin.Text?.Trim()?.ToLower(),
                        UName = tab_UserAdd_mtxt_UName.Text?.Trim(),
                        ChangePassword = bPassBlank ? true : false,
                        LastUpdate = DateTime.Now,
                        Status = true,
                        IdProfile = tab_UserAdd_mcbo_Profile.SelectedIndex
                    };

                    long idUserCreated = new BLL_Security().AddUser(User);

                    if (idUserCreated > 0)
                    {
                        User.IdUser = idUserCreated;

                        var Password = new Model_SecurityPassword()
                        {
                            UPass = bPassBlank ? new SecurityCrypto().clsCrypt(_helperApp.AppSecurity_PassDefault, true) : new SecurityCrypto().clsCrypt(tab_UserAdd_mtxt_UName.Text, true),
                            LastUpdate = DateTime.Now,
                            IdUser = idUserCreated,
                            User = User
                        };

                        long idPassCreated = new BLL_Security().AddUserPassword(Password);

                        if (idPassCreated > 0)
                            return true;
                        else
                        {
                            MessageBox.Show("Error save password for User!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error save User!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Error - TAB_UserAdd_Save : \n\n", ex.Message), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void tab_UserAdd_mbtn_UserAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tab_UserAdd_mtxt_UName.Text))
            {
                if (!CheckUserExists(tab_UserAdd_mtxt_UName.Text))
                {
                    if (!TAB_UserAdd_Save())
                    {
                        MessageBox.Show("Error Add New User!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Load_StartInfoData();

                    MessageBox.Show("New User SAVED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User already exists !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Error no valid User Name!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region TAB - UserUpdate
        private bool TAB_UserUpdate_SetData(string origin)
        {
            try
            {
                if (!TAB_LoadUserName(_helperApp.GetMethodName()))
                {
                    MessageBox.Show("Failed, TAB_LoadUserName !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];
                }
                else
                {
                    tab_UserEdit_mcbo_UserName.SelectedIndex = 0;

                    tab_UserEdit_mtxt_Name.Text = string.Empty;

                    tab_UserEdit_mbtn_UserEditEnable.Visible = false;

                    tab_UserEdit_mbtn_UserEdit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void tab_UserEdit_mcbo_UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_UserEdit_mcbo_UserName.SelectedIndex > 0)
            {
                tab_UserEdit_mbtn_UserEditEnable.Visible = true;

                idUsertSelect = Convert.ToInt64(tab_UserEdit_mcbo_UserName.SelectedValue);

                DataTable dt = bll_User.GetUserById(idUsertSelect);

                if (dt?.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    User = new Model_SecurityUser()
                    {
                        IdUser = row.Field<long>("IdUser"),
                        ULogin = row.Field<string>("ULogin")?.ToString()?.Trim(),
                        UName = row.Field<string>("UName")?.ToString()?.Trim()
                    };

                    tab_UserEdit_mtxt_Name.Text = User.UName;

                    tab_UserEdit_mtxt_Name.Enabled = false;
                }
            }
        }
        private void tab_UserEdit_mbtn_UserEditEnable_Click(object sender, EventArgs e)
        {
            if (idUsertSelect > 0 && !string.IsNullOrEmpty(tab_UserEdit_mtxt_Name.Text))
            {
                tab_UserEdit_mtxt_Name.Enabled = true;

                tab_UserEdit_mbtn_UserEdit.Enabled = true;
            }
        }
        private void tab_UserEdit_mbtn_UserEdit_Click(object sender, EventArgs e)
        {
            if (idUsertSelect > 0 && !string.IsNullOrEmpty(tab_UserEdit_mtxt_Name.Text))
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Update Name the selected User?" + "\n\n" + "\t Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (!bll_User.UpdateUserName(tab_UserEdit_mtxt_Name.Text.Trim(), idUsertSelect))
                    {
                        MessageBox.Show("Error update name select User!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Load_StartInfoData();

                    MessageBox.Show("Name of user UPDATED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tab_UserEdit_mcbo_UserName.SelectedIndex = 0;

                    tab_UserEdit_mtxt_Name.Text = string.Empty;

                    tab_UserEdit_mtxt_Name.Enabled = false;

                    tab_UserEdit_mbtn_UserEdit.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error no valid data for User selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region TAB - UserDelete
        private bool TAB_UserDelete_SetData(string origin)
        {
            try
            {
                if (!TAB_LoadUserName(_helperApp.GetMethodName()))
                {
                    MessageBox.Show("Failed, TAB_LoadUserName !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    TAB_UsersManagement.SelectedTab = TAB_UsersManagement.TabPages["tab_UserView"];
                }
                else
                {
                    tab_UserDelete_mbtn_UserDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void tab_UserDelete_mcbo_UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_UserDelete_mcbo_UserName.SelectedIndex > 0)
            {
                tab_UserDelete_mbtn_UserDelete.Enabled = true;

                idUsertSelect = Convert.ToInt64(tab_UserDelete_mcbo_UserName.SelectedValue);
            }
        }
        private void tab_UserDelete_mbtn_UserDelete_Click(object sender, EventArgs e)
        {
            if (idUsertSelect > 0)
            {
                if (idUsertSelect == HelperApp.UserApp.IdUser)
                {
                    MessageBox.Show("Error select user is Logged!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tab_UserDelete_mcbo_UserName.SelectedIndex = 0;

                    tab_UserDelete_mbtn_UserDelete.Enabled = false;

                    return;
                }

                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the selected User?" + "\n\n" + "\t Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (!bll_User.DeleteUser(idUsertSelect))
                    {
                        MessageBox.Show("Error drop select User!", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        tab_UserDelete_mcbo_UserName.SelectedIndex = 0;

                        tab_UserDelete_mbtn_UserDelete.Enabled = false;

                        return;
                    }

                    Load_StartInfoData();

                    MessageBox.Show("Test data sample DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tab_UserDelete_mcbo_UserName.SelectedIndex = 0;

                    tab_UserDelete_mbtn_UserDelete.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error no valid User selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #endregion

        #region BUTTONS
        private void mbtn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
