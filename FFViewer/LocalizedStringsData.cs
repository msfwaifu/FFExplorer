namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class LocalizedStringsData
    {
        string _StringName;
        string _StringValue;
        string _OrigName;
        int _Offset;

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        public LocalizedStringsData(string name, string value, int offset)
        {
            _StringName = Name;
            _StringValue = Value;
            _OrigName = Name;
            _Offset = Offset;
        }

        /// <summary>
        /// NI
        /// </summary>
        public int Offset
        {
            get
            {
                return _Offset;
            }
            set
            {
                _Offset = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Value
        {
            get
            {
                return _StringName;
            }
            set
            {
                _StringName = value;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Name
        {
            get
            {
                return _StringName;
            }
            set
            {
                _StringName = value;
            }
        }
    }
}