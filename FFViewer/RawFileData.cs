namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class RawFileData
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RawFileData()
        {
            nameOffset = 0;
            contentsOffset = 0;
            originalName = "unnamed";
            newName = "unnamed";
            originalSize = 0;
            actualSize = 0;
            contents = "";
            isChanged = false;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="origName">Original name of rawfile.</param>
        /// <param name="nameOff">Offset of rawfile name in fastfile.</param>
        /// <param name="content">File contents.</param>
        /// <param name="origSize">Original size of rawfile.</param>
        /// <param name="fileOff">Offset of contents in rawfile.</param>
        public RawFileData(string origName, int nameOff, string content, int origSize, int fileOff)
        {
            nameOffset = nameOff;
            contentsOffset = fileOff;
            originalName = origName;
            newName = origName;
            originalSize = origSize;
            actualSize = content.Length;
            contents = content;
            isChanged = false;
        }

        /// <summary>
        /// Gets offset of rawfile's name in fastfile.
        /// </summary>
        public int NameOffset
        {
            get
            {
                return nameOffset;
            }
        }

        /// <summary>
        /// Gets offset of rawfile's contents in fastfile.
        /// </summary>
        public int ContentsOffset
        {
            get
            {
                return contentsOffset;
            }
        }

        /// <summary>
        /// Gets name of rawfile stored in fastfile.
        /// </summary>
        public string OriginalName
        {
            get
            {
                return originalName;
            }
        }

        /// <summary>
        /// Gets or sets new name for rawfile in fastfile.
        /// </summary>
        public string NewName
        {
            get
            {
                return newName;
            }
            set
            {
                newName = value;
            }
        }

        /// <summary>
        /// Gets maximum size of rawfile stored inside fastfile.
        /// </summary>
        public int OriginalSize
        {
            get
            {
                return originalSize;
            }
        }

        /// <summary>
        /// Gets actual size of rawfile's contents.
        /// </summary>
        public int ActualSize
        {
            get
            {
                return actualSize;
            }
        }

        /// <summary>
        /// Gets or sets contents of rawfile stored in fastfile.
        /// </summary>
        public string Contents
        {
            get
            {
                return contents;
            }
            set
            {
                contents = value;
                actualSize = value.Length;
                isChanged = true;
            }
        }

        /// <summary>
        /// Checks if rawfile has been changed.
        /// </summary>
        public bool Changed
        {
            get
            {
                return isChanged;
            }
        }

        int nameOffset;
        int contentsOffset;
        string originalName;
        string newName;
        int originalSize;
        int actualSize;
        string contents;
        bool isChanged;
    }
}