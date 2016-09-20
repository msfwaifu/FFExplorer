namespace FFExplorer
{
    /// <summary>
    /// Currently not implemented because stringtables are different in original and custom fastfiles.
    /// </summary>
    class StringTableData
    {
        public StringTableData(string tName, int tColumns, int tRows, int tOffset)
        {
            filename = tName;
            columns = tColumns;
            rows = tRows;
            offset = tOffset;
        }

        public string Filename
        {
            get
            {
                return filename;
            }
        }

        public int Offset
        {
            get
            {
                return offset;
            }
        }

        public int Columns
        {
            get
            {
                return columns;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }
        }

        int columns;
        int rows;
        string filename;
        int offset;
    }
}