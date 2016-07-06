using System;
using System.IO;

namespace FFViewer_cs
{
    class FFData
    {
        public FFData(string filePath)
        {
            this.filePath = filePath;  
        }

        public void Parse()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                originalSize = (int)fs.Length;
                compressedZone = new byte[originalSize - 12];
                name = filePath;

                fs.Read(header, 0, 8);
                fs.Read(version, 0, 4);
                fs.Read(compressedZone, 0, originalSize - 12);
            }
        }

        public void Clear()
        {
            name = "";
            originalSize = 0;
            Array.Clear(header, 0, header.Length);
            Array.Clear(version, 0, version.Length);
            Array.Clear(compressedZone, 0, compressedZone.Length);
        }
        
        public string FilePath
        {
            get
            {
                return name;
            }
        }
        
        public byte[] Header
        {
            get
            {
                return header;
            }
        }

        
        public byte[] Version
        {
            get
            {
                return version;
            }
        }
             
        public byte[] CompressedZone
        {
            get
            {
                return compressedZone;
            }
            set
            {
                compressedZone = value;
            }
        }

        public int OriginalSize
        {
            get
            {
                return originalSize;
            }
        }

        string filePath;

        string name;
        byte[] header = new byte[8];
        byte[] version = new byte[4];
        byte[] compressedZone;
        int originalSize;
    }
}
