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
    public partial class Form_Operational_Project : Form
    {

        #region Define

        HelperApp _helperApp = new HelperApp();

        BLL_Operational_Project bll_Project = new BLL_Operational_Project();

        Model_Operational_Project_TestConcluded modelOperationalProjectTestConcluded = new Model_Operational_Project_TestConcluded();

        bool selected_entry = false;

        string strIdProjectTestConcluded = string.Empty;
        string strIdProjectTestSampleSelect = string.Empty;
        string strIdProjectSelect = string.Empty;

        string _strTestSel = string.Empty;

        #endregion

        #region Construtor

        public dHide delegateFnLoadTestConcluded = null;
        public Form_Operational_Project(eEXAMTYPE sel_examtype, string udt_filename)
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
            if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestSample.IdProjectTestSample > 0)
                delegateFnLoadTestConcluded(true);
        }
        ///---------------------------------------------------------------------------
        ///
        #endregion

        #region Methods
        private void CurrentProjectData_Clear()
        {
            mtxt_TestTypeName.Text = string.Empty;
            mtxt_Ident.Text = string.Empty;
            mtxt_Customer.Text = string.Empty;
            mtxt_Booster.Text = string.Empty;
            mtxt_Tmc.Text = string.Empty;
            mtxt_ProductionDate.Text = string.Empty;
            mtxt_TO.Text = string.Empty;
            mtxt_Tester.Text = string.Empty;
            mtxt_TestingDate.Text = string.Empty;
            mtxt_Comment.Text = string.Empty;
        }
        ///---------------------------------------------------------------------------
        private void ModelToHeaderData(Model_Operational_Project_TestConcluded model)
        {
            try
            {
                mtxt_Ident.Text = model?.ProjectTestSample?.Project?.Identification?.ToString()?.Trim();

                mtxt_TestTypeName.Text = model?.ProjectTestSample?.TestAvailable?.Test?.ToString()?.Trim();
                mtxt_Customer.Text = model?.ProjectTestSample?.CustomerType?.ToString()?.Trim();
                mtxt_Booster.Text = model?.ProjectTestSample?.Booster?.ToString()?.Trim();
                mtxt_Tmc.Text = model?.ProjectTestSample?.TMC?.ToString()?.Trim();
                mtxt_ProductionDate.Text = model?.ProjectTestSample?.ProductionDate?.ToString()?.Trim();
                mtxt_TO.Text = model?.ProjectTestSample?.T_O?.ToString()?.Trim();
                mtxt_Tester.Text = model?.ProjectTestSample?.User?.UName?.ToString()?.Trim();
                mtxt_TestingDate.Text = model?.ProjectTestSample?.TestingDate?.ToString()?.Trim();
                mtxt_Comment.Text = model?.ProjectTestSample?.Comment?.ToString()?.Trim();
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
                string nullValue = "NULL";
                string strTimeStamp = DateTime.Now.ToString();

                //project Data
                model.ProjectTestSample.Project.Identification = !string.IsNullOrEmpty(mtxt_Ident.Text) ? mtxt_Ident.Text.Trim() : nullValue;
                model.ProjectTestSample.Project.PartNumber = string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), "_|_", model.ProjectTestSample.Project.Identification);
                model.ProjectTestSample.Project.LastUpdatePRJ = strTimeStamp;

                //project sample data
                model.ProjectTestSample.CustomerType = !string.IsNullOrEmpty(mtxt_Customer.Text) ? mtxt_Customer.Text.Trim() : nullValue;
                model.ProjectTestSample.Booster = !string.IsNullOrEmpty(mtxt_Booster.Text) ? mtxt_Booster.Text.Trim() : nullValue;
                model.ProjectTestSample.TMC = !string.IsNullOrEmpty(mtxt_Tmc.Text) ? mtxt_Tmc.Text.Trim() : nullValue;
                model.ProjectTestSample.ProductionDate = !string.IsNullOrEmpty(mtxt_ProductionDate.Text) ? mtxt_ProductionDate.Text.Trim() : nullValue;
                model.ProjectTestSample.T_O = !string.IsNullOrEmpty(mtxt_TO.Text) ? mtxt_TO.Text.Trim() : nullValue;
                model.ProjectTestSample.IdUser = !string.IsNullOrEmpty(mtxt_Tester.Text) ? _helperApp.GetUserIdByName(mtxt_Tester.Text) : HelperApp.UserApp.IdUser;
                model.ProjectTestSample.TestingDate = selected_entry ? !string.IsNullOrEmpty(mtxt_TestingDate?.Text) ? mtxt_TestingDate.Text.Trim() : nullValue : nullValue;
                model.ProjectTestSample.Comment = !string.IsNullOrEmpty(mtxt_Comment.Text) ? mtxt_Comment.Text.Trim() : nullValue;
                model.ProjectTestSample.LastUpdatePTS = strTimeStamp;

                if (model.ProjectTestSample.IdUser != 0)
                {
                    var user = _helperApp.GetUser(model.ProjectTestSample.IdUser);

                    model.ProjectTestSample.User = new Model_SecurityUser()
                    {
                        IdUser = (long)user.IdUser,
                        ULogin = user.ULogin?.ToString()?.Trim(),
                        UName = user.UName?.ToString()?.Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }
        ///---------------------------------------------------------------------------
        private void AvailableProject_GetInfoData()
        {
            try
            {
                grid_ProjectTest.DataSource = new DataTable();

                tree_Projects.BeginUpdate();
                tree_Projects.CollapseAll();
                tree_Projects.EndUpdate();

                tree_Projects.Nodes.Clear();

                DataTable dt = bll_Project.GetAvailableProjects();

                TreeView_Populate(dt, 0, null);

                CurrentProjectData_Clear();

                mtxt_Ident.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private void Load_StartInfoData()
        {
            try
            {
                AvailableProject_GetInfoData();

                mtxt_TestTypeName.ReadOnly = true;

                mtxt_Tester.Text = _helperApp.GetUserName(HelperApp.UserApp.IdUser)?.ToUpper();

                mtxt_Tester.ReadOnly = true;

                mtxt_TestingDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

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
        private bool TEST_Concluded_DeleteFileData()
        {
            try
            {
                string _initialDirPathTestFile = System.IO.Path.Combine(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppTests_Path);

                string fileIdentificationTest =string.Empty;

                if (modelOperationalProjectTestConcluded != null && !string.IsNullOrEmpty(strIdProjectTestSampleSelect)) //delete SAMPLE
                    fileIdentificationTest = string.Concat('#', modelOperationalProjectTestConcluded.ProjectTestSample?.SampleSequence,'#', modelOperationalProjectTestConcluded.ProjectTestSample?.Project?.Identification?.Trim());
                else
                    fileIdentificationTest = bll_Project.GetProjectIdentificationByIdProject(strIdProjectSelect); //delete PROJECT

                string[] allFiles = System.IO.Directory.GetFiles(_initialDirPathTestFile);

                foreach (string file in allFiles)
                {
                    if (file.Contains(fileIdentificationTest.Trim()))
                        System.IO.File.Delete(file);
                }
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
                if (string.IsNullOrEmpty(mtxt_Ident.Text.Trim()))
                {
                    MessageBox.Show("Inform IDENT Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    Model_Operational_Project_TestConcluded modelPrjTestConcluded = new Model_Operational_Project_TestConcluded();

                    modelPrjTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

                    modelPrjTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();

                    modelPrjTestConcluded = HeaderDataToModel(modelPrjTestConcluded);

                    if (DialogResult.Yes == MessageBox.Show($"      Are you sure you want to create project \n\n\t      {modelPrjTestConcluded.ProjectTestSample.Project.Identification} \n\n            and all it´s measurement data? \n\n\t Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        int idProjectInsert = bll_Project.AddProject(modelPrjTestConcluded.ProjectTestSample.Project);

                        if (idProjectInsert > 0)
                        {
                            modelPrjTestConcluded.ProjectTestSample.Project.IdProject = idProjectInsert;
                            modelPrjTestConcluded.ProjectTestSample.IdProject = idProjectInsert;
                            modelPrjTestConcluded.ProjectTestSample.SampleSequence = modelPrjTestConcluded.ProjectTestSample.SampleSequence + 1;

                            int idProjectTestSampleInsert = bll_Project.AddProjectTestSample(modelPrjTestConcluded.ProjectTestSample);

                            if (idProjectTestSampleInsert > 0)
                            {
                                modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = idProjectTestSampleInsert;
                                HelperTestBase.ProjectTestConcluded = modelPrjTestConcluded;
                            }
                            else
                            {
                                HelperApp.lblstsbar03 = string.Empty;

                                HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                                MessageBox.Show("Failed, create Project Test Sample!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return false;
                            }
                        }
                        else
                        {
                            HelperApp.lblstsbar03 = string.Empty;

                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                            MessageBox.Show("Failed, created project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return false;
                        }
                    }
                    else
                        return false;
                }
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
                if (string.IsNullOrEmpty(mtxt_Ident.Text.Trim()))
                {
                    MessageBox.Show("Inform IDENT Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    Model_Operational_Project_TestConcluded modelPrjTestConcluded = new Model_Operational_Project_TestConcluded();
                    //modelPrjTestConcluded = HelperTestBase.ProjectTestConcluded;

                    Model_Operational_Project_TestSample modelPrjTestSample = new Model_Operational_Project_TestSample();

                    modelPrjTestConcluded.ProjectTestSample = new Model_Operational_Project_TestSample();

                    modelPrjTestConcluded.ProjectTestSample.Project = new Model_Operational_Project();

                    modelPrjTestConcluded = HeaderDataToModel(modelPrjTestConcluded);

                    if (modelPrjTestConcluded.IdProjectTestConcluded == 0)
                    {
                        modelPrjTestConcluded.IdProjectTestConcluded = modelOperationalProjectTestConcluded.IdProjectTestConcluded;
                        modelPrjTestConcluded.IdProjectTestSample = modelOperationalProjectTestConcluded.IdProjectTestSample;
                        modelPrjTestConcluded.IdTestAvailable = modelOperationalProjectTestConcluded.IdTestAvailable;
                        modelPrjTestConcluded.LastUpdatePTC = modelOperationalProjectTestConcluded.LastUpdatePTC;
                        modelPrjTestConcluded.ProjectTestFileName = modelOperationalProjectTestConcluded.ProjectTestFileName;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject = modelOperationalProjectTestConcluded.ProjectTestSample.Project.IdProject;
                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject = modelOperationalProjectTestConcluded.ProjectTestSample.IdProject;
                    }
                    
                    modelPrjTestConcluded.ProjectTestSample.Project.IdProject = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject;
                    modelPrjTestConcluded.ProjectTestSample.IdProject = HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject;
                    modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = modelOperationalProjectTestConcluded.IdProjectTestSample;
                    modelPrjTestConcluded.ProjectTestSample.SampleSequence = modelOperationalProjectTestConcluded.ProjectTestSample.SampleSequence;
                    modelPrjTestConcluded.ProjectTestSample.TestAvailable = modelOperationalProjectTestConcluded.ProjectTestSample.TestAvailable;

                    //update max sample
                    if (HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject > 0)
                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence = bll_Project.GetMaxProjectSampleTestByIdProject(HelperTestBase.ProjectTestConcluded.ProjectTestSample.IdProject.ToString());


                    modelPrjTestConcluded.ProjectTestSample.SampleSequence = HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence;
                    modelPrjTestConcluded.ProjectTestSample.SampleSequence = modelPrjTestConcluded.ProjectTestSample.SampleSequence + 1;

                    int idProjectTestSampleInsert = bll_Project.AddProjectTestSample(modelPrjTestConcluded.ProjectTestSample);

                    if (idProjectTestSampleInsert > 0)
                    {
                        modelPrjTestConcluded.ProjectTestSample.IdProjectTestSample = idProjectTestSampleInsert;
                        modelPrjTestConcluded.IdProjectTestSample = idProjectTestSampleInsert;
                        HelperTestBase.ProjectTestConcluded = modelPrjTestConcluded;
                    }
                    else
                    {
                        HelperApp.lblstsbar03 = string.Empty;

                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                        MessageBox.Show("Failed, create Project Test Sample!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
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
                int iExists = bll_Project.CheckProjectByIdent(mtxt_Ident.Text.Trim());

                if (iExists > 0)
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

        #region TREE
        private void TreeView_Populate(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            try
            {
                tree_Projects.BeginUpdate();

                foreach (DataRow row in dtParent.Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row["Name"].ToString(),
                        Tag = row["Id"]
                    };

                    if (parentId == 0)
                    {
                        string IdProject = child.Tag.ToString();

                        tree_Projects.Nodes.Add(child);
                        DataTable dtChild = bll_Project.GetProject_TestConcluded(IdProject, null);
                        TreeView_Populate(dtChild, Convert.ToInt32(child.Tag), child);
                    }
                    else
                    {
                        treeNode.Nodes.Add(child);
                    }
                }

                tree_Projects.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private void tree_Projects_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        ///---------------------------------------------------------------------------
        private void tree_Projects_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeView tv = sender as TreeView;

                if (tv != null)
                {
                    TreeNode selected = e.Node;
                    if (selected != null)
                    {
                        if (selected.Parent != null)
                        {
                            if (!string.IsNullOrEmpty(selected.Tag?.ToString()))
                            {
                                strIdProjectSelect = selected.Tag.ToString();

                                int idxTextRemove = selected.Text.ToString().IndexOf('-') + 2;

                                _strTestSel = selected.Text.Trim();

                                string strTestTypeName = !string.IsNullOrEmpty(_strTestSel?.Trim()) ? _strTestSel?.ToString().Substring(idxTextRemove, _strTestSel.Length - idxTextRemove).Trim() : string.Empty;

                                if (!string.IsNullOrEmpty(strTestTypeName))
                                {
                                    DataTable dt = bll_Project.GetChildTestsByProjectAndTestType(strIdProjectSelect, strTestTypeName);

                                    if (dt.Rows.Count > 0)
                                    {
                                        GridView_Populate(dt);

                                        mbtn_BDeleteProject.Enabled = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Projets not found with Test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Projets not found with Test!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(selected.Tag?.ToString()))
                            {
                                strIdProjectSelect = selected.Tag?.ToString()?.Trim();

                                DisableButtons();

                                mbtn_BDeleteProject.Enabled = true;
                            }
                            else
                            {
                                strIdProjectSelect = string.Empty;

                                mbtn_BDeleteProject.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///---------------------------------------------------------------------------
        private void tree_Projects_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("tree_TVExplorer_TabIndexChanged", _helperApp.appMsg_Name);

            //void __fastcall TFormLoadEval::TVExplorerChange(TObject *Sender, TTreeNode *Node)
        }
        ///---------------------------------------------------------------------------

        #endregion

        #region GRIDVIEW
        private void grid_ProjectTest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (grid_ProjectTest.SelectedCells.Count > 0)
                    {
                        DataGridViewRow row = grid_ProjectTest.Rows[e.RowIndex];

                        if (!string.IsNullOrEmpty(row.Cells["IdProject"].Value.ToString()))
                        {
                            modelOperationalProjectTestConcluded = GridView_GetSelectedProjectTestItem(row);

                            if (modelOperationalProjectTestConcluded != null)
                            {
                                if (selected_entry && modelOperationalProjectTestConcluded.IdProjectTestConcluded > 0)
                                {
                                    ModelToHeaderData(modelOperationalProjectTestConcluded);

                                    strIdProjectTestConcluded = modelOperationalProjectTestConcluded.IdProjectTestConcluded.ToString();
                                    strIdProjectTestSampleSelect = modelOperationalProjectTestConcluded.IdProjectTestSample.ToString();
                                    strIdProjectSelect = !string.IsNullOrEmpty(strIdProjectSelect) ? strIdProjectSelect : modelOperationalProjectTestConcluded.ProjectTestSample.IdProject.ToString();

                                    modelOperationalProjectTestConcluded.ProjectTestSample.Project.is_OnLIne = true;
                                    modelOperationalProjectTestConcluded.ProjectTestSample.Project.is_OnLIne = false;

                                    mbtn_BDeleteProject.Enabled = false;
                                    EnableButtons();
                                }
                            }
                            else
                                selected_entry = false;
                        }
                        else
                        {
                            MessageBox.Show("Please select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///---------------------------------------------------------------------------
        private void GridView_Populate(DataTable dt)
        {
            try
            {
                grid_ProjectTest.DataSource = dt;

                ////columns
                for (int i = 0; i < grid_ProjectTest.Columns.Count; i++)
                {
                    grid_ProjectTest.Columns[i].Visible = false;
                    grid_ProjectTest.Columns[i].ReadOnly = true;
                    grid_ProjectTest.Columns[i].HeaderCell.Value = String.Empty;
                    grid_ProjectTest.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grid_ProjectTest.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grid_ProjectTest.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    grid_ProjectTest.Columns[i].Resizable = DataGridViewTriState.False;
                }

                ////hide default grid's column's
                grid_ProjectTest.RowHeadersVisible = false;
                grid_ProjectTest.ColumnHeadersVisible = true;

                //show grid's column's

                grid_ProjectTest.Columns["SampleSequence"].HeaderText = "Sample";
                grid_ProjectTest.Columns["SampleSequence"].Visible = true;
                grid_ProjectTest.Columns["SampleSequence"].Width = 75;
                grid_ProjectTest.Columns["SampleSequence"].DisplayIndex = 0;

                grid_ProjectTest.Columns["LastUpdatePTS"].HeaderText = "Testing Date";
                grid_ProjectTest.Columns["LastUpdatePTS"].Visible = true;
                grid_ProjectTest.Columns["LastUpdatePTS"].Width = 150;
                grid_ProjectTest.Columns["LastUpdatePTS"].DisplayIndex = 1;

                grid_ProjectTest.Columns["CustomerType"].HeaderText = "Customer/Type";
                grid_ProjectTest.Columns["CustomerType"].Visible = true;
                grid_ProjectTest.Columns["CustomerType"].Width = 150;
                grid_ProjectTest.Columns["CustomerType"].DisplayIndex = 2;

                grid_ProjectTest.Columns["Booster"].HeaderText = "Booster #";
                grid_ProjectTest.Columns["Booster"].Visible = true;
                grid_ProjectTest.Columns["Booster"].Width = 130;
                grid_ProjectTest.Columns["Booster"].DisplayIndex = 3;

                grid_ProjectTest.Columns["TMC"].HeaderText = "TMC #";
                grid_ProjectTest.Columns["TMC"].Visible = true;
                grid_ProjectTest.Columns["TMC"].Width = 150;
                grid_ProjectTest.Columns["TMC"].DisplayIndex = 4;

                grid_ProjectTest.Columns["ProductionDate"].HeaderText = "Production Date";
                grid_ProjectTest.Columns["ProductionDate"].Visible = true;
                grid_ProjectTest.Columns["ProductionDate"].Width = 170;
                grid_ProjectTest.Columns["ProductionDate"].DisplayIndex = 5;

                grid_ProjectTest.Columns["UName"].HeaderText = "Operator";
                grid_ProjectTest.Columns["UName"].Visible = true;
                grid_ProjectTest.Columns["UName"].Width = 150;
                grid_ProjectTest.Columns["UName"].DisplayIndex = 6;

                grid_ProjectTest.Columns["Comment"].HeaderText = "Comment";
                grid_ProjectTest.Columns["Comment"].Visible = true;
                grid_ProjectTest.Columns["Comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grid_ProjectTest.Columns["Comment"].Width = 300;
                grid_ProjectTest.Columns["Comment"].DisplayIndex = 7;

                grid_ProjectTest.Columns["IdProjectTestConcluded"].Visible = true;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].Width = 0;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].DisplayIndex = 8;

                grid_ProjectTest.Columns["PartNumber"].Visible = true;
                grid_ProjectTest.Columns["PartNumber"].Width = 0;
                grid_ProjectTest.Columns["PartNumber"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["PartNumber"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["PartNumber"].DisplayIndex = 9;

                grid_ProjectTest.Columns["IdProject"].Visible = true;
                grid_ProjectTest.Columns["IdProject"].Width = 0;
                grid_ProjectTest.Columns["IdProject"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["IdProject"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["IdProject"].DisplayIndex = 10;

                grid_ProjectTest.Columns["IdProjectTestSample"].Visible = true;
                grid_ProjectTest.Columns["IdProjectTestSample"].Width = 0;
                grid_ProjectTest.Columns["IdProjectTestSample"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["IdProjectTestSample"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["IdProjectTestSample"].DisplayIndex = 11;

                grid_ProjectTest.Columns["Test"].Visible = true;
                grid_ProjectTest.Columns["Test"].Width = 0;
                grid_ProjectTest.Columns["Test"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["Test"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["Test"].DisplayIndex = 12;

                ////Changes grid's column's header's font size to 10.
                grid_ProjectTest.ColumnHeadersDefaultCellStyle.Font = new Font("", 10.0f, FontStyle.Bold);

                ////Changes grid's data's font size to 8.
                grid_ProjectTest.Font = new Font("", 8.0f);

                //selection
                grid_ProjectTest.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                grid_ProjectTest.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                grid_ProjectTest.DefaultCellStyle.SelectionForeColor = Color.Black;

                grid_ProjectTest.ClearSelection();
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
            mchk_CBPrintSeries.Checked = true;
            mchk_CBExportBitmapSeries.Checked = true;
            mchk_CBExportExcelSeries.Checked = true;
        }

        private void DisableChecks()
        {
            mchk_CBPrintSeries.Checked = false;
            mchk_CBExportBitmapSeries.Checked = false;
            mchk_CBExportExcelSeries.Checked = false;
        }

        #endregion

        #region BUTTONS
        private void EnableButtons()
        {
            mbtn_BDeleteTest.Enabled = true;
            mbtn_BLoadTest.Enabled = true;
        }
        private void DisableButtons()
        {
            mbtn_BDeleteProject.Enabled = false;
            mbtn_BDeleteTest.Enabled = false;
            mbtn_BLoadTest.Enabled = false;
        }
        private void mbtn_BLoadTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected_entry)
                {
                    if (modelOperationalProjectTestConcluded != null)
                    {
                        if (selected_entry && modelOperationalProjectTestConcluded.IdProjectTestConcluded > 0)
                        {
                            HelperApp.uiTesteSelecionado = (int)modelOperationalProjectTestConcluded.IdTestAvailable;

                            if (modelOperationalProjectTestConcluded?.ProjectTestSample != null)
                            {
                                if (HelperApp.uiProjectTestSampleSelecionado == 0 && HelperTestBase.ProjectTestSample.SampleSequence == 0)
                                {
                                    HelperTestBase.ProjectTestSample = modelOperationalProjectTestConcluded?.ProjectTestSample;
                                    HelperApp.uiProjectTestSampleSelecionado = (long)modelOperationalProjectTestConcluded?.ProjectTestSample.IdProjectTestSample;
                                }
                                else
                                {
                                    if (HelperTestBase.ProjectTestSample.Project.Identification.Equals(modelOperationalProjectTestConcluded?.ProjectTestSample.Project.Identification) && 
                                        HelperTestBase.ProjectTestSample.SampleSequence.Equals(modelOperationalProjectTestConcluded?.ProjectTestSample.SampleSequence))
                                    {
                                        selected_entry = false;

                                        MessageBox.Show("Error sample sequence already selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    else
                                    {
                                        HelperTestBase.ProjectTestSample = modelOperationalProjectTestConcluded?.ProjectTestSample;
                                        HelperApp.uiProjectTestSampleSelecionado = (long)modelOperationalProjectTestConcluded?.ProjectTestSample.IdProjectTestSample;
                                    }
                                }
                            }

                            if (modelOperationalProjectTestConcluded?.ProjectTestSample?.Project != null)
                            {
                                HelperApp.uiProjectSelecionado = (long)modelOperationalProjectTestConcluded?.ProjectTestSample?.Project.IdProject;
                                HelperTestBase.ProjectTest = modelOperationalProjectTestConcluded?.ProjectTestSample?.Project;
                            }

                            HelperTestBase.ProjectTestConcluded = modelOperationalProjectTestConcluded;
                            HelperApp.uiProjectTestConcludedSelecionado = modelOperationalProjectTestConcluded.IdProjectTestConcluded;
                        }
                    }

                    if (HelperTestBase.ProjectTestConcluded.IdProjectTestConcluded > 0 && HelperTestBase.ProjectTestSample?.Project?.IdProject > 0)
                    {
                        if (DialogResult.Yes == MessageBox.Show($"      You want the selected Project data  \n\n\t {HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.Identification} \n\n\t {_strTestSel} \n\n         all it´s measurement data ? \n\n        Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            HelperApp.bLoadPrjTestOffLine = true;

                            this.Close();
                        }
                    }
                }
                else
                {
                    HelperApp.bLoadPrjTestOffLine = false;
                    delegateFnLoadTestConcluded(false);

                    MessageBox.Show("Error no valid Test selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                HelperApp.bLoadPrjTestOffLine = false;

                delegateFnLoadTestConcluded(false);

                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            this.Close();
        }
        private void mbtn_BDeleteTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(strIdProjectSelect))
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure to drop the selected test and all it´s measurement data?" + "\n\n" + "\t Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        if (!bll_Project.DeleteTest(strIdProjectTestConcluded, strIdProjectTestSampleSelect))
                        {
                            MessageBox.Show("Error drop select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        { 
                            if(!TEST_Concluded_DeleteFileData())
                            {
                                MessageBox.Show("Error when deleting Test Files of select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        Load_StartInfoData();

                        MessageBox.Show("Test data sample DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Error no valid Test selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void mbtn_BDeleteProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(strIdProjectSelect))
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure to drop the selected Project and all it´s measurement data?" + "\n\n" + "\t Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        if (!TEST_Concluded_DeleteFileData())
                        {
                            MessageBox.Show("Error when deleting Test Files of select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (!bll_Project.DeleteProject(strIdProjectSelect))
                            {
                                MessageBox.Show("Error drop select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        Load_StartInfoData();

                        MessageBox.Show("Test data sample DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Error no valid Project selected!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        private void mbtn_BExportSeries_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(strIdProjectSelect))
            {
                if (mchk_CBPrintSeries.Checked || mchk_CBExportBitmapSeries.Checked || mchk_CBExportExcelSeries.Checked)
                {
                    //bool dir_selected = false;

                    //            // 2. export all wanted data
                    //            FormMain->BatchExport(CBMatchingOnly->Checked ? &match_list : &(database.Directory()->entrys),
                    //                                   FormSelectDir->SelectedDir(),
                    //                                   CBPrintSeries->Checked,
                    //                                   dir_selected && CBExportExcelSeries->Checked,
                    //                                   dir_selected && CBExportBitmapSeries->Checked);
                }
            }
        }
        private void mbtn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxt_Ident.Text.Trim()))
            {
                HelperApp.bLoadPrjTestOffLine = false;

                delegateFnLoadTestConcluded(false);
                this.Close();
            }
            else
            {
                if (CheckProjectExists())
                {
                    string strMsgProjectExists = String.Concat($"\t PROJECT { mtxt_Ident.Text.Trim() } EXISTS !", "\n\n\n", "\tDo you want SAVE NEW SAMPLE for Test ? ", "\n\n\n", $"\t\t {string.Concat("T",modelOperationalProjectTestConcluded.IdTestAvailable, " - ", modelOperationalProjectTestConcluded.ProjectTestSample.TestAvailable.Test)}");

                    if (DialogResult.No == MessageBox.Show(strMsgProjectExists, _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        HelperApp.bLoadPrjTestOffLine = false;

                        HelperApp.bPrjTestCreateNewSampleOnLine = false;

                        delegateFnLoadTestConcluded(false);
                        this.Close();
                    }
                    else
                    {
                        if (SaveProjectTestSampleData())
                        {
                            HelperApp.bLoadPrjTestOffLine = false;

                            HelperApp.bPrjTestCreateNewSampleOnLine = true;

                            HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, "");
                        }
                        else
                        {
                            HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;
                            CurrentProjectData_Clear();
                        }
                    }
                }
                else
                {
                    if (SaveProjectData())
                    {
                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = true;

                        HelperApp.bPrjTestCreateNewSampleOnLine = true;

                        HelperApp.uiProjectSelecionado = HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.IdProject;

                        HelperApp.lblstsbar03 = string.Concat("Ident # - [ ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project?.Identification, " ]", " - # Sample : ", HelperTestBase.ProjectTestConcluded.ProjectTestSample.SampleSequence, "");

                        MessageBox.Show("Success, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        HelperTestBase.ProjectTestConcluded.ProjectTestSample.Project.is_Created = false;

                        CurrentProjectData_Clear();
                    }

                    //HelperApp.bPrjTestCreateNewSampleOnLine = false;
                }

                HelperApp.bLoadPrjTestOffLine = false;

                delegateFnLoadTestConcluded(false);
                this.Close();
            }
        }

        #endregion
    }
}
