using Ionic.Zlib;
using System.Text;
using System.IO;

namespace FFViewer_cs
{
    class FFBackend
    {
        public FFData GetFFData(string filePath)
        {
            FFData result = new FFData(filePath);
            result.Parse();
            return result;
        }

        public ZoneData GetZoneData(FFData ffData)
        {
            ZoneData result = new ZoneData(ffData.CompressedZone);
            result.DecompressZlib();
            result.ParseFastfile();
            return result;
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
                if (!rawFile.Changed)
                    continue;

                if (rawFile.Size > rawFile.OriginalSize)
                    throw new InternalBufferOverflowException("Attempting to overrun rawfile data: " + rawFile.Name);

                zoneData.DecompressedData = ByteHandling.SetBytes(zoneData.DecompressedData, rawFile.ContentsOffset, rawFile.OriginalSize, 0x00);
                zoneData.DecompressedData = ByteHandling.ReplaceBytes(zoneData.DecompressedData, rawFile.ContentsOffset, ASCIIEncoding.ASCII.GetBytes(rawFile.Contents));
            }

            return zoneData;
        }

        public FFData WriteZoneData(FFData ffData, ZoneData zoneData)
        {
            ffData.CompressedZone = CompressZone(zoneData.DecompressedData);
            return ffData;
        }

        public void WriteFastFile(FFData ffData)
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
    }
}
