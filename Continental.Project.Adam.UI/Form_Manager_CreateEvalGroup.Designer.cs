
namespace Continental.Project.Adam.UI
{
    partial class Form_Manager_CreateEvalGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Manager_CreateEvalGroup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tree_TVEvalSequences = new System.Windows.Forms.TreeView();
            this.mTile = new MetroFramework.Controls.MetroTile();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mbtn_BLoad = new MetroFramework.Controls.MetroButton();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.mbtn_BSaveAs = new MetroFramework.Controls.MetroButton();
            this.mbtn_BNew = new MetroFramework.Controls.MetroButton();
            this.mbtn_BDelete = new MetroFramework.Controls.MetroButton();
            this.lst_LBEvalDest = new System.Windows.Forms.ListBox();
            this.mbtn_BAddToList = new MetroFramework.Controls.MetroButton();
            this.mBtn_Ok = new MetroFramework.Controls.MetroButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DlgSave = new System.Windows.Forms.SaveFileDialog();
            this.DlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tree_TVEvalSequences);
            this.groupBox1.Controls.Add(this.mTile);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 499);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tree_TVEvalSequences
            // 
            this.tree_TVEvalSequences.Location = new System.Drawing.Point(6, 67);
            this.tree_TVEvalSequences.Name = "tree_TVEvalSequences";
            this.tree_TVEvalSequences.Size = new System.Drawing.Size(441, 426);
            this.tree_TVEvalSequences.TabIndex = 0;
            // 
            // mTile
            // 
            this.mTile.ActiveControl = null;
            this.mTile.Cursor = System.Windows.Forms.Cursors.Default;
            this.mTile.Enabled = false;
            this.mTile.Location = new System.Drawing.Point(0, 1);
            this.mTile.Name = "mTile";
            this.mTile.Size = new System.Drawing.Size(451, 60);
            this.mTile.Style = MetroFramework.MetroColorStyle.Orange;
            this.mTile.TabIndex = 21;
            this.mTile.Text = " Basic Evaluation Pool ";
            this.mTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.mTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.mTile.UseSelectable = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mbtn_BLoad);
            this.groupBox2.Controls.Add(this.metroTile1);
            this.groupBox2.Controls.Add(this.mbtn_BSaveAs);
            this.groupBox2.Controls.Add(this.mbtn_BNew);
            this.groupBox2.Controls.Add(this.mbtn_BDelete);
            this.groupBox2.Controls.Add(this.lst_LBEvalDest);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(525, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 499);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // mbtn_BLoad
            // 
            this.mbtn_BLoad.Location = new System.Drawing.Point(330, 67);
            this.mbtn_BLoad.Name = "mbtn_BLoad";
            this.mbtn_BLoad.Size = new System.Drawing.Size(115, 45);
            this.mbtn_BLoad.TabIndex = 4;
            this.mbtn_BLoad.Text = "&Load...";
            this.mbtn_BLoad.UseSelectable = true;
            this.mbtn_BLoad.Click += new System.EventHandler(this.mbtn_BLoad_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(0, 1);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(451, 60);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile1.TabIndex = 22;
            this.metroTile1.Text = " Created Evaluation Group ";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            // 
            // mbtn_BSaveAs
            // 
            this.mbtn_BSaveAs.Location = new System.Drawing.Point(139, 67);
            this.mbtn_BSaveAs.Name = "mbtn_BSaveAs";
            this.mbtn_BSaveAs.Size = new System.Drawing.Size(175, 45);
            this.mbtn_BSaveAs.TabIndex = 3;
            this.mbtn_BSaveAs.Text = "&Save...";
            this.mbtn_BSaveAs.UseSelectable = true;
            this.mbtn_BSaveAs.Click += new System.EventHandler(this.mbtn_BSaveAs_Click);
            // 
            // mbtn_BNew
            // 
            this.mbtn_BNew.Location = new System.Drawing.Point(5, 67);
            this.mbtn_BNew.Name = "mbtn_BNew";
            this.mbtn_BNew.Size = new System.Drawing.Size(115, 45);
            this.mbtn_BNew.TabIndex = 2;
            this.mbtn_BNew.Text = "&New";
            this.mbtn_BNew.UseSelectable = true;
            this.mbtn_BNew.Click += new System.EventHandler(this.mbtn_BNew_Click);
            // 
            // mbtn_BDelete
            // 
            this.mbtn_BDelete.Location = new System.Drawing.Point(109, 448);
            this.mbtn_BDelete.Name = "mbtn_BDelete";
            this.mbtn_BDelete.Size = new System.Drawing.Size(245, 45);
            this.mbtn_BDelete.TabIndex = 1;
            this.mbtn_BDelete.Text = "&Delete Selected";
            this.mbtn_BDelete.UseSelectable = true;
            this.mbtn_BDelete.Click += new System.EventHandler(this.mbtn_BDelete_Click);
            // 
            // lst_LBEvalDest
            // 
            this.lst_LBEvalDest.BackColor = System.Drawing.Color.White;
            this.lst_LBEvalDest.ForeColor = System.Drawing.Color.Black;
            this.lst_LBEvalDest.FormattingEnabled = true;
            this.lst_LBEvalDest.ItemHeight = 16;
            this.lst_LBEvalDest.Location = new System.Drawing.Point(5, 118);
            this.lst_LBEvalDest.Name = "lst_LBEvalDest";
            this.lst_LBEvalDest.Size = new System.Drawing.Size(440, 324);
            this.lst_LBEvalDest.TabIndex = 0;
            // 
            // mbtn_BAddToList
            // 
            this.mbtn_BAddToList.Location = new System.Drawing.Point(469, 72);
            this.mbtn_BAddToList.Name = "mbtn_BAddToList";
            this.mbtn_BAddToList.Size = new System.Drawing.Size(50, 432);
            this.mbtn_BAddToList.TabIndex = 2;
            this.mbtn_BAddToList.Text = "Add";
            this.mbtn_BAddToList.UseSelectable = true;
            this.mbtn_BAddToList.Click += new System.EventHandler(this.mbtn_BAddToList_Click);
            // 
            // mBtn_Ok
            // 
            this.mBtn_Ok.Location = new System.Drawing.Point(820, 510);
            this.mBtn_Ok.Name = "mBtn_Ok";
            this.mBtn_Ok.Size = new System.Drawing.Size(150, 45);
            this.mBtn_Ok.TabIndex = 23;
            this.mBtn_Ok.Text = "&Ok";
            this.mBtn_Ok.UseSelectable = true;
            this.mBtn_Ok.Click += new System.EventHandler(this.mBtn_Ok_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DlgOpen
            // 
            this.DlgOpen.FileName = "openFileDialog1";
            // 
            // Form_Manager_CreateEvalGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.ControlBox = false;
            this.Controls.Add(this.mBtn_Ok);
            this.Controls.Add(this.mbtn_BAddToList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(422, 147);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Manager_CreateEvalGroup";
            this.Text = "Continental - ADAM Functional Test Bench -  Created Evaluation Group ";
            this.Load += new System.EventHandler(this.Form_Manager_CreateEvalGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tree_TVEvalSequences;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton mbtn_BLoad;
        private MetroFramework.Controls.MetroButton mbtn_BSaveAs;
        private MetroFramework.Controls.MetroButton mbtn_BNew;
        private MetroFramework.Controls.MetroButton mbtn_BDelete;
        private System.Windows.Forms.ListBox lst_LBEvalDest;
        private MetroFramework.Controls.MetroButton mbtn_BAddToList;
        private MetroFramework.Controls.MetroTile mTile;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroButton mBtn_Ok;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SaveFileDialog DlgSave;
        private System.Windows.Forms.OpenFileDialog DlgOpen;
    }
}