
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using Continental.Project.Adam.UI.Helper;
using Continental.Project.Adam.UI.Helper.Com;
using Continental.Project.Adam.UI.BLL;
using Continental.Project.Adam.UI.Enum;

namespace Continental.Project.Adam.UI
{
    
    public partial class DEV : Form
    {

    #region Define

    HelperApp _helperApp = new HelperApp();

        Form_Adam_Main _formMain = new Form_Adam_Main();

        #endregion

        public DEV()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
    }
}
