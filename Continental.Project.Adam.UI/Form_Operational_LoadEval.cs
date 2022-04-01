using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using System.ComponentModel;
using System.Linq;
using System.Collections;
using Continental.Project.Adam.UI.Models.Operational;
using Continental.Project.Adam.UI.Enum;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using Continental.Project.Adam.UI.Models.Security;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.Helper.Tests;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_LoadEval : Form
    {
        #region Define

        HelperApp _helperApp = new HelperApp();
        HelperAdam _helperAdam = new HelperAdam();

        BLL_Operational_LoadEval bll_Operational_LoadEval = new BLL_Operational_LoadEval();

        Model_Operational_Project modelOperationalProject = new Model_Operational_Project();

        bool selected_entry = false;

        string IdProjectSelect = string.Empty;
        #endregion

        #region Construtor
        public Form_Operational_LoadEval(eEXAMTYPE sel_examtype, string udt_filename)
        {
            InitializeComponent();
        }

        #endregion

        #region Form

        ///---------------------------------------------------------------------------
        private void Form_Operational_LoadEval_Load(object sender, EventArgs e)
        {
            //	UpdateSQLSet();
            AvailableProject_GetInfoData();

            Load_StartInfoData();

            mchk_CBPrintSeries.Checked = false;
            mchk_CBExportBitmapSeries.Checked = false;
            mchk_CBExportExcelSeries.Checked = false;
        }

        ///---------------------------------------------------------------------------

        private void Form_Operational_LoadEval_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        ///---------------------------------------------------------------------------
        private void Form_Operational_LoadEval_FormClosing(object sender, FormClosingEventArgs e)
        {
            var abc = e.CloseReason;

            //ClearExplorers();

            //mbtn_BLoadMeasurement_Click(sender, e);

            //var formTests = new trash.Form_Tests();

            //formTests.btnLoadSel_Click(sender, e);

            //e.Cancel = true;
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
        private void HeaderDataToDialog(Model_Operational_Project model)
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
        ///---------------------------------------------------------------------------
        private Model_Operational_Project DialogToHeaderData(Model_Operational_Project model)
        {
            string nullValue = "NULL";

            model.Identification = !string.IsNullOrEmpty(mtxt_EIdent.Text) ? mtxt_EIdent.Text.Trim() : nullValue;
            model.CustomerType = !string.IsNullOrEmpty(mtxt_ECustomer.Text) ? mtxt_ECustomer.Text.Trim() : nullValue;
            model.Booster = !string.IsNullOrEmpty(mtxt_Booster.Text) ? mtxt_Booster.Text.Trim() : nullValue;
            model.TMC = !string.IsNullOrEmpty(mtxt_Tmc.Text) ? mtxt_Tmc.Text.Trim() : nullValue;
            model.ProductionDate = !string.IsNullOrEmpty(mtxt_ProductionDate.Text) ? mtxt_ProductionDate.Text.Trim() : nullValue;
            model.T_O = !string.IsNullOrEmpty(mtxt_TO.Text) ? mtxt_TO.Text.Trim() : nullValue;
            model.IdUserTester = !string.IsNullOrEmpty(mtxt_Tester.Text) ? _helperApp.GetUserIdByName(mtxt_Tester.Text) : HelperApp.UserId;
            model.TestingDate = !string.IsNullOrEmpty(mtxt_TestingDate?.Text) ? mtxt_TestingDate.Text.Trim() : nullValue;
            model.Comment = !string.IsNullOrEmpty(mtxt_Comment.Text) ? mtxt_Comment.Text.Trim() : nullValue;

            if (model.IdUserTester != 0)
            {
                var user = _helperApp.GetUser(model.IdUserTester);

                model.User = new Model_SecurityUser()
                {
                    IdUser = (long)user.IdUser,
                    ULogin = user.ULogin?.ToString()?.Trim(),
                    UName = user.UName?.ToString()?.Trim()
                };
            }
            
            return model;
        }
        ///---------------------------------------------------------------------------
        private void AvailableProject_GetInfoData()
        {
            DataTable dt = bll_Operational_LoadEval.GetAvailableProjects();

            TreeView_Populate(dt, 0, null);
        }
        ///---------------------------------------------------------------------------
        private void Load_StartInfoData()
        {
            mtxt_Tester.Text = _helperApp.GetUserName(HelperApp.UserId);
            mtxt_Tester.ReadOnly = true;

            string strTestingDateFormat = string.Concat("MM/dd/yyyy", " - ", "HH:mm:ss");
            mtxt_TestingDate.Text = DateTime.Now.ToString(strTestingDateFormat);
        }
        ///---------------------------------------------------------------------------
        private void ClearExplorers()
        {
            tree_TVExplorer.Nodes.Clear(); ;
            grid_LVExplorer.DataSource = null;
        }
        ///---------------------------------------------------------------------------
        private bool SaveProjectData()
        {
            try
            {
                if (HelperApp.examtype != eEXAMTYPE.ET_NONE)
                {
                    HelperApp.examtype = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado);
                    HelperTestBase.eExamType = EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado);

                    if (string.IsNullOrEmpty(mtxt_EIdent.Text.Trim()))
                    {
                        MessageBox.Show("Inform IDENT Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        Model_Operational_Project modelPrj = new Model_Operational_Project();

                        modelPrj = DialogToHeaderData(modelPrj);

                        //TODO
                        modelPrj.examtype = HelperApp.examtype;

                        string testTypeName = HelperApp.uiTesteSelecionado == 0 ? EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(modelPrj.examtype.ToString()).ToString() : EnumExtensionMethods.GetEnumValue<eEXAMTYPE>(HelperApp.uiTesteSelecionado).ToString();

                        if (DialogResult.Yes == MessageBox.Show($"Are you sure create test \n\n {modelPrj.Identification} \n\n and all it´s measurement data? \n\n  Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            int sucessInsert = bll_Operational_LoadEval.AddProject(modelPrj);

                            if (sucessInsert == 1)
                            {
                                string dirPathTestFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppTests_Path);

                                string testIdentName = Regex.Replace(modelPrj.Identification, @"\.|-|\s|_|;", "-");

                                string prjTestFilename = string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), "#", HelperApp.uiTesteSelecionado, "#", testTypeName, "#", testIdentName, _helperApp.AppTests_DefaultExtension);

                                if (!string.IsNullOrEmpty(prjTestFilename))
                                {
                                    if (_helperApp.AppTests_UseBinFormat)
                                        _helperApp.AppTests_UseBinFormat = false;
                                    //WriteBinaryFile(prjTestFilename, udtHeaderFile);
                                    else
                                    {
                                        modelPrj.PrjTestFileName = prjTestFilename.Trim();

                                        prjTestFilename = string.Concat(dirPathTestFile, prjTestFilename);

                                        File.AppendAllText(prjTestFilename, _helperApp.AppendTxtData_Header_ActuationType().ToString());
                                    }
                                }

                                HelperTestBase.currentTestFile = modelPrj;
                                HelperTestBase.eExamType = modelPrj.examtype;
                            }
                            else
                            {
                                MessageBox.Show("Failed, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Its necessary create testt ", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //var formMain = new Form_Adam_Main(false, false, HelperApp.examtype);
                    //this.Dispose();

                    //int TShActuationParams = 2;

                    //formMain.ActivePage(TShActuationParams);

                    //formMain.SetNewTestProgram(sel_examtype, udt_filename);

                    //PCMain->ActivePage = TShActuationParams;

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

        ///
        ///---------------------------------------------------------------------------
        ///

        #region Events
        private void mchk_CBMatchingOnly_CheckedChanged(object sender, EventArgs e)
        {
            //        UpdateSQLSet();
            AvailableProject_GetInfoData();

            //        if (CBMatchingOnly->Checked)
            //        {
            //            TVExplorer->Color = 0x00A0FFFF;
            //            LVExplorer->Color = 0x00A0FFFF;
            //        }
            //        else
            //        {
            //            TVExplorer->Color = clWindow;
            //            LVExplorer->Color = clWindow;
            //        }
        }


        #region TREE

        private void TreeView_Populate(DataTable dtParent, int parentId, TreeNode treeNode)
        {
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

                    tree_TVExplorer.Nodes.Add(child);
                    DataTable dtChild = bll_Operational_LoadEval.GetProjects_x_Tests(IdProject,null);
                    TreeView_Populate(dtChild, Convert.ToInt32(child.Tag), child);
                }
                else
                {
                    treeNode.Nodes.Add(child);
                }
            }
        }
        ///---------------------------------------------------------------------------
        private void TreeView_Populate1(DataTable dtParent, int parentId, TreeNode treeNode)
        {
            foreach (DataRow row in dtParent.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["Name"].ToString(),
                    Tag = row["Id"]
                };

                if (parentId == 0)
                {
                    string IdTestGroup = child.Tag.ToString();

                    tree_TVExplorer.Nodes.Add(child);
                    DataTable dtChild = bll_Operational_LoadEval.GetNodeAvailableTests(IdTestGroup);
                    TreeView_Populate(dtChild, Convert.ToInt32(child.Tag), child);
                }
                else
                {
                    treeNode.Nodes.Add(child);
                }
            }
        }

        ///---------------------------------------------------------------------------
        private void tree_TVExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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

                        DataTable dt = bll_Operational_LoadEval.GetTestsFromProject(idProject);

                        GridView_Populate(dt);
                    }
                }
            }
        }
        ///---------------------------------------------------------------------------
        private void tree_TVExplorer_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("tree_TVExplorer_TabIndexChanged", _helperApp.appMsg_Name);

            //void __fastcall TFormLoadEval::TVExplorerChange(TObject *Sender, TTreeNode *Node)
        }
        ///---------------------------------------------------------------------------

        #endregion

        #region GRIDVIEW

        private void grid_LVExplorer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grid_LVExplorer.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = grid_LVExplorer.Rows[e.RowIndex];

                    if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
                    {
                        modelOperationalProject = GridView_GetSelectedProjectItem(row);

                        if (modelOperationalProject != null)
                        {
                            if (selected_entry)
                                HeaderDataToDialog(modelOperationalProject);
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
        ///---------------------------------------------------------------------------
        private void GridView_Populate(DataTable dt)
        {
            grid_LVExplorer.DataSource = dt;

            ////Changes grid's column's header's font size to 10.
            grid_LVExplorer.ColumnHeadersDefaultCellStyle.Font = new Font("", 10.0f, FontStyle.Bold);

            ////Changes grid's data's font size to 8.
            grid_LVExplorer.Font = new Font("", 8.0f);

            ////hide grid's column's
            grid_LVExplorer.RowHeadersVisible = false;
            grid_LVExplorer.ColumnHeadersVisible = true;

            grid_LVExplorer.Columns["IdProject"].Visible = false;
            grid_LVExplorer.Columns["IdProject"].Width = 0;

            grid_LVExplorer.Columns["Identification"].Visible = false;
            grid_LVExplorer.Columns["Identification"].Width = 0;

            grid_LVExplorer.Columns["T_O"].Visible = false;
            grid_LVExplorer.Columns["T_O"].Width = 0;

            grid_LVExplorer.Columns["IdUserTester"].Visible = false;
            grid_LVExplorer.Columns["IdUserTester"].Width = 0;

            grid_LVExplorer.Columns["ULogin"].Visible = false;
            grid_LVExplorer.Columns["ULogin"].Width = 0;

            //////sized grid's column's
            grid_LVExplorer.Columns["CustomerType"].Width = 130;
            grid_LVExplorer.Columns["TestingDate"].Width = 130;
            grid_LVExplorer.Columns["Booster"].Width = 100;
            grid_LVExplorer.Columns["TMC"].Width = 130;
            grid_LVExplorer.Columns["ProductionDate"].Width = 130;
            grid_LVExplorer.Columns["UName"].Width = 150;
            grid_LVExplorer.Columns["Comment"].Width = 300;

            ////alignment
            for (int i = 0; i < grid_LVExplorer.Columns.Count; i++)
            {
                grid_LVExplorer.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grid_LVExplorer.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grid_LVExplorer.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                grid_LVExplorer.Columns[i].Resizable = DataGridViewTriState.False;
            }

            //columsn order
            grid_LVExplorer.Columns["CustomerType"].DisplayIndex = 0;
            grid_LVExplorer.Columns["TestingDate"].DisplayIndex = 1;
            grid_LVExplorer.Columns["Booster"].DisplayIndex = 2;
            grid_LVExplorer.Columns["TMC"].DisplayIndex = 3;
            grid_LVExplorer.Columns["ProductionDate"].DisplayIndex = 4;
            grid_LVExplorer.Columns["UName"].DisplayIndex = 5;
            grid_LVExplorer.Columns["Comment"].DisplayIndex = 6;

            //columsn order
            grid_LVExplorer.Columns["CustomerType"].HeaderText = "Customer/Type";
            grid_LVExplorer.Columns["TestingDate"].HeaderText = "Testing Date";
            grid_LVExplorer.Columns["Booster"].HeaderText = "Booster #";
            grid_LVExplorer.Columns["TMC"].HeaderText = "TMC #";
            grid_LVExplorer.Columns["ProductionDate"].HeaderText = "Production Date";
            grid_LVExplorer.Columns["UName"].HeaderText = "Operator";

            //selection
            grid_LVExplorer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid_LVExplorer.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            grid_LVExplorer.DefaultCellStyle.SelectionForeColor = Color.Black;

            grid_LVExplorer.ClearSelection();
        }
        ///---------------------------------------------------------------------------
        private Model_Operational_Project GridView_GetSelectedProjectItem(DataGridViewRow gvRow)
        {

            CurrentProjectData_Clear();

            var gvModelProject = new Model_Operational_Project()
            {
                Id = (long)gvRow.Cells[0].Value,
                Identification = gvRow.Cells[1].Value?.ToString()?.Trim(),
                CustomerType = gvRow.Cells[2].Value?.ToString()?.Trim(),
                Booster = gvRow.Cells[3].Value?.ToString()?.Trim(),
                TMC = gvRow.Cells[4].Value?.ToString()?.Trim(),
                ProductionDate = gvRow.Cells[5].Value?.ToString()?.Trim(),
                T_O = gvRow.Cells[6].Value?.ToString()?.Trim(),
                IdUserTester = (long)gvRow.Cells[7].Value,
                TestingDate = gvRow.Cells[8].Value?.ToString()?.Trim(),
                Comment = gvRow.Cells[9].Value?.ToString()?.Trim(),
                User = new Model_SecurityUser()
                {
                    IdUser = (long)gvRow.Cells[7].Value,
                    ULogin = gvRow.Cells[11].Value?.ToString()?.Trim(),
                    UName = gvRow.Cells[10].Value.ToString()?.Trim()
                }
            };

            if (gvModelProject.Id != 0)
            {
                gvModelProject.examtype = _helperApp.SelectedExamType(gvModelProject.Id);

                IdProjectSelect = gvModelProject.Id.ToString();

                selected_entry = true;
            }

            return gvModelProject;
        }
        ///---------------------------------------------------------------------------
        #endregion

        #region BUTTONS
        private void mbtn_BLoadMeasurement_Click(object sender, EventArgs e)
        {
            HelperApp.examtype = modelOperationalProject.examtype;

            //var formMain = new Form_Adam_Main(false, false, HelperApp.examtype);

            var formTests = new trash.Form_Tests();

            List<string> lstReturnRead = new List<string>();

            try
            {

                var b = formTests.Controls.Find("btnLoadSel", true).OfType<Button>().FirstOrDefault();
                if (b != null)
                    b.PerformClick();

                this.Close();
                return;

                string dirPathTestFile = _helperApp.GetDirPathTestFile();

                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open Text File";
                theDialog.Filter = "TXT files|*.txt;*.tst";
                theDialog.InitialDirectory = string.Concat(dirPathTestFile, "texst.txt");
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(theDialog.FileName))
                        lstReturnRead = _helperApp.ReadExistTestFileText(theDialog.SafeFileName, theDialog.FileName);

                    if (lstReturnRead.Count() > 0)
                    {
                        //formTests.ChartLoadMeasurement(lstReturnRead, formTests.chart);

                        //this.Dispose();

                        //formMain.Refresh();
                        //formMain.Controls.Clear();
                        //formMain.Invalidate();
                        //formMain.ChartLoadMeasurement(lstReturnRead, formMain.chart);
                        //formMain.tab_Diagram_SetChart();
                    }
                        else
                            MessageBox.Show("Failed, reloading project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured while reloading Project " + ex.ToString());
            }


            //if (Application.OpenForms.OfType<Form_Adam_Main>().Any())
            //    MessageBox.Show("Form_Adam_Main is opened");
            //else
            //    MessageBox.Show("Form_Adam_Main is not opened");



            //formMain.InitializeComponent();
            //formMain.Show();

            //helperApp.Form_Open(new Form_Adam_Main(false, false, HelperApp.examtype), new Home());

            //if (string.IsNullOrEmpty(IdProjectSelect))
            //{
            //    MessageBox.Show("Error no valid Test selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}



            //if (Application.OpenForms.OfType<Form_Adam_Main>().Any())
            //{
            //    Application.OpenForms.OfType<Form_Adam_Main>().First().Close();
            //   // MessageBox.Show("Form_Adam_Main is opened");
            //}
            //else
            //{


            //    helperApp.Form_Open(new Form_Adam_Main(false, false, gvModelProject.examtype), new Home());

            //    //helperApp.Form_Open(new Form_Adam_Main(false, false, eEXAMTYPE.ET_NONE), this);

            //    // MessageBox.Show("Form_Adam_Main is not opened");

            //    //helperApp.Form_Close(new Form_Adam_Main(false, false, eEXAMTYPE.ET_NONE));

            //    //var formMain = new Form_Adam_Main(false, false, gvModelProject.examtype);

            //    //formMain.StartPosition = FormStartPosition.CenterScreen;
            //    //formMain.WindowState = FormWindowState.Maximized;
            //    //formMain.MdiParent = new Home();
            //    //formMain.Show();

            //    // this.Close();
            //}


            //var formHome = new Home();
            //formHome.Closed += (s, args) => this.Close();
            //formHome.Show();





            //DataTable dt = bll_Operational_LoadEval.GetProjects_x_Tests(IdProjectSelect, IdProjectSelect);

            //int idTestAvailableSelect = (int)dt.Rows[0].Field<Int64>("IdTestAvailable");

            //helperApp.Graph_Load_Projects_x_Tests(idTestAvailableSelect);

            this.Close();
        }

        private void mbtn_BDeleteTest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdProjectSelect))
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to drop the selected test and all it´s measurement data?" + "\n" + "Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    bool ret = bll_Operational_LoadEval.DeleteProject(IdProjectSelect);

                    if (!ret)
                        MessageBox.Show("Error drop select Test item", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //        UpdateSQLSet();
                    AvailableProject_GetInfoData();
                }
            }
        }

        private void mbtn_BExportSeries_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdProjectSelect))
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
                this.Close();
            else
            {
                if (SaveProjectData())
                {
                    HelperTestBase.currentTestFile.is_Created = true;

                    MessageBox.Show("Success, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HelperTestBase.currentTestFile.is_Created = false;

                    MessageBox.Show("Failed, create project !", _helperApp.appMsg_Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void WriteHeaderTextFile(string prjTestFilename, Model_Operational_Project modelPrj)
        {
            using (StreamWriter sw = new StreamWriter(prjTestFilename))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append($"{modelPrj.examtype}");
                sb.Append($"\r\n");
                sb.Append($"\r\n");

                sb.Append($"{mlbl_Ident.Text}\t \t \t \t: {modelPrj.Identification}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_CustomerType.Text}\t: {modelPrj.CustomerType}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_Booster.Text}\t \t \t: {modelPrj.Booster}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_Tmc.Text}\t \t \t \t: {modelPrj.TMC}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_ProductionDate.Text}\t \t: {modelPrj.ProductionDate}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_TO.Text}\t \t \t \t: {modelPrj.T_O}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_Tester.Text}\t \t \t \t: {modelPrj?.User?.UName}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_TestingDate.Text}\t \t: {modelPrj.TestingDate}");
                sb.Append($"\r\n");
                sb.Append($"{mlbl_Comment.Text}\t \t \t \t: {modelPrj.Comment}");
                sb.Append($"\r\n");
                sb.Append($"\r\n");

                sw.WriteLine(sb.ToString());

                sw.Close();
            }
        }

        #endregion

        #endregion

        private void mTileCurrentProject_Click(object sender, EventArgs e)
        {
            this.Close();
            //mbtn_BLoadMeasurement_Click(sender, e);
        }
    }
}
