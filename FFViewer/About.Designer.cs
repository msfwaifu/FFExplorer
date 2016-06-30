namespace FFViewer_cs
{
    partial class About
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
            this.AppNameVer = new System.Windows.Forms.Label();
            this.LicenseButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.CopyrightJames = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AppNameVer
            // 
            this.AppNameVer.AutoSize = true;
            this.AppNameVer.Location = new System.Drawing.Point(12, 9);
            this.AppNameVer.Name = "AppNameVer";
            this.AppNameVer.Size = new System.Drawing.Size(93, 13);
            this.AppNameVer.TabIndex = 21;
            this.AppNameVer.Text = "YYYYYY vXXXXX";
            // 
            // LicenseButton
            // 
            this.LicenseButton.Location = new System.Drawing.Point(401, 41);
            this.LicenseButton.Name = "LicenseButton";
            this.LicenseButton.Size = new System.Drawing.Size(75, 23);
            this.LicenseButton.TabIndex = 20;
            this.LicenseButton.Text = "Лицензия";
            this.LicenseButton.UseVisualStyleBackColor = true;
            this.LicenseButton.Click += new System.EventHandler(this.LicenseButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(401, 12);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 13;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CopyrightJames
            // 
            this.CopyrightJames.AutoSize = true;
            this.CopyrightJames.Location = new System.Drawing.Point(12, 22);
            this.CopyrightJames.Name = "CopyrightJames";
            this.CopyrightJames.Size = new System.Drawing.Size(320, 13);
            this.CopyrightJames.TabIndex = 12;
            this.CopyrightJames.Text = "Special thanks to James \'prasoc\' Blandford for his FFViewer v2.65.";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 73);
            this.Controls.Add(this.AppNameVer);
            this.Controls.Add(this.LicenseButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CopyrightJames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label AppNameVer;
        internal System.Windows.Forms.Button LicenseButton;
        internal System.Windows.Forms.Button OkButton;
        internal System.Windows.Forms.Label CopyrightJames;
    }
}