
namespace Continental.Project.Adam.UI
{
    partial class Form_Adam_Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Adam_Welcome));
            this.picContinental = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).BeginInit();
            this.SuspendLayout();
            // 
            // picContinental
            // 
            this.picContinental.Image = ((System.Drawing.Image)(resources.GetObject("picContinental.Image")));
            this.picContinental.Location = new System.Drawing.Point(765, 450);
            this.picContinental.Name = "picContinental";
            this.picContinental.Size = new System.Drawing.Size(405, 124);
            this.picContinental.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picContinental.TabIndex = 0;
            this.picContinental.TabStop = false;
            this.picContinental.Click += new System.EventHandler(this.picContinental_Click);
            // 
            // Form_Adam_Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.picContinental);
            this.DoubleBuffered = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1364, 726);
            this.Movable = false;
            this.Name = "Form_Adam_Welcome";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Continental - ADAM Functional Test Bench";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Adam_Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picContinental)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picContinental;
    }
}