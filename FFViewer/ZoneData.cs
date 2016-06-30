using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ionic.Zlib;

namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class ZoneData
    {
        byte[] _CompressedData;
        byte[] _DecompressedData;
        int _DecompressedSize = 0;
        //
        int _ZoneSize = 0;
        int[] _ZoneSizes;
        int _ListStringCount;
        int _ListStringOffset;
        string[] _ListStrings;
        int _AssetsCount;
        int _AssetsListOffset;
        int[] _AssetsTypesCount;
        int _AssetsDataOffset;

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="compressed"></param>
        public ZoneData(byte[] compressed)
        {
            try
            {
                _CompressedData = compressed;
                _DecompressedData = ZlibStream.UncompressBuffer(compressed);
                //comment line later
                System.IO.File.WriteAllBytes("extracted-zone.dat", _DecompressedData);
                //
                _DecompressedSize = _DecompressedData.Length;

                _ZoneSize = ByteHandling.GetDWORD(_DecompressedData, 0);
                _ZoneSizes = new int[10];
                for (int i = 0; i < 10; ++i)
                    _ZoneSizes[i] = ByteHandling.GetDWORD(_DecompressedData, 4 * i);
                _ListStringCount = ByteHandling.GetDWORD(_DecompressedData, 0x2C);
                _AssetsCount = ByteHandling.GetDWORD(_DecompressedData, 0x34);
                _ListStringOffset = 0x3C + _ListStringCount * 4;
                _ListStrings = new string[_ListStringCount];

                //Getting the strings from list
                int listStringStrStartOffset = _ListStringOffset;
                int listStringStrEndOffset = _ListStringOffset;
                for (int i = 0; i < _ListStringCount; ++i)
                    if ((UInt32)ByteHandling.GetDWORD(_DecompressedData, 0x3C + 4 * i) == 0xFFFFFFFF)
                    {
                        listStringStrEndOffset = ByteHandling.FindByte(_DecompressedData, 0x00, listStringStrStartOffset);
                        _ListStrings[i] = ByteHandling.GetString(_DecompressedData, listStringStrStartOffset, listStringStrEndOffset);
                        listStringStrStartOffset = listStringStrEndOffset + 1;
                    }

                _AssetsListOffset = _ListStringCount > 0 ? listStringStrEndOffset + 1 : listStringStrEndOffset;

                //Getting the assets' count from assets list
                _AssetsTypesCount = new int[33];
                for (int i = 0; i < _AssetsCount; ++i)
                {
                    int assetType = ByteHandling.GetDWORD(_DecompressedData, _AssetsListOffset + 8 * i);
                    _AssetsTypesCount[assetType]++;
                }

                _AssetsDataOffset = _AssetsListOffset + _AssetsCount * 8;


            }
            catch(Exception ex)
            {
                MessageBox.Show("При получении информации о Zone произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public byte[] CompressedData
        {
            get
            {
                return _CompressedData;
            }
            set
            {
                _CompressedData = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public byte[] DecompressedData
        {
            get
            {
                return _DecompressedData;
            }
            set
            {
                _DecompressedData = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int DecompressedSize
        {
            get
            {
                return _DecompressedSize;
            }
            set
            {
                _DecompressedSize = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ZoneSize
        {
            get
            {
                return _ZoneSize;
            }
            set
            {
                _ZoneSize = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int[] ZoneSizes
        {
            get
            {
                return _ZoneSizes;
            }
            set
            {
                _ZoneSizes = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ListStringCount
        {
            get
            {
                return _ListStringCount;
            }
            set
            {
                _ListStringCount = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ListStringOffset
        {
            get
            {
                return _ListStringOffset;
            }
            set
            {
                _ListStringOffset = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string[] ListStrings
        {
            get
            {
                return _ListStrings;
            }
            set
            {
                _ListStrings = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int AssetsCount
        {
            get
            {
                return _AssetsCount;
            }
            set
            {
                _AssetsCount = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int AssetsListOffset
        {
            get
            {
                return _AssetsListOffset;
            }
            set
            {
                _AssetsListOffset = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int[] AssetsTypesCount
        {
            get
            {
                return _AssetsTypesCount;
            }
            set
            {
                _AssetsTypesCount = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int AssetsDataOffset
        {
            get
            {
                return _AssetsDataOffset;
            }
            set
            {
                _AssetsDataOffset = value;
            }
        }
    }
}