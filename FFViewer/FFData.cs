using System.IO;

namespace FFViewer_cs
{
    class FFData
    {
        public FFData(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                size = (int)fs.Length;
                header = new byte[8];
                version = new byte[4];
                zoneData = new byte[size - 12];
                name = filePath;

                fs.Read(header, 0, 8);
                fs.Read(version, 0, 4);
                fs.Read(zoneData, 0, size - 12);
            }
        }
        
        public string Name
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
        
        public int Size
        {
            get
            {
                return size;
            }
        }
        
        public byte[] ZoneData
        {
            get
            {
                return zoneData;
            }
            set
            {
                zoneData = value;
            }
        }

        string name;
        byte[] header;
        byte[] version;
        int size;
        byte[] zoneData;
    }
}
