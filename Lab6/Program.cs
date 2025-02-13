using System.Diagnostics;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; 
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Procesamiento secuencial:");
            stopwatch.Start();


            foreach (var item in data)
            {
                int result = Calculate(item);
                Console.WriteLine($"Resultado: {result}");
            }

            stopwatch.Stop();
            Console.WriteLine($"Tiempo secuencial: {stopwatch.ElapsedMilliseconds} ms");
        }


        static int Calculate(int value)
        {
            System.Threading.Thread.Sleep(500); // Simula un retraso de 500 ms
            return value * value;
        }
    }
}
