namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class StringTableData
    {
        /// <summary>
        /// NI
        /// </summary>
        /// <param name="name"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        /// <param name="fileOffset"></param>
        public StringTableData(string name, int columns, int rows, int fileOffset)
        {
            Filename = name;
            Columns = columns;
            Rows = rows;
            Offset = fileOffset;
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Filename { get { return _Filename; } set { _Filename = value; } }

        /// <summary>
        /// NI
        /// </summary>
        public int Offset { get { return _Offset; } set { _Offset = value; } }

        /// <summary>
        /// NI
        /// </summary>
        public int Columns { get { return _Columns; } set { _Columns = value; } }

        /// <summary>
        /// NI
        /// </summary>
        public int Rows { get { return _Rows; } set { _Rows = value; } }

        int _Columns;
        int _Rows;
        string _Filename;
        int _Offset;
    }
}