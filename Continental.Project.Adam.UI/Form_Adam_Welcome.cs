using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Continental.Project.Adam.UI.Helper;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Adam_Welcome : MetroForm
    {
        HelperApp _helperApp = new HelperApp();
        public Form_Adam_Welcome()
        {
            InitializeComponent();
        }

        private void Form_Adam_Welcome_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void picContinental_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                var formHome = new Home();
                formHome.Closed += (s, args) => this.Close();
                formHome.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _helperApp.appMsg_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
