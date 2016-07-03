using System.Collections.Generic;
using System.Text;

namespace FFViewer_cs
{
    class AssetData
    {
        public AssetData(ZoneData zoneData)
        {
            zd = zoneData;
        }

        public void AddKnownAssets()
        {
            byte[] gscFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'c', '\0' });
            byte[] gsxFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'g', 's', 'x', '\0' });
            byte[] rmbFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'r', 'm', 'b', '\0' });
            byte[] cfgFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'c', 'f', 'g', '\0' });
            byte[] defFormat = ASCIIEncoding.ASCII.GetBytes(new char[] { '.', 'd', 'e', 'f', '\0' });

            AddRawFiles(zd, gsxFormat);
            AddRawFiles(zd, gscFormat);
            AddRawFiles(zd, rmbFormat);
            AddRawFiles(zd, defFormat);
            AddRawFiles(zd, cfgFormat);
        }

        void AddRawFiles(ZoneData zoneData, byte[] extension)
        {
            int offset = ByteHandling.FindBytes(zoneData.DecompressedData, extension);
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

        public void Clear()
        {
            zd.Clear();
            rawFiles.Clear();
        }

        public List<RawFileData> RawFiles
        {
            get
            {
                return rawFiles;
            }
        }

        ZoneData zd;
        List<RawFileData> rawFiles = new List<RawFileData>();
    }
}