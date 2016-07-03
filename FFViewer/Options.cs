﻿using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public partial class Options : Form
    {
        private Form1 owner;

        /// <summary>
        /// NI
        /// </summary>
        public Options()
        {
            InitializeComponent();
            owner = null;
        }

        private void Options_Load(object sender, EventArgs e)
        {
            if (owner == null)
                owner = this.Owner as Form1;

            try
            {
                RLF.Checked = owner.Options.RememberLastFolder;
                SaveTemp.Checked = owner.Options.SaveTemporaryFiles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла настроек:\n"+ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                owner.Options.RememberLastFolder = RLF.Checked;
                owner.Options.SaveTemporaryFiles = SaveTemp.Checked;
                MessageBox.Show("Настройки успешно сохранены", "Сохранено", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении настроек:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK);
            }

            this.Hide();
            owner.Focus();
        }
    }
}
