using System;
using System.IO;
using Ionic.Zlib;


namespace FFViewer_cs
{
    class ZoneData
    {
        public ZoneData(byte[] compressed)
        {
            compressedData = compressed;
        }

        public void DecompressZlib()
        {
            decompressedData = ZlibStream.UncompressBuffer(compressedData);
        }

        public void ParseFastfile()
        {
            g_streamOutSize = ByteHandling.GetDword(decompressedData, 0);
            for (int i = 0; i < 9; ++i)
                g_streamBlockSize[i] = ByteHandling.GetDword(decompressedData, 4 * (i + 1));

            listStringCount = ByteHandling.GetDword(decompressedData, 0x2C);
            assetsCount = ByteHandling.GetDword(decompressedData, 0x34);
            listStringOffset = 0x3C + listStringCount * 4;
            listStrings = new string[listStringCount];

            //Getting the strings from list
            int listStringStrStartOffset = listStringOffset;
            int listStringStrEndOffset = listStringOffset;
            for (int i = 0; i < listStringCount; ++i)
                if ((UInt32)ByteHandling.GetDword(decompressedData, 0x3C + 4 * i) == 0xFFFFFFFF)
                {
                    listStringStrEndOffset = ByteHandling.FindByte(decompressedData, 0x00, listStringStrStartOffset);
                    listStrings[i] = ByteHandling.GetString(decompressedData, listStringStrStartOffset, listStringStrEndOffset);
                    listStringStrStartOffset = listStringStrEndOffset + 1;
                }

            assetsListOffset = listStringCount > 0 ? listStringStrEndOffset + 1 : listStringStrEndOffset;

            //Getting the assets' count from assets list
            for (int i = 0; i < assetsCount; ++i)
            {
                int assetType = ByteHandling.GetDword(decompressedData, assetsListOffset + 8 * i);
                assetsTypesCount[assetType]++;
            }

            assetsDataOffset = assetsListOffset + assetsCount * 8;
        }

        public void WriteDecompressedZone(string path)
        {
           File.WriteAllBytes(path, decompressedData);
        }

        public void Clear()
        {
            Array.Clear(compressedData, 0, compressedData.Length);
            Array.Clear(decompressedData, 0, decompressedData.Length);
            Array.Clear(g_streamBlockSize, 0, g_streamBlockSize.Length);
            Array.Clear(listStrings, 0, listStrings.Length);
            Array.Clear(assetsTypesCount, 0, assetsTypesCount.Length);
            g_streamOutSize = 0;
            listStringCount = 0;
            listStringOffset = 0;
            assetsCount = 0;
            assetsListOffset = 0;
            assetsDataOffset = 0;
        }

        public byte[] CompressedData
        {
            get
            {
                return compressedData;
            }
        }

        public byte[] DecompressedData
        {
            get
            {
                return decompressedData;
            }
            set
            {
                decompressedData = value;
            }
        }

        public int ZoneSize
        {
            get
            {
                return g_streamOutSize;
            }
        }

        public int[] BlockSize
        {
            get
            {
                return g_streamBlockSize;
            }
        }

        public int ListStringCount
        {
            get
            {
                return listStringCount;
            }
        }

        public int ListStringOffset
        {
            get
            {
                return listStringOffset;
            }
        }

        public string[] ListStrings
        {
            get
            {
                return listStrings;
            }
        }

        public int AssetsCount
        {
            get
            {
                return assetsCount;
            }
        }

        public int AssetsListOffset
        {
            get
            {
                return assetsListOffset;
            }
        }

        public int[] AssetsTypesCount
        {
            get
            {
                return assetsTypesCount;
            }
        }

        public int AssetsDataOffset
        {
            get
            {
                return assetsDataOffset;
            }
        }

        byte[] compressedData;
        byte[] decompressedData;

        int g_streamOutSize = 0;
        int[] g_streamBlockSize = new int[9];
        int listStringCount = 0;
        int listStringOffset = 0;
        string[] listStrings;
        int assetsCount = 0;
        int assetsListOffset = 0;
        int[] assetsTypesCount = new int[33];
        int assetsDataOffset = 0;
    }
}