namespace FFViewer_cs
{
    public class StringTableData
    {
        public StringTableData(string name, int columns, int rows, int fileOffset)
        {
            Filename = name;
            Columns = columns;
            Rows = rows;
            Offset = fileOffset;
        }

        public string Filename { get { return _Filename; } set { _Filename = value; } }
        public int Offset { get { return _Offset; } set { _Offset = value; } }
        public int Columns { get { return _Columns; } set { _Columns = value; } }
        public int Rows { get { return _Rows; } set { _Rows = value; } }

        int _Columns;
        int _Rows;
        string _Filename;
        int _Offset;
    }
}