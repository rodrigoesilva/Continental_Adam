using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Enum;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Continental.Project.Adam.UI.Models.Security;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.Helper.Tests;
using Continental.Project.Adam.UI.Models.Manager;

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
        string strIdProjectSelect = string.Empty;
        string strIdTestSelect = string.Empty;

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
                //	UpdateSQLSet();
                AvailableProject_GetInfoData();

                Load_StartInfoData();

                mchk_CBPrintSeries.Checked = false;
                mchk_CBExportBitmapSeries.Checked = false;
                mchk_CBExportExcelSeries.Checked = false;
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
            if (HelperApp.uiProjectSelecionado > 0 && HelperApp.uiProjectSelecionado > 0)
                delegateFnLoadTestConcluded(true);
        }
        ///---------------------------------------------------------------------------
        ///
        #endregion

        #region Methods
        private void CurrentProjectData_Clear()
        {
            mtxt_EIdent.Text = string.Empty;
            mtxt_ECustomer.Text = string.Empty;
            mtxt_Booster.Text = string.Empty;
            mtxt_Tmc.Text = string.Empty;
            mtxt_ProductionDate.Text = string.Empty;
            mtxt_TO.Text = string.Empty;
            mtxt_Tester.Text = string.Empty;
            mtxt_TestingDate.Text = string.Empty;
            mtxt_Comment.Text = string.Empty;
        }
        ///---------------------------------------------------------------------------
        private void HeaderDataToDialog(Model_Operational_Project model)
        {
            try
            {
                mtxt_EIdent.Text = model.Identification?.ToString()?.Trim();
                mtxt_ECustomer.Text = model.CustomerType?.ToString()?.Trim();
                mtxt_Booster.Text = model.Booster?.ToString()?.Trim();
                mtxt_Tmc.Text = model.TMC?.ToString()?.Trim();
                mtxt_ProductionDate.Text = model.ProductionDate?.ToString()?.Trim();
                mtxt_TO.Text = model.T_O?.ToString()?.Trim();
                mtxt_Tester.Text = model?.User?.UName?.ToString()?.Trim();
                mtxt_TestingDate.Text = model.TestingDate?.ToString()?.Trim();
                mtxt_Comment.Text = model.Comment?.ToString()?.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private Model_Operational_Project_TestConcluded DialogToHeaderData(Model_Operational_Project_TestConcluded model)
        {
            try
            {
                string nullValue = "NULL";

                model.Project.Identification = !string.IsNullOrEmpty(mtxt_EIdent.Text) ? mtxt_EIdent.Text.Trim() : nullValue;
                model.Project.CustomerType = !string.IsNullOrEmpty(mtxt_ECustomer.Text) ? mtxt_ECustomer.Text.Trim() : nullValue;
                model.Project.Booster = !string.IsNullOrEmpty(mtxt_Booster.Text) ? mtxt_Booster.Text.Trim() : nullValue;
                model.Project.TMC = !string.IsNullOrEmpty(mtxt_Tmc.Text) ? mtxt_Tmc.Text.Trim() : nullValue;
                model.Project.ProductionDate = !string.IsNullOrEmpty(mtxt_ProductionDate.Text) ? mtxt_ProductionDate.Text.Trim() : nullValue;
                model.Project.T_O = !string.IsNullOrEmpty(mtxt_TO.Text) ? mtxt_TO.Text.Trim() : nullValue;
                model.Project.IdUserTester = !string.IsNullOrEmpty(mtxt_Tester.Text) ? _helperApp.GetUserIdByName(mtxt_Tester.Text) : HelperApp.UserId;
                model.Project.TestingDate = !string.IsNullOrEmpty(mtxt_TestingDate?.Text) ? mtxt_TestingDate.Text.Trim() : nullValue;
                model.Project.Comment = !string.IsNullOrEmpty(mtxt_Comment.Text) ? mtxt_Comment.Text.Trim() : nullValue;

                if (model.Project.IdUserTester != 0)
                {
                    var user = _helperApp.GetUser(model.Project.IdUserTester);

                    model.Project.User = new Model_SecurityUser()
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
                throw;
            }

            return model;
        }
        ///---------------------------------------------------------------------------
        private void AvailableProject_GetInfoData()
        {
            try
            {
                tree_Projects.Nodes.Clear();

                DataTable dt = bll_Project.GetAvailableProjects();

                TreeView_Populate(dt, 0, null);
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
                mtxt_Tester.Text = _helperApp.GetUserName(HelperApp.UserId)?.ToUpper();
                mtxt_Tester.ReadOnly = true;

                string strTestingDateFormat = string.Concat("MM/dd/yyyy", " - ", "HH:mm:ss");
                mtxt_TestingDate.Text = DateTime.Now.ToString(strTestingDateFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        ///---------------------------------------------------------------------------
        private void ClearExplorers()
        {
            tree_Projects.Nodes.Clear(); ;
            grid_ProjectTest.DataSource = null;
        }
        ///---------------------------------------------------------------------------
        private bool SaveProjectData()
        {
            try
            {
                if (string.IsNullOrEmpty(mtxt_EIdent.Text.Trim()))
                {
                    MessageBox.Show("Inform IDENT Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    Model_Operational_Project_TestConcluded modelPrjTestConcluded = new Model_Operational_Project_TestConcluded();

                    modelPrjTestConcluded.Project = new Model_Operational_Project();

                    modelPrjTestConcluded = DialogToHeaderData(modelPrjTestConcluded);

                    if (DialogResult.Yes == MessageBox.Show($"      Are you sure you want to create project \n\n\t\t {modelPrjTestConcluded.Project.Identification} \n\n\t and all it´s measurement data? \n\n\t  Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        int idProjectInsert = bll_Project.AddProject(modelPrjTestConcluded.Project);

                        if (idProjectInsert > 0)
                        {
                            HelperTestBase.ProjectTestConcluded.Project.is_Created = true;
                            HelperApp.uiProjectSelecionado = idProjectInsert;
                            HelperTestBase.ProjectTestConcluded.Project = modelPrjTestConcluded.Project;
                        }
                        else
                        {
                            HelperTestBase.ProjectTestConcluded.Project.is_Created = false;

                            MessageBox.Show("Failed, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool CheckProjectExists()
        {
            try
            {
                int iExists = bll_Project.CheckProjectByIdent(mtxt_EIdent.Text.Trim());

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


        //    void __fastcall TFormLoadEval::LVExplorerCompare(TObject * Sender,
        //                                                      TListItem * Item1,
        //                                                      TListItem * Item2,
        //                                                      int Data,
        //                                                      int & Compare)
        //{
        //        cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry1 = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Item1->Data);
        //        cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry2 = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Item2->Data);

        //        Compare = -strcmp(entry1->header.UniqueID.c_str(), entry2->header.UniqueID.c_str());
        //    }

        ///---------------------------------------------------------------------------
        ///
        ///---------------------------------------------------------------------------

        //    void __fastcall TFormLoadEval::LVExplorerSelectItem(TObject * Sender, TListItem * Item, bool Selected)
        //{
        //        EIdent->Text = "";
        //        ECustomer->Text = "";
        //        ETestingDate->Text = "";
        //        EProduct1->Text = "";
        //        EProduct2->Text = "";
        //        EProduct3->Text = "";
        //        ETester->Text = "";
        //        EProduct4->Text = "";
        //        LComment->CxLabel = "";

        //        if (Selected)
        //        {
        //            selected_entry = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Item->Data);

        //            if (selected_entry)
        //            {
        //                EIdent->Text = selected_entry->header.Ident;

        //                if (strlen(selected_entry->header.UniqueID.c_str()) > 0)
        //                {
        //                    ECustomer->Text = selected_entry->header.Customer;

        //                    if (Item->SubItems->Count > 0)    // there will be the complete header info only if it's a leaf (Count > 0)
        //                        HeaderDataToDialog(&(selected_entry->header));
        //                }
        //            }
        //        }
        //        else
        //            selected_entry = 0;
        //    }

        ///---------------------------------------------------------------------------

        //void __fastcall TFormLoadEval::TVExplorerChange(TObject *Sender, TTreeNode *Node)
        //{
        //    if (no_lv_update)
        //        return;

        //    ClearLVExplorer();

        //    LVExplorer->Items->BeginUpdate();

        //#define BUILD_COL_EX(_caption)               \
        //    column = LVExplorer->Columns->Add();      \
        //    column->Caption = _caption;                \
        //    column->Width = ColumnTextWidth;

        //#define BUILD_COL(_item_type)                                                                                   \
        //    BUILD_COL_EX(cPF_STRING(cDATABASE::sEXAMFILE::db_headinfo[cDATABASE::sEXAMFILE::_item_type].Caption()));  \

        //  try
        //    {
        //        selected_entry = (cDATABASE_FILEDB::sDIRECTORY::sENTRY*)(Node->Data);

        //        if (selected_entry)
        //        {
        //            // create new columns of the list-view
        //            TListColumn* column;

        //            BUILD_COL(IT_Customer)
        //          BUILD_COL(IT_TestingDate)
        //          BUILD_COL(IT_Product1)
        //          BUILD_COL(IT_Product2)
        //          BUILD_COL(IT_Product3)
        //          BUILD_COL(IT_Tester)
        //          BUILD_COL(IT_Product4)
        //          BUILD_COL(IT_Comment)

        //      cDATABASE_FILEDB::sDIRECTORY::sENTRY* entry = database.Directory()->First();
        //            while (entry)
        //            {
        //                if (strcmp(entry->header.Ident.c_str(), selected_entry->header.Ident.c_str()) == 0
        //                    && entry->header.ExamType == selected_entry->header.ExamType
        //                    && (!CBMatchingOnly->Checked
        //                        || ((strlen(EIdent->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Ident.c_str(), EIdent->Text.Trim().c_str()))
        //                            && (strlen(ECustomer->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Customer.c_str(), ECustomer->Text.Trim().c_str()))
        //                            && (strlen(EProduct1->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Product1.c_str(), EProduct1->Text.Trim().c_str()))
        //                            && (strlen(EProduct2->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Product2.c_str(), EProduct2->Text.Trim().c_str()))
        //                            && (strlen(EProduct3->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Product3.c_str(), EProduct3->Text.Trim().c_str()))
        //                            && (strlen(EProduct4->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Product4.c_str(), EProduct4->Text.Trim().c_str()))
        //                            && (strlen(ETestingDate->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.TestingDate.c_str(), ETestingDate->Text.Trim().c_str()))
        //                            && (strlen(ETester->Text.Trim().c_str()) == 0
        //                                || strstr(entry->header.Tester.c_str(), ETester->Text.Trim().c_str())))))
        //                {
        //                    TListItem* list_item = LVExplorer->Items->Add();
        //                    list_item->Caption = entry->header.Customer;

        //                    switch (entry->header.DataType)
        //                    {
        //                        default:
        //                        case cDATABASE::sEXAMFILE::DT_UNKNOWN:
        //                            list_item->ImageIndex = 0;
        //                            break;
        //                        case cDATABASE::sEXAMFILE::DT_EXAM:
        //                            list_item->ImageIndex = 1;
        //                            break;
        //                        case cDATABASE::sEXAMFILE::DT_PURE_PARAMSET:
        //                            list_item->ImageIndex = 2;
        //                            break;
        //                    }

        //                    list_item->Data = (void*)entry;

        //                    list_item->SubItems->Add(entry->header.TestingDate);
        //                    list_item->SubItems->Add(entry->header.Product1);
        //                    list_item->SubItems->Add(entry->header.Product2);
        //                    list_item->SubItems->Add(entry->header.Product3);
        //                    list_item->SubItems->Add(entry->header.Tester);
        //                    list_item->SubItems->Add(entry->header.Product4);
        //                    list_item->SubItems->Add(entry->header.Comment);
        //                }

        //                entry = database.Directory()->Next();
        //            }
        //        }
        //    }
        //    catch (...) { }

        //    LVExplorer->AlphaSort();

        //    LVExplorer->Items->EndUpdate();
        //    }

        ///---------------------------------------------------------------------------

        //        AnsiString & TFormLoadEval::BuildBackupDirName(void)
        //    {
        //            static AnsiString result;

        //            char buf[100];
        //            time_t t = time(NULL);

        //    struct tm * loctm = localtime(&t);
        //    sprintf(buf, "Conti_Backup_%.2d.%.2d.%.2d_%.2d.%.2d.%.2d", loctm->tm_mday, loctm->tm_mon + 1, (loctm->tm_year) % 100,
        //																														  loctm->tm_hour, loctm->tm_min, loctm->tm_sec);

        //	result = buf;
        //	return result;
        //    }

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
                            string idProject = selected.Tag.ToString();

                            DataTable dt = bll_Project.GetChildTestsByProject(idProject);

                            GridView_Populate(dt);

                            mbtn_BDeleteTest.Enabled = true;
                            mbtn_BLoadTest.Enabled = true;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(selected.Tag?.ToString()))
                            {
                                strIdProjectSelect = selected.Tag?.ToString()?.Trim();

                                mbtn_BDeleteProject.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
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
                                    HeaderDataToDialog(modelOperationalProjectTestConcluded.Project);
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
                throw;
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

                grid_ProjectTest.Columns["CustomerType"].HeaderText = "Customer/Type";
                grid_ProjectTest.Columns["CustomerType"].Visible = true;
                grid_ProjectTest.Columns["CustomerType"].Width = 150;
                grid_ProjectTest.Columns["CustomerType"].DisplayIndex = 0;

                grid_ProjectTest.Columns["TestingDate"].HeaderText = "Testing Date";
                grid_ProjectTest.Columns["TestingDate"].Visible = true;
                grid_ProjectTest.Columns["TestingDate"].Width = 150;
                grid_ProjectTest.Columns["TestingDate"].DisplayIndex = 1;

                grid_ProjectTest.Columns["Booster"].HeaderText = "Booster #";
                grid_ProjectTest.Columns["Booster"].Visible = true;
                grid_ProjectTest.Columns["Booster"].Width = 130;
                grid_ProjectTest.Columns["Booster"].DisplayIndex = 2;

                grid_ProjectTest.Columns["TMC"].HeaderText = "TMC #";
                grid_ProjectTest.Columns["TMC"].Visible = true;
                grid_ProjectTest.Columns["TMC"].Width = 150;
                grid_ProjectTest.Columns["TMC"].DisplayIndex = 3;

                grid_ProjectTest.Columns["ProductionDate"].HeaderText = "Production Date";
                grid_ProjectTest.Columns["ProductionDate"].Visible = true;
                grid_ProjectTest.Columns["ProductionDate"].Width = 170;
                grid_ProjectTest.Columns["ProductionDate"].DisplayIndex = 4;

                grid_ProjectTest.Columns["UName"].HeaderText = "Operator";
                grid_ProjectTest.Columns["UName"].Visible = true;
                grid_ProjectTest.Columns["UName"].Width = 150;
                grid_ProjectTest.Columns["UName"].DisplayIndex = 5;

                grid_ProjectTest.Columns["Comment"].HeaderText = "Comment";
                grid_ProjectTest.Columns["Comment"].Visible = true;
                grid_ProjectTest.Columns["Comment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grid_ProjectTest.Columns["Comment"].Width = 300;
                grid_ProjectTest.Columns["Comment"].DisplayIndex = 6;

                grid_ProjectTest.Columns["IdProjectTestConcluded"].Visible = true;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].Width = 0;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["IdProjectTestConcluded"].DisplayIndex = 7;

                grid_ProjectTest.Columns["IdProject"].Visible = true;
                grid_ProjectTest.Columns["IdProject"].Width = 0;
                grid_ProjectTest.Columns["IdProject"].DefaultCellStyle.BackColor = Color.White;
                grid_ProjectTest.Columns["IdProject"].DefaultCellStyle.ForeColor = Color.White;
                grid_ProjectTest.Columns["IdProject"].DisplayIndex = 8;

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
                    IdProject = (long)gvRow.Cells["IdProject"].Value,
                    IdTestAvailable = (long)gvRow.Cells["IdTestAvailable"].Value,
                    TestDateTime = gvRow.Cells["TestDateTime"].Value?.ToString()?.Trim(),
                    TestTypeName = gvRow.Cells["TestTypeName"].Value?.ToString()?.Trim(), //Test
                    TestIdentName = gvRow.Cells["TestIdentName"].Value?.ToString()?.Trim(),
                    TestFileName = gvRow.Cells["TestFileName"].Value?.ToString()?.Trim(),
                    LastUpdate = gvRow.Cells["LastUpdate"].Value != null ? gvRow.Cells["LastUpdate"].Value?.ToString()?.Trim() : DateTime.Now.ToString(),

                    Project = new Model_Operational_Project()
                    {
                        IdProject = (long)gvRow.Cells["IdProject1"].Value,
                        Identification = gvRow.Cells["Identification"].Value?.ToString()?.Trim(),
                        CustomerType = gvRow.Cells["CustomerType"].Value?.ToString()?.Trim(),
                        Booster = gvRow.Cells["Booster"].Value?.ToString()?.Trim(),
                        TMC = gvRow.Cells["TMC"].Value?.ToString()?.Trim(),
                        ProductionDate = gvRow.Cells["ProductionDate"].Value?.ToString()?.Trim(),
                        T_O = gvRow.Cells["T_O"].Value?.ToString()?.Trim(),
                        IdUserTester = (long)gvRow.Cells["IdUserTester"].Value,
                        TestingDate = gvRow.Cells["TestingDate"].Value?.ToString()?.Trim(),
                        Comment = gvRow.Cells["Comment"].Value?.ToString()?.Trim(),
                        TestAvailable = new Model_Manager_TestAvailable()
                        {
                            IdTestAvailable = (long)gvRow.Cells["IdTestAvailable"].Value
                        },
                        User = new Model_SecurityUser()
                        {
                            IdUser = (long)gvRow.Cells["IdUserTester"].Value,
                            ULogin = gvRow.Cells["ULogin"].Value?.ToString()?.Trim(),
                            UName = gvRow.Cells["UName"].Value.ToString()?.Trim()
                        }
                    }
                };

                if (gvModelProjectTestConcluded.IdProjectTestConcluded != 0)
                {
                    gvModelProjectTestConcluded.Project.examtype = _helperApp.SelectedExamType(gvModelProjectTestConcluded.Project.IdProject);
                    
                    strIdProjectTestConcluded = gvModelProjectTestConcluded.IdProjectTestConcluded.ToString();

                    if (!string.IsNullOrEmpty(strIdProjectTestConcluded))
                    {
                        HelperTestBase.ProjectTest = gvModelProjectTestConcluded?.Project;

                        strIdProjectSelect = gvModelProjectTestConcluded?.Project?.IdProject.ToString();
                        strIdTestSelect = gvModelProjectTestConcluded?.Project?.TestAvailable?.IdTestAvailable.ToString();

                        gvModelProjectTestConcluded.IdProject = !string.IsNullOrEmpty(gvModelProjectTestConcluded.IdProject.ToString()) ? gvModelProjectTestConcluded.IdProject : gvModelProjectTestConcluded.Project.IdProject;
                        gvModelProjectTestConcluded.IdTestAvailable = !string.IsNullOrEmpty(gvModelProjectTestConcluded.IdTestAvailable.ToString()) ? gvModelProjectTestConcluded.IdTestAvailable : (long)gvModelProjectTestConcluded?.Project.TestAvailable.IdTestAvailable;
                        gvModelProjectTestConcluded.TestDateTime = !string.IsNullOrEmpty(gvModelProjectTestConcluded.TestDateTime) ? gvModelProjectTestConcluded.TestDateTime : gvModelProjectTestConcluded.Project.TestingDate.ToString();
                        gvModelProjectTestConcluded.TestTypeName = !string.IsNullOrEmpty(gvModelProjectTestConcluded.TestTypeName) ? gvModelProjectTestConcluded.TestTypeName : gvModelProjectTestConcluded.Project.examtype.ToString();
                        gvModelProjectTestConcluded.TestIdentName = !string.IsNullOrEmpty(gvModelProjectTestConcluded.TestIdentName) ? gvModelProjectTestConcluded.TestIdentName : gvModelProjectTestConcluded.Project.Identification.ToString();
                        
                        HelperApp.uiProjectSelecionado = Convert.ToInt32(strIdProjectSelect);
                        HelperApp.uiTesteSelecionado = Convert.ToInt32(strIdTestSelect);

                        HelperTestBase.ProjectTestConcluded = gvModelProjectTestConcluded;
                    }

                    selected_entry = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return gvModelProjectTestConcluded;
        }
        ///---------------------------------------------------------------------------

        #endregion

        #region BUTTONS
        private void mbtn_BLoadTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (selected_entry)
                {
                    if (HelperTestBase.ProjectTestConcluded.Project.IdProject != null)
                    {
                        HelperTestBase.ProjectTest = HelperTestBase.ProjectTestConcluded.Project;

                        if (DialogResult.Yes == MessageBox.Show($"      You want the selected Project data  \n\n\t {HelperTestBase.ProjectTestConcluded.Project.Identification} \n\n    and all it´s measurement data ? \n\n        Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {

                            delegateFnLoadTestConcluded(false);

                            HelperApp.uiProjectSelecionado = !string.IsNullOrEmpty(strIdProjectSelect) ? Convert.ToInt32(strIdProjectSelect) : 0;

                            HelperApp.uiProjectTestSelecionado = !string.IsNullOrEmpty(strIdTestSelect) ? Convert.ToInt32(strIdTestSelect) : 0;

                            this.Close();
                        }
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
                    if (DialogResult.Yes == MessageBox.Show("Are you sure to drop the selected test and all it´s measurement data?" + "\n" + "Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        if (!bll_Project.DeleteTest(strIdProjectSelect))
                            MessageBox.Show("Error drop select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Test data DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //        UpdateSQLSet();
                        AvailableProject_GetInfoData();
                    }
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
                if (!string.IsNullOrEmpty(strIdProjectTestConcluded) && !string.IsNullOrEmpty(strIdProjectSelect))
                {
                    if (DialogResult.Yes == MessageBox.Show("Are you sure to drop the selected test and all it´s measurement data?" + "\n" + "Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        //delet project test
                        if (!bll_Project.DeleteProjectTestConcluded(strIdProjectTestConcluded, strIdProjectSelect))
                            MessageBox.Show("Error drop select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Project data DELETED !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AvailableProject_GetInfoData();
                    }
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
            if (string.IsNullOrEmpty(mtxt_EIdent.Text.Trim()))
            {
                delegateFnLoadTestConcluded(false);
                this.Close();
            }
            else
            {
                if (!selected_entry)
                {
                    if (CheckProjectExists())
                    {
                        MessageBox.Show("Failed, Project Exist!", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (SaveProjectData())
                        {
                            HelperTestBase.ProjectTestConcluded.Project.is_Created = true;

                            MessageBox.Show("Success, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            HelperTestBase.ProjectTestConcluded.Project.is_Created = false;

                            CurrentProjectData_Clear();
                        }
                    }
                }

                this.Close();
            }
        }

        #endregion
    }
}
