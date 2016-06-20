using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    public partial class GotoLine : Form
    {
        public GotoLine()
        {
            InitializeComponent();
        }

        private void GotoButton_Click(object sender, EventArgs e)
        {
            Form1 owner = this.Owner as Form1;
            if (double.Parse(SearchBox.Text) > 0 && double.Parse(SearchBox.Text) < owner.SubStrCount(owner.CodeBox.Text, "\r\n"))
            {
                for (int i = 0; i <= double.Parse(SearchBox.Text) - 2; ++i)
                    owner.CodeBox.SelectionStart = owner.CodeBox.Text.IndexOf("\r\n", owner.CodeBox.SelectionStart) + 2;
                owner.CodeBox.ScrollToCaret();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
