namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.SaveTemp = new System.Windows.Forms.CheckBox();
            this.RLF = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CnclButton = new System.Windows.Forms.Button();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            resources.ApplyResources(this.GroupBox2, "GroupBox2");
            this.GroupBox2.Controls.Add(this.SaveTemp);
            this.GroupBox2.Controls.Add(this.RLF);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.TabStop = false;
            // 
            // SaveTemp
            // 
            resources.ApplyResources(this.SaveTemp, "SaveTemp");
            this.SaveTemp.Name = "SaveTemp";
            this.SaveTemp.UseVisualStyleBackColor = true;
            // 
            // RLF
            // 
            resources.ApplyResources(this.RLF, "RLF");
            this.RLF.Name = "RLF";
            this.RLF.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CnclButton
            // 
            resources.ApplyResources(this.CnclButton, "CnclButton");
            this.CnclButton.Name = "CnclButton";
            this.CnclButton.UseVisualStyleBackColor = true;
            this.CnclButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Options
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox SaveTemp;
        internal System.Windows.Forms.CheckBox RLF;
        internal System.Windows.Forms.Button SaveButton;
        internal System.Windows.Forms.Button CnclButton;
    }
}