using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FFViewer_cs
{
    public delegate void HandleException_d(Exception ex);

    public partial class Form1 : Form
    {
        bool isFastFileOpened;
        string currentAppDirectory;
        string currentFFName;
        string currentRawFileName;
        int currentRawFileOriginalSize;
        int currentRawFileNewSize;
        int codeBoxLine;
        int codeBoxCol;

        FFData ffInfo;
        ZoneData zoneInfo;
        AssetData assetInfo;
        TreeNode[] rawFileNodes;
        //string FFViewerVersion;
        public OptionsHandler options;
 
        OpenFileDialog OpenDialog;
        SaveFileDialog SaveDialog;
        FolderBrowserDialog DirectoryDialog;

        About dlgAbout;
        Find dlgFind;
        GotoLine dlgGoto;
        Options dlgOptions;
        Wait dlgWait;

        public Form1()
        {
            InitializeComponent();
            currentAppDirectory = Application.StartupPath;
            options = new OptionsHandler(currentAppDirectory, HandleException);

            //
            isFastFileOpened = false;
            currentFFName = "";
            //
            //FFViewerVersion = "1.0";

            OpenDialog = new OpenFileDialog();
            SaveDialog = new SaveFileDialog();
            DirectoryDialog = new FolderBrowserDialog();

            dlgAbout = new About();
            dlgFind = new Find();
            dlgGoto = new GotoLine();
            dlgOptions = new Options();
            dlgWait = new Wait();

            dlgAbout.Owner = this;
            dlgFind.Owner = this;
            dlgGoto.Owner = this;
            dlgOptions.Owner = this;
            dlgWait.Owner = this;

            StatusLine_Clear();
            SaveFFToolStripMenuItem.Enabled = false;
            CloseFFToolStripMenuItem.Enabled = false;
        }

        private void SetWindowName(string name)
        {
            Text = name;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            bool handled = false;
            if (CodeBox.Focused)
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.F)
                    {
                        //dlgFind.OpenWithText(CodeBox.SelectedText);
                        FindToolStripMenuItem.PerformClick();
                        handled = true;
                    }
                    if (e.KeyCode == Keys.G)
                    {
                        dlgGoto.Show();
                        handled = true;
                    }
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
                    /*if (e.KeyCode == Keys.V)
                        CodeBox.Paste();*/
                    //TODO:
                    if (e.KeyCode == Keys.Z)
                        handled = true;
                    if (e.KeyCode == Keys.Y)
                        handled = true;
                }
                if (e.KeyCode == Keys.F3)
                {
                    FindNextToolStripMenuItem_Click("", new EventArgs());
                    handled = true;
                }
            }
            if (e.Control)
            {
                if (e.KeyCode == Keys.O)
                {
                    if (OpenFFToolStripMenuItem.Enabled)
                        OpenFFToolStripMenuItem.PerformClick(); //AnalyzeFastfile();
                    handled = true;
                }
                if (e.KeyCode == Keys.S)
                {
                    if (SaveFFToolStripMenuItem.Enabled)
                        SaveFFToolStripMenuItem.PerformClick(); //SaveFFToolStripMenuItem_Click("", new EventArgs());
                    handled = true;
                }
                if (e.KeyCode == Keys.Q)
                {
                    if (CloseFFToolStripMenuItem.Enabled)
                        CloseFFToolStripMenuItem.PerformClick(); //CloseFFToolStripMenuItem_Click("", new EventArgs());
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

        private void AnalyzeFastfile()
        {
            if(isFastFileOpened)
                CloseFFToolStripMenuItem_Click(this, new EventArgs());

            try
            {
                if (currentFFName == "")
                {
                    OpenDialog.Title = "Открыть .FF";
                    OpenDialog.Filter = ".FF файлы(*.ff)|*.ff";
                    OpenDialog.FileName = "";
                    OpenDialog.FilterIndex = 1;

                    if (options.RememberLastFolder)
                        OpenDialog.InitialDirectory = options.LastFolder;
                    else
                        OpenDialog.InitialDirectory = Directory.GetCurrentDirectory();

                    OpenDialog.RestoreDirectory = true;
                    if (OpenDialog.ShowDialog() == DialogResult.OK && OpenDialog.CheckFileExists)
                        currentFFName = OpenDialog.FileName;
                    else
                        return;
                }

                if (File.GetAttributes(currentFFName) == FileAttributes.ReadOnly)
                {
                    MessageBox.Show("Файл не может быть открыт из-за флага \"Только чтение\"", "Ошибка при открытии файла", MessageBoxButtons.OK);
                    currentFFName = "";
                    return;
                }

                if (File.GetAttributes(currentFFName) == FileAttributes.Directory)
                {
                    MessageBox.Show("Файл не может быть открыт потому, что является директорией", "Ошибка при открытии файла", MessageBoxButtons.OK);
                    currentFFName = "";
                    return;
                }

                if (currentFFName.Substring(currentFFName.LastIndexOf("."), 3).ToLower() != ".ff")
                {
                    MessageBox.Show("Неверное расширение файла: " + currentFFName.Substring(currentFFName.LastIndexOf(".") + 1, 2), "Ошибка при открытии файла", MessageBoxButtons.OK);
                    currentFFName = "";
                    return;
                }

                dlgWait.SetState("Получение информации о Fastfile", 0);
                ffInfo = FFBackend.GetFFData(currentFFName);

                dlgWait.SetState("Получение информации о Zone файле", 25);
                zoneInfo = FFBackend.GetZoneData(ffInfo);

                dlgWait.SetState("Получение информации об Asset файлах", 50);
                assetInfo = FFBackend.GetAssetData(zoneInfo);

                options.LastFolder = ffInfo.Name.Substring(0, ffInfo.Name.LastIndexOf("\\"));
                SetWindowName("FF Viewer - [" + ffInfo.Name + "]");

                dlgWait.SetState("Заполнение списка Raw файлов", 75);

                rawFileNodes = new TreeNode[assetInfo.RawFiles.Count];
                for (int i = 0; i < assetInfo.RawFiles.Count; ++i)
                {
                    rawFileNodes[i] = new TreeNode();
                    rawFileNodes[i].Text = assetInfo.RawFiles[i].OriginalName;
                    rawFileNodes[i].Nodes.Add("Оригинальное название: " + assetInfo.RawFiles[i].OriginalName);
                    rawFileNodes[i].Nodes.Add("Новое название: " + assetInfo.RawFiles[i].NewName);
                    rawFileNodes[i].Nodes.Add("Оригинальный размер: " + assetInfo.RawFiles[i].OriginalSize);

                    RawFiles.Nodes.Add(rawFileNodes[i]);
                    Application.DoEvents();
                }

                isFastFileOpened = true;
                OpenFFToolStripMenuItem.Enabled = false;
                SaveFFToolStripMenuItem.Enabled = true;
                CloseFFToolStripMenuItem.Enabled = true;

                dlgWait.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При загрузке Fastfile'a произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void SaveFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            try
            {
                dlgWait.SetState("Запись информации об Asset файлах", 0);
                zoneInfo = FFBackend.WriteAssetData(zoneInfo, assetInfo);
                dlgWait.SetState("Запись Zone файла", 33);
                ffInfo = FFBackend.WriteZoneData(ffInfo, zoneInfo);
                dlgWait.SetState("Сохранение Fastfile'a", 66);
                FFBackend.WriteFastFile(ffInfo);

                StatusLine_Clear();
                dlgWait.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При сохранении Fastfile произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public int SubStrCount(string str, string substr)
        {
            if (str == "" || substr == "")
                return 0;

            try
            {
                if (str == "" || substr == "")
                    return 0;

                byte[] strBytes = ASCIIEncoding.ASCII.GetBytes(str.ToCharArray());
                byte[] substrBytes = ASCIIEncoding.ASCII.GetBytes(substr.ToCharArray());
                return ByteHandling.CountBytes(strBytes, substrBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подсчёте количество подстрок в строке:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return 0;
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

                    CodeBox.Text = "";
                    SetWindowName("FF Viewer");
                    
                    OpenFFToolStripMenuItem.Enabled = true;
                    SaveFFToolStripMenuItem.Enabled = false;
                    CloseFFToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При закрытии Fastfile произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("При удалении комментариев произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
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
            dlgAbout.Show();
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
                    Snippets.DropDownItems.Add(gsc.Name, null, new EventHandler(onClickCustomSnippets));
            }
            catch (Exception ex)
            {
                MessageBox.Show("При обновлении списка произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
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
            dlgFind.Show();
        }

        private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selectionStart = CodeBox.Text.IndexOf(CodeBox.SelectedText, CodeBox.SelectionStart + CodeBox.SelectionLength);
                if (selectionStart == -1)
                    selectionStart = CodeBox.Text.IndexOf(CodeBox.SelectedText, 0);
                CodeBox.SelectionStart = selectionStart;
                CodeBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При попытке найти следующий элемент произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void GotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgGoto.Show();
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
                MessageBox.Show("При вставке отрывка произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void ExportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;
            try
            {
                SaveDialog.Title = "Экспортировать файл";
                SaveDialog.Filter = "Все файлы(*.*)|*.*";

                if (assetInfo.RawFiles[RawFiles.SelectedNode.Index].NewName.Contains("/"))                    
                    SaveDialog.FileName = assetInfo.RawFiles[RawFiles.SelectedNode.Index].NewName.Substring(assetInfo.RawFiles[RawFiles.SelectedNode.Index].NewName.LastIndexOf("/") + 1);
                else
                    SaveDialog.FileName = assetInfo.RawFiles[RawFiles.SelectedNode.Index].NewName;

                SaveDialog.FilterIndex = 1;
                if (options.RememberLastFolder)
                    SaveDialog.InitialDirectory = options.LastFolder;
                else
                    SaveDialog.InitialDirectory = Directory.GetCurrentDirectory();

                SaveDialog.RestoreDirectory = true;
                if (SaveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (SaveDialog.CheckFileExists)
                        File.Delete(SaveDialog.FileName);

                    RawFileData selectedRaw = assetInfo.RawFiles[RawFiles.SelectedNode.Index];
                    File.WriteAllText(SaveDialog.FileName, selectedRaw.Contents);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("При экспорте файла произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void EditSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;
        }

        private void ExtractAllGSCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            try
            {
                DirectoryDialog.Description = "Укажите директорию для сохранения файлов";
                if (DirectoryDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(DirectoryDialog.SelectedPath))
                        Directory.CreateDirectory(DirectoryDialog.SelectedPath);

                    for(int i = 0; i < assetInfo.RawFiles.Count; ++i)
                    {
                        string filePath = DirectoryDialog.SelectedPath + "\\" + assetInfo.RawFiles[i].NewName.Replace('/', '\\');
                        string fileDir = filePath.Substring(0, filePath.LastIndexOf('\\'));

                        if (!Directory.Exists(fileDir))
                            Directory.CreateDirectory(fileDir);

                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        dlgWait.SetState("Экспорт \'"+ assetInfo.RawFiles[i].NewName +"\'", (i*100)/assetInfo.RawFiles.Count );

                        File.WriteAllText(filePath, assetInfo.RawFiles[i].Contents);
                    }
                }
                dlgWait.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При экспорте файлов произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
            if (!isFastFileOpened)
                return;

            try
            {
                int rawIndex = RawFiles.SelectedNode.Nodes.Count == 0 ? RawFiles.SelectedNode.Parent.Index : RawFiles.SelectedNode.Index;
                RawFileData selectedRaw = assetInfo.RawFiles[rawIndex];

                currentRawFileNewSize = CodeBox.Text.Length;
                selectedRaw.Contents = CodeBox.Text;
                selectedRaw.ActualSize = currentRawFileNewSize;
                selectedRaw.IsChanged = true;

                StatusLine_UpdateRawFileNewSize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При редактировании произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void CodeBox_Click(object sender, EventArgs e)
        {
            try
            {
                codeBoxLine = CodeBox.GetLineFromCharIndex(CodeBox.SelectionStart) + 1;
                codeBoxCol = CodeBox.SelectionStart - CodeBox.GetFirstCharIndexOfCurrentLine() + 1;
                StatusLine_UpdateLine();
                StatusLine_UpdateColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При обновлении произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void CodeBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                codeBoxLine = CodeBox.GetLineFromCharIndex(CodeBox.SelectionStart) + 1;
                codeBoxCol = CodeBox.SelectionStart - CodeBox.GetFirstCharIndexOfCurrentLine() + 1;
                StatusLine_UpdateLine();
                StatusLine_UpdateColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При обновлении произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
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
                MessageBox.Show("При переносе файла произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void PadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CodeBox.Focused)
                    return;

                if (currentRawFileNewSize >= currentRawFileOriginalSize)
                {
                    MessageBox.Show("Текущий размер файла больше или равен оригинальному.", "Ошибка", MessageBoxButtons.OK);
                    return;
                }

                int required = currentRawFileOriginalSize - currentRawFileNewSize;
                int numLines = required / 1020 + 1;
                int maxPortion = required % 1020 > 4 ? 1020 : 1010;
                string text = CodeBox.Text;
                for (int i = 0; i < numLines; ++i)
                {
                    int portion = required > maxPortion ? maxPortion : required;
                    text += "//";
                    for (int j = 0; j < portion - 4; ++j)
                        text += "/";
                    text += "\r\n";
                    required -= portion;
                }
                CodeBox.Text = text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("При заполнении файла произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void StatusLine_UpdateRawFileOriginalSize()
        {
            OldSizeLbl.Text = "Ориг. размер: " + currentRawFileOriginalSize.ToString();
        }

        private void StatusLine_UpdateRawFileNewSize()
        {
            NewSizeLbl.Text = "Новый размер: " + currentRawFileNewSize.ToString();
        }

        private void StatusLine_UpdateRawFileName()
        {
            OpenRawFile.Text = "Файл: " + currentRawFileName;
        }

        private void StatusLine_UpdateLine()
        {
            LnLbl.Text = "Строка: " + codeBoxLine.ToString();
        }

        private void StatusLine_UpdateColumn()
        {
            ColLbl.Text = "Колонка: " + codeBoxCol.ToString();
        }

        private void StatusLine_Update()
        {
            StatusLine_UpdateColumn();
            StatusLine_UpdateLine();
            StatusLine_UpdateRawFileName();
            StatusLine_UpdateRawFileNewSize();
            StatusLine_UpdateRawFileOriginalSize();
        }

        private void StatusLine_Clear()
        {
            currentRawFileName = "";
            codeBoxCol = 0;
            codeBoxLine = 0;
            currentRawFileNewSize = 0;
            currentRawFileOriginalSize = 0;
            StatusLine_Update();
        }

        private void RawFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int rawIndex = RawFiles.SelectedNode.Nodes.Count == 0 ? RawFiles.SelectedNode.Parent.Index : RawFiles.SelectedNode.Index;
                RawFileData selectedRaw = assetInfo.RawFiles[rawIndex];
                CodeBox.Text = selectedRaw.Contents;
                currentRawFileOriginalSize = selectedRaw.OriginalSize;
                currentRawFileNewSize = selectedRaw.Contents.Length;
                currentRawFileName = selectedRaw.NewName;

                StatusLine_UpdateRawFileOriginalSize();
                StatusLine_UpdateRawFileNewSize();
                StatusLine_UpdateRawFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При открытии файла произошла ошибка:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void RawFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                RawFiles.SelectedNode = e.Node;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SetWindowName("FF Viewer");
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
                MessageBox.Show("Ошибка при загрузке программы:\n" + ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            options.Width = this.Size.Width;
            options.Height = this.Size.Height;
        }

        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            Application.Exit();
        }
    }
}
