
namespace Continental.Project.Adam.UI
{
    partial class Form_Operational_Project
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Operational_Project));
            this.mbtn_BDeleteTest = new MetroFramework.Controls.MetroButton();
            this.mbtn_BLoadTest = new MetroFramework.Controls.MetroButton();
            this.mbtn_BExportSeries = new MetroFramework.Controls.MetroButton();
            this.mbtn_Ok = new MetroFramework.Controls.MetroButton();
            this.mchk_CBExportExcelSeries = new MetroFramework.Controls.MetroCheckBox();
            this.mchk_CBExportBitmapSeries = new MetroFramework.Controls.MetroCheckBox();
            this.mchk_CBPrintSeries = new MetroFramework.Controls.MetroCheckBox();
            this.mpnl_Comment = new MetroFramework.Controls.MetroPanel();
            this.mtxt_Comment = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_Comment = new MetroFramework.Controls.MetroLabel();
            this.mpnl_CurrentProject = new MetroFramework.Controls.MetroPanel();
            this.mlbl_TestingDate = new MetroFramework.Controls.MetroLabel();
            this.mTileCurrentProject = new MetroFramework.Controls.MetroTile();
            this.mlbl_Booster = new MetroFramework.Controls.MetroLabel();
            this.mlbl_ProductionDate = new MetroFramework.Controls.MetroLabel();
            this.mlbl_Tmc = new MetroFramework.Controls.MetroLabel();
            this.mlbl_TO = new MetroFramework.Controls.MetroLabel();
            this.mtxt_Tester = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_Tester = new MetroFramework.Controls.MetroLabel();
            this.mtxt_EIdent = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_TestingDate = new MetroFramework.Controls.MetroTextBox();
            this.mlbl_Ident = new MetroFramework.Controls.MetroLabel();
            this.mlbl_CustomerType = new MetroFramework.Controls.MetroLabel();
            this.mtxt_TO = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_ECustomer = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_ProductionDate = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_Booster = new MetroFramework.Controls.MetroTextBox();
            this.mtxt_Tmc = new MetroFramework.Controls.MetroTextBox();
            this.mpnl_AvailableProjects = new MetroFramework.Controls.MetroPanel();
            this.grid_ProjectTest = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.mTile_AvailableProjects = new MetroFramework.Controls.MetroTile();
            this.tree_Projects = new System.Windows.Forms.TreeView();
            this.ILExplorer = new System.Windows.Forms.ImageList(this.components);
            this.DlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.DlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.mbtn_BDeleteProject = new MetroFramework.Controls.MetroButton();
            this.mpnl_Comment.SuspendLayout();
            this.mpnl_CurrentProject.SuspendLayout();
            this.mpnl_AvailableProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ProjectTest)).BeginInit();
            this.SuspendLayout();
            // 
            // mbtn_BDeleteTest
            // 
            this.mbtn_BDeleteTest.Enabled = false;
            this.mbtn_BDeleteTest.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BDeleteTest.Location = new System.Drawing.Point(12, 699);
            this.mbtn_BDeleteTest.Name = "mbtn_BDeleteTest";
            this.mbtn_BDeleteTest.Size = new System.Drawing.Size(310, 45);
            this.mbtn_BDeleteTest.TabIndex = 0;
            this.mbtn_BDeleteTest.Text = "&Delete Test";
            this.mbtn_BDeleteTest.UseSelectable = true;
            this.mbtn_BDeleteTest.Click += new System.EventHandler(this.mbtn_BDeleteTest_Click);
            // 
            // mbtn_BLoadTest
            // 
            this.mbtn_BLoadTest.Enabled = false;
            this.mbtn_BLoadTest.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BLoadTest.Location = new System.Drawing.Point(328, 699);
            this.mbtn_BLoadTest.Name = "mbtn_BLoadTest";
            this.mbtn_BLoadTest.Size = new System.Drawing.Size(310, 45);
            this.mbtn_BLoadTest.TabIndex = 2;
            this.mbtn_BLoadTest.Text = "&Load Test";
            this.mbtn_BLoadTest.UseSelectable = true;
            this.mbtn_BLoadTest.Click += new System.EventHandler(this.mbtn_BLoadTest_Click);
            // 
            // mbtn_BExportSeries
            // 
            this.mbtn_BExportSeries.Enabled = false;
            this.mbtn_BExportSeries.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BExportSeries.Location = new System.Drawing.Point(674, 699);
            this.mbtn_BExportSeries.Name = "mbtn_BExportSeries";
            this.mbtn_BExportSeries.Size = new System.Drawing.Size(450, 45);
            this.mbtn_BExportSeries.TabIndex = 3;
            this.mbtn_BExportSeries.Text = "&Export series selected below...";
            this.mbtn_BExportSeries.UseSelectable = true;
            this.mbtn_BExportSeries.Click += new System.EventHandler(this.mbtn_BExportSeries_Click);
            // 
            // mbtn_Ok
            // 
            this.mbtn_Ok.Location = new System.Drawing.Point(1148, 699);
            this.mbtn_Ok.Name = "mbtn_Ok";
            this.mbtn_Ok.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Ok.TabIndex = 4;
            this.mbtn_Ok.Text = "&Ok";
            this.mbtn_Ok.UseSelectable = true;
            this.mbtn_Ok.Click += new System.EventHandler(this.mbtn_Ok_Click);
            // 
            // mchk_CBExportExcelSeries
            // 
            this.mchk_CBExportExcelSeries.AutoSize = true;
            this.mchk_CBExportExcelSeries.Enabled = false;
            this.mchk_CBExportExcelSeries.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mchk_CBExportExcelSeries.Location = new System.Drawing.Point(674, 659);
            this.mchk_CBExportExcelSeries.Name = "mchk_CBExportExcelSeries";
            this.mchk_CBExportExcelSeries.Size = new System.Drawing.Size(71, 25);
            this.mchk_CBExportExcelSeries.TabIndex = 5;
            this.mchk_CBExportExcelSeries.Text = "Excel";
            this.mchk_CBExportExcelSeries.UseSelectable = true;
            // 
            // mchk_CBExportBitmapSeries
            // 
            this.mchk_CBExportBitmapSeries.AutoSize = true;
            this.mchk_CBExportBitmapSeries.Enabled = false;
            this.mchk_CBExportBitmapSeries.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mchk_CBExportBitmapSeries.Location = new System.Drawing.Point(851, 659);
            this.mchk_CBExportBitmapSeries.Name = "mchk_CBExportBitmapSeries";
            this.mchk_CBExportBitmapSeries.Size = new System.Drawing.Size(95, 25);
            this.mchk_CBExportBitmapSeries.TabIndex = 6;
            this.mchk_CBExportBitmapSeries.Text = "Pictures";
            this.mchk_CBExportBitmapSeries.UseSelectable = true;
            // 
            // mchk_CBPrintSeries
            // 
            this.mchk_CBPrintSeries.AutoSize = true;
            this.mchk_CBPrintSeries.Enabled = false;
            this.mchk_CBPrintSeries.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.mchk_CBPrintSeries.Location = new System.Drawing.Point(1060, 659);
            this.mchk_CBPrintSeries.Name = "mchk_CBPrintSeries";
            this.mchk_CBPrintSeries.Size = new System.Drawing.Size(68, 25);
            this.mchk_CBPrintSeries.TabIndex = 7;
            this.mchk_CBPrintSeries.Text = "Print";
            this.mchk_CBPrintSeries.UseSelectable = true;
            // 
            // mpnl_Comment
            // 
            this.mpnl_Comment.Controls.Add(this.mtxt_Comment);
            this.mpnl_Comment.Controls.Add(this.mlbl_Comment);
            this.mpnl_Comment.HorizontalScrollbarBarColor = true;
            this.mpnl_Comment.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_Comment.HorizontalScrollbarSize = 10;
            this.mpnl_Comment.Location = new System.Drawing.Point(5, 556);
            this.mpnl_Comment.Name = "mpnl_Comment";
            this.mpnl_Comment.Size = new System.Drawing.Size(1305, 86);
            this.mpnl_Comment.TabIndex = 8;
            this.mpnl_Comment.VerticalScrollbarBarColor = true;
            this.mpnl_Comment.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Comment.VerticalScrollbarSize = 10;
            // 
            // mtxt_Comment
            // 
            // 
            // 
            // 
            this.mtxt_Comment.CustomButton.Image = null;
            this.mtxt_Comment.CustomButton.Location = new System.Drawing.Point(1260, 2);
            this.mtxt_Comment.CustomButton.Name = "";
            this.mtxt_Comment.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_Comment.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Comment.CustomButton.TabIndex = 1;
            this.mtxt_Comment.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Comment.CustomButton.UseSelectable = true;
            this.mtxt_Comment.CustomButton.Visible = false;
            this.mtxt_Comment.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mtxt_Comment.Lines = new string[0];
            this.mtxt_Comment.Location = new System.Drawing.Point(5, 45);
            this.mtxt_Comment.MaxLength = 32767;
            this.mtxt_Comment.Name = "mtxt_Comment";
            this.mtxt_Comment.PasswordChar = '\0';
            this.mtxt_Comment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Comment.SelectedText = "";
            this.mtxt_Comment.SelectionLength = 0;
            this.mtxt_Comment.SelectionStart = 0;
            this.mtxt_Comment.ShortcutsEnabled = true;
            this.mtxt_Comment.Size = new System.Drawing.Size(1288, 30);
            this.mtxt_Comment.TabIndex = 11;
            this.mtxt_Comment.UseSelectable = true;
            this.mtxt_Comment.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Comment.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_Comment
            // 
            this.mlbl_Comment.AutoSize = true;
            this.mlbl_Comment.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_Comment.Location = new System.Drawing.Point(5, 15);
            this.mlbl_Comment.Name = "mlbl_Comment";
            this.mlbl_Comment.Size = new System.Drawing.Size(78, 20);
            this.mlbl_Comment.TabIndex = 9;
            this.mlbl_Comment.Text = "Comment";
            // 
            // mpnl_CurrentProject
            // 
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_TestingDate);
            this.mpnl_CurrentProject.Controls.Add(this.mTileCurrentProject);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_Booster);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_ProductionDate);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_Tmc);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_TO);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_Tester);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_Tester);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_EIdent);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_TestingDate);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_Ident);
            this.mpnl_CurrentProject.Controls.Add(this.mlbl_CustomerType);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_TO);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_ECustomer);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_ProductionDate);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_Booster);
            this.mpnl_CurrentProject.Controls.Add(this.mtxt_Tmc);
            this.mpnl_CurrentProject.HorizontalScrollbarBarColor = true;
            this.mpnl_CurrentProject.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_CurrentProject.HorizontalScrollbarSize = 10;
            this.mpnl_CurrentProject.Location = new System.Drawing.Point(5, 0);
            this.mpnl_CurrentProject.Name = "mpnl_CurrentProject";
            this.mpnl_CurrentProject.Size = new System.Drawing.Size(350, 550);
            this.mpnl_CurrentProject.TabIndex = 12;
            this.mpnl_CurrentProject.VerticalScrollbarBarColor = true;
            this.mpnl_CurrentProject.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_CurrentProject.VerticalScrollbarSize = 10;
            // 
            // mlbl_TestingDate
            // 
            this.mlbl_TestingDate.AutoSize = true;
            this.mlbl_TestingDate.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_TestingDate.Location = new System.Drawing.Point(5, 514);
            this.mlbl_TestingDate.Name = "mlbl_TestingDate";
            this.mlbl_TestingDate.Size = new System.Drawing.Size(97, 20);
            this.mlbl_TestingDate.TabIndex = 26;
            this.mlbl_TestingDate.Text = "Testing Date";
            // 
            // mTileCurrentProject
            // 
            this.mTileCurrentProject.ActiveControl = null;
            this.mTileCurrentProject.Enabled = false;
            this.mTileCurrentProject.Location = new System.Drawing.Point(0, 1);
            this.mTileCurrentProject.Name = "mTileCurrentProject";
            this.mTileCurrentProject.Size = new System.Drawing.Size(350, 60);
            this.mTileCurrentProject.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTileCurrentProject.TabIndex = 21;
            this.mTileCurrentProject.Text = "Current Project";
            this.mTileCurrentProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTileCurrentProject.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTileCurrentProject.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTileCurrentProject.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTileCurrentProject.UseSelectable = true;
            // 
            // mlbl_Booster
            // 
            this.mlbl_Booster.AutoSize = true;
            this.mlbl_Booster.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_Booster.Location = new System.Drawing.Point(5, 227);
            this.mlbl_Booster.Name = "mlbl_Booster";
            this.mlbl_Booster.Size = new System.Drawing.Size(77, 20);
            this.mlbl_Booster.TabIndex = 25;
            this.mlbl_Booster.Text = "Booster #";
            // 
            // mlbl_ProductionDate
            // 
            this.mlbl_ProductionDate.AutoSize = true;
            this.mlbl_ProductionDate.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_ProductionDate.Location = new System.Drawing.Point(5, 343);
            this.mlbl_ProductionDate.Name = "mlbl_ProductionDate";
            this.mlbl_ProductionDate.Size = new System.Drawing.Size(123, 20);
            this.mlbl_ProductionDate.TabIndex = 23;
            this.mlbl_ProductionDate.Text = "Production Date";
            // 
            // mlbl_Tmc
            // 
            this.mlbl_Tmc.AutoSize = true;
            this.mlbl_Tmc.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_Tmc.Location = new System.Drawing.Point(5, 285);
            this.mlbl_Tmc.Name = "mlbl_Tmc";
            this.mlbl_Tmc.Size = new System.Drawing.Size(54, 20);
            this.mlbl_Tmc.TabIndex = 24;
            this.mlbl_Tmc.Text = "TMC #";
            // 
            // mlbl_TO
            // 
            this.mlbl_TO.AutoSize = true;
            this.mlbl_TO.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_TO.Location = new System.Drawing.Point(5, 401);
            this.mlbl_TO.Name = "mlbl_TO";
            this.mlbl_TO.Size = new System.Drawing.Size(48, 20);
            this.mlbl_TO.TabIndex = 22;
            this.mlbl_TO.Text = "T.O. #";
            // 
            // mtxt_Tester
            // 
            // 
            // 
            // 
            this.mtxt_Tester.CustomButton.Image = null;
            this.mtxt_Tester.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_Tester.CustomButton.Name = "";
            this.mtxt_Tester.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_Tester.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Tester.CustomButton.TabIndex = 1;
            this.mtxt_Tester.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Tester.CustomButton.UseSelectable = true;
            this.mtxt_Tester.CustomButton.Visible = false;
            this.mtxt_Tester.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Tester.Lines = new string[0];
            this.mtxt_Tester.Location = new System.Drawing.Point(138, 448);
            this.mtxt_Tester.MaxLength = 32767;
            this.mtxt_Tester.Name = "mtxt_Tester";
            this.mtxt_Tester.PasswordChar = '\0';
            this.mtxt_Tester.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Tester.SelectedText = "";
            this.mtxt_Tester.SelectionLength = 0;
            this.mtxt_Tester.SelectionStart = 0;
            this.mtxt_Tester.ShortcutsEnabled = true;
            this.mtxt_Tester.Size = new System.Drawing.Size(200, 30);
            this.mtxt_Tester.TabIndex = 19;
            this.mtxt_Tester.UseSelectable = true;
            this.mtxt_Tester.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Tester.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_Tester
            // 
            this.mlbl_Tester.AutoSize = true;
            this.mlbl_Tester.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_Tester.Location = new System.Drawing.Point(5, 459);
            this.mlbl_Tester.Name = "mlbl_Tester";
            this.mlbl_Tester.Size = new System.Drawing.Size(52, 20);
            this.mlbl_Tester.TabIndex = 21;
            this.mlbl_Tester.Text = "Tester";
            // 
            // mtxt_EIdent
            // 
            // 
            // 
            // 
            this.mtxt_EIdent.CustomButton.Image = null;
            this.mtxt_EIdent.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_EIdent.CustomButton.Name = "";
            this.mtxt_EIdent.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_EIdent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_EIdent.CustomButton.TabIndex = 1;
            this.mtxt_EIdent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_EIdent.CustomButton.UseSelectable = true;
            this.mtxt_EIdent.CustomButton.Visible = false;
            this.mtxt_EIdent.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_EIdent.Lines = new string[0];
            this.mtxt_EIdent.Location = new System.Drawing.Point(138, 100);
            this.mtxt_EIdent.MaxLength = 32767;
            this.mtxt_EIdent.Name = "mtxt_EIdent";
            this.mtxt_EIdent.PasswordChar = '\0';
            this.mtxt_EIdent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_EIdent.SelectedText = "";
            this.mtxt_EIdent.SelectionLength = 0;
            this.mtxt_EIdent.SelectionStart = 0;
            this.mtxt_EIdent.ShortcutsEnabled = true;
            this.mtxt_EIdent.Size = new System.Drawing.Size(200, 30);
            this.mtxt_EIdent.TabIndex = 11;
            this.mtxt_EIdent.UseSelectable = true;
            this.mtxt_EIdent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_EIdent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_TestingDate
            // 
            // 
            // 
            // 
            this.mtxt_TestingDate.CustomButton.Image = null;
            this.mtxt_TestingDate.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_TestingDate.CustomButton.Name = "";
            this.mtxt_TestingDate.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_TestingDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_TestingDate.CustomButton.TabIndex = 1;
            this.mtxt_TestingDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_TestingDate.CustomButton.UseSelectable = true;
            this.mtxt_TestingDate.CustomButton.Visible = false;
            this.mtxt_TestingDate.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_TestingDate.Lines = new string[0];
            this.mtxt_TestingDate.Location = new System.Drawing.Point(138, 506);
            this.mtxt_TestingDate.MaxLength = 32767;
            this.mtxt_TestingDate.Name = "mtxt_TestingDate";
            this.mtxt_TestingDate.PasswordChar = '\0';
            this.mtxt_TestingDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_TestingDate.SelectedText = "";
            this.mtxt_TestingDate.SelectionLength = 0;
            this.mtxt_TestingDate.SelectionStart = 0;
            this.mtxt_TestingDate.ShortcutsEnabled = true;
            this.mtxt_TestingDate.Size = new System.Drawing.Size(200, 30);
            this.mtxt_TestingDate.TabIndex = 20;
            this.mtxt_TestingDate.UseSelectable = true;
            this.mtxt_TestingDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_TestingDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlbl_Ident
            // 
            this.mlbl_Ident.AutoSize = true;
            this.mlbl_Ident.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_Ident.Location = new System.Drawing.Point(5, 111);
            this.mlbl_Ident.Name = "mlbl_Ident";
            this.mlbl_Ident.Size = new System.Drawing.Size(59, 20);
            this.mlbl_Ident.TabIndex = 12;
            this.mlbl_Ident.Text = "Ident #";
            // 
            // mlbl_CustomerType
            // 
            this.mlbl_CustomerType.AutoSize = true;
            this.mlbl_CustomerType.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlbl_CustomerType.Location = new System.Drawing.Point(5, 169);
            this.mlbl_CustomerType.Name = "mlbl_CustomerType";
            this.mlbl_CustomerType.Size = new System.Drawing.Size(139, 20);
            this.mlbl_CustomerType.TabIndex = 13;
            this.mlbl_CustomerType.Text = "Custommer / Type";
            // 
            // mtxt_TO
            // 
            // 
            // 
            // 
            this.mtxt_TO.CustomButton.Image = null;
            this.mtxt_TO.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_TO.CustomButton.Name = "";
            this.mtxt_TO.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_TO.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_TO.CustomButton.TabIndex = 1;
            this.mtxt_TO.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_TO.CustomButton.UseSelectable = true;
            this.mtxt_TO.CustomButton.Visible = false;
            this.mtxt_TO.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_TO.Lines = new string[0];
            this.mtxt_TO.Location = new System.Drawing.Point(138, 390);
            this.mtxt_TO.MaxLength = 32767;
            this.mtxt_TO.Name = "mtxt_TO";
            this.mtxt_TO.PasswordChar = '\0';
            this.mtxt_TO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_TO.SelectedText = "";
            this.mtxt_TO.SelectionLength = 0;
            this.mtxt_TO.SelectionStart = 0;
            this.mtxt_TO.ShortcutsEnabled = true;
            this.mtxt_TO.Size = new System.Drawing.Size(200, 30);
            this.mtxt_TO.TabIndex = 18;
            this.mtxt_TO.UseSelectable = true;
            this.mtxt_TO.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_TO.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_ECustomer
            // 
            // 
            // 
            // 
            this.mtxt_ECustomer.CustomButton.Image = null;
            this.mtxt_ECustomer.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_ECustomer.CustomButton.Name = "";
            this.mtxt_ECustomer.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_ECustomer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_ECustomer.CustomButton.TabIndex = 1;
            this.mtxt_ECustomer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_ECustomer.CustomButton.UseSelectable = true;
            this.mtxt_ECustomer.CustomButton.Visible = false;
            this.mtxt_ECustomer.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_ECustomer.Lines = new string[0];
            this.mtxt_ECustomer.Location = new System.Drawing.Point(138, 158);
            this.mtxt_ECustomer.MaxLength = 32767;
            this.mtxt_ECustomer.Name = "mtxt_ECustomer";
            this.mtxt_ECustomer.PasswordChar = '\0';
            this.mtxt_ECustomer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_ECustomer.SelectedText = "";
            this.mtxt_ECustomer.SelectionLength = 0;
            this.mtxt_ECustomer.SelectionStart = 0;
            this.mtxt_ECustomer.ShortcutsEnabled = true;
            this.mtxt_ECustomer.Size = new System.Drawing.Size(200, 30);
            this.mtxt_ECustomer.TabIndex = 14;
            this.mtxt_ECustomer.UseSelectable = true;
            this.mtxt_ECustomer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_ECustomer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_ProductionDate
            // 
            // 
            // 
            // 
            this.mtxt_ProductionDate.CustomButton.Image = null;
            this.mtxt_ProductionDate.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_ProductionDate.CustomButton.Name = "";
            this.mtxt_ProductionDate.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_ProductionDate.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_ProductionDate.CustomButton.TabIndex = 1;
            this.mtxt_ProductionDate.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_ProductionDate.CustomButton.UseSelectable = true;
            this.mtxt_ProductionDate.CustomButton.Visible = false;
            this.mtxt_ProductionDate.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_ProductionDate.Lines = new string[0];
            this.mtxt_ProductionDate.Location = new System.Drawing.Point(138, 332);
            this.mtxt_ProductionDate.MaxLength = 32767;
            this.mtxt_ProductionDate.Name = "mtxt_ProductionDate";
            this.mtxt_ProductionDate.PasswordChar = '\0';
            this.mtxt_ProductionDate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_ProductionDate.SelectedText = "";
            this.mtxt_ProductionDate.SelectionLength = 0;
            this.mtxt_ProductionDate.SelectionStart = 0;
            this.mtxt_ProductionDate.ShortcutsEnabled = true;
            this.mtxt_ProductionDate.Size = new System.Drawing.Size(200, 30);
            this.mtxt_ProductionDate.TabIndex = 17;
            this.mtxt_ProductionDate.UseSelectable = true;
            this.mtxt_ProductionDate.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_ProductionDate.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_Booster
            // 
            // 
            // 
            // 
            this.mtxt_Booster.CustomButton.Image = null;
            this.mtxt_Booster.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_Booster.CustomButton.Name = "";
            this.mtxt_Booster.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_Booster.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Booster.CustomButton.TabIndex = 1;
            this.mtxt_Booster.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Booster.CustomButton.UseSelectable = true;
            this.mtxt_Booster.CustomButton.Visible = false;
            this.mtxt_Booster.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Booster.Lines = new string[0];
            this.mtxt_Booster.Location = new System.Drawing.Point(138, 216);
            this.mtxt_Booster.MaxLength = 32767;
            this.mtxt_Booster.Name = "mtxt_Booster";
            this.mtxt_Booster.PasswordChar = '\0';
            this.mtxt_Booster.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Booster.SelectedText = "";
            this.mtxt_Booster.SelectionLength = 0;
            this.mtxt_Booster.SelectionStart = 0;
            this.mtxt_Booster.ShortcutsEnabled = true;
            this.mtxt_Booster.Size = new System.Drawing.Size(200, 30);
            this.mtxt_Booster.TabIndex = 15;
            this.mtxt_Booster.UseSelectable = true;
            this.mtxt_Booster.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Booster.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxt_Tmc
            // 
            // 
            // 
            // 
            this.mtxt_Tmc.CustomButton.Image = null;
            this.mtxt_Tmc.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.mtxt_Tmc.CustomButton.Name = "";
            this.mtxt_Tmc.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_Tmc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_Tmc.CustomButton.TabIndex = 1;
            this.mtxt_Tmc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_Tmc.CustomButton.UseSelectable = true;
            this.mtxt_Tmc.CustomButton.Visible = false;
            this.mtxt_Tmc.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_Tmc.Lines = new string[0];
            this.mtxt_Tmc.Location = new System.Drawing.Point(138, 274);
            this.mtxt_Tmc.MaxLength = 32767;
            this.mtxt_Tmc.Name = "mtxt_Tmc";
            this.mtxt_Tmc.PasswordChar = '\0';
            this.mtxt_Tmc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_Tmc.SelectedText = "";
            this.mtxt_Tmc.SelectionLength = 0;
            this.mtxt_Tmc.SelectionStart = 0;
            this.mtxt_Tmc.ShortcutsEnabled = true;
            this.mtxt_Tmc.Size = new System.Drawing.Size(200, 30);
            this.mtxt_Tmc.TabIndex = 16;
            this.mtxt_Tmc.UseSelectable = true;
            this.mtxt_Tmc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_Tmc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mpnl_AvailableProjects
            // 
            this.mpnl_AvailableProjects.Controls.Add(this.grid_ProjectTest);
            this.mpnl_AvailableProjects.Controls.Add(this.progressBar);
            this.mpnl_AvailableProjects.Controls.Add(this.mTile_AvailableProjects);
            this.mpnl_AvailableProjects.Controls.Add(this.tree_Projects);
            this.mpnl_AvailableProjects.HorizontalScrollbarBarColor = true;
            this.mpnl_AvailableProjects.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_AvailableProjects.HorizontalScrollbarSize = 10;
            this.mpnl_AvailableProjects.Location = new System.Drawing.Point(360, 0);
            this.mpnl_AvailableProjects.Name = "mpnl_AvailableProjects";
            this.mpnl_AvailableProjects.Size = new System.Drawing.Size(950, 550);
            this.mpnl_AvailableProjects.TabIndex = 13;
            this.mpnl_AvailableProjects.VerticalScrollbarBarColor = true;
            this.mpnl_AvailableProjects.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_AvailableProjects.VerticalScrollbarSize = 10;
            // 
            // grid_ProjectTest
            // 
            this.grid_ProjectTest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid_ProjectTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ProjectTest.Location = new System.Drawing.Point(361, 100);
            this.grid_ProjectTest.MultiSelect = false;
            this.grid_ProjectTest.Name = "grid_ProjectTest";
            this.grid_ProjectTest.ReadOnly = true;
            this.grid_ProjectTest.RowHeadersWidth = 51;
            this.grid_ProjectTest.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grid_ProjectTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_ProjectTest.Size = new System.Drawing.Size(580, 400);
            this.grid_ProjectTest.TabIndex = 94;
            this.grid_ProjectTest.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_ProjectTest_CellMouseClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(5, 514);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(937, 23);
            this.progressBar.TabIndex = 23;
            // 
            // mTile_AvailableProjects
            // 
            this.mTile_AvailableProjects.ActiveControl = null;
            this.mTile_AvailableProjects.Location = new System.Drawing.Point(0, 1);
            this.mTile_AvailableProjects.Name = "mTile_AvailableProjects";
            this.mTile_AvailableProjects.Size = new System.Drawing.Size(1007, 60);
            this.mTile_AvailableProjects.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile_AvailableProjects.TabIndex = 22;
            this.mTile_AvailableProjects.Text = "Available Projects in Database";
            this.mTile_AvailableProjects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile_AvailableProjects.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile_AvailableProjects.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile_AvailableProjects.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile_AvailableProjects.UseSelectable = true;
            this.mTile_AvailableProjects.Click += new System.EventHandler(this.mbtn_Ok_Click);
            // 
            // tree_Projects
            // 
            this.tree_Projects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_Projects.Location = new System.Drawing.Point(5, 100);
            this.tree_Projects.Name = "tree_Projects";
            this.tree_Projects.Size = new System.Drawing.Size(350, 400);
            this.tree_Projects.TabIndex = 3;
            this.tree_Projects.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_Projects_NodeMouseClick);
            this.tree_Projects.TabIndexChanged += new System.EventHandler(this.tree_Projects_TabIndexChanged);
            // 
            // ILExplorer
            // 
            this.ILExplorer.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ILExplorer.ImageSize = new System.Drawing.Size(16, 16);
            this.ILExplorer.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DlgOpenFile
            // 
            this.DlgOpenFile.FileName = "openFileDialog1";
            // 
            // mbtn_BDeleteProject
            // 
            this.mbtn_BDeleteProject.Enabled = false;
            this.mbtn_BDeleteProject.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtn_BDeleteProject.Location = new System.Drawing.Point(12, 648);
            this.mbtn_BDeleteProject.Name = "mbtn_BDeleteProject";
            this.mbtn_BDeleteProject.Size = new System.Drawing.Size(626, 45);
            this.mbtn_BDeleteProject.TabIndex = 2;
            this.mbtn_BDeleteProject.Text = "Delete &Project";
            this.mbtn_BDeleteProject.UseSelectable = true;
            this.mbtn_BDeleteProject.Click += new System.EventHandler(this.mbtn_BDeleteProject_Click);
            // 
            // Form_Operational_Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 761);
            this.ControlBox = false;
            this.Controls.Add(this.mpnl_AvailableProjects);
            this.Controls.Add(this.mpnl_CurrentProject);
            this.Controls.Add(this.mpnl_Comment);
            this.Controls.Add(this.mchk_CBPrintSeries);
            this.Controls.Add(this.mchk_CBExportBitmapSeries);
            this.Controls.Add(this.mchk_CBExportExcelSeries);
            this.Controls.Add(this.mbtn_Ok);
            this.Controls.Add(this.mbtn_BExportSeries);
            this.Controls.Add(this.mbtn_BLoadTest);
            this.Controls.Add(this.mbtn_BDeleteTest);
            this.Controls.Add(this.mbtn_BDeleteProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "Form_Operational_Project";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Continental - ADAM Functional Test Bench - Load Available Projects";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Operational_Project_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Operational_Project_FormClosed);
            this.Load += new System.EventHandler(this.Form_Operational_Project_Load);
            this.mpnl_Comment.ResumeLayout(false);
            this.mpnl_Comment.PerformLayout();
            this.mpnl_CurrentProject.ResumeLayout(false);
            this.mpnl_CurrentProject.PerformLayout();
            this.mpnl_AvailableProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_ProjectTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton mbtn_BDeleteTest;
        private MetroFramework.Controls.MetroButton mbtn_BLoadTest;
        private MetroFramework.Controls.MetroButton mbtn_BExportSeries;
        private MetroFramework.Controls.MetroButton mbtn_Ok;
        private MetroFramework.Controls.MetroCheckBox mchk_CBExportExcelSeries;
        private MetroFramework.Controls.MetroCheckBox mchk_CBExportBitmapSeries;
        private MetroFramework.Controls.MetroCheckBox mchk_CBPrintSeries;
        private MetroFramework.Controls.MetroPanel mpnl_Comment;
        private MetroFramework.Controls.MetroLabel mlbl_Comment;
        private MetroFramework.Controls.MetroTextBox mtxt_Comment;
        private MetroFramework.Controls.MetroPanel mpnl_CurrentProject;
        private MetroFramework.Controls.MetroTextBox mtxt_EIdent;
        private MetroFramework.Controls.MetroPanel mpnl_AvailableProjects;
        private System.Windows.Forms.TreeView tree_Projects;
        private MetroFramework.Controls.MetroLabel mlbl_TestingDate;
        private MetroFramework.Controls.MetroLabel mlbl_Booster;
        private MetroFramework.Controls.MetroLabel mlbl_Tmc;
        private MetroFramework.Controls.MetroLabel mlbl_ProductionDate;
        private MetroFramework.Controls.MetroLabel mlbl_TO;
        private MetroFramework.Controls.MetroLabel mlbl_Tester;
        private MetroFramework.Controls.MetroTextBox mtxt_TestingDate;
        private MetroFramework.Controls.MetroTextBox mtxt_Tester;
        private MetroFramework.Controls.MetroTextBox mtxt_TO;
        private MetroFramework.Controls.MetroTextBox mtxt_ProductionDate;
        private MetroFramework.Controls.MetroTextBox mtxt_Tmc;
        private MetroFramework.Controls.MetroTextBox mtxt_Booster;
        private MetroFramework.Controls.MetroTextBox mtxt_ECustomer;
        private MetroFramework.Controls.MetroLabel mlbl_CustomerType;
        private MetroFramework.Controls.MetroLabel mlbl_Ident;
        private MetroFramework.Controls.MetroTile mTileCurrentProject;
        private MetroFramework.Controls.MetroTile mTile_AvailableProjects;
        private System.Windows.Forms.ImageList ILExplorer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog DlgOpenFile;
        private System.Windows.Forms.SaveFileDialog DlgSaveFile;
        private System.Windows.Forms.DataGridView grid_ProjectTest;
        private MetroFramework.Controls.MetroButton mbtn_BDeleteProject;
    }
}