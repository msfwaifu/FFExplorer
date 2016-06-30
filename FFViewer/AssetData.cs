using System.Collections.Generic;
using System.Text;

namespace FFViewer_cs
{
    /// <summary>
    /// A class used to analyze and construct lists contains various assets stored in fastfile.
    /// </summary>
    public class AssetData
    {
        List<RawFileData> rawFiles = new List<RawFileData>();

        /// <summary>
        /// Constructs <see cref="AssetData"/> class instance according to passed <see cref="ZoneData"/>.
        /// </summary>
        /// <param name="zoneData">Uncompressed and extracted fastfile.</param>
        public AssetData(ZoneData zoneData)
        {
            zd = zoneData;
        }

        /// <summary>
        /// Adds known assets to various lists.
        /// </summary>
        public void AddKnownAssets()
        {
            byte[] gscFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'c', '\0' });
            byte[] gsxFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'x', '\0' });
            byte[] rmbFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'r', 'm', 'b', '\0' });
            byte[] cfgFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'c', 'f', 'g', '\0' });
            byte[] defFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'd', 'e', 'f', '\0' });
            //byte[] csvFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'c', 's', 'v', '\0' });

            AddRawFiles(zd, gsxFormat);
            AddRawFiles(zd, gscFormat);
            AddRawFiles(zd, rmbFormat);
            AddRawFiles(zd, defFormat);
            AddRawFiles(zd, cfgFormat);
        }

        /// <summary>
        /// Gets list of rawfiles stored in fastfile.
        /// </summary>
        public List<RawFileData> RawFiles
        {
            get
            {
                return rawFiles;
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
            int offset = ByteHandling.FindBytes(zoneData.DecompressedData, extension, 0);
            while(offset != -1)
            {
                int startOfNameOffset = ByteHandling.FindByteBackward(zoneData.DecompressedData, 0xFF, offset + 1) + 1;
                int endOfNameOffset = ByteHandling.FindByte(zoneData.DecompressedData, 0x00, offset + 1);
                int assetSize = ByteHandling.GetDword(zoneData.DecompressedData, startOfNameOffset - 8);
                string assetName = ByteHandling.GetString(zoneData.DecompressedData, startOfNameOffset, endOfNameOffset);
                int startOfContents = endOfNameOffset + 1;
                int endOfContents = ByteHandling.FindByte(zoneData.DecompressedData, 0x00, startOfContents);
                string contents = ByteHandling.GetString(zoneData.DecompressedData, startOfContents, endOfContents);
    
                rawFiles.Add(new RawFileData(assetName, startOfNameOffset, contents, assetSize, startOfContents));
                offset = ByteHandling.FindBytes(zoneData.DecompressedData, extension, offset + 1);
            }
        }

        ZoneData zd;
    }
}