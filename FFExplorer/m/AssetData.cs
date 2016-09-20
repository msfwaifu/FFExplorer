using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FFExplorer
{
    class AssetData
    {
        public AssetData(ZoneData zoneData)
        {
            zd = zoneData;
        }

        public void AddKnownAssets()
        {
            byte[] gscFormat = Encoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'c', '\0' });
            byte[] gsxFormat = Encoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'x', '\0' });
            byte[] rmbFormat = Encoding.ASCII.GetBytes(new char[] { '.', 'r', 'm', 'b', '\0' });
            byte[] cfgFormat = Encoding.ASCII.GetBytes(new char[] { '.', 'c', 'f', 'g', '\0' });
            byte[] defFormat = Encoding.ASCII.GetBytes(new char[] { '.', 'd', 'e', 'f', '\0' });

            rawfileIndex = 0;
            AddRawFiles(gsxFormat);
            AddRawFiles(gscFormat);
            AddRawFiles(rmbFormat);
            AddRawFiles(defFormat);
            AddRawFiles(cfgFormat);

            AddLocalizedStrings();

            zd = null;
        }

        void AddRawFiles(byte[] extension)
        {
            int offset = ByteHandling.FindBytes(zd.DecompressedData, extension);
            while(offset != -1)
            {
                int startOfNameOffset = ByteHandling.FindByteBackward(zd.DecompressedData, 0xFF, offset + 1) + 1;
                int endOfNameOffset = ByteHandling.FindByte(zd.DecompressedData, 0x00, offset + 1);
                int assetSize = ByteHandling.GetDword(zd.DecompressedData, startOfNameOffset - 8);
                string assetName = ByteHandling.GetString(zd.DecompressedData, startOfNameOffset, endOfNameOffset);
                int startOfContents = endOfNameOffset + 1;
                int endOfContents = ByteHandling.FindByte(zd.DecompressedData, 0x00, startOfContents);
                string contents = ByteHandling.GetString(zd.DecompressedData, startOfContents, endOfContents);
    
                rawFiles.Add(new RawFileData(rawfileIndex, assetName, startOfNameOffset, contents, assetSize, startOfContents));
                ++rawfileIndex;
                offset = ByteHandling.FindBytes(zd.DecompressedData, extension, offset + 1);
            }
        }

        public void Clear()
        {
            rawFiles.Clear();
        }

        public List<RawFileData> RawFiles
        {
            get
            {
                return rawFiles;
            }
        }

        public List<LocalizedStringData> LocalizedString
        {
            get
            {
                return locStrings;
            }
        }

        public string[] LocalizedStringPrefixes
        {
            get
            {
                return locStringsPrefixes;
            }
            set
            {
                locStringsPrefixes = value;
            }
        }


        //TODO: save and load set of prefixes to options.
        private void AddLocalizedStrings()
        {
            HashSet<string> hs;
            if(locStringsPrefixes.Length == 0)
                 hs = new HashSet<string>();
            else
                hs = new HashSet<string>(locStringsPrefixes.AsEnumerable());

            bool setUpdated = false;
            foreach (RawFileData rawfile in rawFiles)
            {
                int offset = rawfile.Contents.IndexOf("&\"");
                while (offset != -1)
                {
                    if (rawfile.Contents[offset + 2] != '\"')
                    {
                        int underlineOffset = rawfile.Contents.IndexOf("_", offset);
                        string s = rawfile.Contents.Substring(offset + 2, underlineOffset - offset - 2);
                        string rn = rawfile.Name;
                        hs.Add(s);
                        setUpdated = true;
                    }
                    offset = rawfile.Contents.IndexOf("&\"", offset + 2);
                }
            }
            if (setUpdated)
                locStringsPrefixes = hs.ToArray();
                
            int locStringIndex = 0;
            foreach (string prefix in hs)
            {
                byte[] seek = Encoding.ASCII.GetBytes(string.Format(":{0}:", prefix));
                seek[0] = 0;
                seek[seek.Length - 1] = (byte)'_';
                int offset = ByteHandling.FindBytes(zd.DecompressedData, seek);
                while (offset != -1)
                {
                    int startOfValueOffset = ByteHandling.FindByteBackward(zd.DecompressedData, 0xFF, offset) + 1;
                    int endOfKeyOffset = ByteHandling.FindByte(zd.DecompressedData, 0x00, offset + 1);
                    string value = ByteHandling.GetString(zd.DecompressedData, startOfValueOffset, offset);
                    string key = ByteHandling.GetString(zd.DecompressedData, offset + 1, endOfKeyOffset);
                    locStrings.Add(new LocalizedStringData(locStringIndex, prefix, key, value, offset + 1, startOfValueOffset));
                    ++locStringIndex;
                    offset = ByteHandling.FindBytes(zd.DecompressedData, seek, offset + 1);
                }
            }
        }

        ZoneData zd;
        string[] locStringsPrefixes;
        List<RawFileData> rawFiles = new List<RawFileData>();
        List<LocalizedStringData> locStrings = new List<LocalizedStringData>();
        int rawfileIndex;
    }
}