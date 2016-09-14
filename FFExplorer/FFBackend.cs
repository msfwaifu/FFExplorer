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

namespace FFExplorer
{

    delegate void RawFileDiscovered_d(int index, string name, string originalName, int originalSize);
    delegate void LocalizedStringDiscovered_d(int index, string prefix, string key);
    delegate string[] LocalizedStringPrefixesRequest_d();
    delegate void LocalizedStringPrefixesUpdated_d(string[] prefixes);

    class FFBackend
    {
        public event SetProgressBarPercentage_d OnProgressChanged;
        public event RawFileDiscovered_d OnRawfileDiscovered;
        public event LocalizedStringDiscovered_d OnLocalizedStringDiscovered;
        public event LocalizedStringPrefixesRequest_d OnLocalizedStringPrefixRequest;
        public event LocalizedStringPrefixesUpdated_d OnLocalizedStringPrefixesUpdated;        

        FFData ffData;
        ZoneData zoneData;
        AssetData assetData;

        public void OpenFastfile(string path)
        {
            OnProgressChanged?.Invoke(20);
            ffData = GetFFData(path);

            OnProgressChanged?.Invoke(40);
            zoneData = GetZoneData();

            OnProgressChanged?.Invoke(60);
            assetData = GetAssetData();

            OnProgressChanged?.Invoke(80);
            foreach (RawFileData r in assetData.RawFiles)
                OnRawfileDiscovered?.Invoke(r.Index, r.Name, r.OriginalName, r.OriginalSize);

            OnProgressChanged?.Invoke(100);
            foreach (LocalizedStringData ls in assetData.LocalizedString)
                OnLocalizedStringDiscovered?.Invoke(ls.Index, ls.Prefix, ls.Key);

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

            OnProgressChanged?.Invoke(0);
        }

        private FFData GetFFData(string filePath)
        {
            FFData result = new FFData(filePath);
            result.Parse();
            return result;
        }

        private ZoneData GetZoneData()
        {
            ZoneData result = new ZoneData(ffData.CompressedZone);
            result.DecompressZlib();
            result.ParseZoneHeader();
            return result;
        }

        private AssetData GetAssetData()
        {
            AssetData result = new AssetData(zoneData);
            result.LocalizedStringPrefixes = OnLocalizedStringPrefixRequest?.Invoke();
            if (result.LocalizedStringPrefixes == null)
                result.LocalizedStringPrefixes = new string[0];

            result.AddKnownAssets();
            OnLocalizedStringPrefixesUpdated?.Invoke(result.LocalizedStringPrefixes);
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

        //TODO: write localized strings asset
        private void WriteAssetData()
        {
            foreach (RawFileData rawFile in assetData.RawFiles)
            {
                if (!rawFile.Changed)
                    continue;

                if (rawFile.Size > rawFile.OriginalSize)
                    throw new InternalBufferOverflowException("Attempting to overrun rawfile data: " + rawFile.Name);

                zoneData.DecompressedData = ByteHandling.SetBytes(zoneData.DecompressedData, rawFile.ContentsOffset, rawFile.OriginalSize, 0x00);
                zoneData.DecompressedData = ByteHandling.ReplaceBytes(zoneData.DecompressedData, rawFile.ContentsOffset, Encoding.ASCII.GetBytes(rawFile.Contents));
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
            RawFileData result = assetData.RawFiles.Find(r => r.Index == index);
            if(result == null)
                throw new FileNotFoundException("Rawfile with index " + index + " not found");
            return result;
        }

        private LocalizedStringData FindLocalizedString(int index)
        {
            LocalizedStringData result = assetData.LocalizedString.Find(r => r.Index == index);
            if (result == null)
                throw new FileNotFoundException("Localizedstring with index " + index + " not found");
            return result;
        }

        public void ResetLocalizedString(int index)
        {
            LocalizedStringData d = FindLocalizedString(index);
            d.Key = d.KeyOriginal;
            d.Value = d.ValueOriginal;
        }

        public string GetLocalizedStringKey(int index)
        {
            return FindLocalizedString(index).Key;
        }

        public string GetLocalizedStringValue(int index)
        {
            return FindLocalizedString(index).Value;
        }

        public int GetLocalizedStringKeyMaxSize(int index)
        {
            return FindLocalizedString(index).KeyMaxLength;
        }

        public int GetLocalizedStringValueMaxSize(int index)
        {
            return FindLocalizedString(index).ValueMaxLength;
        }

        public int GetLocalizedStringKeyOffset(int index)
        {
            return FindLocalizedString(index).KeyOffset;
        }

        public int GetLocalizedStringValueOffset(int index)
        {
            return FindLocalizedString(index).ValueOffset;
        }

        public void SetLocalizedStringKey(int index, string key)
        {
            FindLocalizedString(index).Key = key;
        }

        public void SetLocalizedStringValue(int index, string value)
        {
            FindLocalizedString(index).Value = value;
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

        public void DecompressZlibArchive(string input, string output)
        {
            OnProgressChanged?.Invoke(10);
            byte[] data = File.ReadAllBytes(input);

            OnProgressChanged?.Invoke(90);
            data = ZLibDeflate(data);

            OnProgressChanged?.Invoke(100);
            File.WriteAllBytes(output, data);

            OnProgressChanged?.Invoke(0);
        }

        public void CompressZlibArchive(string input, string output)
        {
            OnProgressChanged?.Invoke(10);
            byte[] data = File.ReadAllBytes(input);

            OnProgressChanged?.Invoke(90);
            data = ZlibInflate(data);

            OnProgressChanged?.Invoke(100);
            File.WriteAllBytes(output, data);

            OnProgressChanged?.Invoke(0);
        }
    }
}
