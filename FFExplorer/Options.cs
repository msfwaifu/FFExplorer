using System;
using System.Windows.Forms;

namespace FFExplorer
{
    /// <summary>
    /// A delegate used to apply some logic after changing options through dialog.
    /// </summary>
    public delegate void OnOptionsSaved_d();

    /// <summary>
    /// This dialog contains controls for changing various options.
    /// </summary>
    partial class Options : Form
    {
        Form1 owner;
        public event OnOptionsSaved_d OnOptionsSaved;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            owner = this.Owner as Form1;
            UpdateFields();            
        }

        private void CnclButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            owner.Options.RememberLastFolder = MainRememberLastFolder.Checked;
            owner.Options.SaveTemporaryFiles = MainSaveTemporary.Checked;
            owner.Options.ShowLog = MainShowLog.Checked;
            owner.Options.LogFilesDaysLimit = (int)LoggerLogDaysLimitValue.Value;

            OnOptionsSaved?.Invoke();

            Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            owner.Options.Reset();
            UpdateFields();
        }

        private void UpdateFields()
        {
            MainRememberLastFolder.Checked = owner.Options.RememberLastFolder;
            MainSaveTemporary.Checked = owner.Options.SaveTemporaryFiles;
            MainShowLog.Checked = owner.Options.ShowLog;
            LoggerLogDaysLimitValue.Value =
                owner.Options.LogFilesDaysLimit < LoggerLogDaysLimitValue.Minimum? LoggerLogDaysLimitValue.Minimum :
                owner.Options.LogFilesDaysLimit > LoggerLogDaysLimitValue.Maximum? LoggerLogDaysLimitValue.Maximum :
                owner.Options.LogFilesDaysLimit;
        }
    }
}
