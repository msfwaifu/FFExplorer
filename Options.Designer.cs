namespace FFViewer_cs
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteTemp = new System.Windows.Forms.CheckBox();
            this.RLF = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CnclButton = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.DeleteTemp);
            this.GroupBox2.Controls.Add(this.RLF);
            this.GroupBox2.Location = new System.Drawing.Point(12, 10);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(261, 70);
            this.GroupBox2.TabIndex = 3;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Основные";
            // 
            // DeleteTemp
            // 
            this.DeleteTemp.AutoSize = true;
            this.DeleteTemp.Location = new System.Drawing.Point(9, 42);
            this.DeleteTemp.Name = "DeleteTemp";
            this.DeleteTemp.Size = new System.Drawing.Size(240, 17);
            this.DeleteTemp.TabIndex = 4;
            this.DeleteTemp.Text = "Удалять временные файлы при закрытии";
            this.DeleteTemp.UseVisualStyleBackColor = true;
            // 
            // RLF
            // 
            this.RLF.AutoSize = true;
            this.RLF.Location = new System.Drawing.Point(9, 19);
            this.RLF.Name = "RLF";
            this.RLF.Size = new System.Drawing.Size(181, 17);
            this.RLF.TabIndex = 0;
            this.RLF.Text = "Запоминать последнюю папку";
            this.RLF.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(109, 86);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(79, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CnclButton.Location = new System.Drawing.Point(194, 86);
            this.CnclButton.Name = "CnclButton";
            this.CnclButton.Size = new System.Drawing.Size(79, 23);
            this.CnclButton.TabIndex = 5;
            this.CnclButton.Text = "Отмена";
            this.CnclButton.UseVisualStyleBackColor = true;
            this.CnclButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 115);
            this.ControlBox = false;
            this.Controls.Add(this.CnclButton);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox DeleteTemp;
        internal System.Windows.Forms.CheckBox RLF;
        internal System.Windows.Forms.Button SaveButton;
        internal System.Windows.Forms.Button CnclButton;
    }
}