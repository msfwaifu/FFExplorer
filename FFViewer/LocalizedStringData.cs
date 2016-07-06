namespace FFViewer_cs
{
    /// <summary>
    /// Not in use.
    /// </summary>
    class LocalizedStringData
    {
        public LocalizedStringData(int index, string prefix, string key, string value, int startOfKey, int startOfValue)
        {
            this.index = index;
            this.prefix = prefix;
            this.key = key;
            this.value = value;
            this.keyOffset = startOfKey;
            this.valueOffset = startOfValue;

            keyOriginal = key;
            valueOriginal = value;
            keyMaxLength = key.Length;
            valueMaxLength = value.Length;
            
            //TODO: check of key\value length may be any
        }

        public string Prefix
        {
            get
            {
                return prefix;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
        }

        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
                prefix = key.Substring(0, key.IndexOf('_'));
            }
        }

        public string KeyOriginal
        {
            get
            {
                return keyOriginal;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public string ValueOriginal
        {
            get
            {
                return valueOriginal;
            }
        }

        public int KeyOffset
        {
            get
            {
                return keyOffset;
            }
        }

        public int ValueOffset
        {
            get
            {
                return valueOffset;
            }
        }

        public int ValueMaxLength
        {
            get
            {
                return valueMaxLength;
            }
        }

        public int KeyMaxLength
        {
            get
            {
                return keyMaxLength;
            }
        }

        int index;
        string prefix;
        string key;
        string keyOriginal;
        string value;
        string valueOriginal;
        int keyOffset;
        int valueOffset;
        int keyMaxLength;
        int valueMaxLength;
    }
}