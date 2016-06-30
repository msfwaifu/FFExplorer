namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class LocalizedStringsData
    {
        /// <summary>
        /// NI
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="strOffset"></param>
        public LocalizedStringsData(string name, string value, int strOffset)
        {
            stringName = name;
            stringValue = value;
            origName = name;
            offset = strOffset;
        }

        /// <summary>
        /// NI
        /// </summary>
        public int Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Value
        {
            get
            {
                return stringValue;
            }
            set
            {
                stringValue = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Name
        {
            get
            {
                return stringName;
            }
            set
            {
                stringName = value;
            }
        }
        /// <summary>
        /// NI
        /// </summary>
        public string OriginalName
        {
            get
            {
                return origName;
            }
            set
            {
                origName = value;
            }
        }

        string stringName;
        string stringValue;
        string origName;
        int offset;
    }
}