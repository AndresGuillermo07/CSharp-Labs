namespace lab2;

class Program
{
    static void Main(string[] args)
    {
        OperacionesString operaciones = new OperacionesString("Hola, mundo!");

        Console.WriteLine("String original:");
        Console.WriteLine(operaciones.Cadena);

        Console.WriteLine("\nDividir y unir string:");
        string resultadoDividirUnir = operaciones.DividirYUnir();
        Console.WriteLine(resultadoDividirUnir);

        Console.WriteLine("\nObtener substring:");
        string substring = operaciones.ObtenerSubstring(0, 4);
        Console.WriteLine(substring);

        Console.WriteLine("\nComparar strings:");
        bool comparacion = operaciones.CompararStrings("Hola");
        Console.WriteLine($"¿Son iguales 'Hola' y '{operaciones.Cadena}'? {comparacion}");

        Console.WriteLine("\nBuscar string dentro de otro string:");
        bool encontrado = operaciones.BuscarString("mundo");
        Console.WriteLine($"¿Se encontró 'mundo' en '{operaciones.Cadena}'? {encontrado}");

        // el destructor se llama automaticamente
    }
}