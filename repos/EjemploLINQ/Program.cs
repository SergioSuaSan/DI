
namespace EjemploLINQ
{
    class EjemLINQ
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Estos son los números pares: ");
            IEnumerable<int> nPares = from n in numeros where n % 2 == 0 select n;
            foreach (int n in nPares)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números pares: ");
            Console.WriteLine(nPares.Count());

            IEnumerable<int> nImpares = from n in numeros where n % 2 != 0 select n;
            Console.WriteLine("Estos son los números impares: ");
            foreach (int n in nImpares)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números impares: ");
            Console.WriteLine(nImpares.Count());

            IEnumerable<int> mult3 = from n in numeros where n % 3 == 0 select n;
            Console.WriteLine("Estos son los números múltiplos de 3: ");
            foreach (int n in mult3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números múltiplos de 3: ");
            Console.WriteLine(mult3.Count());




            IEnumerable<int> multi3 = from n in nPares where n % 3 == 0 select n;
            Console.WriteLine("Estos son los números pares múltiplos de 3: ");
            foreach (int n in multi3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números pares múltiplos de 3: ");
            Console.WriteLine(multi3.Count());

            
        }
    }
}