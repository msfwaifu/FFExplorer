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
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Wait = new System.Windows.Forms.ToolStripProgressBar();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SyntaxCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.zlibToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZlibCompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZlibDecompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Snippets = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateSnippetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuStripPanel = new System.Windows.Forms.Panel();
            this.OpenFFDialog = new System.Windows.Forms.OpenFileDialog();
            this.ExtractDialog = new System.Windows.Forms.SaveFileDialog();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.TabPage1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.MenuStripPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            resources.ApplyResources(this.SplitContainer1, "SplitContainer1");
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            resources.ApplyResources(this.SplitContainer1.Panel1, "SplitContainer1.Panel1");
            this.SplitContainer1.Panel1.Controls.Add(this.RawFiles);
            // 
            // SplitContainer1.Panel2
            // 
            resources.ApplyResources(this.SplitContainer1.Panel2, "SplitContainer1.Panel2");
            this.SplitContainer1.Panel2.Controls.Add(this.CodeBox);
            this.SplitContainer1.Panel2.Controls.Add(this.RawfileInfoPanel);
            this.SplitContainer1.Panel2.Controls.Add(this.SearchBoxAndGoToPanel);
            // 
            // RawFiles
            // 
            resources.ApplyResources(this.RawFiles, "RawFiles");
            this.RawFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RawFiles.ContextMenuStrip = this.FileListRightClick;
            this.RawFiles.FullRowSelect = true;
            this.RawFiles.HideSelection = false;
            this.RawFiles.Name = "RawFiles";
            this.RawFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RawFiles_AfterSelect);
            this.RawFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RawFiles_NodeMouseClick);
            // 
            // FileListRightClick
            // 
            resources.ApplyResources(this.FileListRightClick, "FileListRightClick");
            this.FileListRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportFileToolStripMenuItem,
            this.EditSelectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExtractAllGSCsToolStripMenuItem});
            this.FileListRightClick.Name = "FileListRightClick";
            // 
            // ExportFileToolStripMenuItem
            // 
            resources.ApplyResources(this.ExportFileToolStripMenuItem, "ExportFileToolStripMenuItem");
            this.ExportFileToolStripMenuItem.Name = "ExportFileToolStripMenuItem";
            this.ExportFileToolStripMenuItem.Click += new System.EventHandler(this.ExportFileToolStripMenuItem_Click);
            // 
            // EditSelectionToolStripMenuItem
            // 
            resources.ApplyResources(this.EditSelectionToolStripMenuItem, "EditSelectionToolStripMenuItem");
            this.EditSelectionToolStripMenuItem.Name = "EditSelectionToolStripMenuItem";
            this.EditSelectionToolStripMenuItem.Click += new System.EventHandler(this.EditSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // ExtractAllGSCsToolStripMenuItem
            // 
            resources.ApplyResources(this.ExtractAllGSCsToolStripMenuItem, "ExtractAllGSCsToolStripMenuItem");
            this.ExtractAllGSCsToolStripMenuItem.Name = "ExtractAllGSCsToolStripMenuItem";
            this.ExtractAllGSCsToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllGSCsToolStripMenuItem_Click);
            // 
            // CodeBox
            // 
            this.CodeBox.AcceptsTab = true;
            resources.ApplyResources(this.CodeBox, "CodeBox");
            this.CodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeBox.ContextMenuStrip = this.CodeBoxRightClick;
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Click += new System.EventHandler(this.CodeBox_Click);
            this.CodeBox.TextChanged += new System.EventHandler(this.CodeBox_TextChanged);
            this.CodeBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CodeBox_KeyUp);
            // 
            // CodeBoxRightClick
            // 
            resources.ApplyResources(this.CodeBoxRightClick, "CodeBoxRightClick");
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
            // 
            // CutToolStripMenuItem
            // 
            resources.ApplyResources(this.CutToolStripMenuItem, "CutToolStripMenuItem");
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            resources.ApplyResources(this.CopyToolStripMenuItem, "CopyToolStripMenuItem");
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            resources.ApplyResources(this.PasteToolStripMenuItem, "PasteToolStripMenuItem");
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // FindToolStripMenuItem
            // 
            resources.ApplyResources(this.FindToolStripMenuItem, "FindToolStripMenuItem");
            this.FindToolStripMenuItem.Name = "FindToolStripMenuItem";
            this.FindToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // FindNextToolStripMenuItem
            // 
            resources.ApplyResources(this.FindNextToolStripMenuItem, "FindNextToolStripMenuItem");
            this.FindNextToolStripMenuItem.Name = "FindNextToolStripMenuItem";
            this.FindNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextToolStripMenuItem_Click);
            // 
            // GotoToolStripMenuItem
            // 
            resources.ApplyResources(this.GotoToolStripMenuItem, "GotoToolStripMenuItem");
            this.GotoToolStripMenuItem.Name = "GotoToolStripMenuItem";
            this.GotoToolStripMenuItem.Click += new System.EventHandler(this.GotoToolStripMenuItem_Click);
            // 
            // SelectAllToolStripMenuItem
            // 
            resources.ApplyResources(this.SelectAllToolStripMenuItem, "SelectAllToolStripMenuItem");
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // RawfileInfoPanel
            // 
            resources.ApplyResources(this.RawfileInfoPanel, "RawfileInfoPanel");
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoFileName);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoFileLabel);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSizeOriginal);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSizeSeparator);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSize);
            this.RawfileInfoPanel.Controls.Add(this.RawfileInfoSizeLabel);
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
            resources.ApplyResources(this.SearchBoxAndGoToPanel, "SearchBoxAndGoToPanel");
            this.SearchBoxAndGoToPanel.Controls.Add(this.FindTextPanel);
            this.SearchBoxAndGoToPanel.Controls.Add(this.GoToLinePanel);
            this.SearchBoxAndGoToPanel.Name = "SearchBoxAndGoToPanel";
            // 
            // FindTextPanel
            // 
            resources.ApplyResources(this.FindTextPanel, "FindTextPanel");
            this.FindTextPanel.Controls.Add(this.FindTextBox);
            this.FindTextPanel.Controls.Add(this.FindTextLabel);
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
            resources.ApplyResources(this.SplitContainer3.Panel1, "SplitContainer3.Panel1");
            this.SplitContainer3.Panel1.Controls.Add(this.MiscData);
            // 
            // SplitContainer3.Panel2
            // 
            resources.ApplyResources(this.SplitContainer3.Panel2, "SplitContainer3.Panel2");
            // 
            // MiscData
            // 
            resources.ApplyResources(this.MiscData, "MiscData");
            this.MiscData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscData.ContextMenuStrip = this.FileListRightClick;
            this.MiscData.FullRowSelect = true;
            this.MiscData.HideSelection = false;
            this.MiscData.Name = "MiscData";
            // 
            // Tabs
            // 
            resources.ApplyResources(this.Tabs, "Tabs");
            this.Tabs.Controls.Add(this.TabPage1);
            this.Tabs.Controls.Add(this.TabPage3);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            // 
            // TabPage1
            // 
            resources.ApplyResources(this.TabPage1, "TabPage1");
            this.TabPage1.Controls.Add(this.SplitContainer1);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // TabPage3
            // 
            resources.ApplyResources(this.TabPage3, "TabPage3");
            this.TabPage3.Controls.Add(this.SplitContainer3);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // StatusStrip1
            // 
            resources.ApplyResources(this.StatusStrip1, "StatusStrip1");
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel5,
            this.Wait});
            this.StatusStrip1.Name = "StatusStrip1";
            // 
            // ToolStripStatusLabel5
            // 
            resources.ApplyResources(this.ToolStripStatusLabel5, "ToolStripStatusLabel5");
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            this.ToolStripStatusLabel5.Spring = true;
            // 
            // Wait
            // 
            resources.ApplyResources(this.Wait, "Wait");
            this.Wait.MarqueeAnimationSpeed = 1;
            this.Wait.Name = "Wait";
            // 
            // MenuStrip
            // 
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.Snippets});
            this.MenuStrip.Name = "MenuStrip";
            // 
            // FileToolStripMenuItem
            // 
            resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFFToolStripMenuItem,
            this.SaveFFToolStripMenuItem,
            this.CloseFFToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.OptionsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            // 
            // OpenFFToolStripMenuItem
            // 
            resources.ApplyResources(this.OpenFFToolStripMenuItem, "OpenFFToolStripMenuItem");
            this.OpenFFToolStripMenuItem.Name = "OpenFFToolStripMenuItem";
            this.OpenFFToolStripMenuItem.Click += new System.EventHandler(this.OpenFFToolStripMenuItem_Click);
            // 
            // SaveFFToolStripMenuItem
            // 
            resources.ApplyResources(this.SaveFFToolStripMenuItem, "SaveFFToolStripMenuItem");
            this.SaveFFToolStripMenuItem.Name = "SaveFFToolStripMenuItem";
            this.SaveFFToolStripMenuItem.Click += new System.EventHandler(this.SaveFFToolStripMenuItem_Click);
            // 
            // CloseFFToolStripMenuItem
            // 
            resources.ApplyResources(this.CloseFFToolStripMenuItem, "CloseFFToolStripMenuItem");
            this.CloseFFToolStripMenuItem.Name = "CloseFFToolStripMenuItem";
            this.CloseFFToolStripMenuItem.Click += new System.EventHandler(this.CloseFFToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            resources.ApplyResources(this.ToolStripMenuItem1, "ToolStripMenuItem1");
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            // 
            // OptionsToolStripMenuItem
            // 
            resources.ApplyResources(this.OptionsToolStripMenuItem, "OptionsToolStripMenuItem");
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            resources.ApplyResources(this.ToolsToolStripMenuItem, "ToolsToolStripMenuItem");
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyntaxCheckerToolStripMenuItem,
            this.RemoveCommentsToolStripMenuItem,
            this.PadFileToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.zlibToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            // 
            // SyntaxCheckerToolStripMenuItem
            // 
            resources.ApplyResources(this.SyntaxCheckerToolStripMenuItem, "SyntaxCheckerToolStripMenuItem");
            this.SyntaxCheckerToolStripMenuItem.Name = "SyntaxCheckerToolStripMenuItem";
            this.SyntaxCheckerToolStripMenuItem.Click += new System.EventHandler(this.SyntaxCheckerToolStripMenuItem_Click);
            // 
            // RemoveCommentsToolStripMenuItem
            // 
            resources.ApplyResources(this.RemoveCommentsToolStripMenuItem, "RemoveCommentsToolStripMenuItem");
            this.RemoveCommentsToolStripMenuItem.Name = "RemoveCommentsToolStripMenuItem";
            this.RemoveCommentsToolStripMenuItem.Click += new System.EventHandler(this.RemoveCommentsToolStripMenuItem_Click);
            // 
            // PadFileToolStripMenuItem
            // 
            resources.ApplyResources(this.PadFileToolStripMenuItem, "PadFileToolStripMenuItem");
            this.PadFileToolStripMenuItem.Name = "PadFileToolStripMenuItem";
            this.PadFileToolStripMenuItem.Click += new System.EventHandler(this.PadFileToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem5
            // 
            resources.ApplyResources(this.ToolStripMenuItem5, "ToolStripMenuItem5");
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            // 
            // zlibToolStripMenuItem
            // 
            resources.ApplyResources(this.zlibToolStripMenuItem, "zlibToolStripMenuItem");
            this.zlibToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZlibCompressToolStripMenuItem,
            this.ZlibDecompressToolStripMenuItem});
            this.zlibToolStripMenuItem.Name = "zlibToolStripMenuItem";
            // 
            // ZlibCompressToolStripMenuItem
            // 
            resources.ApplyResources(this.ZlibCompressToolStripMenuItem, "ZlibCompressToolStripMenuItem");
            this.ZlibCompressToolStripMenuItem.Name = "ZlibCompressToolStripMenuItem";
            this.ZlibCompressToolStripMenuItem.Click += new System.EventHandler(this.ZlibCompressToolStripMenuItem_Click);
            // 
            // ZlibDecompressToolStripMenuItem
            // 
            resources.ApplyResources(this.ZlibDecompressToolStripMenuItem, "ZlibDecompressToolStripMenuItem");
            this.ZlibDecompressToolStripMenuItem.Name = "ZlibDecompressToolStripMenuItem";
            this.ZlibDecompressToolStripMenuItem.Click += new System.EventHandler(this.ZlibDecompressToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Snippets
            // 
            resources.ApplyResources(this.Snippets, "Snippets");
            this.Snippets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionsToolStripMenuItem,
            this.UpdateSnippetsToolStripMenuItem,
            this.ToolStripMenuItem6});
            this.Snippets.Name = "Snippets";
            // 
            // InstructionsToolStripMenuItem
            // 
            resources.ApplyResources(this.InstructionsToolStripMenuItem, "InstructionsToolStripMenuItem");
            this.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem";
            this.InstructionsToolStripMenuItem.Click += new System.EventHandler(this.InstructionsToolStripMenuItem_Click);
            // 
            // UpdateSnippetsToolStripMenuItem
            // 
            resources.ApplyResources(this.UpdateSnippetsToolStripMenuItem, "UpdateSnippetsToolStripMenuItem");
            this.UpdateSnippetsToolStripMenuItem.Name = "UpdateSnippetsToolStripMenuItem";
            this.UpdateSnippetsToolStripMenuItem.Click += new System.EventHandler(this.UpdateSnippetsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem6
            // 
            resources.ApplyResources(this.ToolStripMenuItem6, "ToolStripMenuItem6");
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            // 
            // MenuStripPanel
            // 
            resources.ApplyResources(this.MenuStripPanel, "MenuStripPanel");
            this.MenuStripPanel.Controls.Add(this.MenuStrip);
            this.MenuStripPanel.Name = "MenuStripPanel";
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
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MenuStripPanel);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.Tabs);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
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
            this.TabPage1.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.MenuStripPanel.ResumeLayout(false);
            this.MenuStripPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TabControl Tabs;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.TreeView RawFiles;
        internal System.Windows.Forms.TextBox CodeBox;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.SplitContainer SplitContainer3;
        internal System.Windows.Forms.TreeView MiscData;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel5;
        internal System.Windows.Forms.ContextMenuStrip FileListRightClick;
        internal System.Windows.Forms.ToolStripMenuItem ExportFileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExtractAllGSCsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditSelectionToolStripMenuItem;
        internal System.Windows.Forms.ContextMenuStrip CodeBoxRightClick;
        internal System.Windows.Forms.ToolStripMenuItem CutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FindToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FindNextToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem GotoToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
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
        internal System.Windows.Forms.MenuStrip MenuStrip;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenFFToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SaveFFToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CloseFFToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SyntaxCheckerToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RemoveCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PadFileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem zlibToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZlibCompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZlibDecompressToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem Snippets;
        internal System.Windows.Forms.ToolStripMenuItem InstructionsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem UpdateSnippetsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem6;
        private System.Windows.Forms.Panel MenuStripPanel;
        private System.Windows.Forms.OpenFileDialog OpenFFDialog;
        private System.Windows.Forms.SaveFileDialog ExtractDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    }
}

