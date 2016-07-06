namespace FFViewer_cs
{
    /// <summary>
    /// Not in use since almost impossible to find correct offset.
    /// </summary>
    class LocalizedStringData
    {
        public LocalizedStringData(string key, string value, int offset)
        {
            stringKey = key;
            stringKeyOriginal = key;
            stringValue = value;
            stringOffset = offset;
        }

        public int Offset
        {
            get
            {
                return stringOffset;
            }
        }

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

        public string Key
        {
            get
            {
                return stringKey;
            }
            set
            {
                stringKey = value;
            }
        }
        
        public string KeyOriginal
        {
            get
            {
                return stringKeyOriginal;
            }
        }

        string stringKey;
        string stringKeyOriginal;
        string stringValue;
        int stringOffset;
    }
}