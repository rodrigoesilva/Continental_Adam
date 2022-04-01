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
    public partial class Form_Adam_About : Form
    {
        public Form_Adam_About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void TransfDelegate(String value);
        public event TransfDelegate TransfEvent;

        private void btfetch_Click(object sender, EventArgs e)
        {
            //Me.Parent.tmrParent.Enabled = True.

            var tt = this.Parent.Enabled;

            string str = lbl_About.Text.ToString();
            TransfEvent(str);
        }
    }
}
