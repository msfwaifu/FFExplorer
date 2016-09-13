using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace FFViewer_cs
{
    /// <summary>
    /// Delegate used to handle all thrown exception.
    /// </summary>
    /// <param name="ex"></param>
    public delegate void HandleException_d(Exception ex);

    /// <summary>
    /// Delegate used to change application's progress bar value.
    /// </summary>
    /// <param name="val"></param>
    public delegate void SetProgressBarPercentage_d(int val);

    enum SearchBoxShowMode
    {
        SHOW = 0,
        HIDE = 1,
        INVERT = 2
    };

    public partial class Form1 : Form
    {
        static string currentAppDirectory = Application.StartupPath;
        static string applicationWindowName = Application.ProductName;

        bool isFastFileOpened = false;
        string currentFFName = "";
        int currentRawfileIndex = -1;
        int currentLocalizedStringIndex = -1;

        FFBackend ffBackend;
        OptionsHandler options;
        Updater updater;
        Logger logger;

        About dlgAbout;

        /// <summary>
        /// Gets options handler to access any preferences saved by application.
        /// </summary>
        public OptionsHandler Options { get { return options; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            CustomMenuStripRenderer renderer = new CustomMenuStripRenderer();
            MenuStripLine.Renderer = renderer;
            CodeBoxRightClick.Renderer = renderer;
            FileListRightClick.Renderer = renderer;

            RawfilesWindow.Dock = DockStyle.Fill;
            LocalizedStringsWindow.Dock = DockStyle.Fill;
            RawfilesControlButton_Click(RawfilesControlButton, new EventArgs()); // There is no sender generation with PerformClick().           

            options = new OptionsHandler();

            ffBackend = new FFBackend();
            ffBackend.OnProgressChanged += SetProgressBarPercentage;
            ffBackend.OnRawfileDiscovered += FFBackend_OnRawfileDiscovered;
            ffBackend.OnLocalizedStringDiscovered += FFBackend_OnLocalizedStringDiscovered;
            ffBackend.OnLocalizedStringPrefixRequest += FFBackend_OnLocalizedStringPrefixRequest;
            ffBackend.OnLocalizedStringPrefixesUpdated += FFBackend_OnLocalizedStringPrefixesUpdated;

            dlgAbout = new About();
            dlgAbout.Owner = this;

            StatusLine_Clear();
            SaveFFToolStripMenuItem.Enabled = false;
            CloseFFToolStripMenuItem.Enabled = false;
            ExportFileToolStripMenuItem.Enabled = false;

            updater = new Updater();
            updater.OnExceptionRaised += HandleException;
            updater.OnUpdateAvailable += Updater_OnUpdateAvailable;
            updater.OnFileDownloaded += Updater_OnFileDownloaded;
            updater.OnUpdateDone += Updater_OnUpdateDone;

            logger = new Logger();
            logger.OnWriteLine += Logger_OnWriteLine;
            logger.OnWriteException += Logger_OnWriteException;

            ShowSearchPanel(SearchBoxShowMode.HIDE);
            SetWindowFileName("");
            LogGroup.Visible = options.ShowLog;
        }

        private void FFBackend_OnLocalizedStringDiscovered(int index, string prefix, string key)
        {
            if (InvokeRequired)
            {
                LocalizedStringDiscovered_d d = FFBackend_OnLocalizedStringDiscovered;
                BeginInvoke(d, index, prefix, key);
                return;
            }

            TreeNode n = new TreeNode(key);
            n.Tag = index;

            TreeNode[] searchResult = Localizedstrings.Nodes.Find(prefix, true);

            if (searchResult.Length != 0)
            {
                searchResult[0].Nodes.Add(n);
                return;
            }

            TreeNode prefixNode = Localizedstrings.Nodes.Add(prefix, prefix);
            prefixNode.Tag = -1;
            prefixNode.Nodes.Add(n);
        }

        private void FFBackend_OnLocalizedStringPrefixesUpdated(string[] prefixes)
        {
            options.LocalizedStringPrefixes = prefixes;
        }

        private string[] FFBackend_OnLocalizedStringPrefixRequest()
        {
            return options.LocalizedStringPrefixes;
        }

        private void FFBackend_OnRawfileDiscovered(int index, string name, string originalName, int originalSize)
        {
            if (InvokeRequired)
            {
                RawFileDiscovered_d d = FFBackend_OnRawfileDiscovered;
                BeginInvoke(d, index, name, originalName, originalSize);
                return;
            }

            TreeNode rawFileNode = new TreeNode();

            rawFileNode.Text = name;
            rawFileNode.Nodes.Add("Index: " + index);
            rawFileNode.Nodes.Add("Name: " + name);
            rawFileNode.Nodes.Add("Original name: " + originalName);
            rawFileNode.Nodes.Add("Original size: " + originalSize.ToString());
            rawFileNode.Tag = index;

            RawFiles.Nodes.Add(rawFileNode);
        }

        private void Logger_OnWriteException(string timestamp, Exception ex)
        {
            StatusBarLogValue.Text = ex.Message;
            LogTextBox.Text += timestamp + ex.Message + "\r\n" + ex.StackTrace + "\r\n";
            LogTextBox.ScrollToCaret();
        }

        private void Logger_OnWriteLine(string timestamp, string line)
        {
            StatusBarLogValue.Text = line;
            LogTextBox.AppendText(timestamp + line + "\r\n");
        }

        private void Updater_OnUpdateDone()
        {
            throw new NotImplementedException();
        }

        private void Updater_OnFileDownloaded(string fileName)
        {
            throw new NotImplementedException();
        }

        private void Updater_OnUpdateAvailable()
        {
            throw new NotImplementedException();
        }

        private void SetWindowFileName(string filePath)
        {
            if (filePath == "")
                Text = applicationWindowName;
            else
                Text = String.Format("{0} - [ {1} ]", applicationWindowName, filePath);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool handled = false;

            if (e.KeyCode == Keys.Escape)
            {
                ShowSearchPanel(SearchBoxShowMode.HIDE);
                handled = true;
            }
            if (e.Control)
            {
                if (e.KeyCode == Keys.F)
                {
                    FindToolStripMenuItem.PerformClick();
                    handled = true;
                }
                else if (e.KeyCode == Keys.G)
                {
                    GotoToolStripMenuItem.PerformClick();
                    handled = true;
                }
            }

            if (CodeBox.Focused)
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.A)
                    {
                        CodeBox.SelectAll();
                        handled = true;
                    }
                    if (e.KeyCode == Keys.C)
                    {
                        if (CodeBox.SelectedText.Length > 0)
                            Clipboard.SetText(CodeBox.SelectedText);
                        handled = true;
                    }

                    if (e.KeyCode == Keys.X)
                    {
                        CodeBox.Cut();
                        handled = true;
                    }
                }
                if (e.KeyCode == Keys.F3)
                {
                    FindNextToolStripMenuItem.PerformClick();
                    handled = true;
                }
            }
            else if (FindTextBox.Focused)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int selectionStart = CodeBox.Text.IndexOf(FindTextBox.Text);
                    if (selectionStart >= 0)
                    {
                        CodeBox.Select(selectionStart, FindTextBox.TextLength);
                        CodeBox.ScrollToCaret();
                        ShowSearchPanel(SearchBoxShowMode.HIDE);
                    }

                    handled = true;
                }
            }
            else if (GoToLineBox.Focused)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GoToLine();
                    ShowSearchPanel(SearchBoxShowMode.HIDE);
                    handled = true;
                }
            }
            if (e.Control)
            {
                if (e.KeyCode == Keys.O)
                {
                    if (OpenFFToolStripMenuItem.Enabled)
                        OpenFFToolStripMenuItem.PerformClick();
                    handled = true;
                }
                if (e.KeyCode == Keys.S)
                {
                    if (SaveFFToolStripMenuItem.Enabled)
                        SaveFFToolStripMenuItem.PerformClick();
                    handled = true;
                }
                if (e.KeyCode == Keys.Q)
                {
                    if (CloseFFToolStripMenuItem.Enabled)
                        CloseFFToolStripMenuItem.PerformClick();
                    handled = true;
                }
            }
            e.Handled = handled;
            e.SuppressKeyPress = handled;
        }

        private void OpenFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalyzeFastfile();
        }

        /// <returns>
        /// <para><see cref="SearchBoxShowMode.HIDE"/> when hidden.</para>
        /// <para><see cref="SearchBoxShowMode.SHOW"/> when shown.</para>
        /// </returns>
        private SearchBoxShowMode ShowSearchPanel(SearchBoxShowMode mode)
        {
            if (mode == SearchBoxShowMode.SHOW)
                SearchBoxAndGoToPanel.Show();
            else if (mode == SearchBoxShowMode.HIDE)
            {
                SearchBoxAndGoToPanel.Hide();
                CodeBox.Focus();
            }
            else if (mode == SearchBoxShowMode.INVERT)
            {
                if (SearchBoxAndGoToPanel.Visible)
                {
                    SearchBoxAndGoToPanel.Hide();
                    CodeBox.Focus();
                    return SearchBoxShowMode.HIDE;
                }
                else
                {
                    SearchBoxAndGoToPanel.Show();
                    return SearchBoxShowMode.SHOW;
                }
            }
            return mode;
        }

        private async void AnalyzeFastfile()
        {
            if (isFastFileOpened)
                CloseFFToolStripMenuItem.PerformClick();

            if (currentFFName == "")
            {
                if (options.RememberLastFolder)
                    OpenFFDialog.InitialDirectory = options.LastFolder;
                else
                    OpenFFDialog.InitialDirectory = Directory.GetCurrentDirectory();

                if (OpenFFDialog.ShowDialog() == DialogResult.OK && OpenFFDialog.CheckFileExists)
                    currentFFName = OpenFFDialog.FileName;
                else
                    return;
            }

            if (currentFFName.Substring(currentFFName.LastIndexOf("."), 3).ToLower() != ".ff")
                throw new Exception("Fastfile format must be .ff");

            LockInterface(true);
            await Task.Run(() => { ffBackend.OpenFastfile(currentFFName); });

            if (options.SaveTemporaryFiles)
                await Task.Run(() => { ffBackend.ExportZone(currentAppDirectory + "/decompressed-zone.dat"); });

            options.LastFolder = ffBackend.FFPath.Substring(0, ffBackend.FFPath.LastIndexOf("\\"));
            SetWindowFileName(ffBackend.FFPath);

            RawFiles.Sort();
            Localizedstrings.Sort();

            isFastFileOpened = true;
            OpenFFToolStripMenuItem.Enabled = false;
            SaveFFToolStripMenuItem.Enabled = true;
            CloseFFToolStripMenuItem.Enabled = true;
            ExportFileToolStripMenuItem.Enabled = true;
            LockInterface(false);
        }

        private async void SaveFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            LockInterface(true);
            await Task.Run(() => { ffBackend.SaveFastfile(); });
            StatusLine_Clear();
            LockInterface(false);
        }

        int SubStrCount(string str, string substr)
        {
            if (str == "" || substr == "")
                return 0;

            return ByteHandling.CountBytes(Encoding.ASCII.GetBytes(str.ToCharArray()), Encoding.ASCII.GetBytes(substr.ToCharArray()));
        }

        private void CloseFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            isFastFileOpened = false;
            currentFFName = "";
            RawfilesTabCleanup();
            LocalizedStringTabCleanup();
            
            ffBackend.Cleanup();
            SetWindowFileName("");

            OpenFFToolStripMenuItem.Enabled = true;
            SaveFFToolStripMenuItem.Enabled = false;
            CloseFFToolStripMenuItem.Enabled = false;
            ExportFileToolStripMenuItem.Enabled = false;
        }

        private void LocalizedStringTabCleanup()
        {
            Localizedstrings.Nodes.Clear();
            LocalizedStringsFieldsCleanup();
        }

        private void LocalizedStringsFieldsCleanup()
        {
            LocalizedStringKeyTextBox.Text = "";
            LocalizedStringValueTextBox.Text = "";
            LocalizedStringKeySizeValue.Text = "0";
            LocalizedStringKeySizeMaxValue.Text = "0";
            LocalizedStringKeyOffsetValue.Text = "0";
            LocalizedStringValueSizeVal.Text = "0";
            LocalizedStringValueSizeMaxVal.Text = "0";
            LocalizedStringValueOffsetVal.Text = "0";
        }

        private void RawfilesTabCleanup()
        {
            RawFiles.Nodes.Clear();
            StatusLine_Clear();            
            CodeBox.Text = "";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SyntaxCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRawfileIndex == -1)
                return;

            ffBackend.RawfileCheckSyntax(currentRawfileIndex);
        }

        private void RemoveCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRawfileIndex == -1)
                return;

            ffBackend.RawfileRemoveComments(currentRawfileIndex);
            CodeBox.Text = ffBackend.GetRawfileContents(currentRawfileIndex);
            RawfileInfo_Update();
        }

        private async void ZlibCompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.PrintLine("Zlib compression: waiting for input file");
            if (OpenDecompressedZlibFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCompressedZlibFileDialog.FileName = OpenDecompressedZlibFileDialog.FileName;
                logger.PrintLine("Zlib compression: waiting for output file");
                if (SaveCompressedZlibFileDialog.ShowDialog() == DialogResult.OK)
                {
                    logger.PrintLine("Zlib compression: working...");
                    await Task.Run(() => { ffBackend.CompressZlibArchive(OpenDecompressedZlibFileDialog.FileName, SaveCompressedZlibFileDialog.FileName); });
                    logger.PrintLine("Zlib compression: done!");
                    return;
                }
            }
            logger.PrintLine("Zlib compression: cancelled");
        }

        private async void ZlibDecompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.PrintLine("Zlib decompression: waiting for input file");
            if (OpenCompressedZlibFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDecompressedZlibFileDialog.FileName = OpenCompressedZlibFileDialog.FileName;
                logger.PrintLine("Zlib decompression: waiting for output file");
                if (SaveDecompressedZlibFileDialog.ShowDialog() == DialogResult.OK)
                {
                    logger.PrintLine("Zlib decompression: working...");
                    await Task.Run(() => { ffBackend.DecompressZlibArchive(OpenCompressedZlibFileDialog.FileName, SaveDecompressedZlibFileDialog.FileName);});
                    logger.PrintLine("Zlib decompression: done!");
                    return;
                }
            }
            logger.PrintLine("Zlib decompression: cancelled");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgAbout.ShowDialog();
        }

        private void InstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Поместите текстовые файлы формата .gsc в папку \"snippets\".", "Инструкция", MessageBoxButtons.OK);
        }

        private void UpdateSnippetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo allFiles = new DirectoryInfo(currentAppDirectory + "\\snippets");
            foreach (FileInfo gsc in allFiles.GetFiles("*.gsc"))
            {
                Snippets.DropDownItems.Add(gsc.Name, null, new EventHandler(onClickCustomSnippets));
            }

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeBox.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CodeBox.SelectedText.Length > 0)
                Clipboard.SetText(CodeBox.SelectedText);
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeBox.Paste();
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowSearchPanel(SearchBoxShowMode.INVERT) == SearchBoxShowMode.HIDE)
                return;
            
            FindTextBox.Focus();
            if (CodeBox.SelectionLength > 0)
            {
                FindTextBox.Text = CodeBox.SelectedText;
                FindTextBox.SelectionStart = 0;
                FindTextBox.SelectionLength = CodeBox.SelectionLength;
            }
        }

        private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectionStart = CodeBox.Text.IndexOf(CodeBox.SelectedText, CodeBox.SelectionStart + CodeBox.SelectionLength);
            if (selectionStart == -1)
                selectionStart = CodeBox.Text.IndexOf(CodeBox.SelectedText, 0);
            CodeBox.SelectionStart = selectionStart;
            CodeBox.ScrollToCaret();
        }

        private void GotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowSearchPanel(SearchBoxShowMode.INVERT) == SearchBoxShowMode.HIDE)
                return;

            GoToLineBox.Focus();
            GoToLineBox.Select(0, GoToLineBox.Value.ToString().Length);
        }

        private void GoToLine()
        {
            if (GoToLineBox.Value > 0)
            {
                CodeBox.SelectionStart = 0;
                for (int i = 0; i < GoToLineBox.Value - 1; ++i)
                    CodeBox.SelectionStart = CodeBox.Text.IndexOf("\r\n", CodeBox.SelectionStart) + 2;

                CodeBox.ScrollToCaret();
                CodeBox.Focus();
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CodeBox.SelectAll();
        }

        private void onClickCustomSnippets(object sender, EventArgs e)
        {
            string filename = sender.ToString();
            if (File.Exists(currentAppDirectory + "\\snippets\\" + filename))
                CodeBox.Paste(File.ReadAllText(currentAppDirectory + "\\snippets\\" + filename));
        }

        private void ExportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            string rn = ffBackend.GetRawfileName(RawFiles.SelectedNode.Index);
            if (rn.Contains("/"))
                ExtractDialog.FileName = rn.Substring(rn.LastIndexOf("/") + 1);
            else
                ExtractDialog.FileName = rn;

            if (options.RememberLastFolder)
                ExtractDialog.InitialDirectory = options.LastFolder;
            else
                ExtractDialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (ExtractDialog.ShowDialog() == DialogResult.OK)
                ffBackend.ExtractRawFile(ExtractDialog.FileName, RawFiles.SelectedNode.Index);
        }

        private async void ExtractAllGSCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(FolderBrowserDialog.SelectedPath))
                    Directory.CreateDirectory(FolderBrowserDialog.SelectedPath);

                LockInterface(true);
                await Task.Run(() => { ffBackend.ExtractAllRawfiles(FolderBrowserDialog.SelectedPath); });
                LockInterface(false);
            }
        }

        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            if (currentRawfileIndex == -1)
                return;

            GoToLineBox.Maximum = SubStrCount(CodeBox.Text, "\r\n") + 1;

            ffBackend.SetRawfileContents(currentRawfileIndex, CodeBox.Text);
            RawfileInfo_UpdateSize();
        }

        private void CodeBox_Click(object sender, EventArgs e)
        {
            RawfileInfo_UpdateCurrentLine();
        }

        private void CodeBox_KeyUp(object sender, KeyEventArgs e)
        {
            RawfileInfo_UpdateCurrentLine();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dataFullStrings = e.Data.GetData("FileDrop") as string[];
            currentFFName = dataFullStrings[0];
            AnalyzeFastfile();
        }

        private void PadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentRawfileIndex == -1)
                return;

            ffBackend.PadRawfile(currentRawfileIndex);
            RawfileInfo_Update();
        }

        private void RawfileInfo_UpdateOriginalSize()
        {
            if (currentRawfileIndex == -1)
                RawfileInfoSizeOriginal.Text = "0";
            else
                RawfileInfoSizeOriginal.Text = ffBackend.GetRawfileOriginalSize(currentRawfileIndex).ToString();
        }

        private void RawfileInfo_UpdateSize()
        {
            if (currentRawfileIndex == -1)
                RawfileInfoSize.Text = "0";
            else
                RawfileInfoSize.Text = ffBackend.GetRawfileSize(currentRawfileIndex).ToString();
        }

        private void RawfileInfo_UpdateFileName()
        {
            if (currentRawfileIndex == -1)
                RawfileInfoFileName.Text = "unnamed";
            else
                RawfileInfoFileName.Text = ffBackend.GetRawfileName(currentRawfileIndex);
        }

        private void RawfileInfo_UpdateCurrentLine()
        {
            GoToLineBox.Text = (CodeBox.GetLineFromCharIndex(CodeBox.SelectionStart) + 1).ToString();
        }

        private void RawfileInfo_Update()
        {
            if (currentRawfileIndex == -1)
            {
                RawfileInfoPanel.Visible = false;
                return;
            }
            
            RawfileInfo_UpdateCurrentLine();
            RawfileInfo_UpdateFileName();
            RawfileInfo_UpdateSize();
            RawfileInfo_UpdateOriginalSize();
            RawfileInfoPanel.Visible = true;
        }

        private void StatusLine_Clear()
        {
            currentRawfileIndex = -1;
            RawfileInfo_Update();
        }

        private void RawFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentRawfileIndex = (int)(RawFiles.SelectedNode.Nodes.Count == 0 ? RawFiles.SelectedNode.Parent.Tag : RawFiles.SelectedNode.Tag);
            CodeBox.Text = ffBackend.GetRawfileContents(currentRawfileIndex);
            RawfileInfo_Update();
        }

        private void RawFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                RawFiles.SelectedNode = e.Node;
        }

        //TODO: dirty
        private void Form1_Shown(object sender, EventArgs e)
        {
            SetWindowFileName("");
            this.Width = options.Width;
            this.Height = options.Height;

            if (!Directory.Exists(currentAppDirectory + "\\snippets"))
                Directory.CreateDirectory(currentAppDirectory + "\\snippets");

            UpdateSnippetsToolStripMenuItem.PerformClick();

            string[] arg = Environment.GetCommandLineArgs();
            if (arg.Length > 1)
            {
                if (arg[1] != "")
                {
                    if (File.Exists(arg[1]))
                    {
                        currentFFName = arg[1];
                        AnalyzeFastfile();
                    }
                    else
                        MessageBox.Show("Не удаётся найти требуемый файл:\n" + arg[1]);
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            options.Width = this.Size.Width;
            options.Height = this.Size.Height;
        }

        /// <summary>
        /// Default exception handler for application.
        /// </summary>
        /// <param name="ex">An exception class used to get information about exception.</param>
        static public void HandleException(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Exception caught", MessageBoxButtons.OK);
            Application.Exit();
        }

        /// <summary>
        /// Used to lock whole application interface.
        /// </summary>
        /// <param name="state">True for lock, false for unlock.</param>
        protected void LockInterface(bool state)
        {
            MenuStripLine.Enabled = !state;
            //ControlButtonsPanel.Enabled = !state;
            InterfaceBody.Enabled = !state; 
            Wait.Visible = state;
        }

        /// <summary>
        /// Used to change application's progress bar value.
        /// </summary>
        /// <param name="percent"></param>
        private void SetProgressBarPercentage(int percent)
        {
            if (this.InvokeRequired)
            {
                SetProgressBarPercentage_d d = SetProgressBarPercentage;
                this.BeginInvoke(d, percent);
                return;
            }

            percent = percent < 0 ? 0 : percent;
            percent = percent > 100 ? 100 : percent;
            Wait.Value = percent;
            Wait.Visible = percent != 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.PrintLine("FFViewer started!");
            logger.PrintLine("Getting update information.");
            updater.GetUpdateInfo();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options dlg = new Options();
            dlg.Owner = this;
            dlg.OnOptionsSaved += Dlg_OnOptionsSaved;
            dlg.ShowDialog();
        }

        private void Dlg_OnOptionsSaved()
        {
            if (options.ShowLog)
                LogGroup.Visible = true;
            else
                LogGroup.Visible = false;
        }

        private void StatusLogLabel_Click(object sender, EventArgs e)
        {
            LogGroup.Visible = !LogGroup.Visible;
        }

        private void ExtractZoneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void SaveAsFastfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void SaveExtractedZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void OpenExtractedZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private async void SaveAsFastfileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OpenZoneDialog.ShowDialog() != DialogResult.OK)
                return;

            if (SaveFastfileDialog.ShowDialog() != DialogResult.OK)
                return;

            logger.PrintLine("Saving zone as CoD4 fastfile.");
            await Task.Run(() => { ffBackend.SaveAsFastfile(OpenZoneDialog.FileName, SaveFastfileDialog.FileName); });
            logger.PrintLine("Fastfile saved.");
        }

        private async void ExportZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ExportZoneDialog.ShowDialog() != DialogResult.OK)
                return;

            logger.PrintLine("Exporting zone.");
            await Task.Run(() => { ffBackend.ExportZone(ExportZoneDialog.FileName); });
            logger.PrintLine("Export done.");
        }

        private void Localizedstrings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentLocalizedStringIndex = (int) e.Node.Tag;
            if (currentLocalizedStringIndex == -1)
            {
                LocalizedStringKeyGroup.Visible = false;
                LocalizedStringValueGroup.Visible = false;
                return;
            }
            LocalizedStringKeySizeMaxValue.Text = ffBackend.GetLocalizedStringKeyMaxSize(currentLocalizedStringIndex).ToString();
            LocalizedStringKeyOffsetValue.Text = ffBackend.GetLocalizedStringKeyOffset(currentLocalizedStringIndex).ToString();
            LocalizedStringKeyTextBox.Text = ffBackend.GetLocalizedStringKey(currentLocalizedStringIndex);
            LocalizedStringValueSizeMaxVal.Text = ffBackend.GetLocalizedStringValueMaxSize(currentLocalizedStringIndex).ToString();
            LocalizedStringValueOffsetVal.Text = ffBackend.GetLocalizedStringValueOffset(currentLocalizedStringIndex).ToString();
            LocalizedStringValueTextBox.Text = ffBackend.GetLocalizedStringValue(currentLocalizedStringIndex);
            LocalizedStringKeyGroup.Visible = true;
            LocalizedStringValueGroup.Visible = true;
        }

        private void LocalizedStringKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            LocalizedStringKeySizeValue.Text = LocalizedStringKeyTextBox.Text.Length.ToString();
            //TODO: check if size cannot be larger than original
            if(currentLocalizedStringIndex != -1)
                ffBackend.SetLocalizedStringKey(currentLocalizedStringIndex, LocalizedStringKeyTextBox.Text);
        }

        private void LocalizedStringValueTextBox_TextChanged(object sender, EventArgs e)
        {
            LocalizedStringValueSizeVal.Text = LocalizedStringValueTextBox.Text.Length.ToString();
            //TODO: check if size cannot be larger than original
            if(currentLocalizedStringIndex != -1)
                ffBackend.SetLocalizedStringValue(currentLocalizedStringIndex, LocalizedStringValueTextBox.Text);
        }

        private void OnControlButtonClicked(object sender, EventArgs e)
        { 
            Panel controlPanel = ((Button)sender).Parent as Panel;
            foreach (Button btn in controlPanel.Controls)
            {
                if (btn == sender)
                    btn.BackColor = SystemColors.ControlDarkDark;
                else
                    btn.BackColor = SystemColors.AppWorkspace;
            }
        }

        private void OnGroupBoxPaint(object sender, PaintEventArgs e) // Something weird with redrawing border when resizing whole form.
        {
            const int headerTextOffset = 15;
            GroupBox b = sender as GroupBox;
            e.Graphics.Clear(SystemColors.AppWorkspace);
            using (SolidBrush br = new SolidBrush(b.ForeColor))
                e.Graphics.DrawString(b.Text, b.Font, br, headerTextOffset, 0);
            using (Pen p = new Pen(SystemColors.ControlDarkDark))
            {
                Point lu = new Point(0, 7);
                Point lu1 = new Point(headerTextOffset, 7);
                Point lu2 = new Point(headerTextOffset + (int)(e.Graphics.MeasureString(b.Text, b.Font).Width), 7);
                Point ru = new Point(e.ClipRectangle.Width - 1, 7);
                Point rl = new Point(e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                Point ll = new Point(0, e.ClipRectangle.Height - 1);
                e.Graphics.DrawLine(p, lu, lu1);
                e.Graphics.DrawLine(p, lu2, ru);
                e.Graphics.DrawLine(p, ru, rl);
                e.Graphics.DrawLine(p, ll, rl);
                e.Graphics.DrawLine(p, lu, ll);
            }
        }

        private void RawfilesControlButton_Click(object sender, EventArgs e)
        {
            OnControlButtonClicked(sender, e);
            RawfilesWindow.Visible = true;
            LocalizedStringsWindow.Visible = false;
        }

        private void LocalizedStringControlButton_Click(object sender, EventArgs e)
        {
            OnControlButtonClicked(sender, e);
            RawfilesWindow.Visible = false;
            LocalizedStringsWindow.Visible = true;
        }

        private void OtherControlButton_Click(object sender, EventArgs e)
        {
            OnControlButtonClicked(sender, e);
            RawfilesWindow.Visible = false;
            LocalizedStringsWindow.Visible = false;
        }
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class CustomMenuStripRenderer : ToolStripProfessionalRenderer
    {
        // Toolstrip connected area background: 2 rectangles
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.AffectedBounds == e.ToolStrip.Bounds)
                base.OnRenderToolStripBorder(e);
            else
            {
                using (Pen p = new Pen(SystemColors.ControlDarkDark))
                {
                    e.Graphics.DrawRectangle(p, e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
                    p.Color = SystemColors.AppWorkspace;
                    e.Graphics.DrawRectangle(p, e.AffectedBounds.X + 1, e.AffectedBounds.Y + 1, e.AffectedBounds.Width - 3, e.AffectedBounds.Height - 3);
                }
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            Rectangle bg = new Rectangle(Point.Empty, e.Item.Size);
            using (SolidBrush b = new SolidBrush(SystemColors.AppWorkspace))
            {
                e.Graphics.FillRectangle(b, bg);
            }
            using (Pen p = new Pen(SystemColors.ControlDarkDark))
            {
                Point left = new Point(bg.X, bg.Y + bg.Height / 2);
                Point right = new Point(bg.X + bg.Width, bg.Y + bg.Height / 2);
                e.Graphics.DrawLine(p, left, right);
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            using (SolidBrush s = new SolidBrush(SystemColors.ControlDarkDark))
            {
                Rectangle r = new Rectangle(Point.Empty, e.Item.Size);
                if (e.Item.Selected)
                {
                    if (e.Item.Enabled)
                    {
                        s.Color = SystemColors.ControlDarkDark;
                        e.Graphics.FillRectangle(s, r);
                    }
                    else
                    {
                        s.Color = SystemColors.ButtonShadow;
                        e.Graphics.FillRectangle(s, r);
                    }
                }
                else if (e.Item.Pressed) // Button on top of dropdown list
                {
                    s.Color = SystemColors.ControlDarkDark;
                    e.Graphics.FillRectangle(s, r);
                }
                else
                    base.OnRenderMenuItemBackground(e);
            }
        }
    };
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
