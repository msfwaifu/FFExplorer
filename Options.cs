﻿using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    public partial class Options : Form
    {
        private Form1 owner;
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
                RLF.Checked = owner.options.RememberLastFolder;
                DeleteTemp.Checked = owner.options.DeleteTemporaryFiles;
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
                owner.options.RememberLastFolder = RLF.Checked;
                owner.options.DeleteTemporaryFiles = DeleteTemp.Checked;
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
