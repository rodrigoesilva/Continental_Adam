using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Helper;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Manager_CreateEvalGroup : Form
    {
        #region variables declare

        HelperApp _helperApp = new HelperApp();

        BLL_Manager_SelectEvalProgram bll_Manager_SelectEvalProgram = new BLL_Manager_SelectEvalProgram();

        bool group_dirty = false;

        string splitterTestChar = ";";
        string pipeTestChar = "|";

        #endregion

        public Form_Manager_CreateEvalGroup()
        {
            InitializeComponent();
        }

        private void Form_Manager_CreateEvalGroup_Load(object sender, EventArgs e)
        {
            TreeView_Initialize();
            ListView_Initialize();
            AvailableTests_GetInfoData();
        }

        private void AvailableTests_GetInfoData()
        {
            DataTable dt = bll_Manager_SelectEvalProgram.GetAvailableTestGroup();

            TreeView_Populate(dt, 0, null);

            tree_TVEvalSequences.SelectedNode = null;
        }

        #region Buttons Events
        private void mbtn_BAddToList_Click(object sender, EventArgs e)
        {
            LBEvalDestDragDrop();
            tree_TVEvalSequences.Focus();
        }

        private void mbtn_BNew_Click(object sender, EventArgs e)
        {
            ListView_ResetGroup();
        }

        private void mbtn_BSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_LBEvalDest.Items.Count == 0)
                {
                    MessageBox.Show("Informe algo na caixa de texto");
                    return;
                }

                GroupSaveToDisk();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        private void mbtn_BLoad_Click(object sender, EventArgs e)
        {
            if (DlgOpen.ShowDialog() == DialogResult.OK)
                if (!ListView_ResetGroup())
                    return;

            GroupLoadFromDisk(DlgOpen.FileName);
        }

        private void mbtn_BDelete_Click(object sender, EventArgs e)
        {
                if (DialogResult.Yes == MessageBox.Show("Please confirm before proceed" + "\n" + "Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    List<ListViewItem> lstLvItem = new List<ListViewItem>();

                    foreach (ListViewItem item in lst_LBEvalDest.Items)
                    {
                        lstLvItem.Add(item);
                    }

                    var lvItem = ListView_GetSelectedItem();

                    lstLvItem.Remove(lvItem);

                    lst_LBEvalDest.DataSource = lstLvItem;
                    lst_LBEvalDest.DisplayMember = "Text";

                    if (lst_LBEvalDest.Items.Count == 0)
                    {
                        mbtn_BDelete.Enabled = false;
                        mbtn_BSaveAs.Enabled = false;
                    }

                group_dirty = true;     // ask for saving...
            }

        }

        private void mBtn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region treeView

        private void TreeView_Initialize()
        {
            // icons image list
            ImageList il = new ImageList();

           // il.Images.Add(new Icon("\\Resources\\Imagens\\Icons\\ico_Continental.ico"));

            //il.Images.Add(new Icon(Properties.Resources.ico_Continental.ToString()));
            //il.Images.Add(new Icon(Properties.Resources.img_Selectable.ToString()));
            ////il.Images.Add(new Icon("\\dados\\Imagens\\Critter.ico"));
            ////il.Images.Add(new Icon("\\dados\\Imagens\\Mouse.ico"));
            //tree_TVEvalSequences.ImageList = il;

            //RootNode
            TreeNode rootNode = tree_TVEvalSequences.Nodes.Add("Continental - ADAM Functional Test Bench");
            rootNode.ImageIndex = 0;

            // Cria os nós filhos para o raiz
            //TreeNode states1 = rootNode.Nodes.Add("São Paulo");
            //states1.ImageIndex = 1;
            //TreeNode states2 = rootNode.Nodes.Add("Goiás");
            //states2.ImageIndex = 1;
            //TreeNode states3 = rootNode.Nodes.Add("Rio de Janeiro");
            //states3.ImageIndex = 1;
            //TreeNode states4 = rootNode.Nodes.Add("Minas Gerais");
            //states4.ImageIndex = 1;
        }
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
                    string IdTestGroup = child.Tag.ToString();

                    tree_TVEvalSequences.Nodes.Add(child);
                    DataTable dtChild = bll_Manager_SelectEvalProgram.GetNodeAvailableTestsByGroup(IdTestGroup);
                    TreeView_Populate(dtChild, Convert.ToInt32(child.Tag), child);
                }
                else
                {
                    treeNode.Nodes.Add(child);
                }
            }
        }
        private TreeNode TreeView_GetSelectedItem()
        {
            TreeNode childNode = new TreeNode();

            if (tree_TVEvalSequences.SelectedNode != null)
            {
                int idTestGroup = Convert.ToInt32(tree_TVEvalSequences.SelectedNode.Tag);

                if (tree_TVEvalSequences.SelectedNode.Level == 1 || idTestGroup == 7) // Check Test - Lost Travel TMC
                {
                    childNode.Tag = tree_TVEvalSequences.SelectedNode.Tag.ToString();
                    childNode.Text = tree_TVEvalSequences.SelectedNode.Text.ToString();
                }
                else
                    MessageBox.Show("Select a Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return childNode;
        }
        #endregion

        #region ListView

        private void ListView_Initialize()
        {
            if (lst_LBEvalDest.Items.Count == 0)
            {
                mbtn_BSaveAs.Enabled = false;
                mbtn_BDelete.Enabled = false;
            }
        }
        private void LBEvalDestDragDrop()
        {
            var childNode = TreeView_GetSelectedItem();

            if (childNode != null)
                group_dirty = AppendGroupEntry(childNode);
        }

        bool AppendGroupEntry(TreeNode childNode)
        {
            if (!string.IsNullOrEmpty(childNode.Text))
            {
                List<ListViewItem> lstLvItem = new List<ListViewItem>();

                ListViewItem lvItem = new ListViewItem
                {
                    Tag = childNode?.Tag,
                    Text = childNode?.Text
                };

                if (lst_LBEvalDest.Items.Count == 0)
                {
                    lstLvItem.Add(lvItem);

                    lst_LBEvalDest.DataSource = lstLvItem;
                    lst_LBEvalDest.DisplayMember = "Text";
                }
                else
                {
                    foreach (ListViewItem itemList in lst_LBEvalDest.Items)
                    {
                        if (itemList.Text != lvItem.Text)
                        {
                            lstLvItem.Add(itemList);
                            lstLvItem.Add(lvItem);

                            lst_LBEvalDest.DataSource = lstLvItem;
                            lst_LBEvalDest.DisplayMember = "Text";
                        }
                    }
                }

                mbtn_BDelete.Enabled = true;
                mbtn_BSaveAs.Enabled = true;

                return true;
            }
            return false;
        }
        bool ListView_ResetGroup()
        {
            bool do_clear = !group_dirty;

            if (DialogResult.Yes == MessageBox.Show("Are you sure want delete all current entrys withou saving" + "\n" + "Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                do_clear = true;

            if (do_clear)
            {
                lst_LBEvalDest.DataSource = null;

                //lst_LBEvalDest.Items.Clear();

                group_dirty = false;
            }

            return do_clear;
        }

        void ListView_SaveGroup()
        {
            bool do_clear = !group_dirty;

            if (DialogResult.Yes == MessageBox.Show("Are you sure want delete all current entrys withou saving" + "\n" + "Do you want to Continue ? ", _helperApp.appMsg_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                do_clear = true;

            if (do_clear)
            {
                lst_LBEvalDest.Items.Clear();

                group_dirty = false;
            }
        }

        private ListViewItem ListView_GetSelectedItem()
        {
            ListViewItem lvItem = new ListViewItem();

            lvItem = (ListViewItem)lst_LBEvalDest.Items[lst_LBEvalDest.SelectedIndex];

            return lvItem;
        }
        #endregion

        #region methods

        #region FILES
        private void GroupSaveToDisk()
        {
            bool binFile = false;

            //define o titulo
            DlgSave.Title = "User defined Tests File";
            //Define as extensões permitidas
            DlgSave.Filter = $"User defined Tests File (.{_helperApp.AppUserDefinedTests_DefaultExtension}) | *.{_helperApp.AppUserDefinedTests_DefaultExtension}";
            //define o indice do filtro
            DlgSave.FilterIndex = 0;
            //Atribui um valor vazio ao nome do arquivo
            DlgSave.FileName = string.Empty;

            //Define a extensão padrão como .txt
            DlgSave.DefaultExt = _helperApp.AppUserDefinedTests_DefaultExtension;
            //define o diretório padrão

            //string dirPathUdtFile = Path.Combine(dirPathUI, dirFilesUDT, DlgSave.FileName);
            string dirPathUdtFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, _helperApp.AppUserDefinedTests_Path);

            DlgSave.InitialDirectory = dirPathUdtFile;

            //restaura o diretorio atual antes de fechar a janela
            DlgSave.RestoreDirectory = true;

            //Se o ousuário pressionar o botão Salvar
            if (DlgSave.ShowDialog() == DialogResult.OK)
            {
                string udtFilename = DlgSave.FileName.ToString();
                string udtHeaderFile = string.Concat("UDTFileGenerated_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), "_", HelperApp.UserName, splitterTestChar);

                if (!string.IsNullOrEmpty(udtFilename))
                {
                    if (binFile)
                        WriteBinaryFile(udtFilename, udtHeaderFile);
                    else
                        WriteTextFile(udtFilename, udtHeaderFile);

                    group_dirty = false;
                }
            }
            else
                MessageBox.Show("Action canceled !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GroupLoadFromDisk(string udtFilename)
        {
            bool binFile = false;

            if (!string.IsNullOrEmpty(udtFilename))
            {

                if (File.Exists(udtFilename))
                {
                    if (binFile)
                        ReadBinaryFile(udtFilename);
                    else
                        ReadTextFile(udtFilename);

                    group_dirty = false;
                }
            }
        }
        private void ReadBinaryFile(string fname)
        {

        }
        private void ReadTextFile(string fname)
        {
            using (StreamReader file = new StreamReader(fname))
            {
                int i = 0;
                string ln;

                List<string> lstUdt = new List<string>();

                TreeNode childNode = new TreeNode();

                while ((ln = file.ReadLine()) != null)
                {
                    if (!ln.StartsWith("UDTFileGenerated_"))
                    {
                        string[] childArray = Regex.Replace(ln, @"\t|\n|\r|;", "").Split(char.Parse(pipeTestChar));

                        if (childArray.Length > 0) // Check Test - Lost Travel TMC
                        {
                            childNode.Tag = childArray[0].ToString();
                            childNode.Text = childArray[1].ToString();
                        }

                        if (childNode != null)
                            if(!AppendGroupEntry(childNode))
                                MessageBox.Show("Failed load Test !", _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        i++;
                    }
                }

                file.Close();
            }
        }
        private void WriteBinaryFile(string udtFilename, string udtHeaderFile)
        {
            try
            {
                Encoding ascii = Encoding.ASCII;

                using (BinaryWriter binWriter = new BinaryWriter(File.Open(udtFilename, FileMode.Create), ascii))
                {
                    binWriter.Write(udtHeaderFile);

                    foreach (ListViewItem item in lst_LBEvalDest.Items)
                    {
                        binWriter.Write(string.Concat(item.SubItems[0].Text, splitterTestChar));
                    }

                    binWriter.Close();
                }


                //Console.WriteLine("Binary Writer");
                //string authorName = "Mahesh Chand";
                //int age = 30;
                //string bookTitle = "ADO.NET Programming using C#";
                //bool mvp = true;
                //double price = 54.99;

                //string fileName = @"C:\TsTemp\MC.bin";
                ////BinaryWriter bwStream = new BinaryWriter(new FileStream(fileName, FileMode.Create));

                ////Encoding ascii = Encoding.ASCII;
                ////BinaryWriter bwEncoder = new BinaryWriter(new FileStream(fileName, FileMode.Create), ascii);

                //using (BinaryWriter binWriter = new BinaryWriter(File.Open(fileName, FileMode.Create), ascii))
                //{
                //    // Write string
                //    binWriter.Write(authorName);
                //    // Write string
                //    // Write integer
                //    binWriter.Write(age);
                //    binWriter.Write(bookTitle);
                //    // Write boolean
                //    binWriter.Write(mvp);
                //    // Write double
                //    binWriter.Write(price);
                //}
                //Console.WriteLine("Data Written!");
                //Console.WriteLine();
            }
            catch (IOException ioexp)
            {
                Console.WriteLine("Error: {0}", ioexp.Message);
            }
        }
        private void WriteTextFile(string udtFilename, string udtHeaderFile)
        {
            using (StreamWriter sw = new StreamWriter(udtFilename))
            {
                sw.WriteLine(udtHeaderFile);
                //sw.WriteLine("{0}{1}", string.Concat("UDTFileGenerated_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), "_", HelperApp.UserName), splitterChar);

                foreach (ListViewItem item in lst_LBEvalDest.Items)
                {
                    sw.WriteLine("{0}{1}{2}{3}", item.Tag, pipeTestChar, item.Text, splitterTestChar);
                }

                sw.Close();
            }
        }
        #endregion

        #endregion
    }
}
