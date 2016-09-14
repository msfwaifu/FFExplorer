namespace FFExplorer
{
    class RawFileData
    {
        public RawFileData(){}

        public RawFileData(int idx, string origName, int nameOff, string content, int origSize, int fileOff)
        {
            index = idx;
            nameOffset = nameOff;
            contentsOffset = fileOff;
            originalName = origName;
            name = origName;
            originalSize = origSize;
            size = content.Length;
            contents = content;
            isChanged = false;
        }

        public int NameOffset
        {
            get
            {
                return nameOffset;
            }
        }

        public int ContentsOffset
        {
            get
            {
                return contentsOffset;
            }
        }

        public string OriginalName
        {
            get
            {
                return originalName;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int OriginalSize
        {
            get
            {
                return originalSize;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public string Contents
        {
            get
            {
                return contents;
            }
            set
            {
                contents = value;
                size = value.Length;
                isChanged = true;
            }
        }

        public bool Changed
        {
            get
            {
                return isChanged;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
        }

        int index;
        int nameOffset = 0;
        int contentsOffset = 0;
        string originalName = "unnamed";
        string name = "unnamed";
        int originalSize = 0;
        int size = 0;
        string contents = "";
        bool isChanged = false;
    }
}