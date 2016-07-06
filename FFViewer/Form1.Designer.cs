namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RawFiles = new System.Windows.Forms.TreeView();
            this.FileListRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExtractAllGSCsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.CodeBoxRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RawfileInfoPanel = new System.Windows.Forms.Panel();
            this.RawfileInfoFileName = new System.Windows.Forms.Label();
            this.RawfileInfoFileLabel = new System.Windows.Forms.Label();
            this.RawfileInfoSizeOriginal = new System.Windows.Forms.Label();
            this.RawfileInfoSizeSeparator = new System.Windows.Forms.Label();
            this.RawfileInfoSize = new System.Windows.Forms.Label();
            this.RawfileInfoSizeLabel = new System.Windows.Forms.Label();
            this.SearchBoxAndGoToPanel = new System.Windows.Forms.Panel();
            this.FindTextPanel = new System.Windows.Forms.Panel();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.FindTextLabel = new System.Windows.Forms.Label();
            this.GoToLinePanel = new System.Windows.Forms.Panel();
            this.GoToLineLabel = new System.Windows.Forms.Label();
            this.GoToLineBox = new System.Windows.Forms.NumericUpDown();
            this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MiscData = new System.Windows.Forms.TreeView();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.RawfilesPage = new System.Windows.Forms.TabPage();
            this.LocalizedStringsPage = new System.Windows.Forms.TabPage();
            this.LocalizedStringsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.LocalizedStringsTreeView = new System.Windows.Forms.TreeView();
            this.LocalizedStringKeyGroup = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LocalizedStringKeySizeLabel = new System.Windows.Forms.Label();
            this.LocalizedStringKeyOffsetValue = new System.Windows.Forms.Label();
            this.LocalizedStringKeySizeValue = new System.Windows.Forms.Label();
            this.LocalizedStringKeyOffsetLabel = new System.Windows.Forms.Label();
            this.LocalizedStringKeySizeDelimeter = new System.Windows.Forms.Label();
            this.LocalizedStringKeySizeMaxValue = new System.Windows.Forms.Label();
            this.LocalizedStringKeyTextBox = new System.Windows.Forms.TextBox();
            this.OtherPage = new System.Windows.Forms.TabPage();
            this.StatusStripLine = new System.Windows.Forms.StatusStrip();
            this.StatusBarLogLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarLogValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Wait = new System.Windows.Forms.ToolStripProgressBar();
            this.MenuStripLine = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.ZlibStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZlibCompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZlibDecompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FastfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveExtractedZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenExtractedZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CoD4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtractZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsFastfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Snippets = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateSnippetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenFFDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExtractDialog = new System.Windows.Forms.SaveFileDialog();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LogGroup = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ExportZoneDialog = new System.Windows.Forms.SaveFileDialog();
            this.SaveFastfileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenZoneDialog = new System.Windows.Forms.OpenFileDialog();
            this.LocalizedStringValueGroup = new System.Windows.Forms.GroupBox();
            this.LocalizedStringValueTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LocalizedStringValueOffsetVal = new System.Windows.Forms.Label();
            this.LocalizedStringValueOffsetLabel = new System.Windows.Forms.Label();
            this.LocalizedStringValueSizeMaxVal = new System.Windows.Forms.Label();
            this.LocalizedStringValueSizeDelimeter = new System.Windows.Forms.Label();
            this.LocalizedStringValueSizeVal = new System.Windows.Forms.Label();
            this.LocalizedStringValueSizeLabel = new System.Windows.Forms.Label();
            this.LocalizedStringsWarningLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.FileListRightClick.SuspendLayout();
            this.CodeBoxRightClick.SuspendLayout();
            this.RawfileInfoPanel.SuspendLayout();
            this.SearchBoxAndGoToPanel.SuspendLayout();
            this.FindTextPanel.SuspendLayout();
            this.GoToLinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoToLineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).BeginInit();
            this.SplitContainer3.Panel1.SuspendLayout();
            this.SplitContainer3.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.RawfilesPage.SuspendLayout();
            this.LocalizedStringsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizedStringsSplitContainer)).BeginInit();
            this.LocalizedStringsSplitContainer.Panel1.SuspendLayout();
            this.LocalizedStringsSplitContainer.Panel2.SuspendLayout();
            this.LocalizedStringsSplitContainer.SuspendLayout();
            this.LocalizedStringKeyGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.OtherPage.SuspendLayout();
            this.StatusStripLine.SuspendLayout();
            this.MenuStripLine.SuspendLayout();
            this.LogGroup.SuspendLayout();
            this.LocalizedStringValueGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            resources.ApplyResources(this.SplitContainer1, "SplitContainer1");
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.RawFiles);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.CodeBox);
            this.SplitContainer1.Panel2.Controls.Add(this.RawfileInfoPanel);
            this.SplitContainer1.Panel2.Controls.Add(this.SearchBoxAndGoToPanel);
            // 
            // RawFiles
            // 
            this.RawFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RawFiles.ContextMenuStrip = this.FileListRightClick;
            resources.ApplyResources(this.RawFiles, "RawFiles");
            this.RawFiles.FullRowSelect = true;
            this.RawFiles.HideSelection = false;
            this.RawFiles.Name = "RawFiles";
            this.RawFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RawFiles_AfterSelect);
            this.RawFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RawFiles_NodeMouseClick);
            // 
            // FileListRightClick
            // 
            this.FileListRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportFileToolStripMenuItem,
            this.EditSelectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExtractAllGSCsToolStripMenuItem});
            this.FileListRightClick.Name = "FileListRightClick";
            resources.ApplyResources(this.FileListRightClick, "FileListRightClick");
            // 
            // ExportFileToolStripMenuItem
            // 
            this.ExportFileToolStripMenuItem.Name = "ExportFileToolStripMenuItem";
            resources.ApplyResources(this.ExportFileToolStripMenuItem, "ExportFileToolStripMenuItem");
            this.ExportFileToolStripMenuItem.Click += new System.EventHandler(this.ExportFileToolStripMenuItem_Click);
            // 
            // EditSelectionToolStripMenuItem
            // 
            this.EditSelectionToolStripMenuItem.Name = "EditSelectionToolStripMenuItem";
            resources.ApplyResources(this.EditSelectionToolStripMenuItem, "EditSelectionToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // ExtractAllGSCsToolStripMenuItem
            // 
            this.ExtractAllGSCsToolStripMenuItem.Name = "ExtractAllGSCsToolStripMenuItem";
            resources.ApplyResources(this.ExtractAllGSCsToolStripMenuItem, "ExtractAllGSCsToolStripMenuItem");
            this.ExtractAllGSCsToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllGSCsToolStripMenuItem_Click);
            // 
            // CodeBox
            // 
            this.CodeBox.AcceptsTab = true;
            this.CodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeBox.ContextMenuStrip = this.CodeBoxRightClick;
            resources.ApplyResources(this.CodeBox, "CodeBox");
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Click += new System.EventHandler(this.CodeBox_Click);
            this.CodeBox.TextChanged += new System.EventHandler(this.CodeBox_TextChanged);
            this.CodeBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodeBox_KeyUp);
            // 
            // CodeBoxRightClick
            // 
            this.CodeBoxRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.toolStripSeparator2,
            this.FindToolStripMenuItem,
            this.FindNextToolStripMenuItem,
            this.GotoToolStripMenuItem,
            this.SelectAllToolStripMenuItem});
            this.CodeBoxRightClick.Name = "CodeBoxRightClick";
            resources.ApplyResources(this.CodeBoxRightClick, "CodeBoxRightClick");
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            resources.ApplyResources(this.CutToolStripMenuItem, "CutToolStripMenuItem");
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            resources.ApplyResources(this.CopyToolStripMenuItem, "CopyToolStripMenuItem");
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            resources.ApplyResources(this.PasteToolStripMenuItem, "PasteToolStripMenuItem");
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // FindToolStripMenuItem
            // 
            this.FindToolStripMenuItem.Name = "FindToolStripMenuItem";
            resources.ApplyResources(this.FindToolStripMenuItem, "FindToolStripMenuItem");
            this.FindToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // FindNextToolStripMenuItem
            // 
            this.FindNextToolStripMenuItem.Name = "FindNextToolStripMenuItem";
            resources.ApplyResources(this.FindNextToolStripMenuItem, "FindNextToolStripMenuItem");
            this.FindNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextToolStripMenuItem_Click);
            // 
            // GotoToolStripMenuItem
            // 
            this.GotoToolStripMenuItem.Name = "GotoToolStripMenuItem";
            resources.ApplyResources(this.GotoToolStripMenuItem, "GotoToolStripMenuItem");
            this.GotoToolStripMenuItem.Click += new System.EventHandler(this.GotoToolStripMenuItem_Click);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            resources.ApplyResources(this.SelectAllToolStripMenuItem, "SelectAllToolStripMenuItem");
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // RawfileInfoPanel
            // 
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoFileName);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoFileLabel);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSizeOriginal);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSizeSeparator);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSize);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSizeLabel);
            resources.ApplyResources(this.RawfileInfoPanel, "RawfileInfoPanel");
            this.RawfileInfoPanel.Name = "RawfileInfoPanel";
            // 
            // RawfileInfoFileName
            // 
            resources.ApplyResources(this.RawfileInfoFileName, "RawfileInfoFileName");
            this.RawfileInfoFileName.Name = "RawfileInfoFileName";
            // 
            // RawfileInfoFileLabel
            // 
            resources.ApplyResources(this.RawfileInfoFileLabel, "RawfileInfoFileLabel");
            this.RawfileInfoFileLabel.Name = "RawfileInfoFileLabel";
            // 
            // RawfileInfoSizeOriginal
            // 
            resources.ApplyResources(this.RawfileInfoSizeOriginal, "RawfileInfoSizeOriginal");
            this.RawfileInfoSizeOriginal.Name = "RawfileInfoSizeOriginal";
            // 
            // RawfileInfoSizeSeparator
            // 
            resources.ApplyResources(this.RawfileInfoSizeSeparator, "RawfileInfoSizeSeparator");
            this.RawfileInfoSizeSeparator.Name = "RawfileInfoSizeSeparator";
            // 
            // RawfileInfoSize
            // 
            resources.ApplyResources(this.RawfileInfoSize, "RawfileInfoSize");
            this.RawfileInfoSize.Name = "RawfileInfoSize";
            // 
            // RawfileInfoSizeLabel
            // 
            resources.ApplyResources(this.RawfileInfoSizeLabel, "RawfileInfoSizeLabel");
            this.RawfileInfoSizeLabel.Name = "RawfileInfoSizeLabel";
            // 
            // SearchBoxAndGoToPanel
            // 
            this.SearchBoxAndGoToPanel.Controls.Add(this.FindTextPanel);
            this.SearchBoxAndGoToPanel.Controls.Add(this.GoToLinePanel);
            resources.ApplyResources(this.SearchBoxAndGoToPanel, "SearchBoxAndGoToPanel");
            this.SearchBoxAndGoToPanel.Name = "SearchBoxAndGoToPanel";
            // 
            // FindTextPanel
            // 
            this.FindTextPanel.Controls.Add(this.FindTextBox);
            this.FindTextPanel.Controls.Add(this.FindTextLabel);
            resources.ApplyResources(this.FindTextPanel, "FindTextPanel");
            this.FindTextPanel.Name = "FindTextPanel";
            // 
            // FindTextBox
            // 
            resources.ApplyResources(this.FindTextBox, "FindTextBox");
            this.FindTextBox.Name = "FindTextBox";
            // 
            // FindTextLabel
            // 
            resources.ApplyResources(this.FindTextLabel, "FindTextLabel");
            this.FindTextLabel.Name = "FindTextLabel";
            // 
            // GoToLinePanel
            // 
            resources.ApplyResources(this.GoToLinePanel, "GoToLinePanel");
            this.GoToLinePanel.Controls.Add(this.GoToLineLabel);
            this.GoToLinePanel.Controls.Add(this.GoToLineBox);
            this.GoToLinePanel.Name = "GoToLinePanel";
            // 
            // GoToLineLabel
            // 
            resources.ApplyResources(this.GoToLineLabel, "GoToLineLabel");
            this.GoToLineLabel.Name = "GoToLineLabel";
            // 
            // GoToLineBox
            // 
            resources.ApplyResources(this.GoToLineBox, "GoToLineBox");
            this.GoToLineBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GoToLineBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GoToLineBox.Name = "GoToLineBox";
            this.GoToLineBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SplitContainer3
            // 
            resources.ApplyResources(this.SplitContainer3, "SplitContainer3");
            this.SplitContainer3.Name = "SplitContainer3";
            // 
            // SplitContainer3.Panel1
            // 
            this.SplitContainer3.Panel1.Controls.Add(this.MiscData);
            // 
            // MiscData
            // 
            this.MiscData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscData.ContextMenuStrip = this.FileListRightClick;
            resources.ApplyResources(this.MiscData, "MiscData");
            this.MiscData.FullRowSelect = true;
            this.MiscData.HideSelection = false;
            this.MiscData.Name = "MiscData";
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.RawfilesPage);
            this.Tabs.Controls.Add(this.LocalizedStringsPage);
            this.Tabs.Controls.Add(this.OtherPage);
            resources.ApplyResources(this.Tabs, "Tabs");
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            // 
            // RawfilesPage
            // 
            this.RawfilesPage.Controls.Add(this.SplitContainer1);
            resources.ApplyResources(this.RawfilesPage, "RawfilesPage");
            this.RawfilesPage.Name = "RawfilesPage";
            this.RawfilesPage.UseVisualStyleBackColor = true;
            // 
            // LocalizedStringsPage
            // 
            this.LocalizedStringsPage.Controls.Add(this.LocalizedStringsSplitContainer);
            resources.ApplyResources(this.LocalizedStringsPage, "LocalizedStringsPage");
            this.LocalizedStringsPage.Name = "LocalizedStringsPage";
            this.LocalizedStringsPage.UseVisualStyleBackColor = true;
            // 
            // LocalizedStringsSplitContainer
            // 
            resources.ApplyResources(this.LocalizedStringsSplitContainer, "LocalizedStringsSplitContainer");
            this.LocalizedStringsSplitContainer.Name = "LocalizedStringsSplitContainer";
            // 
            // LocalizedStringsSplitContainer.Panel1
            // 
            this.LocalizedStringsSplitContainer.Panel1.Controls.Add(this.LocalizedStringsTreeView);
            // 
            // LocalizedStringsSplitContainer.Panel2
            // 
            this.LocalizedStringsSplitContainer.Panel2.Controls.Add(this.LocalizedStringsWarningLabel);
            this.LocalizedStringsSplitContainer.Panel2.Controls.Add(this.LocalizedStringKeyGroup);
            // 
            // LocalizedStringsTreeView
            // 
            resources.ApplyResources(this.LocalizedStringsTreeView, "LocalizedStringsTreeView");
            this.LocalizedStringsTreeView.Name = "LocalizedStringsTreeView";
            // 
            // LocalizedStringKeyGroup
            // 
            resources.ApplyResources(this.LocalizedStringKeyGroup, "LocalizedStringKeyGroup");
            this.LocalizedStringKeyGroup.Controls.Add(this.LocalizedStringValueGroup);
            this.LocalizedStringKeyGroup.Controls.Add(this.LocalizedStringKeyTextBox);
            this.LocalizedStringKeyGroup.Controls.Add(this.panel1);
            this.LocalizedStringKeyGroup.Name = "LocalizedStringKeyGroup";
            this.LocalizedStringKeyGroup.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.LocalizedStringKeyOffsetValue);
            this.panel1.Controls.Add(this.LocalizedStringKeyOffsetLabel);
            this.panel1.Controls.Add(this.LocalizedStringKeySizeMaxValue);
            this.panel1.Controls.Add(this.LocalizedStringKeySizeDelimeter);
            this.panel1.Controls.Add(this.LocalizedStringKeySizeValue);
            this.panel1.Controls.Add(this.LocalizedStringKeySizeLabel);
            this.panel1.Name = "panel1";
            // 
            // LocalizedStringKeySizeLabel
            // 
            resources.ApplyResources(this.LocalizedStringKeySizeLabel, "LocalizedStringKeySizeLabel");
            this.LocalizedStringKeySizeLabel.Name = "LocalizedStringKeySizeLabel";
            // 
            // LocalizedStringKeyOffsetValue
            // 
            resources.ApplyResources(this.LocalizedStringKeyOffsetValue, "LocalizedStringKeyOffsetValue");
            this.LocalizedStringKeyOffsetValue.Name = "LocalizedStringKeyOffsetValue";
            // 
            // LocalizedStringKeySizeValue
            // 
            resources.ApplyResources(this.LocalizedStringKeySizeValue, "LocalizedStringKeySizeValue");
            this.LocalizedStringKeySizeValue.Name = "LocalizedStringKeySizeValue";
            // 
            // LocalizedStringKeyOffsetLabel
            // 
            resources.ApplyResources(this.LocalizedStringKeyOffsetLabel, "LocalizedStringKeyOffsetLabel");
            this.LocalizedStringKeyOffsetLabel.Name = "LocalizedStringKeyOffsetLabel";
            // 
            // LocalizedStringKeySizeDelimeter
            // 
            resources.ApplyResources(this.LocalizedStringKeySizeDelimeter, "LocalizedStringKeySizeDelimeter");
            this.LocalizedStringKeySizeDelimeter.Name = "LocalizedStringKeySizeDelimeter";
            // 
            // LocalizedStringKeySizeMaxValue
            // 
            resources.ApplyResources(this.LocalizedStringKeySizeMaxValue, "LocalizedStringKeySizeMaxValue");
            this.LocalizedStringKeySizeMaxValue.Name = "LocalizedStringKeySizeMaxValue";
            // 
            // LocalizedStringKeyTextBox
            // 
            resources.ApplyResources(this.LocalizedStringKeyTextBox, "LocalizedStringKeyTextBox");
            this.LocalizedStringKeyTextBox.Name = "LocalizedStringKeyTextBox";
            // 
            // OtherPage
            // 
            this.OtherPage.Controls.Add(this.SplitContainer3);
            resources.ApplyResources(this.OtherPage, "OtherPage");
            this.OtherPage.Name = "OtherPage";
            this.OtherPage.UseVisualStyleBackColor = true;
            // 
            // StatusStripLine
            // 
            this.StatusStripLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLogLabel,
            this.StatusBarLogValue,
            this.ToolStripStatusLabel5,
            this.Wait});
            resources.ApplyResources(this.StatusStripLine, "StatusStripLine");
            this.StatusStripLine.Name = "StatusStripLine";
            // 
            // StatusBarLogLabel
            // 
            this.StatusBarLogLabel.Name = "StatusBarLogLabel";
            resources.ApplyResources(this.StatusBarLogLabel, "StatusBarLogLabel");
            this.StatusBarLogLabel.Click += new System.EventHandler(this.StatusLogLabel_Click);
            // 
            // StatusBarLogValue
            // 
            this.StatusBarLogValue.Name = "StatusBarLogValue";
            resources.ApplyResources(this.StatusBarLogValue, "StatusBarLogValue");
            // 
            // ToolStripStatusLabel5
            // 
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            resources.ApplyResources(this.ToolStripStatusLabel5, "ToolStripStatusLabel5");
            this.ToolStripStatusLabel5.Spring = true;
            // 
            // Wait
            // 
            this.Wait.MarqueeAnimationSpeed = 1;
            this.Wait.Name = "Wait";
            resources.ApplyResources(this.Wait, "Wait");
            // 
            // MenuStripLine
            // 
            this.MenuStripLine.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuStripLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.Snippets});
            resources.ApplyResources(this.MenuStripLine, "MenuStripLine");
            this.MenuStripLine.Name = "MenuStripLine";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFFToolStripMenuItem,
            this.SaveFFToolStripMenuItem,
            this.CloseFFToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.ExportToolStripMenuItem,
            this.toolStripSeparator3,
            this.OptionsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            // 
            // OpenFFToolStripMenuItem
            // 
            this.OpenFFToolStripMenuItem.Name = "OpenFFToolStripMenuItem";
            resources.ApplyResources(this.OpenFFToolStripMenuItem, "OpenFFToolStripMenuItem");
            this.OpenFFToolStripMenuItem.Click += new System.EventHandler(this.OpenFFToolStripMenuItem_Click);
            // 
            // SaveFFToolStripMenuItem
            // 
            this.SaveFFToolStripMenuItem.Name = "SaveFFToolStripMenuItem";
            resources.ApplyResources(this.SaveFFToolStripMenuItem, "SaveFFToolStripMenuItem");
            this.SaveFFToolStripMenuItem.Click += new System.EventHandler(this.SaveFFToolStripMenuItem_Click);
            // 
            // CloseFFToolStripMenuItem
            // 
            this.CloseFFToolStripMenuItem.Name = "CloseFFToolStripMenuItem";
            resources.ApplyResources(this.CloseFFToolStripMenuItem, "CloseFFToolStripMenuItem");
            this.CloseFFToolStripMenuItem.Click += new System.EventHandler(this.CloseFFToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            resources.ApplyResources(this.ToolStripMenuItem1, "ToolStripMenuItem1");
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportZoneToolStripMenuItem});
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            resources.ApplyResources(this.ExportToolStripMenuItem, "ExportToolStripMenuItem");
            // 
            // ExportZoneToolStripMenuItem
            // 
            this.ExportZoneToolStripMenuItem.Name = "ExportZoneToolStripMenuItem";
            resources.ApplyResources(this.ExportZoneToolStripMenuItem, "ExportZoneToolStripMenuItem");
            this.ExportZoneToolStripMenuItem.Click += new System.EventHandler(this.ExportZoneToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            resources.ApplyResources(this.OptionsToolStripMenuItem, "OptionsToolStripMenuItem");
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckSyntaxToolStripMenuItem,
            this.RemoveCommentsToolStripMenuItem,
            this.FillFileToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.ZlibStripMenuItem,
            this.FastfileToolStripMenuItem,
            this.CoD4ToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            resources.ApplyResources(this.ToolsToolStripMenuItem, "ToolsToolStripMenuItem");
            // 
            // CheckSyntaxToolStripMenuItem
            // 
            resources.ApplyResources(this.CheckSyntaxToolStripMenuItem, "CheckSyntaxToolStripMenuItem");
            this.CheckSyntaxToolStripMenuItem.Name = "CheckSyntaxToolStripMenuItem";
            this.CheckSyntaxToolStripMenuItem.Click += new System.EventHandler(this.SyntaxCheckerToolStripMenuItem_Click);
            // 
            // RemoveCommentsToolStripMenuItem
            // 
            this.RemoveCommentsToolStripMenuItem.Name = "RemoveCommentsToolStripMenuItem";
            resources.ApplyResources(this.RemoveCommentsToolStripMenuItem, "RemoveCommentsToolStripMenuItem");
            this.RemoveCommentsToolStripMenuItem.Click += new System.EventHandler(this.RemoveCommentsToolStripMenuItem_Click);
            // 
            // FillFileToolStripMenuItem
            // 
            this.FillFileToolStripMenuItem.Name = "FillFileToolStripMenuItem";
            resources.ApplyResources(this.FillFileToolStripMenuItem, "FillFileToolStripMenuItem");
            this.FillFileToolStripMenuItem.Click += new System.EventHandler(this.PadFileToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            resources.ApplyResources(this.ToolStripMenuItem5, "ToolStripMenuItem5");
            // 
            // ZlibStripMenuItem
            // 
            this.ZlibStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZlibCompressToolStripMenuItem,
            this.ZlibDecompressToolStripMenuItem});
            resources.ApplyResources(this.ZlibStripMenuItem, "ZlibStripMenuItem");
            this.ZlibStripMenuItem.Name = "ZlibStripMenuItem";
            // 
            // ZlibCompressToolStripMenuItem
            // 
            this.ZlibCompressToolStripMenuItem.Name = "ZlibCompressToolStripMenuItem";
            resources.ApplyResources(this.ZlibCompressToolStripMenuItem, "ZlibCompressToolStripMenuItem");
            this.ZlibCompressToolStripMenuItem.Click += new System.EventHandler(this.ZlibCompressToolStripMenuItem_Click);
            // 
            // ZlibDecompressToolStripMenuItem
            // 
            this.ZlibDecompressToolStripMenuItem.Name = "ZlibDecompressToolStripMenuItem";
            resources.ApplyResources(this.ZlibDecompressToolStripMenuItem, "ZlibDecompressToolStripMenuItem");
            this.ZlibDecompressToolStripMenuItem.Click += new System.EventHandler(this.ZlibDecompressToolStripMenuItem_Click);
            // 
            // FastfileToolStripMenuItem
            // 
            this.FastfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveExtractedZoneToolStripMenuItem,
            this.OpenExtractedZoneToolStripMenuItem});
            resources.ApplyResources(this.FastfileToolStripMenuItem, "FastfileToolStripMenuItem");
            this.FastfileToolStripMenuItem.Name = "FastfileToolStripMenuItem";
            // 
            // SaveExtractedZoneToolStripMenuItem
            // 
            this.SaveExtractedZoneToolStripMenuItem.Name = "SaveExtractedZoneToolStripMenuItem";
            resources.ApplyResources(this.SaveExtractedZoneToolStripMenuItem, "SaveExtractedZoneToolStripMenuItem");
            this.SaveExtractedZoneToolStripMenuItem.Click += new System.EventHandler(this.SaveExtractedZoneToolStripMenuItem_Click);
            // 
            // OpenExtractedZoneToolStripMenuItem
            // 
            this.OpenExtractedZoneToolStripMenuItem.Name = "OpenExtractedZoneToolStripMenuItem";
            resources.ApplyResources(this.OpenExtractedZoneToolStripMenuItem, "OpenExtractedZoneToolStripMenuItem");
            this.OpenExtractedZoneToolStripMenuItem.Click += new System.EventHandler(this.OpenExtractedZoneToolStripMenuItem_Click);
            // 
            // CoD4ToolStripMenuItem
            // 
            this.CoD4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExtractZoneToolStripMenuItem,
            this.SaveAsFastfileToolStripMenuItem});
            this.CoD4ToolStripMenuItem.Name = "CoD4ToolStripMenuItem";
            resources.ApplyResources(this.CoD4ToolStripMenuItem, "CoD4ToolStripMenuItem");
            // 
            // ExtractZoneToolStripMenuItem
            // 
            resources.ApplyResources(this.ExtractZoneToolStripMenuItem, "ExtractZoneToolStripMenuItem");
            this.ExtractZoneToolStripMenuItem.Name = "ExtractZoneToolStripMenuItem";
            // 
            // SaveAsFastfileToolStripMenuItem
            // 
            this.SaveAsFastfileToolStripMenuItem.Name = "SaveAsFastfileToolStripMenuItem";
            resources.ApplyResources(this.SaveAsFastfileToolStripMenuItem, "SaveAsFastfileToolStripMenuItem");
            this.SaveAsFastfileToolStripMenuItem.Click += new System.EventHandler(this.SaveAsFastfileToolStripMenuItem_Click_1);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Snippets
            // 
            this.Snippets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionsToolStripMenuItem,
            this.UpdateSnippetsToolStripMenuItem,
            this.ToolStripMenuItem6});
            this.Snippets.Name = "Snippets";
            resources.ApplyResources(this.Snippets, "Snippets");
            // 
            // InstructionsToolStripMenuItem
            // 
            this.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem";
            resources.ApplyResources(this.InstructionsToolStripMenuItem, "InstructionsToolStripMenuItem");
            this.InstructionsToolStripMenuItem.Click += new System.EventHandler(this.InstructionsToolStripMenuItem_Click);
            // 
            // UpdateSnippetsToolStripMenuItem
            // 
            this.UpdateSnippetsToolStripMenuItem.Name = "UpdateSnippetsToolStripMenuItem";
            resources.ApplyResources(this.UpdateSnippetsToolStripMenuItem, "UpdateSnippetsToolStripMenuItem");
            this.UpdateSnippetsToolStripMenuItem.Click += new System.EventHandler(this.UpdateSnippetsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            resources.ApplyResources(this.ToolStripMenuItem6, "ToolStripMenuItem6");
            // 
            // OpenFFDialog
            // 
            this.OpenFFDialog.DefaultExt = "ff";
            resources.ApplyResources(this.OpenFFDialog, "OpenFFDialog");
            // 
            // ExtractDialog
            // 
            resources.ApplyResources(this.ExtractDialog, "ExtractDialog");
            // 
            // FolderBrowserDialog
            // 
            resources.ApplyResources(this.FolderBrowserDialog, "FolderBrowserDialog");
            // 
            // LogGroup
            // 
            this.LogGroup.Controls.Add(this.LogTextBox);
            resources.ApplyResources(this.LogGroup, "LogGroup");
            this.LogGroup.Name = "LogGroup";
            this.LogGroup.TabStop = false;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LogTextBox, "LogTextBox");
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            // 
            // ExportZoneDialog
            // 
            resources.ApplyResources(this.ExportZoneDialog, "ExportZoneDialog");
            // 
            // SaveFastfileDialog
            // 
            resources.ApplyResources(this.SaveFastfileDialog, "SaveFastfileDialog");
            // 
            // OpenZoneDialog
            // 
            this.OpenZoneDialog.DefaultExt = "ff";
            resources.ApplyResources(this.OpenZoneDialog, "OpenZoneDialog");
            // 
            // LocalizedStringValueGroup
            // 
            resources.ApplyResources(this.LocalizedStringValueGroup, "LocalizedStringValueGroup");
            this.LocalizedStringValueGroup.Controls.Add(this.LocalizedStringValueTextBox);
            this.LocalizedStringValueGroup.Controls.Add(this.panel2);
            this.LocalizedStringValueGroup.Name = "LocalizedStringValueGroup";
            this.LocalizedStringValueGroup.TabStop = false;
            // 
            // LocalizedStringValueTextBox
            // 
            resources.ApplyResources(this.LocalizedStringValueTextBox, "LocalizedStringValueTextBox");
            this.LocalizedStringValueTextBox.Name = "LocalizedStringValueTextBox";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.LocalizedStringValueOffsetVal);
            this.panel2.Controls.Add(this.LocalizedStringValueOffsetLabel);
            this.panel2.Controls.Add(this.LocalizedStringValueSizeMaxVal);
            this.panel2.Controls.Add(this.LocalizedStringValueSizeDelimeter);
            this.panel2.Controls.Add(this.LocalizedStringValueSizeVal);
            this.panel2.Controls.Add(this.LocalizedStringValueSizeLabel);
            this.panel2.Name = "panel2";
            // 
            // LocalizedStringValueOffsetVal
            // 
            resources.ApplyResources(this.LocalizedStringValueOffsetVal, "LocalizedStringValueOffsetVal");
            this.LocalizedStringValueOffsetVal.Name = "LocalizedStringValueOffsetVal";
            // 
            // LocalizedStringValueOffsetLabel
            // 
            resources.ApplyResources(this.LocalizedStringValueOffsetLabel, "LocalizedStringValueOffsetLabel");
            this.LocalizedStringValueOffsetLabel.Name = "LocalizedStringValueOffsetLabel";
            // 
            // LocalizedStringValueSizeMaxVal
            // 
            resources.ApplyResources(this.LocalizedStringValueSizeMaxVal, "LocalizedStringValueSizeMaxVal");
            this.LocalizedStringValueSizeMaxVal.Name = "LocalizedStringValueSizeMaxVal";
            // 
            // LocalizedStringValueSizeDelimeter
            // 
            resources.ApplyResources(this.LocalizedStringValueSizeDelimeter, "LocalizedStringValueSizeDelimeter");
            this.LocalizedStringValueSizeDelimeter.Name = "LocalizedStringValueSizeDelimeter";
            // 
            // LocalizedStringValueSizeVal
            // 
            resources.ApplyResources(this.LocalizedStringValueSizeVal, "LocalizedStringValueSizeVal");
            this.LocalizedStringValueSizeVal.Name = "LocalizedStringValueSizeVal";
            // 
            // LocalizedStringValueSizeLabel
            // 
            resources.ApplyResources(this.LocalizedStringValueSizeLabel, "LocalizedStringValueSizeLabel");
            this.LocalizedStringValueSizeLabel.Name = "LocalizedStringValueSizeLabel";
            // 
            // LocalizedStringsWarningLabel
            // 
            resources.ApplyResources(this.LocalizedStringsWarningLabel, "LocalizedStringsWarningLabel");
            this.LocalizedStringsWarningLabel.Name = "LocalizedStringsWarningLabel";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.MenuStripLine);
            this.Controls.Add(this.LogGroup);
            this.Controls.Add(this.StatusStripLine);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStripLine;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.FileListRightClick.ResumeLayout(false);
            this.CodeBoxRightClick.ResumeLayout(false);
            this.RawfileInfoPanel.ResumeLayout(false);
            this.RawfileInfoPanel.PerformLayout();
            this.SearchBoxAndGoToPanel.ResumeLayout(false);
            this.SearchBoxAndGoToPanel.PerformLayout();
            this.FindTextPanel.ResumeLayout(false);
            this.FindTextPanel.PerformLayout();
            this.GoToLinePanel.ResumeLayout(false);
            this.GoToLinePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GoToLineBox)).EndInit();
            this.SplitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).EndInit();
            this.SplitContainer3.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.RawfilesPage.ResumeLayout(false);
            this.LocalizedStringsPage.ResumeLayout(false);
            this.LocalizedStringsSplitContainer.Panel1.ResumeLayout(false);
            this.LocalizedStringsSplitContainer.Panel2.ResumeLayout(false);
            this.LocalizedStringsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocalizedStringsSplitContainer)).EndInit();
            this.LocalizedStringsSplitContainer.ResumeLayout(false);
            this.LocalizedStringKeyGroup.ResumeLayout(false);
            this.LocalizedStringKeyGroup.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.OtherPage.ResumeLayout(false);
            this.StatusStripLine.ResumeLayout(false);
            this.StatusStripLine.PerformLayout();
            this.MenuStripLine.ResumeLayout(false);
            this.MenuStripLine.PerformLayout();
            this.LogGroup.ResumeLayout(false);
            this.LogGroup.PerformLayout();
            this.LocalizedStringValueGroup.ResumeLayout(false);
            this.LocalizedStringValueGroup.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage RawfilesPage;
        private System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.TreeView RawFiles;
        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.TabPage OtherPage;
        private System.Windows.Forms.SplitContainer SplitContainer3;
        private System.Windows.Forms.TreeView MiscData;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel5;
        private System.Windows.Forms.ContextMenuStrip FileListRightClick;
        private System.Windows.Forms.ToolStripMenuItem ExportFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtractAllGSCsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditSelectionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip CodeBoxRightClick;
        private System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FindNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.NumericUpDown GoToLineBox;
        private System.Windows.Forms.ToolStripProgressBar Wait;
        private System.Windows.Forms.Panel SearchBoxAndGoToPanel;
        private System.Windows.Forms.Panel FindTextPanel;
        private System.Windows.Forms.Label FindTextLabel;
        private System.Windows.Forms.Panel GoToLinePanel;
        private System.Windows.Forms.Label GoToLineLabel;
        private System.Windows.Forms.Panel RawfileInfoPanel;
        private System.Windows.Forms.Label RawfileInfoFileName;
        private System.Windows.Forms.Label RawfileInfoFileLabel;
        private System.Windows.Forms.Label RawfileInfoSizeOriginal;
        private System.Windows.Forms.Label RawfileInfoSizeSeparator;
        private System.Windows.Forms.Label RawfileInfoSize;
        private System.Windows.Forms.Label RawfileInfoSizeLabel;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckSyntaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ZlibStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZlibCompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZlibDecompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Snippets;
        private System.Windows.Forms.ToolStripMenuItem InstructionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateSnippetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripMenuItem6;
        private System.Windows.Forms.OpenFileDialog OpenFFDialog;
        private System.Windows.Forms.SaveFileDialog ExtractDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLogLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLogValue;
        private System.Windows.Forms.MenuStrip MenuStripLine;
        private System.Windows.Forms.StatusStrip StatusStripLine;
        private System.Windows.Forms.GroupBox LogGroup;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.ToolStripMenuItem FastfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveExtractedZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenExtractedZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog ExportZoneDialog;
        private System.Windows.Forms.ToolStripMenuItem CoD4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtractZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsFastfileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFastfileDialog;
        private System.Windows.Forms.OpenFileDialog OpenZoneDialog;
        private System.Windows.Forms.TabPage LocalizedStringsPage;
        private System.Windows.Forms.SplitContainer LocalizedStringsSplitContainer;
        private System.Windows.Forms.TreeView LocalizedStringsTreeView;
        private System.Windows.Forms.GroupBox LocalizedStringKeyGroup;
        private System.Windows.Forms.Label LocalizedStringKeyOffsetValue;
        private System.Windows.Forms.Label LocalizedStringKeyOffsetLabel;
        private System.Windows.Forms.Label LocalizedStringKeySizeMaxValue;
        private System.Windows.Forms.Label LocalizedStringKeySizeDelimeter;
        private System.Windows.Forms.Label LocalizedStringKeySizeValue;
        private System.Windows.Forms.Label LocalizedStringKeySizeLabel;
        private System.Windows.Forms.TextBox LocalizedStringKeyTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox LocalizedStringValueGroup;
        private System.Windows.Forms.TextBox LocalizedStringValueTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LocalizedStringValueOffsetVal;
        private System.Windows.Forms.Label LocalizedStringValueOffsetLabel;
        private System.Windows.Forms.Label LocalizedStringValueSizeMaxVal;
        private System.Windows.Forms.Label LocalizedStringValueSizeDelimeter;
        private System.Windows.Forms.Label LocalizedStringValueSizeVal;
        private System.Windows.Forms.Label LocalizedStringValueSizeLabel;
        private System.Windows.Forms.Label LocalizedStringsWarningLabel;
    }
}

