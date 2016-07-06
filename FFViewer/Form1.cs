using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

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

        bool isFastFileOpened;
        string currentFFName;

        FFBackend ffBackend;
        OptionsHandler options;
        Updater updater;
        Logger logger;
 
        About dlgAbout;

        RawFileData currentRawFile;

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
            options = new OptionsHandler();

            isFastFileOpened = false;
            currentFFName = "";

            ffBackend = new FFBackend();
            ffBackend.OnProgressChanged += SetProgressBarPercentage;
            ffBackend.OnRawfileDiscovered += FFBackend_OnRawfileDiscovered;

            dlgAbout = new About();
            //dlgOptions = new Options();

            dlgAbout.Owner = this;
            //dlgOptions.Owner = this;

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

            currentRawFile = new RawFileData();
            ShowSearchPanel(SearchBoxShowMode.HIDE);
            SetWindowFileName("");
            LogGroup.Visible = options.ShowLog;
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
            LogTextBox.Text += timestamp + line + "\r\n";
            LogTextBox.ScrollToCaret();
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
            if(filePath == "")
                Text = applicationWindowName;
            else
            {
                Text = String.Format("{0} - [ {1} ]", applicationWindowName, filePath);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                HandleException(ex);
            }
        }

        private void OpenFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AnalyzeFastfile();
            }
            catch(Exception ex)
            {
                HandleException(ex);
            }
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

            if (File.GetAttributes(currentFFName) == FileAttributes.ReadOnly)
            {
                MessageBox.Show("Файл не может быть открыт из-за флага \"Только чтение\"", "Ошибка при открытии файла", MessageBoxButtons.OK);
                currentFFName = "";
                return;
            }

            if (currentFFName.Substring(currentFFName.LastIndexOf("."), 3).ToLower() != ".ff")
            {
                MessageBox.Show("Неверное расширение файла: " + currentFFName.Substring(currentFFName.LastIndexOf(".") + 1, 2), "Ошибка при открытии файла", MessageBoxButtons.OK);
                currentFFName = "";
                return;
            }

            LockInterface(true);
            await Task.Run(() => { ffBackend.OpenFastfile(currentFFName); });

            if (options.SaveTemporaryFiles)
                await Task.Run(() => { ffBackend.ExportZone(currentAppDirectory + "/decompressed-zone.dat"); });

            options.LastFolder = ffBackend.FFPath.Substring(0, ffBackend.FFPath.LastIndexOf("\\"));
            SetWindowFileName(ffBackend.FFPath);

            RawFiles.Sort();
            isFastFileOpened = true;
            OpenFFToolStripMenuItem.Enabled = false;
            SaveFFToolStripMenuItem.Enabled = true;
            CloseFFToolStripMenuItem.Enabled = true;
            ExportFileToolStripMenuItem.Enabled = true;
            LockInterface(false);
        }

        //TODO: move to backend
        private async void SaveFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            SetProgressBarPercentage(0);
            LockInterface(true);
            await Task.Run(() => { ffBackend.SaveFastfile(); });
            StatusLine_Clear();
            LockInterface(false);

            /*
            finally
            {
                SetProgressBarPercentage(0);
                LockInterface(false);
                OpenFFToolStripMenuItem.PerformClick();
            }*/
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

            try
            {
                if (MessageBox.Show("Вы уверены? Все несохранённые изменения будут утеряны.", "Закрыть Fastfile?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    currentFFName = "";
                    StatusLine_Clear();                    
                    RawFiles.Nodes.Clear();
                    ffBackend.Cleanup();

                    CodeBox.Text = "";
                    SetWindowFileName("");
                    
                    OpenFFToolStripMenuItem.Enabled = true;
                    SaveFFToolStripMenuItem.Enabled = false;
                    CloseFFToolStripMenuItem.Enabled = false;
                    ExportFileToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch(Exception ex)
            {
                HandleException(ex);
            }
        }

        private void SyntaxCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*int i = 1;
            int openStasheCount = 0;
            int closeStasheCount = 0;
            int startLineSearchBracket = -1;
            int currentSearchBracket = -1;
            string[] totalLines = CodeBox.Text.Split("\r\n".ToCharArray());
            string[] functions = new string[450];
            string[] includes = new string[25]; //  it actually stores the included files :O
            int functionCount = 0;
            int includeCount = 0;

            //  Go line by line, counting up the amounts of things like curly braces
            foreach (string line in totalLines)
            {
                int commentChar = line.Length;
                if (line.LastIndexOf("//") != -1)
                    commentChar = line.IndexOf("//");

                string beforeComment = line.Substring(0, commentChar);
                openStasheCount = openStasheCount + SubStrCount(beforeComment, "{");
                closeStasheCount = closeStasheCount + SubStrCount(beforeComment, "}");
                if (openStasheCount == closeStasheCount && line.IndexOf("}") >= 0 && line.IndexOf("#include") == -1)
                {
                    //  if the line isn't in a function....
                    if ((line.IndexOf("(") == -1))
                    {
                        // functions(functionCount) = line.Substring(0, line.Length)
                        //  tbh, it should not even do this :S
                    }
                    else
                    {
                        functions[functionCount] = line.Substring(0, line.IndexOf("("));
                        ++functionCount;
                    }
                }

                if (line.IndexOf("#include") != -1)
                {
                    includes[includeCount++] = line.Substring((line.IndexOf("#include") + 8));
                    ++includeCount;
                }

                i++;
            }

            //  So, we have all of the functions. Now see if anything is called that ins't a function!
            string allFunctions = "";
            string allIncludes = "";
            for (int k = 0; (k
                        <= (functions.Length - 1)); k++)
            {
                allFunctions = (allFunctions
                            + (functions[k] + ","));
            }

            object functions;
            for (int k = 0; (k
                        <= (includes.Length - 1)); k++)
            {
                allIncludes = (allIncludes
                            + (includes[k] + ","));
            }

            object functions;
            i = 1;
            foreach (string line in totalLines)
            {
                if ((line.IndexOf("self thread ") != -1))
                {
                    //  here is a function called...
                    int endOffset = (line.IndexOfAny(new char[] {
                            "(",
                            " "}, (line.IndexOf(" thread ") + 8))
                                - (line.IndexOf(" thread ") - 8));
                    string called = line.Substring((line.IndexOf(" thread ") + 8), endOffset);
                    if ((allFunctions.IndexOf((called + ",")) == -1))
                    {
                        //  the function was NOT found! Check the includes...
                        if ((called.IndexOf("\\") == -1))
                        {
                            //  there was also no file reference, so it is an unknown function.
                            MessageBox.Show(("Script compile error: Unknown function \""
                                            + (called + ("\" on line " + i.ToString()))));
                        }

                    }

                }

                i++;
            }

            if (openStasheCount < closeStasheCount)
            {
                MessageBox.Show("Syntax error: Too many close braces }");
            }

            if (openStasheCount > closeStasheCount)
            {
                MessageBox.Show("Syntax error: Too many open braces {");
            }
            MessageBox.Show("Finished checking syntax.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, false);
        */}

        private void RemoveCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = CodeBox.Text.Split(new char[] { '\r', '\n' });

                int oneLineCommentIndex = -1;
                int multiLineCommentIndexStart = -1;
                int multiLineCommentIndexEnd = -1;
                int devCommentIndexStart = -1;
                int devCommentIndexEnd = -1;

                bool isInMultiLineComment = false;
                bool isInDevComment = false;
                for (int i = 0; i < lines.Length; ++i)
                {
                    if (isInMultiLineComment)
                    {
                        multiLineCommentIndexEnd = lines[i].IndexOf("*/");
                        if (multiLineCommentIndexEnd != -1)
                        {
                            isInMultiLineComment = false;
                            lines[i] = lines[i].Substring(multiLineCommentIndexEnd + 2);
                        }
                        else
                        {
                            lines[i] = "";
                            continue;
                        }
                    }
                    if (isInDevComment)
                    {
                        devCommentIndexEnd = lines[i].IndexOf("#/");
                        if (devCommentIndexEnd != -1)
                        {
                            isInDevComment = false;
                            lines[i] = lines[i].Substring(devCommentIndexEnd + 2);
                        }
                        else
                        {
                            lines[i] = "";
                            continue;
                        }
                    }
                    //one-line comment
                    oneLineCommentIndex = lines[i].IndexOf("//");
                    if (oneLineCommentIndex != -1)
                        lines[i] = lines[i].Substring(0, oneLineCommentIndex);

                    //multi-line comment
                    multiLineCommentIndexStart = lines[i].IndexOf("/*");
                    if (multiLineCommentIndexStart != -1)
                    {
                        multiLineCommentIndexEnd = lines[i].IndexOf("*/");
                        if (multiLineCommentIndexEnd == -1)
                        {
                            isInMultiLineComment = true;
                            lines[i] = lines[i].Substring(0, multiLineCommentIndexStart);
                        }
                        else
                            lines[i] = lines[i].Substring(0, multiLineCommentIndexStart) + lines[i].Substring(multiLineCommentIndexEnd + 2);

                        continue;
                    }

                    //dev comment
                    devCommentIndexStart = lines[i].IndexOf("/#");
                    if (devCommentIndexStart != -1)
                    {
                        devCommentIndexEnd = lines[i].IndexOf("#/");
                        if (devCommentIndexEnd == -1)
                        {
                            isInMultiLineComment = true;
                            lines[i] = lines[i].Substring(0, devCommentIndexStart);
                        }
                        else
                            lines[i] = lines[i].Substring(0, devCommentIndexStart) + lines[i].Substring(devCommentIndexEnd + 2);

                        continue;
                    }
                }

                string text = "";
                for (int i = 0; i < lines.Length; ++i)
                    if (lines[i] != "")
                        text += (i == lines.Length - 1 ? lines[i] : lines[i] + "\r\n");

                CodeBox.Text = text;
            }
            catch(Exception ex)
            {
                HandleException(ex);
            }
        }

        private void ZlibCompressToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ZlibDecompressToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            try
            {
                DirectoryInfo allFiles = new DirectoryInfo(currentAppDirectory + "\\snippets");
                foreach (FileInfo gsc in allFiles.GetFiles("*.gsc"))
                {
                    Snippets.DropDownItems.Add(gsc.Name, null, new EventHandler(onClickCustomSnippets));
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
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
            try
            {
                string filename = sender.ToString();
                if (File.Exists(currentAppDirectory + "\\snippets\\" + filename))
                    CodeBox.Paste(File.ReadAllText(currentAppDirectory + "\\snippets\\" + filename));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void ExportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            RawFileData r = ffBackend.RawfileAtIndex(RawFiles.SelectedNode.Index);
            if (r.Name.Contains("/"))
                ExtractDialog.FileName = r.Name.Substring(r.Name.LastIndexOf("/") + 1);
            else
                ExtractDialog.FileName = r.Name;

            if (options.RememberLastFolder)
                ExtractDialog.InitialDirectory = options.LastFolder;
            else
                ExtractDialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (ExtractDialog.ShowDialog() == DialogResult.OK)
                ffBackend.ExtractRawFile(ExtractDialog.FileName, RawFiles.SelectedNode.Index);
        }

        private void EditSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;
        }

        //TODO: move to ffbackend.ExtractRawfiles, progressbar?!
        private async void ExtractAllGSCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            try
            {
                if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(FolderBrowserDialog.SelectedPath))
                        Directory.CreateDirectory(FolderBrowserDialog.SelectedPath);

                    LockInterface(true);
                    await Task.Run(() => { ffBackend.ExtractAllRawfiles(FolderBrowserDialog.SelectedPath); });
                    LockInterface(false);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GoToLineBox.Maximum = SubStrCount(CodeBox.Text, "\r\n") + 1;

                 if (!isFastFileOpened)
                     return;
            
                currentRawFile.Contents = CodeBox.Text;
                RawfileInfo_UpdateSize();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void CodeBox_Click(object sender, EventArgs e)
        {
            try
            {
                RawfileInfo_UpdateCurrentLine();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void CodeBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                RawfileInfo_UpdateCurrentLine();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
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
            try
            {
                string[] dataFullStrings = e.Data.GetData("FileDrop") as string[];
                currentFFName = dataFullStrings[0];
                AnalyzeFastfile();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void PadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CodeBox.Focused)
                    return;

                if (currentRawFile.Size >= currentRawFile.OriginalSize)
                    throw new Exception("Rawfile size >= original size");

                int required = currentRawFile.OriginalSize - currentRawFile.Size;

                if (required < 2)
                    throw new Exception("Not enough space to place comment");

                string text = CodeBox.Text + "//";
                for (int i = 0; i < required - 2; ++i)
                    text += "/";
                CodeBox.Text = text;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void RawfileInfo_UpdateOriginalSize()
        {
            RawfileInfoSizeOriginal.Text = currentRawFile.OriginalSize.ToString();
        }

        private void RawfileInfo_UpdateSize()
        {
            RawfileInfoSize.Text = currentRawFile.Size.ToString();
        }

        private void RawfileInfo_UpdateFileName()
        {
            RawfileInfoFileName.Text = currentRawFile.Name;
        }

        private void RawfileInfo_UpdateCurrentLine()
        {
            GoToLineBox.Text = (CodeBox.GetLineFromCharIndex(CodeBox.SelectionStart) + 1).ToString();
        }

        private void RawfileInfo_Update()
        {
            RawfileInfo_UpdateCurrentLine();
            RawfileInfo_UpdateFileName();
            RawfileInfo_UpdateSize();
            RawfileInfo_UpdateOriginalSize();
        }

        private void StatusLine_Clear()
        {
            currentRawFile = new RawFileData();
            RawfileInfo_Update();
        }

        private void RawFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int rawIndex = (int)(RawFiles.SelectedNode.Nodes.Count == 0 ? RawFiles.SelectedNode.Parent.Tag : RawFiles.SelectedNode.Tag);
                currentRawFile = ffBackend.RawfileAtIndex(rawIndex);
                CodeBox.Text = currentRawFile.Contents;
                RawfileInfo_Update();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void RawFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                RawFiles.SelectedNode = e.Node;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SetWindowFileName("");
            this.Width = options.Width;
            this.Height = options.Height;

            try
            {
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
            catch (Exception ex)
            {
                HandleException(ex);
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
            //TODO: handle error and apply finally blocks to it instead of exiting.
        }

        /// <summary>
        /// Used to lock whole application interface.
        /// </summary>
        /// <param name="state">True for lock, false for unlock.</param>
        protected void LockInterface(bool state)
        {
            MenuStripLine.Enabled = !state;
            Tabs.Enabled = !state;
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
            try
            {
                logger.PrintLine("Getting update information.");
                updater.GetUpdateInfo();
            }
            catch(Exception ex)
            {
                HandleException(ex);
            }
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

        //TODO: remake it inside backend
        private void SaveAsFastfileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OpenZoneDialog.ShowDialog() != DialogResult.OK)
                return;

            //TODO: move to backend. All of it
            byte[] decompressed = File.ReadAllBytes(OpenZoneDialog.FileName);
            byte[] compressed = Ionic.Zlib.ZlibStream.CompressBuffer(decompressed);
            if (SaveFastfileDialog.ShowDialog() != DialogResult.OK)
                return;

            using (FileStream fs = new FileStream(SaveFastfileDialog.FileName, FileMode.Create))
            {
                fs.Write(Encoding.ASCII.GetBytes("IWffu100"), 0, 8);
                //DIRTY!
                fs.WriteByte(5);
                fs.WriteByte(0);
                fs.WriteByte(0);
                fs.WriteByte(0);
                fs.Write(compressed, 0, compressed.Length);
            }

            logger.PrintLine("Fastfile saved");
        }

        private async void ExportZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ExportZoneDialog.ShowDialog() != DialogResult.OK)
                return;

            if (File.Exists(ExportZoneDialog.FileName))
                File.Delete(ExportZoneDialog.FileName);

            SetProgressBarPercentage(100); //TODO: check if this progress works incorrect.
            await Task.Run(() => { ffBackend.ExportZone(ExportZoneDialog.FileName); });
            SetProgressBarPercentage(0);
        }
    }
}
