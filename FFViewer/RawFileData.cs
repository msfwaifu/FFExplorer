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