using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Enum;
using Continental.Project.Adam.UI.Helper.Com;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Continental.Project.Adam.UI.COM;
using Continental.Project.Adam.UI.Helper.Tests;
using System.Threading;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Manager_SelectEvalProgram : Form
    {
        #region Define

        BLL_Manager_TestAvailable bll_Manager_SelectEvalProgram = new BLL_Manager_TestAvailable();

        eEXAMTYPE sel_examtype_ref;

        string udtDefaultExt = "*.udt";

        string udt_fname_ref = string.Empty;

        int idTestSelected = 0;

        #region Helpers

        HelperApp _helperApp = new HelperApp();

        HelperMODBUS _helperMODBUS = new HelperMODBUS();

        #endregion

        #endregion

        #region Initial
        public Form_Manager_SelectEvalProgram()
        {
            InitializeComponent();
        }

        #endregion

        #region Form
        private void Form_Manager_SelectEvalProgram_Load(object sender, EventArgs e)
        {
            LoadSelectEvalProgram();
        }

        public void LoadSelectEvalProgram()
        {
            try
            {
                // deselect all
                tree_TVEvalSequences.SelectedNode = null;
                lst_FLBUserDefinedTests.SelectedIndex = -1;
                mtxt_LSelectedTest.Text = string.Empty;
                sel_examtype_ref = eEXAMTYPE.ET_NONE;

                SetEnablesTreeViewItens();

                if (tbc_TestingProgram.SelectedIndex == 0) //tab_AvailableTests
                {
                    tree_TVEvalSequences.Nodes.Clear();
                    tab_AvailableTests_GetInfoData();
                    tree_TVEvalSequences.Focus();
                }
                else //tab_UserDefinedTests
                {
                    tab_UserDefinedTests_GetInfoData();
                }
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_Manager_SelectEvalProgram_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form_Adam_Main _formMain = new Form_Adam_Main(eEXAMTYPE.ET_NONE);

            //_formMain.ActivePage(2);

            //_formMain.tab_ActionParameters_GeneralSettings_CoBSelectTest_SetChange(HelperApp.uiTesteSelecionado);
        }

        #endregion

        #region Buttons
        private void mbtn_Cancel_Click(object sender, EventArgs e)
        {
            sel_examtype_ref = eEXAMTYPE.ET_NONE;
            idTestSelected = 0;

            HelperTestBase.eExamType = sel_examtype_ref;
            HelperApp.uiTesteSelecionado = idTestSelected;

            this.Close();
        }

        private void mbtn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (sel_examtype_ref != eEXAMTYPE.ET_NONE)
                {
                    HelperTestBase.eExamType = sel_examtype_ref;
                    HelperApp.uiTesteSelecionado = idTestSelected;
                }
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        #endregion

        #region Tabs
        private void tbc_TestingProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectEvalProgram();
        }

        private void tab_AvailableTests_GetInfoData()
        {
            DataTable dt = bll_Manager_SelectEvalProgram.GetAvailableTestGroup();

            PopulateTreeView(dt, 0, null);
        }

        private void tab_UserDefinedTests_GetInfoData()
        {
            lst_FLBUserDefinedTests.Items.Clear();

            try
            {
                string dirPathUdtFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppUserDefinedTests_Path);

                string[] arrUdtFiles = Directory.GetFiles(dirPathUdtFile, udtDefaultExt);

                foreach (var fileUdt in arrUdtFiles)
                    lst_FLBUserDefinedTests.Items.Add(Path.GetFileName(fileUdt));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        #endregion

        #region TreeView
        private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
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

                    tree_TVEvalSequences.Nodes.Add(child);
                    DataTable dtChild = bll_Manager_SelectEvalProgram.GetNodeAvailableTestsByGroup(IdTestGroup);
                    PopulateTreeView(dtChild, Convert.ToInt32(child.Tag), child);
                }
                else
                {
                    treeNode.Nodes.Add(child);
                }
            }
        }

        private void lst_FLBUserDefinedTests_DoubleClick(object sender, EventArgs e)
        {
            int sel_ix = lst_FLBUserDefinedTests.SelectedIndex;

            if (sel_ix >= 0)
            {
                mtxt_LSelectedTest.Text = String.Concat("User defined - ", lst_FLBUserDefinedTests.SelectedItem.ToString());

                udt_fname_ref = lst_FLBUserDefinedTests.Text.ToString();

                sel_examtype_ref = eEXAMTYPE.ET_USER_DEFINED;
            }

            SetEnablesTreeViewItens();
        }

        private void SetEnablesTreeViewItens()
        {
            mbtn_Ok.Enabled = (sel_examtype_ref != eEXAMTYPE.ET_NONE);
        }

        private void tree_TVEvalSequences_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var childNode = e.Node;

                if (childNode != null)
                {
                    idTestSelected = int.Parse(childNode.Tag.ToString());

                    if (childNode.Parent != null || idTestSelected == 7) // Check Test - Lost Travel TMC
                    {
                        childNode.Tag = childNode.Tag.ToString();
                        childNode.Text = childNode.Text.ToString();

                        sel_examtype_ref = _helperApp.SelectedExamType(idTestSelected);

                        mtxt_LSelectedTest.Text = childNode.Text.ToString();
                    }
                    else
                    {
                        sel_examtype_ref = eEXAMTYPE.ET_NONE;

                        mtxt_LSelectedTest.Text = string.Empty;
                    }
                }

                SetEnablesTreeViewItens();
            }
            catch (Exception ex)
            {
                var err = string.Concat("Exception : ", ex.Message);
                MessageBox.Show(err, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        
    }
}
