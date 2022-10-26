using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Models.Security;
using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.Manager;
using System.Collections.Generic;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Security_User_Management : Form
    {

        #region Define

        HelperApp _helperApp = new HelperApp();

        BLL_Security_User bll_User = new BLL_Security_User();

        Model_Operational_Project_TestConcluded modelOperationalProjectTestConcluded = new Model_Operational_Project_TestConcluded();

        bool selected_entry = false;

        string strIdProjectTestConcluded = string.Empty;
        string strIdProjectTestSampleSelect = string.Empty;
        string strIdProjectSelect = string.Empty;

        string _strTestSel = string.Empty;

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
                Load_StartInfoData();
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
                AvailableUsers_GetInfoData();

                mtxt_Information.ReadOnly = true;

                mtxt_Information.Text = string.Concat("Actual User  - ", HelperApp.UserName.ToUpper());

                grid_Users.ReadOnly = true;

                DisableButtons();

                DisableChecks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private void CurrentProjectData_Clear()
        {
            //mtxt_TestTypeName.Text = string.Empty;
            //mtxt_Ident.Text = string.Empty;
            //mtxt_Customer.Text = string.Empty;
            //mtxt_Booster.Text = string.Empty;
            //mtxt_Tmc.Text = string.Empty;
            //mtxt_ProductionDate.Text = string.Empty;
            //mtxt_TO.Text = string.Empty;
            //mtxt_Tester.Text = string.Empty;
            //mtxt_TestingDate.Text = string.Empty;
            //mtxt_Comment.Text = string.Empty;
        }
        ///---------------------------------------------------------------------------
        private void ModelToHeaderData(Model_Operational_Project_TestConcluded model)
        {
            try
            {
                //mtxt_Ident.Text = model?.ProjectTestSample?.Project?.Identification?.ToString()?.Trim();

                //mtxt_TestTypeName.Text = model?.ProjectTestSample?.TestAvailable?.Test?.ToString()?.Trim();
                //mtxt_Customer.Text = model?.ProjectTestSample?.CustomerType?.ToString()?.Trim();
                //mtxt_Booster.Text = model?.ProjectTestSample?.Booster?.ToString()?.Trim();
                //mtxt_Tmc.Text = model?.ProjectTestSample?.TMC?.ToString()?.Trim();
                //mtxt_ProductionDate.Text = model?.ProjectTestSample?.ProductionDate?.ToString()?.Trim();
                //mtxt_TO.Text = model?.ProjectTestSample?.T_O?.ToString()?.Trim();
                //mtxt_Tester.Text = model?.ProjectTestSample?.User?.UName?.ToString()?.Trim();
                //mtxt_TestingDate.Text = model?.ProjectTestSample?.TestingDate?.ToString()?.Trim();
                //mtxt_Comment.Text = model?.ProjectTestSample?.Comment?.ToString()?.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private Model_Operational_Project_TestConcluded HeaderDataToModel(Model_Operational_Project_TestConcluded model)
        {
            try
            {
                //string nullValue = "NULL";
                //string strTimeStamp = DateTime.Now.ToString();

                ////project Data
                //model.ProjectTestSample.Project.Identification = !string.IsNullOrEmpty(mtxt_Ident.Text) ? mtxt_Ident.Text.Trim() : nullValue;
                //model.ProjectTestSample.Project.PartNumber = string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), "_|_", model.ProjectTestSample.Project.Identification);
                //model.ProjectTestSample.Project.LastUpdatePRJ = strTimeStamp;

                ////project sample data
                //model.ProjectTestSample.CustomerType = !string.IsNullOrEmpty(mtxt_Customer.Text) ? mtxt_Customer.Text.Trim() : nullValue;
                //model.ProjectTestSample.Booster = !string.IsNullOrEmpty(mtxt_Booster.Text) ? mtxt_Booster.Text.Trim() : nullValue;
                //model.ProjectTestSample.TMC = !string.IsNullOrEmpty(mtxt_Tmc.Text) ? mtxt_Tmc.Text.Trim() : nullValue;
                //model.ProjectTestSample.ProductionDate = !string.IsNullOrEmpty(mtxt_ProductionDate.Text) ? mtxt_ProductionDate.Text.Trim() : nullValue;
                //model.ProjectTestSample.T_O = !string.IsNullOrEmpty(mtxt_TO.Text) ? mtxt_TO.Text.Trim() : nullValue;
                //model.ProjectTestSample.IdUser = !string.IsNullOrEmpty(mtxt_Tester.Text) ? _helperApp.GetUserIdByName(mtxt_Tester.Text) : HelperApp.UserId;
                //model.ProjectTestSample.TestingDate = selected_entry ? !string.IsNullOrEmpty(mtxt_TestingDate?.Text) ? mtxt_TestingDate.Text.Trim() : nullValue : nullValue;
                //model.ProjectTestSample.Comment = !string.IsNullOrEmpty(mtxt_Comment.Text) ? mtxt_Comment.Text.Trim() : nullValue;
                //model.ProjectTestSample.LastUpdatePTS = strTimeStamp;

                //if (model.ProjectTestSample.IdUser != 0)
                //{
                //    var user = _helperApp.GetUser(model.ProjectTestSample.IdUser);

                //    model.ProjectTestSample.User = new Model_SecurityUser()
                //    {
                //        IdUser = (long)user.IdUser,
                //        ULogin = user.ULogin?.ToString()?.Trim(),
                //        UName = user.UName?.ToString()?.Trim()
                //    };
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }
        ///---------------------------------------------------------------------------
        private void AvailableUsers_GetInfoData()
        {
            try
            {
                grid_Users.DataSource = new DataTable();

                DataTable dt = bll_User.GetAllUserInfo();

                GridView_Populate(dt);

                CurrentProjectData_Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }        
        ///---------------------------------------------------------------------------
        private bool TEST_Concluded_DeleteFileData()
        {
            try
            {
                //string _initialDirPathTestFile = System.IO.Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppTests_Path);

                //string fileIdentificationTest =string.Empty;

                //if (modelOperationalProjectTestConcluded != null && !string.IsNullOrEmpty(strIdProjectTestSampleSelect)) //delete SAMPLE
                //    fileIdentificationTest = string.Concat('#', modelOperationalProjectTestConcluded.ProjectTestSample?.SampleSequence,'#', modelOperationalProjectTestConcluded.ProjectTestSample?.Project?.Identification?.Trim());
                //else
                //    fileIdentificationTest = bll_Project.GetProjectIdentificationByIdProject(strIdProjectSelect); //delete PROJECT

                //string[] allFiles = System.IO.Directory.GetFiles(_initialDirPathTestFile);

                //foreach (string file in allFiles)
                //{
                //    if (file.Contains(fileIdentificationTest.Trim()))
                //        System.IO.File.Delete(file);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString(), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        ///---------------------------------------------------------------------------
        private bool SaveProjectData()
        {
            try
            {
            //    if (string.IsNullOrEmpty(mtxt_Ident.Text.Trim()))
            //    {
            //        MessageBox.Show("Inform IDENT Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else
            //    {
            //        Model_Operational_Project_TestConcluded modelPrjTestConcluded = new Model_Operational_Project_TestConcluded();

            //        modelPrjTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

            //        modelPrjTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();

            //        modelPrjTestConcluded = HeaderDataToModel(modelPrjTestConcluded);

            //        if (DialogResult.Yes == MessageBox.Show($"      Are you sure you want to create project \n\n\t      {modelPrjTestConcluded.ProjectTestSample.Project.Identification} \n\n            and all it´s measurement data? \n\n\t Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            //        {
            //            int idProjectInsert = bll_Project.AddProject(modelPrjTestConcluded.ProjectTestSample.Project);

            //            if (idProjectInsert > 0)
            //            {
            //                modelPrjTestConcluded.ProjectTestSample.Project.IdProject = idProjectInsert;
            //                modelPrjTestConcluded.ProjectTestSample.IdProject = idProjectInsert;
            //                modelPrjTestConcluded.ProjectTestSample.SampleSequence = modelPrjTestConcluded.ProjectTestSample.SampleSequence + 1;

            //                int idProjectTestSampleInsert = bll_Project.AddProjectTestSample(modelPrjTestConcluded.ProjectTestSample);

            //                if (idProjectTestSampleInsert > 0)
            //                {
            //                    modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = idProjectTestSampleInsert;
            //                    HelperTestBase.ProjectTestConcluded = modelPrjTestConcluded;
            //                }
            //                else
            //                {
            //                    HelperApp.lblstsbar03 = string.Empty;

            //                    HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

            //                    MessageBox.Show("Failed, create Project Test Sample!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                    return false;
            //                }
            //            }
            //            else
            //            {
            //                HelperApp.lblstsbar03 = string.Empty;

            //                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

            //                MessageBox.Show("Failed, created project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                return false;
            //            }
            //        }
            //        else
                        return false;
            //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString(), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        ///---------------------------------------------------------------------------
        private bool SaveProjectTestSampleData()
        {
            try
            {
                //if (string.IsNullOrEmpty(mtxt_Ident.Text.Trim()))
                //{
                //    MessageBox.Show("Inform IDENT Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}
                //else
                //{
                //    Model_Operational_Project_TestConcluded modelPrjTestConcluded = new Model_Operational_Project_TestConcluded();
                //    //modelPrjTestConcluded = HelperTestBase.ProjectTestConcluded;

                //    Model_Operational_Project_TestSample modelPrjTestSample = new Model_Operational_Project_TestSample();

                //    modelPrjTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

                //    modelPrjTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();

                //    modelPrjTestConcluded = HeaderDataToModel(modelPrjTestConcluded);

                //    if (modelPrjTestConcluded.IdProjectTestConcluded == 0)
                //    {
                //        modelPrjTestConcluded.IdProjectTestConcluded = modelOperationalProjectTestConcluded.IdProjectTestConcluded;
                //        modelPrjTestConcluded.IdProjectTestSample = modelOperationalProjectTestConcluded.IdProjectTestSample;
                //        modelPrjTestConcluded.IdTestAvailable = modelOperationalProjectTestConcluded.IdTestAvailable;
                //        modelPrjTestConcluded.LastUpdatePTC = modelOperationalProjectTestConcluded.LastUpdatePTC;
                //        modelPrjTestConcluded.ProjectTestFileName = modelOperationalProjectTestConcluded.ProjectTestFileName;

                //        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject = modelOperationalProjectTestConcluded.ProjectTestSample.Project.IdProject;
                //        HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject = modelOperationalProjectTestConcluded.ProjectTestSample.IdProject;
                //    }
                    
                //    modelPrjTestConcluded.ProjectTestSample.Project.IdProject = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject;
                //    modelPrjTestConcluded.ProjectTestSample.IdProject = HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject;
                //    modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = modelOperationalProjectTestConcluded.IdProjectTestSample;
                //    modelPrjTestConcluded.ProjectTestSample.SampleSequence = modelOperationalProjectTestConcluded.ProjectTestSample.SampleSequence;
                //    modelPrjTestConcluded.ProjectTestSample.TestAvailable = modelOperationalProjectTestConcluded.ProjectTestSample.TestAvailable;

                //    //update max sample
                //    if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject > 0)
                //        HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = bll_Project.GetMaxProjectSampleTestByIdProject(HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject.ToString());


                //    modelPrjTestConcluded.ProjectTestSample.SampleSequence = HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence;
                //    modelPrjTestConcluded.ProjectTestSample.SampleSequence = modelPrjTestConcluded.ProjectTestSample.SampleSequence + 1;

                //    int idProjectTestSampleInsert = bll_Project.AddProjectTestSample(modelPrjTestConcluded.ProjectTestSample);

                //    if (idProjectTestSampleInsert > 0)
                //    {
                //        modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = idProjectTestSampleInsert;
                //        modelPrjTestConcluded.IdProjectTestSample = idProjectTestSampleInsert;
                //        HelperTestBase.ProjectTestConcluded = modelPrjTestConcluded;
                //    }
                //    else
                //    {
                //        HelperApp.lblstsbar03 = string.Empty;

                //        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                //        MessageBox.Show("Failed, create Project Test Sample!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                       return false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString(), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        ///---------------------------------------------------------------------------
        private bool CheckProjectExists()
        {
            try
            {
                //int iExists = bll_Project.CheckProjectByIdent(mtxt_Ident.Text.Trim());

                //if (iExists > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString(), _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return false;
        }
        ///---------------------------------------------------------------------------
        ///
        #endregion

        #region GRIDVIEW
        private void grid_Users_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        ///---------------------------------------------------------------------------
        private void GridView_Populate(DataTable dt)
        {
            try
            {
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

                grid_Users.Columns["Status"].HeaderText = "Status";
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

                grid_Users.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private Model_Operational_Project_TestConcluded GridView_GetSelectedProjectTestItem(DataGridViewRow gvRow)
        {
            Model_Operational_Project_TestConcluded gvModelProjectTestConcluded = new Model_Operational_Project_TestConcluded();

            try
            {
                CurrentProjectData_Clear();

                gvModelProjectTestConcluded = new Model_Operational_Project_TestConcluded()
                {
                    IdProjectTestConcluded = (long)gvRow.Cells["IdProjectTestConcluded"].Value,
                    IdProjectTestSample = (long)gvRow.Cells["IdProjectTestSample"].Value,
                    IdTestAvailable = (long)gvRow.Cells["IdTestAvailable"].Value,
                    ProjectTestFileName = gvRow.Cells["ProjectTestFileName"].Value?.ToString()?.Trim(),
                    LastUpdatePTC = gvRow.Cells["LastUpdatePTC"].Value != null ? gvRow.Cells["LastUpdatePTC"].Value?.ToString()?.Trim() : DateTime.Now.ToString(),

                    ProjectTestSample = new Model_Operational_Project_TestSample()
                    {
                        IdProjectTestSample = (long)gvRow.Cells["IdProjectTestSample"].Value,
                        IdProject = (long)gvRow.Cells["IdProject"].Value,
                        SampleSequence = (long)gvRow.Cells["SampleSequence"].Value,                        
                        CustomerType = gvRow.Cells["CustomerType"].Value?.ToString()?.Trim(),
                        Booster = gvRow.Cells["Booster"].Value?.ToString()?.Trim(),
                        TMC = gvRow.Cells["TMC"].Value?.ToString()?.Trim(),
                        ProductionDate = gvRow.Cells["ProductionDate"].Value?.ToString()?.Trim(),
                        T_O = gvRow.Cells["T_O"].Value?.ToString()?.Trim(),
                        IdUser = (long)gvRow.Cells["IdUser"].Value,
                        TestingDate = gvRow.Cells["TestingDate"].Value?.ToString()?.Trim(),
                        Comment = gvRow.Cells["Comment"].Value?.ToString()?.Trim(),
                        LastUpdatePTS = gvRow.Cells["LastUpdatePTS"].Value != null ? gvRow.Cells["LastUpdatePTS"].Value?.ToString()?.Trim() : DateTime.Now.ToString(),

                        Project = new Model_Operational_Project()
                        {
                            IdProject = (long)gvRow.Cells["IdProject"].Value,
                            PartNumber = gvRow.Cells["PartNumber"].Value?.ToString()?.Trim(),
                            Identification = gvRow.Cells["Identification"].Value?.ToString()?.Trim(),
                            LastUpdatePRJ = gvRow.Cells["LastUpdatePRJ"].Value != null ? gvRow.Cells["LastUpdatePRJ"].Value?.ToString()?.Trim() : DateTime.Now.ToString()
                        },

                        User = new Model_SecurityUser()
                        {
                            IdUser = (long)gvRow.Cells["IdUser"].Value,
                            ULogin = gvRow.Cells["ULogin"].Value?.ToString()?.Trim(),
                            UName = gvRow.Cells["UName"].Value.ToString()?.Trim()
                        },

                        TestAvailable = new Model_Manager_TestAvailable()
                        {
                            IdTestAvailable = (long)gvRow.Cells["IdTestAvailable"].Value,
                            Test = gvRow.Cells["Test"].Value?.ToString()?.Trim()
                        }
                    }
                };

                if (gvModelProjectTestConcluded.IdProjectTestConcluded != 0)
                    selected_entry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (gvModelProjectTestConcluded.IdProjectTestConcluded == 0)
            {
                MessageBox.Show("Error no valid IdProjectTestConcluded selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return gvModelProjectTestConcluded;
        }
        ///---------------------------------------------------------------------------

        #endregion

        #region Checks

        private void EnableChecks()
        {
            //mchk_CBPrintSeries.Checked = true;
            //mchk_CBExportBitmapSeries.Checked = true;
            //mchk_CBExportExcelSeries.Checked = true;
        }

        private void DisableChecks()
        {
            //mchk_CBPrintSeries.Checked = false;
            //mchk_CBExportBitmapSeries.Checked = false;
            //mchk_CBExportExcelSeries.Checked = false;
        }

        #endregion

        #region BUTTONS
        private void EnableButtons()
        {
        //    mbtn_BDeleteTest.Enabled = true;
        //    mbtn_BLoadTest.Enabled = true;
        }
        private void DisableButtons()
        {
            //mbtn_BDeleteProject.Enabled = false;
            //mbtn_BDeleteTest.Enabled = false;
            //mbtn_BLoadTest.Enabled = false;
        }
        private void tab_UserAdd_mbtn_UserAdd_Click(object sender, EventArgs e)
        {

        }

        private void mbtn_UserEdit_Click(object sender, EventArgs e)
        {

        }

        private void mbtn_UserEditEnable_Click(object sender, EventArgs e)
        {

        }

        private void mbtn_UserDelete_Click(object sender, EventArgs e)
        {

        }
        private void mbtn_Close_Click(object sender, EventArgs e)
        {

            this.Close();

            //if (string.IsNullOrEmpty(mtxt_Ident.Text.Trim()))
            //{
            //    HelperApp.bLoadPrjTestOffLine = false;

            //    delegateFnLoadTestConcluded(false);
            //    this.Close();
            //}
            //else
            //{
            //    if (CheckProjectExists())
            //    {
            //        string strMsgProjectExists = String.Concat($"\t PROJECT { mtxt_Ident.Text.Trim() } EXISTS !", "\n\n\n", "\tDo you want SAVE NEW SAMPLE for Test ? ", "\n\n\n", $"\t\t {string.Concat("T", modelOperationalProjectTestConcluded.IdTestAvailable, " - ", modelOperationalProjectTestConcluded.ProjectTestSample.TestAvailable.Test)}");

            //        if (DialogResult.No == MessageBox.Show(strMsgProjectExists, _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            //        {
            //            HelperApp.bLoadPrjTestOffLine = false;

            //            HelperApp.bPrjTestCreateNewSampleOnLine = false;

            //            delegateFnLoadTestConcluded(false);
            //            this.Close();
            //        }
            //        else
            //        {
            //            if (SaveProjectTestSampleData())
            //            {
            //                HelperApp.bLoadPrjTestOffLine = false;

            //                HelperApp.bPrjTestCreateNewSampleOnLine = true;

            //                HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, "");
            //            }
            //            else
            //            {
            //                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;
            //                CurrentProjectData_Clear();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (SaveProjectData())
            //        {
            //            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;

            //            HelperApp.bPrjTestCreateNewSampleOnLine = true;

            //            HelperApp.uiProjectSelecionado = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject;

            //            HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, "");

            //            MessageBox.Show("Success, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

            //            CurrentProjectData_Clear();
            //        }

            //        //HelperApp.bPrjTestCreateNewSampleOnLine = false;
            //    }

            //    HelperApp.bLoadPrjTestOffLine = false;

            //    delegateFnLoadTestConcluded(false);
            //    this.Close();
            //}
        }


        #endregion

        
    }
}
