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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.MainGroup = new System.Windows.Forms.GroupBox();
            this.MainShowLog = new System.Windows.Forms.CheckBox();
            this.MainSaveTemporary = new System.Windows.Forms.CheckBox();
            this.MainRememberLastFolder = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.LoggerGroup = new System.Windows.Forms.GroupBox();
            this.LoggerLogDaysLimitPanel = new System.Windows.Forms.Panel();
            this.LoggerLogDaysLimitFooter = new System.Windows.Forms.Label();
            this.LoggerLogDaysLimitValue = new System.Windows.Forms.NumericUpDown();
            this.LoggerLogDaysLimitLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.MainGroup.SuspendLayout();
            this.LoggerGroup.SuspendLayout();
            this.LoggerLogDaysLimitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoggerLogDaysLimitValue)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGroup
            // 
            resources.ApplyResources(this.MainGroup, "MainGroup");
            this.MainGroup.Controls.Add(this.MainShowLog);
            this.MainGroup.Controls.Add(this.MainSaveTemporary);
            this.MainGroup.Controls.Add(this.MainRememberLastFolder);
            this.MainGroup.Name = "MainGroup";
            this.MainGroup.TabStop = false;
            // 
            // MainShowLog
            // 
            resources.ApplyResources(this.MainShowLog, "MainShowLog");
            this.MainShowLog.Name = "MainShowLog";
            this.MainShowLog.UseVisualStyleBackColor = true;
            // 
            // MainSaveTemporary
            // 
            resources.ApplyResources(this.MainSaveTemporary, "MainSaveTemporary");
            this.MainSaveTemporary.Name = "MainSaveTemporary";
            this.MainSaveTemporary.UseVisualStyleBackColor = true;
            // 
            // MainRememberLastFolder
            // 
            resources.ApplyResources(this.MainRememberLastFolder, "MainRememberLastFolder");
            this.MainRememberLastFolder.Name = "MainRememberLastFolder";
            this.MainRememberLastFolder.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LoggerGroup
            // 
            resources.ApplyResources(this.LoggerGroup, "LoggerGroup");
            this.LoggerGroup.Controls.Add(this.LoggerLogDaysLimitPanel);
            this.LoggerGroup.Name = "LoggerGroup";
            this.LoggerGroup.TabStop = false;
            // 
            // LoggerLogDaysLimitPanel
            // 
            resources.ApplyResources(this.LoggerLogDaysLimitPanel, "LoggerLogDaysLimitPanel");
            this.LoggerLogDaysLimitPanel.Controls.Add(this.LoggerLogDaysLimitFooter);
            this.LoggerLogDaysLimitPanel.Controls.Add(this.LoggerLogDaysLimitValue);
            this.LoggerLogDaysLimitPanel.Controls.Add(this.LoggerLogDaysLimitLabel);
            this.LoggerLogDaysLimitPanel.Name = "LoggerLogDaysLimitPanel";
            // 
            // LoggerLogDaysLimitFooter
            // 
            resources.ApplyResources(this.LoggerLogDaysLimitFooter, "LoggerLogDaysLimitFooter");
            this.LoggerLogDaysLimitFooter.Name = "LoggerLogDaysLimitFooter";
            // 
            // LoggerLogDaysLimitValue
            // 
            resources.ApplyResources(this.LoggerLogDaysLimitValue, "LoggerLogDaysLimitValue");
            this.LoggerLogDaysLimitValue.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.LoggerLogDaysLimitValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LoggerLogDaysLimitValue.Name = "LoggerLogDaysLimitValue";
            this.LoggerLogDaysLimitValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LoggerLogDaysLimitLabel
            // 
            resources.ApplyResources(this.LoggerLogDaysLimitLabel, "LoggerLogDaysLimitLabel");
            this.LoggerLogDaysLimitLabel.Name = "LoggerLogDaysLimitLabel";
            // 
            // ResetButton
            // 
            resources.ApplyResources(this.ResetButton, "ResetButton");
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Options
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.LoggerGroup);
            this.Controls.Add(this.MainGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            this.MainGroup.ResumeLayout(false);
            this.MainGroup.PerformLayout();
            this.LoggerGroup.ResumeLayout(false);
            this.LoggerGroup.PerformLayout();
            this.LoggerLogDaysLimitPanel.ResumeLayout(false);
            this.LoggerLogDaysLimitPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoggerLogDaysLimitValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroup;
        private System.Windows.Forms.CheckBox MainSaveTemporary;
        private System.Windows.Forms.CheckBox MainRememberLastFolder;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox LoggerGroup;
        private System.Windows.Forms.Label LoggerLogDaysLimitLabel;
        private System.Windows.Forms.Panel LoggerLogDaysLimitPanel;
        private System.Windows.Forms.Label LoggerLogDaysLimitFooter;
        private System.Windows.Forms.NumericUpDown LoggerLogDaysLimitValue;
        private System.Windows.Forms.CheckBox MainShowLog;
        private System.Windows.Forms.Button ResetButton;
    }
}