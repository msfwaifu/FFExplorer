using Ionic.Zlib;
using System.Text;
using System.IO;

namespace FFViewer_cs
{
    class FFBackend
    {
        public FFData GetFFData(string filePath)
        {
            return new FFData(filePath);
        }

        public ZoneData GetZoneData(FFData ffData)
        {
            return new ZoneData(ffData.ZoneData);
        }

        public AssetData GetAssetData(ZoneData zoneData)
        {
            AssetData result = new AssetData(zoneData);
            result.AddKnownAssets();
            return result;
        }

        public byte[] DecompressZone(byte[] compressedZone)
        {
            return ZlibStream.UncompressBuffer(compressedZone);
        }

        public byte[] CompressZone(byte[] decompressedZone)
        {
            return ZlibStream.CompressBuffer(decompressedZone);
        }

        public ZoneData WriteAssetData(ZoneData zoneData, AssetData assetData)
        {
            foreach (RawFileData rawFile in assetData.RawFiles)
            {
                if (!rawFile.IsChanged)
                    continue;
    
                if (rawFile.ActualSize <= rawFile.OriginalSize)
                {
                    zoneData.DecompressedData = ByteHandling.SetBytes(zoneData.DecompressedData, rawFile.ContentsOffset, rawFile.OriginalSize, 0x00);
                    zoneData.DecompressedData = ByteHandling.ReplaceBytes(zoneData.DecompressedData, rawFile.ContentsOffset, ASCIIEncoding.ASCII.GetBytes(rawFile.Contents));
                }
            }

            return zoneData;
        }

        public FFData WriteZoneData(FFData ffData, ZoneData zoneData)
        {
            ffData.ZoneData = CompressZone(zoneData.DecompressedData);
            return ffData;
        }

        public void WriteFastFile(FFData ffData)
        {
            FileStream fs = new FileStream(ffData.Name, FileMode.Create);                
                
            fs.Write(ffData.Header, 0, ffData.Header.Length);
            fs.Write(ffData.Version, 0, 4);
            fs.Write(ffData.ZoneData, 0, ffData.ZoneData.Length);

            int nullsSize = ffData.Size - (ffData.ZoneData.Length + 12);
            nullsSize = nullsSize > 0 ? nullsSize : 1;
            byte[] nulls = new byte[nullsSize];

            fs.Write(nulls, 0, nullsSize);

            fs.Flush();
            fs.Close();
        }
    }
}
