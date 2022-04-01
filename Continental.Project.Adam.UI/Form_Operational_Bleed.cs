using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_Bleed : Form
    {
        public Form_Operational_Bleed()
        {
            InitializeComponent();
        }

        private void mBtn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mbtn_Bleed1_Start_Click(object sender, EventArgs e)
        {

        }

        private void mbtn_Bleed1_Stop_Click(object sender, EventArgs e)
        {
            //Device.Application.GVL_Geral.bManBombaDreno_K001 = false
        }

        private void mbtn_Drain_BStartDrain_Click(object sender, EventArgs e)
        {
            //Device.Application.GVL_Geral.bManBombaDreno_K001 = true

        }
    }
}
