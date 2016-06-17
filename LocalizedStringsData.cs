using System.ComponentModel;

public class LocalizedStringsData
{
    string _StringName;
    string _StringValue;
    string _OrigName;
    int _Offset;

    public LocalizedStringsData(string name, string value, int offset)
    {
        _StringName = Name;
        _StringValue = Value;
        _OrigName = Name;
        _Offset = Offset;
    }

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