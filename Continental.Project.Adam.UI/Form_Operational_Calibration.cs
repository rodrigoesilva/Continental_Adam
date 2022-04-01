using Continental.Project.Adam.UI.COM;
using System;
using System.Windows.Forms;

namespace Continental.Project.Adam.UI
{
    public partial class Form_Operational_Calibration : Form
    {

        #region Define

        ComHBM _comHBM = new ComHBM();

        #endregion

        public Form_Operational_Calibration()
        {
            InitializeComponent();
        }

        private void Form_Operational_Calibration_Load(object sender, EventArgs e)
        {
            string url = _comHBM._hbm_IpDevice.ToString();

            OpenURLInBrowser(url);
        }

        private void OpenURLInBrowser(string url)
        {
            try
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "http://" + url;

                webBrowser1.Navigate(new Uri(url));
            }
            catch (UriFormatException ex)
            {
                var err = ex.Message;
                return;
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //WebBrowser browser = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            //if (browser != null)
            //    tabControl1.SelectedTab.Text = browser.DocumentTitle;
        }
    }
}
