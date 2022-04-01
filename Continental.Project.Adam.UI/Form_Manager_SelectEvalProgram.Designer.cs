
namespace Continental.Project.Adam.UI
{
    partial class Form_Manager_SelectEvalProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Manager_SelectEvalProgram));
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.tbc_TestingProgram = new System.Windows.Forms.TabControl();
            this.tab_AvailableTests = new System.Windows.Forms.TabPage();
            this.tree_TVEvalSequences = new System.Windows.Forms.TreeView();
            this.tab_UserDefinedTests = new System.Windows.Forms.TabPage();
            this.lst_FLBUserDefinedTests = new System.Windows.Forms.ListBox();
            this.mbtn_Ok = new MetroFramework.Controls.MetroButton();
            this.mbtn_Cancel = new MetroFramework.Controls.MetroButton();
            this.mtxt_LSelectedTest = new MetroFramework.Controls.MetroTextBox();
            this.tbc_TestingProgram.SuspendLayout();
            this.tab_AvailableTests.SuspendLayout();
            this.tab_UserDefinedTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Location = new System.Drawing.Point(2, 2);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(800, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 19;
            this.mTile.Text = "Select Automatic Testing Program";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // tbc_TestingProgram
            // 
            this.tbc_TestingProgram.Controls.Add(this.tab_AvailableTests);
            this.tbc_TestingProgram.Controls.Add(this.tab_UserDefinedTests);
            this.tbc_TestingProgram.Location = new System.Drawing.Point(10, 110);
            this.tbc_TestingProgram.Name = "tbc_TestingProgram";
            this.tbc_TestingProgram.SelectedIndex = 0;
            this.tbc_TestingProgram.Size = new System.Drawing.Size(765, 392);
            this.tbc_TestingProgram.TabIndex = 20;
            this.tbc_TestingProgram.SelectedIndexChanged += new System.EventHandler(this.tbc_TestingProgram_SelectedIndexChanged);
            // 
            // tab_AvailableTests
            // 
            this.tab_AvailableTests.Controls.Add(this.tree_TVEvalSequences);
            this.tab_AvailableTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_AvailableTests.Location = new System.Drawing.Point(4, 22);
            this.tab_AvailableTests.Name = "tab_AvailableTests";
            this.tab_AvailableTests.Padding = new System.Windows.Forms.Padding(3);
            this.tab_AvailableTests.Size = new System.Drawing.Size(757, 366);
            this.tab_AvailableTests.TabIndex = 0;
            this.tab_AvailableTests.Text = "Available tests";
            this.tab_AvailableTests.UseVisualStyleBackColor = true;
            // 
            // tree_TVEvalSequences
            // 
            this.tree_TVEvalSequences.Location = new System.Drawing.Point(5, 5);
            this.tree_TVEvalSequences.Name = "tree_TVEvalSequences";
            this.tree_TVEvalSequences.Size = new System.Drawing.Size(740, 355);
            this.tree_TVEvalSequences.TabIndex = 0;
            this.tree_TVEvalSequences.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_TVEvalSequences_NodeMouseClick);
            // 
            // tab_UserDefinedTests
            // 
            this.tab_UserDefinedTests.Controls.Add(this.lst_FLBUserDefinedTests);
            this.tab_UserDefinedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_UserDefinedTests.Location = new System.Drawing.Point(4, 22);
            this.tab_UserDefinedTests.Name = "tab_UserDefinedTests";
            this.tab_UserDefinedTests.Padding = new System.Windows.Forms.Padding(3);
            this.tab_UserDefinedTests.Size = new System.Drawing.Size(757, 366);
            this.tab_UserDefinedTests.TabIndex = 1;
            this.tab_UserDefinedTests.Text = "User defined tests";
            this.tab_UserDefinedTests.UseVisualStyleBackColor = true;
            // 
            // lst_FLBUserDefinedTests
            // 
            this.lst_FLBUserDefinedTests.FormattingEnabled = true;
            this.lst_FLBUserDefinedTests.ItemHeight = 20;
            this.lst_FLBUserDefinedTests.Location = new System.Drawing.Point(5, 5);
            this.lst_FLBUserDefinedTests.Name = "lst_FLBUserDefinedTests";
            this.lst_FLBUserDefinedTests.Size = new System.Drawing.Size(740, 344);
            this.lst_FLBUserDefinedTests.TabIndex = 1;
            this.lst_FLBUserDefinedTests.DoubleClick += new System.EventHandler(this.lst_FLBUserDefinedTests_DoubleClick);
            // 
            // mbtn_Ok
            // 
            this.mbtn_Ok.Location = new System.Drawing.Point(620, 510);
            this.mbtn_Ok.Name = "mbtn_Ok";
            this.mbtn_Ok.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Ok.TabIndex = 21;
            this.mbtn_Ok.Text = "&Ok";
            this.mbtn_Ok.UseSelectable = true;
            this.mbtn_Ok.Click += new System.EventHandler(this.mbtn_Ok_Click);
            // 
            // mbtn_Cancel
            // 
            this.mbtn_Cancel.Location = new System.Drawing.Point(465, 510);
            this.mbtn_Cancel.Name = "mbtn_Cancel";
            this.mbtn_Cancel.Size = new System.Drawing.Size(150, 45);
            this.mbtn_Cancel.TabIndex = 22;
            this.mbtn_Cancel.Text = "&Cancel";
            this.mbtn_Cancel.UseSelectable = true;
            this.mbtn_Cancel.Click += new System.EventHandler(this.mbtn_Cancel_Click);
            // 
            // mtxt_LSelectedTest
            // 
            // 
            // 
            // 
            this.mtxt_LSelectedTest.CustomButton.Image = null;
            this.mtxt_LSelectedTest.CustomButton.Location = new System.Drawing.Point(737, 2);
            this.mtxt_LSelectedTest.CustomButton.Name = "";
            this.mtxt_LSelectedTest.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtxt_LSelectedTest.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxt_LSelectedTest.CustomButton.TabIndex = 1;
            this.mtxt_LSelectedTest.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxt_LSelectedTest.CustomButton.UseSelectable = true;
            this.mtxt_LSelectedTest.CustomButton.Visible = false;
            this.mtxt_LSelectedTest.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxt_LSelectedTest.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.mtxt_LSelectedTest.Lines = new string[0];
            this.mtxt_LSelectedTest.Location = new System.Drawing.Point(10, 70);
            this.mtxt_LSelectedTest.MaxLength = 32767;
            this.mtxt_LSelectedTest.Name = "mtxt_LSelectedTest";
            this.mtxt_LSelectedTest.PasswordChar = '\0';
            this.mtxt_LSelectedTest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxt_LSelectedTest.SelectedText = "";
            this.mtxt_LSelectedTest.SelectionLength = 0;
            this.mtxt_LSelectedTest.SelectionStart = 0;
            this.mtxt_LSelectedTest.ShortcutsEnabled = true;
            this.mtxt_LSelectedTest.Size = new System.Drawing.Size(765, 30);
            this.mtxt_LSelectedTest.TabIndex = 23;
            this.mtxt_LSelectedTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxt_LSelectedTest.UseSelectable = true;
            this.mtxt_LSelectedTest.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxt_LSelectedTest.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form_Manager_SelectEvalProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.mtxt_LSelectedTest);
            this.Controls.Add(this.mbtn_Cancel);
            this.Controls.Add(this.mbtn_Ok);
            this.Controls.Add(this.tbc_TestingProgram);
            this.Controls.Add(this.mTile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Manager_SelectEvalProgram";
            this.Text = "Continental - ADAM Functional Test Bench - Select Automatic Testing Program";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Manager_SelectEvalProgram_FormClosed);
            this.Load += new System.EventHandler(this.Form_Manager_SelectEvalProgram_Load);
            this.tbc_TestingProgram.ResumeLayout(false);
            this.tab_AvailableTests.ResumeLayout(false);
            this.tab_UserDefinedTests.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile mTile;
        private System.Windows.Forms.TabControl tbc_TestingProgram;
        private System.Windows.Forms.TabPage tab_AvailableTests;
        private System.Windows.Forms.TabPage tab_UserDefinedTests;
        private MetroFramework.Controls.MetroButton mbtn_Ok;
        private MetroFramework.Controls.MetroButton mbtn_Cancel;
        private System.Windows.Forms.TreeView tree_TVEvalSequences;
        private System.Windows.Forms.ListBox lst_FLBUserDefinedTests;
        private MetroFramework.Controls.MetroTextBox mtxt_LSelectedTest;
    }
}