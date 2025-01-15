namespace lab2;

public class OperacionesString
{
    private string cadena;
    
    public string Cadena
    {
        get { return cadena; }
        set { cadena = value; }
    }
    
    public OperacionesString(string cadenaInicial)
    {
        cadena = cadenaInicial;
        Console.WriteLine("Constructor: Objeto creado.");
    }
    
    public string DividirYUnir()
    {
        char[] caracteres = cadena.ToCharArray();
        string resultado = new string(caracteres);
        return resultado;
    }

    public string ObtenerSubstring(int inicio, int longitud)
    {
        if (inicio >= 0 && longitud > 0 && inicio + longitud <= cadena.Length)
        {
            return cadena.Substring(inicio, longitud);
        }

        return "Índices inválidos.";
    }
    
    public bool CompararStrings(string otroString)
    {
        return cadena.Equals(otroString, StringComparison.Ordinal);
    }
    
    public bool BuscarString(string subString)
    {
        return cadena.Contains(subString, StringComparison.Ordinal);
    }

    // Destructor
    ~OperacionesString()
    {
        Console.WriteLine("Destructor: Objeto destruido.");
    }
}