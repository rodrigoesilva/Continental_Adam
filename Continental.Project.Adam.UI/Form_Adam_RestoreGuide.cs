using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Adam_RestoreGuide : Form
    {
        public Form_Adam_RestoreGuide()
        {
            InitializeComponent();
        }

        private void mbtn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtn_DoBackup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
