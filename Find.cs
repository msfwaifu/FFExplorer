using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFViewer_cs
{
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 owner = this.Owner as Form1;
            int selectionStart = owner.CodeBox.Text.IndexOf(SearchBox.Text, owner.CodeBox.SelectionStart);
            if (selectionStart > 0)
            {
                owner.CodeBox.Select(selectionStart, SearchBox.Text.Length);
                owner.CodeBox.ScrollToCaret();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Find_Activated(object sender, EventArgs e)
        {
            Form1 owner = this.Owner as Form1;
            SearchBox.Focus();
            if (owner.CodeBox.SelectionLength > 0)
            {
                SearchBox.Text = owner.CodeBox.SelectedText;
                SearchBox.SelectionStart = owner.CodeBox.SelectionLength;
            }
        }
    }
}
