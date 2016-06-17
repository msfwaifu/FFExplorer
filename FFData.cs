using System;
using System.IO;
using System.Windows.Forms;

namespace FFViewer_cs
{
    class FFData
    {
        string  _Name;
        byte[]  _Header;
        byte[]  _Version;
        int     _iVersion;
        int     _Size;
        byte[]  _ZoneData;

        public FFData(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);                
                _Size = (int)fs.Length;
                _Header = new byte[8];
                _Version = new byte[4];
                _ZoneData = new byte[_Size - 12];
                _Name = filePath;
                
                fs.Read(_Header, 0, 8);
                fs.Read(_Version, 0, 4);
                fs.Read(_ZoneData, 0, _Size - 12);
                _iVersion = ByteHandling.GetDWORD(_Version, 0);

                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("При получении информации о FastFile произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public byte[] Header
        {
            get
            {
                return _Header;
            }
            set
            {
                _Header = value;
            }
        }

        public byte[] Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }

        public int IVersion
        {
            get
            {
                return _iVersion;
            }
            set
            {
                _iVersion = value;
            }
        }

        public int Size
        {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }

        public byte[] ZoneData
        {
            get
            {
                return _ZoneData;
            }
            set
            {
                _ZoneData = value;
            }
        }
    }
}
