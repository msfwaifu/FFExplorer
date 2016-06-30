using System.Collections.Generic;
using System.Text;
using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class AssetData
    {
        event HandleException_d OnExceptionRaised;
        List<RawFileData> _RawFiles = new List<RawFileData>();

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="zoneData"></param>
        public AssetData(ZoneData zoneData)
        {
            byte[] gscFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'c', '\0' });
            byte[] gsxFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'x', '\0' });
            byte[] rmbFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'r', 'm', 'b', '\0' });
            byte[] cfgFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'c', 'f', 'g', '\0' });
            byte[] defFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'd', 'e', 'f', '\0' });
            //byte[] csvFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'c', 's', 'v', (char)0 });

            AddRawFiles(zoneData, gsxFormat);
            AddRawFiles(zoneData, gscFormat);
            AddRawFiles(zoneData, rmbFormat);
            AddRawFiles(zoneData, defFormat);
            AddRawFiles(zoneData, cfgFormat);
        }

        /// <summary>
        /// NI
        /// </summary>
        public List<RawFileData> RawFiles
        {
            get
            {
                return _RawFiles;
            }
            set
            {
                _RawFiles = value;
            }
        }

        /*public List<StringTableData> StringTables
        {
            get
            {
                return _StringTables;
            }
            set
            {
                _StringTables = value;
            }
        }

        public List<LocalizedStringsData> LocalizedStrings
        {
            get
            {
                return _LocalizedStrings;
            }
            set
            {
                _LocalizedStrings = value;
            }
        }*/

        private void AddRawFiles(ZoneData zoneData, byte[] extension)
        {
            try
            {
                int count = ByteHandling.CountBytes(zoneData.DecompressedData, extension);
                int offset = 0;
                for (int i = 0; i < count; ++i)
                {
                    offset = ByteHandling.FindBytes(zoneData.DecompressedData, extension, offset + 1) + 1;
                    int startOfNameOffset = ByteHandling.FindByteBackward(zoneData.DecompressedData, 0xFF, offset) + 1;
                    int endOfNameOffset = ByteHandling.FindByte(zoneData.DecompressedData, 0x00, offset);
                    int assetSize = ByteHandling.GetDWORD(zoneData.DecompressedData, startOfNameOffset - 8);
                    string assetName = ByteHandling.GetString(zoneData.DecompressedData, startOfNameOffset, endOfNameOffset);
                    int startOfContents = endOfNameOffset + 1;
                    int endOfContents = ByteHandling.FindByte(zoneData.DecompressedData, 0x00, startOfContents);
                    string contents = ByteHandling.GetString(zoneData.DecompressedData, startOfContents, endOfContents);

                    _RawFiles.Add(new RawFileData(assetName, startOfNameOffset, contents, assetSize, startOfContents));
                }
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
                //MessageBox.Show("При получении информации о Rawfile'ах произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}