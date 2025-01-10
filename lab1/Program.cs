namespace lab1;

class Program
{


    static void Main(string[] args)
    {
        
        DotTwo dotTwo = new DotTwo();
        float floatValue = dotTwo.FloatToInt(1.2f);
        Console.WriteLine(floatValue.GetType());
        
        // INT TO SHORT
        short shortValue = dotTwo.IntToShort(23);
        Console.WriteLine(shortValue.GetType());
        
        // INT TO LONG
        long longValue = dotTwo.IntToLong(23);
        Console.WriteLine(longValue.GetType());
        
        // INT TO STRING
        string stringValue = dotTwo.IntToString(23);
        Console.WriteLine(stringValue.GetType());
        
        // ARGUMENTS
        Console.WriteLine("\n#-#-# ARGS #-#-#");
        Console.ForegroundColor = ConsoleColor.Green;
        ReadParammeters(args);

    }

    public static void ReadParammeters(string[] args)
    {
        foreach (var arguments in args)
        {
            Console.WriteLine(arguments);
        }
    }
}