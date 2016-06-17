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
    public partial class Wait : Form
    {
        public Wait()
        {
            InitializeComponent();
        }

        public void SetStatusText(string text)
        {
            State.Text = text;
        }

        public void SetProgressBarValue(int value)
        {
            value = value > 100 ? 100 : value;
            value = value < 0 ? 0 : value;

            ProgressBar.Value = value;
        }

        public void SetState(string stateText, int barValue)
        {
            SetStatusText(stateText);
            SetProgressBarValue(barValue);
            this.Show();
            Application.DoEvents();
        }
    }
}
