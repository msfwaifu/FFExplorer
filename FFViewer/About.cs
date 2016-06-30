using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    /// <summary>
    /// Form contains information about authors, licensing etc.
    /// </summary>
    public partial class About : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public About()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void LicenseButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://creativecommons.org/licenses/by-nc-sa/3.0/");
        }

        private void About_Load(object sender, EventArgs e)
        {
            AppNameVer.Text = String.Format("{0} v{1}", Application.ProductName, Application.ProductVersion);
        }
    }
}
