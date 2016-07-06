/*
 * TARGET: changing backend logic must not affect form logic.
 * 
 * Fastfile loading scheme:
 *      FFData: get filepath, determine ff type, ffversion, save compressed buffer
 *      ZoneData: decompresses buffer, parses zone file header.
 *      AssetData: seek in decompressed zone assets, fill its assets fields.
 *      
 * Fastfile saving scheme:
 *      AssetData: update assets in decompressed data.
 *      ZoneData: compresses buffer.
 *      FFData: applies loaded header, saves file.
 */

using Ionic.Zlib;
using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FFViewer_cs
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
    /// <param name="originalName"></param>
    /// <param name="originalSize"></param>
    public delegate void RawFileDiscovered_d(int index, string name, string originalName, int originalSize);


    class FFBackend
    {
        public event SetProgressBarPercentage_d OnProgressChanged;
        public event RawFileDiscovered_d OnRawfileDiscovered;

        FFData ffData;
        ZoneData zoneData;
        AssetData assetData;

        public void OpenFastfile(string path)
        {
            OnProgressChanged?.Invoke(33);
            ffData = GetFFData(path);

            OnProgressChanged?.Invoke(66);
            zoneData = GetZoneData();

            OnProgressChanged?.Invoke(100);
            assetData = GetAssetData();            

            for (int i = 0; i < assetData.RawFiles.Count; ++i)
                OnRawfileDiscovered?.Invoke(assetData.RawFiles[i].Index, assetData.RawFiles[i].Name, assetData.RawFiles[i].OriginalName, assetData.RawFiles[i].OriginalSize);

            OnProgressChanged?.Invoke(0);
        }

        public void SaveFastfile()
        {
            OnProgressChanged?.Invoke(33);
            WriteAssetData();

            OnProgressChanged?.Invoke(66);
            WriteZoneData();

            OnProgressChanged?.Invoke(100);
            WriteFastFile();
        }

        //TODO: I dont like its 'new' - cleanup + parse again each time instead of 'new'
        private FFData GetFFData(string filePath)
        {
            FFData result = new FFData(filePath);
            result.Parse();
            return result;
        }

        //TODO: I dont like its 'new' - cleanup + parse again each time instead of 'new'
        private ZoneData GetZoneData()
        {
            ZoneData result = new ZoneData(ffData.CompressedZone);
            result.DecompressZlib();
            result.ParseZoneHeader();
            return result;
        }

        //TODO: I dont like its 'new' - cleanup + parse again each time instead of 'new'
        private AssetData GetAssetData()
        {
            AssetData result = new AssetData(zoneData);
            result.AddKnownAssets();
            return result;
        }

        private byte[] ZLibDeflate(byte[] compressed)
        {
            return ZlibStream.UncompressBuffer(compressed);
        }

        private byte[] ZlibInflate(byte[] decompressedZone)
        {
            return ZlibStream.CompressBuffer(decompressedZone);
        }

        private void WriteAssetData()
        {
            foreach (RawFileData rawFile in assetData.RawFiles)
            {
                if (!rawFile.Changed)
                    continue;

                if (rawFile.Size > rawFile.OriginalSize)
                    throw new InternalBufferOverflowException("Attempting to overrun rawfile data: " + rawFile.Name);

                zoneData.DecompressedData = ByteHandling.SetBytes(zoneData.DecompressedData, rawFile.ContentsOffset, rawFile.OriginalSize, 0x00);
                zoneData.DecompressedData = ByteHandling.ReplaceBytes(zoneData.DecompressedData, rawFile.ContentsOffset, ASCIIEncoding.ASCII.GetBytes(rawFile.Contents));
            }
        }

        private void WriteZoneData()
        {
            ffData.CompressedZone = ZlibInflate(zoneData.DecompressedData);
        }

        public void WriteFastFile()
        {
            using (FileStream fs = new FileStream(ffData.FilePath, FileMode.Create))
            {
                fs.Write(ffData.Header, 0, ffData.Header.Length);
                fs.Write(ffData.Version, 0, 4);
                fs.Write(ffData.CompressedZone, 0, ffData.CompressedZone.Length);

                int nullsSize = ffData.OriginalSize - (ffData.CompressedZone.Length + 12);
                nullsSize = nullsSize > 0 ? nullsSize : 1;
                byte[] nulls = new byte[nullsSize];

                fs.Write(nulls, 0, nullsSize);

                fs.Flush();
            }
        }

        public void ExportZone(string path)
        {
            if (zoneData.DecompressedData.Length == 0)
                throw new Exception("No opened fastfile");

            File.WriteAllBytes(path, zoneData.DecompressedData);
        }

        public int RawFilesCount
        {
            get
            {
                return assetData.RawFiles.Count;
            }
        }

        public string FFPath
        {
            get
            {
                return ffData.FilePath;
            }
        }

        public void ExtractAllRawfiles(string baseDir)
        {
            for (int i = 0; i < assetData.RawFiles.Count; ++i)
            {
                string filePath = baseDir + "\\" + assetData.RawFiles[i].Name.Replace('/', '\\');

                int progress = (i * 100) / assetData.RawFiles.Count;
                OnProgressChanged?.Invoke(progress + 1);
                OnProgressChanged?.Invoke(progress);

                ExtractRawFile(filePath, i);
            }
        }

        public void ExtractRawFile(string filePath, int index)
        {
            string fileDir = filePath.Substring(0, filePath.LastIndexOf('\\'));

            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, assetData.RawFiles[index].Contents);
        }

        public void Cleanup()
        {
            ffData.Clear();
            zoneData.Clear();
            assetData.Clear();
        }

        private RawFileData FindRawfile(int index)
        {
            foreach (RawFileData r in assetData.RawFiles)
            {
                if (r.Index == index)
                    return r;
            }
            throw new FileNotFoundException("Rawfile with index " + index + " not found");
        }

        public int GetRawfileSize(int index)
        {
            return FindRawfile(index).Size;            
        }

        public int GetRawfileOriginalSize(int index)
        {
            return FindRawfile(index).OriginalSize;
        }

        public string GetRawfileContents(int index)
        {
            return FindRawfile(index).Contents;
        }

        public void SetRawfileContents(int index, string text)
        {
            FindRawfile(index).Contents = text;
        }

        public string GetRawfileName(int index)
        {
            return FindRawfile(index).Name;
        }

        public void PadRawfile(int index)
        {
            RawFileData r = FindRawfile(index);

            if (r.Size >= r.OriginalSize)
                throw new Exception("Rawfile size >= original size");

            int required = r.OriginalSize - r.Size;

            if (required < 2)
                throw new Exception("Not enough space to place comment");

            string text = r.Contents + "//";
            for (int i = 0; i < required - 2; ++i)
                text += "/";

            r.Contents = text;
        }

        public void RawfileCheckSyntax(int index)
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
        */
        }

        public void RawfileRemoveComments(int index)
        {
            RawFileData r = FindRawfile(index);
            string[] lines = r.Contents.Split(new char[] { '\r', '\n' });

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

            r.Contents = text;
        }

        public void SaveAsFastfile(string what, string where)
        {
            OnProgressChanged?.Invoke(33);
            byte[] decompressed = File.ReadAllBytes(what);

            OnProgressChanged?.Invoke(66);
            byte[] compressed = ZlibInflate(decompressed);

            OnProgressChanged?.Invoke(100);
            using (FileStream fs = new FileStream(where, FileMode.Create))
            {
                fs.Write(FFData.HeaderIW3Unsigned, 0, FFData.HeaderIW3Unsigned.Length);
                fs.Write(FFData.HeaderIW3VersionUnsigned, 0, FFData.HeaderIW3VersionUnsigned.Length);
                fs.Write(compressed, 0, compressed.Length);
            }
            OnProgressChanged?.Invoke(0);
        }
    }
}
