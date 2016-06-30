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
        /// <param name="tName"></param>
        /// <param name="tColumns"></param>
        /// <param name="tRows"></param>
        /// <param name="tOffset"></param>
        public StringTableData(string tName, int tColumns, int tRows, int tOffset)
        {
            filename = tName;
            columns = tColumns;
            rows = tRows;
            offset = tOffset;
        }

        /// <summary>
        /// NI
        /// </summary>
        public string Filename
        {
            get
            {
                return filename;
            }
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
        }

        /// <summary>
        /// NI
        /// </summary>
        public int Columns
        {
            get
            {
                return columns;
            }
        }

        /// <summary>
        /// NI
        /// </summary>
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