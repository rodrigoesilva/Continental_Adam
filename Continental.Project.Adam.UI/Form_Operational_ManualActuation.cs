using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_ManualActuation : Form
    {
        public Form_Operational_ManualActuation()
        {
            InitializeComponent();

            CONTROL_WebVisu();
        }

        private void CONTROL_WebVisu()
        {
            var headerBrowser = new ChromiumWebBrowser("http://192.168.0.1:8080/webvisu3.htm") { Dock = DockStyle.Fill };

            if (headerBrowser != null)
                mpnl_ManualActuation.Controls.Add(headerBrowser);
        }
        private void mbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
