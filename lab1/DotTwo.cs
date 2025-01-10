namespace lab1;

public class DotTwo
{

    // Method to convert int to Short
    public short IntToShort(int intValue)
    {
        return Convert.ToInt16(intValue);
    }
    
    // Method to convert Int to Long
    public long IntToLong(int intValue)
    {
        return Convert.ToInt64(intValue);
    }

    public int FloatToInt(float floatValue)
    {
        return (int) floatValue;
    }

    public float IntToFloat(int intValue)
    {
        return Convert.ToSingle(intValue);
    }

    public double IntToDouble(int intValue)
    {
        return intValue;
    }

    public string BoolToString(bool boolValue)
    {
        return boolValue.ToString();
    }

    public string IntToString(int intValue)
    {
        return intValue.ToString();
    }

    public object IntToObject(int intValue)
    {
        return intValue;
    }

    public string? ObjectToString(object objectValue)
    {
        return objectValue.ToString();
    }



}