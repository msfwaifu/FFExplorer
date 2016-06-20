namespace FFViewer_cs
{
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RawFiles = new System.Windows.Forms.TreeView();
            this.FileListRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExtractAllGSCsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindTextPanel = new System.Windows.Forms.TextBox();
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
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MiscData = new System.Windows.Forms.TreeView();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.OldSizeLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.NewSizeLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenRawFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LnLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.ColLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.Wait = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MenuStrip.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.FileListRightClick.SuspendLayout();
            this.CodeBoxRightClick.SuspendLayout();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).BeginInit();
            this.SplitContainer3.Panel1.SuspendLayout();
            this.SplitContainer3.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.Snippets});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.MaximumSize = new System.Drawing.Size(0, 24);
            this.MenuStrip.MinimumSize = new System.Drawing.Size(374, 24);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(374, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFFToolStripMenuItem,
            this.SaveFFToolStripMenuItem,
            this.CloseFFToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.OptionsToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenFFToolStripMenuItem
            // 
            this.OpenFFToolStripMenuItem.Name = "OpenFFToolStripMenuItem";
            this.OpenFFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.OpenFFToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.OpenFFToolStripMenuItem.Text = "Открыть Fastfile";
            this.OpenFFToolStripMenuItem.Click += new System.EventHandler(this.OpenFFToolStripMenuItem_Click);
            // 
            // SaveFFToolStripMenuItem
            // 
            this.SaveFFToolStripMenuItem.Name = "SaveFFToolStripMenuItem";
            this.SaveFFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.SaveFFToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.SaveFFToolStripMenuItem.Text = "Сохранить Fastfile";
            this.SaveFFToolStripMenuItem.Click += new System.EventHandler(this.SaveFFToolStripMenuItem_Click);
            // 
            // CloseFFToolStripMenuItem
            // 
            this.CloseFFToolStripMenuItem.Name = "CloseFFToolStripMenuItem";
            this.CloseFFToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Q";
            this.CloseFFToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.CloseFFToolStripMenuItem.Text = "Закрыть Fastfile";
            this.CloseFFToolStripMenuItem.Click += new System.EventHandler(this.CloseFFToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+T";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.OptionsToolStripMenuItem.Text = "Настройки";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SyntaxCheckerToolStripMenuItem,
            this.RemoveCommentsToolStripMenuItem,
            this.PadFileToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.zlibToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ToolsToolStripMenuItem.Text = "Утилиты";
            // 
            // SyntaxCheckerToolStripMenuItem
            // 
            this.SyntaxCheckerToolStripMenuItem.Name = "SyntaxCheckerToolStripMenuItem";
            this.SyntaxCheckerToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.SyntaxCheckerToolStripMenuItem.Text = "Проверка синтаксиса";
            this.SyntaxCheckerToolStripMenuItem.Click += new System.EventHandler(this.SyntaxCheckerToolStripMenuItem_Click);
            // 
            // RemoveCommentsToolStripMenuItem
            // 
            this.RemoveCommentsToolStripMenuItem.Name = "RemoveCommentsToolStripMenuItem";
            this.RemoveCommentsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.RemoveCommentsToolStripMenuItem.Text = "Удалить комментарии";
            this.RemoveCommentsToolStripMenuItem.Click += new System.EventHandler(this.RemoveCommentsToolStripMenuItem_Click);
            // 
            // PadFileToolStripMenuItem
            // 
            this.PadFileToolStripMenuItem.Name = "PadFileToolStripMenuItem";
            this.PadFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.PadFileToolStripMenuItem.Text = "Заполнить файл";
            this.PadFileToolStripMenuItem.Click += new System.EventHandler(this.PadFileToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(194, 6);
            // 
            // zlibToolStripMenuItem
            // 
            this.zlibToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZlibCompressToolStripMenuItem,
            this.ZlibDecompressToolStripMenuItem});
            this.zlibToolStripMenuItem.Name = "zlibToolStripMenuItem";
            this.zlibToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.zlibToolStripMenuItem.Text = "Zlib";
            // 
            // ZlibCompressToolStripMenuItem
            // 
            this.ZlibCompressToolStripMenuItem.Name = "ZlibCompressToolStripMenuItem";
            this.ZlibCompressToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ZlibCompressToolStripMenuItem.Text = "Упаковать";
            this.ZlibCompressToolStripMenuItem.Click += new System.EventHandler(this.ZlibCompressToolStripMenuItem_Click);
            // 
            // ZlibDecompressToolStripMenuItem
            // 
            this.ZlibDecompressToolStripMenuItem.Name = "ZlibDecompressToolStripMenuItem";
            this.ZlibDecompressToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.ZlibDecompressToolStripMenuItem.Text = "Распаковать";
            this.ZlibDecompressToolStripMenuItem.Click += new System.EventHandler(this.ZlibDecompressToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Snippets
            // 
            this.Snippets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InstructionsToolStripMenuItem,
            this.UpdateSnippetsToolStripMenuItem,
            this.ToolStripMenuItem6});
            this.Snippets.Name = "Snippets";
            this.Snippets.Size = new System.Drawing.Size(154, 20);
            this.Snippets.Text = "Вставить отрывок кода...";
            // 
            // InstructionsToolStripMenuItem
            // 
            this.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem";
            this.InstructionsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.InstructionsToolStripMenuItem.Text = "Инструкция";
            this.InstructionsToolStripMenuItem.Click += new System.EventHandler(this.InstructionsToolStripMenuItem_Click);
            // 
            // UpdateSnippetsToolStripMenuItem
            // 
            this.UpdateSnippetsToolStripMenuItem.Name = "UpdateSnippetsToolStripMenuItem";
            this.UpdateSnippetsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.UpdateSnippetsToolStripMenuItem.Text = "Обновить список";
            this.UpdateSnippetsToolStripMenuItem.Click += new System.EventHandler(this.UpdateSnippetsToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(167, 6);
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.TabPage1);
            this.Tabs.Controls.Add(this.TabPage3);
            this.Tabs.Location = new System.Drawing.Point(0, 24);
            this.Tabs.Margin = new System.Windows.Forms.Padding(0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(524, 215);
            this.Tabs.TabIndex = 4;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.SplitContainer1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Size = new System.Drawing.Size(516, 189);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Raw файлы";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.RawFiles);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.FindTextPanel);
            this.SplitContainer1.Panel2.Controls.Add(this.CodeBox);
            this.SplitContainer1.Size = new System.Drawing.Size(516, 189);
            this.SplitContainer1.SplitterDistance = 196;
            this.SplitContainer1.SplitterWidth = 1;
            this.SplitContainer1.TabIndex = 0;
            // 
            // RawFiles
            // 
            this.RawFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RawFiles.ContextMenuStrip = this.FileListRightClick;
            this.RawFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawFiles.FullRowSelect = true;
            this.RawFiles.HideSelection = false;
            this.RawFiles.Location = new System.Drawing.Point(0, 0);
            this.RawFiles.Margin = new System.Windows.Forms.Padding(0);
            this.RawFiles.Name = "RawFiles";
            this.RawFiles.Size = new System.Drawing.Size(196, 189);
            this.RawFiles.TabIndex = 1;
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
            this.FileListRightClick.Size = new System.Drawing.Size(196, 76);
            // 
            // ExportFileToolStripMenuItem
            // 
            this.ExportFileToolStripMenuItem.Name = "ExportFileToolStripMenuItem";
            this.ExportFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ExportFileToolStripMenuItem.Text = "Экспортировать файл";
            this.ExportFileToolStripMenuItem.Click += new System.EventHandler(this.ExportFileToolStripMenuItem_Click);
            // 
            // EditSelectionToolStripMenuItem
            // 
            this.EditSelectionToolStripMenuItem.Name = "EditSelectionToolStripMenuItem";
            this.EditSelectionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.EditSelectionToolStripMenuItem.Text = "Переименовать файл";
            this.EditSelectionToolStripMenuItem.Click += new System.EventHandler(this.EditSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // ExtractAllGSCsToolStripMenuItem
            // 
            this.ExtractAllGSCsToolStripMenuItem.Name = "ExtractAllGSCsToolStripMenuItem";
            this.ExtractAllGSCsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ExtractAllGSCsToolStripMenuItem.Text = "Экспортировать всё";
            this.ExtractAllGSCsToolStripMenuItem.Click += new System.EventHandler(this.ExtractAllGSCsToolStripMenuItem_Click);
            // 
            // FindTextPanel
            // 
            this.FindTextPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindTextPanel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindTextPanel.Location = new System.Drawing.Point(0, 147);
            this.FindTextPanel.MaximumSize = new System.Drawing.Size(299, 25);
            this.FindTextPanel.MinimumSize = new System.Drawing.Size(299, 25);
            this.FindTextPanel.Name = "FindTextPanel";
            this.FindTextPanel.Size = new System.Drawing.Size(299, 25);
            this.FindTextPanel.TabIndex = 1;
            this.FindTextPanel.Visible = false;
            // 
            // CodeBox
            // 
            this.CodeBox.AcceptsTab = true;
            this.CodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeBox.ContextMenuStrip = this.CodeBoxRightClick;
            this.CodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeBox.Location = new System.Drawing.Point(0, 0);
            this.CodeBox.MaxLength = 2147483647;
            this.CodeBox.Multiline = true;
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CodeBox.Size = new System.Drawing.Size(319, 189);
            this.CodeBox.TabIndex = 0;
            this.CodeBox.WordWrap = false;
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
            this.CodeBoxRightClick.Size = new System.Drawing.Size(213, 164);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.CutToolStripMenuItem.Text = "Вырезать";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.CopyToolStripMenuItem.Text = "Копировать";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.PasteToolStripMenuItem.Text = "Вставить";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // FindToolStripMenuItem
            // 
            this.FindToolStripMenuItem.Name = "FindToolStripMenuItem";
            this.FindToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
            this.FindToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FindToolStripMenuItem.Text = "Найти";
            this.FindToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // FindNextToolStripMenuItem
            // 
            this.FindNextToolStripMenuItem.Name = "FindNextToolStripMenuItem";
            this.FindNextToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.FindNextToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.FindNextToolStripMenuItem.Text = "Найти следующий";
            this.FindNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextToolStripMenuItem_Click);
            // 
            // GotoToolStripMenuItem
            // 
            this.GotoToolStripMenuItem.Name = "GotoToolStripMenuItem";
            this.GotoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
            this.GotoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.GotoToolStripMenuItem.Text = "Перейти к строке";
            this.GotoToolStripMenuItem.Click += new System.EventHandler(this.GotoToolStripMenuItem_Click);
            // 
            // SelectAllToolStripMenuItem
            // 
            this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            this.SelectAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.SelectAllToolStripMenuItem.Text = "Выделить всё";
            this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.SplitContainer3);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(516, 189);
            this.TabPage3.TabIndex = 4;
            this.TabPage3.Text = "Прочее";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // SplitContainer3
            // 
            this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.SplitContainer3.Name = "SplitContainer3";
            // 
            // SplitContainer3.Panel1
            // 
            this.SplitContainer3.Panel1.Controls.Add(this.MiscData);
            this.SplitContainer3.Size = new System.Drawing.Size(516, 189);
            this.SplitContainer3.SplitterDistance = 124;
            this.SplitContainer3.SplitterWidth = 1;
            this.SplitContainer3.TabIndex = 2;
            // 
            // MiscData
            // 
            this.MiscData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MiscData.ContextMenuStrip = this.FileListRightClick;
            this.MiscData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiscData.FullRowSelect = true;
            this.MiscData.HideSelection = false;
            this.MiscData.Location = new System.Drawing.Point(0, 0);
            this.MiscData.Margin = new System.Windows.Forms.Padding(0);
            this.MiscData.Name = "MiscData";
            this.MiscData.Size = new System.Drawing.Size(124, 189);
            this.MiscData.TabIndex = 1;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OldSizeLbl,
            this.NewSizeLbl,
            this.OpenRawFile,
            this.ToolStripStatusLabel5,
            this.LnLbl,
            this.ColLbl});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 239);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(524, 22);
            this.StatusStrip1.TabIndex = 5;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // OldSizeLbl
            // 
            this.OldSizeLbl.Name = "OldSizeLbl";
            this.OldSizeLbl.Size = new System.Drawing.Size(95, 17);
            this.OldSizeLbl.Text = "Старый размер:";
            // 
            // NewSizeLbl
            // 
            this.NewSizeLbl.Name = "NewSizeLbl";
            this.NewSizeLbl.Size = new System.Drawing.Size(91, 17);
            this.NewSizeLbl.Text = "Новый размер:";
            // 
            // OpenRawFile
            // 
            this.OpenRawFile.Name = "OpenRawFile";
            this.OpenRawFile.Size = new System.Drawing.Size(39, 17);
            this.OpenRawFile.Text = "Файл:";
            // 
            // ToolStripStatusLabel5
            // 
            this.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5";
            this.ToolStripStatusLabel5.Size = new System.Drawing.Size(178, 17);
            this.ToolStripStatusLabel5.Spring = true;
            // 
            // LnLbl
            // 
            this.LnLbl.Name = "LnLbl";
            this.LnLbl.Size = new System.Drawing.Size(49, 17);
            this.LnLbl.Text = "Строка:";
            // 
            // ColLbl
            // 
            this.ColLbl.Name = "ColLbl";
            this.ColLbl.Size = new System.Drawing.Size(57, 17);
            this.ColLbl.Text = "Колонка:";
            // 
            // Wait
            // 
            this.Wait.Dock = System.Windows.Forms.DockStyle.Right;
            this.Wait.Location = new System.Drawing.Point(374, 0);
            this.Wait.MaximumSize = new System.Drawing.Size(150, 24);
            this.Wait.MinimumSize = new System.Drawing.Size(150, 24);
            this.Wait.Name = "Wait";
            this.Wait.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Wait.Size = new System.Drawing.Size(150, 24);
            this.Wait.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Wait.TabIndex = 6;
            this.Wait.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MenuStrip);
            this.panel1.Controls.Add(this.Wait);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 24);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.Tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(540, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FFViewer-cs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.FileListRightClick.ResumeLayout(false);
            this.CodeBoxRightClick.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.SplitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).EndInit();
            this.SplitContainer3.ResumeLayout(false);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem5;
        internal System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem Snippets;
        internal System.Windows.Forms.ToolStripMenuItem InstructionsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem UpdateSnippetsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem6;
        internal System.Windows.Forms.TabControl Tabs;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.TreeView RawFiles;
        internal System.Windows.Forms.TextBox CodeBox;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.SplitContainer SplitContainer3;
        internal System.Windows.Forms.TreeView MiscData;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel OldSizeLbl;
        internal System.Windows.Forms.ToolStripStatusLabel NewSizeLbl;
        internal System.Windows.Forms.ToolStripStatusLabel OpenRawFile;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel5;
        internal System.Windows.Forms.ToolStripStatusLabel LnLbl;
        internal System.Windows.Forms.ToolStripStatusLabel ColLbl;
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
        private System.Windows.Forms.ToolStripMenuItem zlibToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZlibCompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZlibDecompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PadFileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ProgressBar Wait;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox FindTextPanel;
    }
}

