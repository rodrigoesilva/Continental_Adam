
namespace Continental.Project.Adam.UI
{
    partial class Form_Operational_ManualActuation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Operational_ManualActuation));
            this.mpnl_ManualActuation = new MetroFramework.Controls.MetroPanel();
            this.mbtnClose = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // mpnl_ManualActuation
            // 
            this.mpnl_ManualActuation.HorizontalScrollbarBarColor = true;
            this.mpnl_ManualActuation.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_ManualActuation.HorizontalScrollbarSize = 10;
            this.mpnl_ManualActuation.Location = new System.Drawing.Point(10, 5);
            this.mpnl_ManualActuation.Name = "mpnl_ManualActuation";
            this.mpnl_ManualActuation.Size = new System.Drawing.Size(1300, 920);
            this.mpnl_ManualActuation.TabIndex = 43;
            this.mpnl_ManualActuation.VerticalScrollbarBarColor = true;
            this.mpnl_ManualActuation.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_ManualActuation.VerticalScrollbarSize = 10;
            // 
            // mbtnClose
            // 
            this.mbtnClose.Location = new System.Drawing.Point(560, 930);
            this.mbtnClose.Name = "mbtnClose";
            this.mbtnClose.Size = new System.Drawing.Size(200, 45);
            this.mbtnClose.TabIndex = 26;
            this.mbtnClose.Text = "&Close";
            this.mbtnClose.UseSelectable = true;
            this.mbtnClose.Click += new System.EventHandler(this.mbtnClose_Click);
            // 
            // Form_Operational_ManualActuation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 981);
            this.ControlBox = false;
            this.Controls.Add(this.mbtnClose);
            this.Controls.Add(this.mpnl_ManualActuation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 726);
            this.Name = "Form_Operational_ManualActuation";
            this.Text = "Continental - ADAM Functional Test Bench - Manual Actuation";
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel mpnl_ManualActuation;
        private MetroFramework.Controls.MetroButton mbtnClose;
    }
}