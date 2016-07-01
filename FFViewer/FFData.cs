using System.IO;

namespace FFViewer_cs
{
    class FFData
    {
        public FFData(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                originalSize = (int)fs.Length;
                header = new byte[8];
                version = new byte[4];
                compressedZone = new byte[originalSize - 12];
                name = filePath;

                fs.Read(header, 0, 8);
                fs.Read(version, 0, 4);
                fs.Read(compressedZone, 0, originalSize - 12);
            }
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

        string name;
        byte[] header;
        byte[] version;
        byte[] compressedZone;
        int originalSize;
    }
}
