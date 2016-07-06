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

        //TODO: check if async required
        public /*async*/ void OpenFastfile(string path)
        {
            OnProgressChanged?.Invoke(0);

            //ffData = await Task<FFData>.Run(() => { return GetFFData(path); });
            ffData = GetFFData(path);
            OnProgressChanged?.Invoke(33);

            //zoneData = await Task<ZoneData>.Run(() => { return ffBackend.GetZoneData(ffInfo); });
            zoneData = GetZoneData();
            OnProgressChanged?.Invoke(66);

            // assetData = await Task<AssetData>.Run(() => { return ffBackend.GetAssetData(zoneInfo); });
            assetData = GetAssetData();
            OnProgressChanged?.Invoke(100);

            for (int i = 0; i < assetData.RawFiles.Count; ++i)
                OnRawfileDiscovered?.Invoke(assetData.RawFiles[i].Index, assetData.RawFiles[i].Name, assetData.RawFiles[i].OriginalName, assetData.RawFiles[i].OriginalSize);
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

        //TODO!
        public void ExportZone(string path)
        {

        }

        public RawFileData RawfileAtIndex(int index)
        {
            foreach (RawFileData r in assetData.RawFiles)
                if (r.Index == index)
                    return r;

            return null;
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
    }
}
