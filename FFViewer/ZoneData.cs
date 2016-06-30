using System;
using Ionic.Zlib;

namespace FFViewer_cs
{
    //TODO
    /// <summary>
    /// NI
    /// </summary>
    public class ZoneData
    {
        byte[] compressedData;
        byte[] decompressedData;

        int zoneSize = 0;
        int[] zoneSizes;
        int listStringCount;
        int listStringOffset;
        string[] listStrings;
        int assetsCount;
        int assetsListOffset;
        int[] assetsTypesCount;
        int assetsDataOffset;

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="compressed"></param>
        public ZoneData(byte[] compressed)
        {
            compressedData = compressed;
            decompressedData = ZlibStream.UncompressBuffer(compressed);

            //comment line later
            //System.IO.File.WriteAllBytes("extracted-zone.dat", decompressedData);
            //

            zoneSize = ByteHandling.GetDword(decompressedData, 0);
            zoneSizes = new int[10];
            for (int i = 0; i < 10; ++i)
                zoneSizes[i] = ByteHandling.GetDword(decompressedData, 4 * i);
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
            assetsTypesCount = new int[33];
            for (int i = 0; i < assetsCount; ++i)
            {
                int assetType = ByteHandling.GetDword(decompressedData, assetsListOffset + 8 * i);
                assetsTypesCount[assetType]++;
            }

            assetsDataOffset = assetsListOffset + assetsCount * 8;
        }

        /// <summary>
        /// NI
        /// </summary>
        public byte[] CompressedData
        {
            get
            {
                return compressedData;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
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

        /// <summary>
        /// NI
        /// </summary>
        public int DecompressedSize
        {
            get
            {
                return decompressedData.Length;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ZoneSize
        {
            get
            {
                return zoneSize;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int[] ZoneSizes
        {
            get
            {
                return zoneSizes;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ListStringCount
        {
            get
            {
                return listStringCount;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ListStringOffset
        {
            get
            {
                return listStringOffset;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string[] ListStrings
        {
            get
            {
                return listStrings;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int AssetsCount
        {
            get
            {
                return assetsCount;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int AssetsListOffset
        {
            get
            {
                return assetsListOffset;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int[] AssetsTypesCount
        {
            get
            {
                return assetsTypesCount;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int AssetsDataOffset
        {
            get
            {
                return assetsDataOffset;
            }
        }
    }
}