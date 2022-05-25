
namespace Continental.Project.Adam.UI
{
    partial class Form_Operational_Bleed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Operational_Bleed));
            this.mBtn_Close = new MetroFramework.Controls.MetroButton();
            this.mpnl_Bleed = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // mBtn_Close
            // 
            this.mBtn_Close.Location = new System.Drawing.Point(169, 404);
            this.mBtn_Close.Name = "mBtn_Close";
            this.mBtn_Close.Size = new System.Drawing.Size(150, 45);
            this.mBtn_Close.TabIndex = 23;
            this.mBtn_Close.Text = "&Close";
            this.mBtn_Close.UseSelectable = true;
            this.mBtn_Close.Click += new System.EventHandler(this.mBtn_Close_Click);
            // 
            // mpnl_Bleed
            // 
            this.mpnl_Bleed.HorizontalScrollbarBarColor = true;
            this.mpnl_Bleed.HorizontalScrollbarHighlightOnWheel = false;
            this.mpnl_Bleed.HorizontalScrollbarSize = 10;
            this.mpnl_Bleed.Location = new System.Drawing.Point(12, 12);
            this.mpnl_Bleed.Name = "mpnl_Bleed";
            this.mpnl_Bleed.Size = new System.Drawing.Size(465, 368);
            this.mpnl_Bleed.TabIndex = 44;
            this.mpnl_Bleed.VerticalScrollbarBarColor = true;
            this.mpnl_Bleed.VerticalScrollbarHighlightOnWheel = false;
            this.mpnl_Bleed.VerticalScrollbarSize = 10;
            // 
            // Form_Operational_Bleed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.ControlBox = false;
            this.Controls.Add(this.mpnl_Bleed);
            this.Controls.Add(this.mBtn_Close);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Operational_Bleed";
            this.Text = "Continental - ADAM Functional Test Bench - Bleed";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton mBtn_Close;
        private MetroFramework.Controls.MetroPanel mpnl_Bleed;
    }
}