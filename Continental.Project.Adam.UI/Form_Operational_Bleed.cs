using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_Bleed : Form
    {
        public Form_Operational_Bleed()
        {
            InitializeComponent();

            CONTROL_WebVisu();
        }

        private void CONTROL_WebVisu()
        {
            var headerBrowser = new ChromiumWebBrowser("http://192.168.0.1:8080/webvisu4.htm") { Dock = DockStyle.Fill };

            if (headerBrowser != null)
                mpnl_Bleed.Controls.Add(headerBrowser);
        }
        private void mBtn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
