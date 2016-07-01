using System;
using Ionic.Zlib;

namespace FFViewer_cs
{
    //TODO
    /// <summary>
    /// Class represents typical fastfile structure.
    /// </summary>
    class ZoneData
    {
        /// <summary>
        /// Constructs <see cref="ZoneData"/> instance according to passed compressed zlib archive.
        /// </summary>
        /// <param name="compressed"></param>
        public ZoneData(byte[] compressed)
        {
            compressedData = compressed;
        }

        /// <summary>
        /// Decompress Zlib archive.
        /// </summary>
        public void DecompressZlib()
        {
            decompressedData = ZlibStream.UncompressBuffer(compressedData);
        }

        /// <summary>
        /// Extract data from decompressed zlib archive.
        /// </summary>
        public void ParseFastfile()
        {
            g_streamOutSize = ByteHandling.GetDword(decompressedData, 0);
            g_streamBlockSize = new int[9];
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
            assetsTypesCount = new int[33];
            for (int i = 0; i < assetsCount; ++i)
            {
                int assetType = ByteHandling.GetDword(decompressedData, assetsListOffset + 8 * i);
                assetsTypesCount[assetType]++;
            }

            assetsDataOffset = assetsListOffset + assetsCount * 8;
        }

        /// <summary>
        /// Gets compressed zlib arhive.
        /// </summary>
        public byte[] CompressedData
        {
            get
            {
                return compressedData;
            }
        }

        /// <summary>
        /// Gets or sets decompressed zlib archive.
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
        /// Gets size of zone file.
        /// </summary>
        public int ZoneSize
        {
            get
            {
                return g_streamOutSize;
            }
        }

        /// <summary>
        /// Gets array of stored in fastfile various sizes used by game.
        /// </summary>
        public int[] BlockSize
        {
            get
            {
                return g_streamBlockSize;
            }
        }

        /// <summary>
        /// Gets count of pre-compiled strings.
        /// </summary>
        public int ListStringCount
        {
            get
            {
                return listStringCount;
            }
        }

        /// <summary>
        /// Gets offset of list of pre-compliled strings.
        /// </summary>
        public int ListStringOffset
        {
            get
            {
                return listStringOffset;
            }
        }

        /// <summary>
        /// Gets list of precompiled strings.
        /// </summary>
        public string[] ListStrings
        {
            get
            {
                return listStrings;
            }
        }

        /// <summary>
        /// Gets count of assets.
        /// </summary>
        public int AssetsCount
        {
            get
            {
                return assetsCount;
            }
        }

        /// <summary>
        /// Gets offset of list of assets.
        /// </summary>
        public int AssetsListOffset
        {
            get
            {
                return assetsListOffset;
            }
        }

        /// <summary>
        /// Gets array contains count of various assets compiled to fastfile.
        /// </summary>
        public int[] AssetsTypesCount
        {
            get
            {
                return assetsTypesCount;
            }
        }

        /// <summary>
        /// Gets offset of assets.
        /// </summary>
        public int AssetsDataOffset
        {
            get
            {
                return assetsDataOffset;
            }
        }

        byte[] compressedData;
        byte[] decompressedData;

        int g_streamOutSize;
        int[] g_streamBlockSize;
        int listStringCount;
        int listStringOffset;
        string[] listStrings;
        int assetsCount;
        int assetsListOffset;
        int[] assetsTypesCount;
        int assetsDataOffset;
    }
}