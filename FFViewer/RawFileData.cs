namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class RawFileData
    {
        int _NameOffset;
        int _ContentsOffset;
        string _OriginalName;
        string _NewName;
        int _OriginalSize;
        int _ActualSize;
        string _Contents;
        bool _IsChanged;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="originalName"></param>
        /// <param name="nameOffset"></param>
        /// <param name="contents"></param>
        /// <param name="originalSize"></param>
        /// <param name="fileOffset"></param>
        public RawFileData(string originalName, int nameOffset, string contents, int originalSize, int fileOffset)
        {
            _NameOffset = nameOffset;
            _ContentsOffset = fileOffset;
            _OriginalName = originalName;
            _NewName = originalName;
            _OriginalSize = originalSize;
            _ActualSize = contents.Length;
            _Contents = contents;
            _IsChanged = false;
        }

        /// <summary>
        /// NI
        /// </summary>
        public int NameOffset
        {
            get
            {
                return _NameOffset;
            }
            set
            {
                _NameOffset = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ContentsOffset
        {
            get
            {
                return _ContentsOffset;
            }
            set
            {
                _ContentsOffset = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string OriginalName
        {
            get
            {
                return _OriginalName;
            }
            set
            {
                _OriginalName = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string NewName
        {
            get
            {
                return _NewName;
            }
            set
            {
                _NewName = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int OriginalSize
        {
            get
            {
                return _OriginalSize;
            }
            set
            {
                _OriginalSize = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public int ActualSize
        {
            get
            {
                return _ActualSize;
            }
            set
            {
                _ActualSize = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Contents
        {
            get
            {
                return _Contents;
            }
            set
            {
                _Contents = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return _IsChanged;
            }
            set
            {
                _IsChanged = value;
            }
        }
    }
}