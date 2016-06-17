using Ionic.Zlib;
using System.Text;
using System.IO;
using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    class FFBackend
    {
        public static FFData GetFFData(string filePath)
        {
            return new FFData(filePath);
        }

        public static ZoneData GetZoneData(FFData ffData)
        {
            return new ZoneData(ffData.ZoneData);
        }

        public static AssetData GetAssetData(ZoneData zoneData)
        {
            return new AssetData(zoneData);
        }

        public static byte[] DecompressZone(byte[] compressedZone)
        {
            return ZlibStream.UncompressBuffer(compressedZone);
        }

        public static byte[] CompressZone(byte[] decompressedZone)
        {
            return ZlibStream.CompressBuffer(decompressedZone);
        }

        public static ZoneData WriteAssetData(ZoneData zoneData, AssetData assetData)
        {
            try
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
            }
            catch(Exception ex)
            {
                MessageBox.Show("При записи информации о Asset файлах произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }

            return zoneData;
        }

        public static FFData WriteZoneData(FFData ffData, ZoneData zoneData)
        {
            try
            {
                ffData.ZoneData = CompressZone(zoneData.DecompressedData);
            }
            catch(Exception ex)
            {
                MessageBox.Show("При записи Zone произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }

            return ffData;
        }

        public static void WriteFastFile(FFData ffData)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show("При записи Fastfile произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
    }
}
