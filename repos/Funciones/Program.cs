
namespace funciones
{
    class Program
    {
        static int suma ( int a, int b , int c = 0, int d = 0, int e = 0) //c, d ,e son parámetros opcionales, solo son obligatorios 2
        {
            int sum = 0;
            sum = a+b+c+d+e;
            return sum;
        }

        static int suma(int x, int y)
        {
            return x + y + 100;
        }

        static void Main( string[] args )
        {
            int x;
            x = suma(4, 5); //Este utiliza el 2 método, el compilador prioriza los métodos que no tienen parámetros opcionales en la sobrecarga
            Console.WriteLine(x); 
            x = suma(4, 5, 6);
            Console.WriteLine(x); 
            x = suma(4, 5, 6, 7);
            Console.WriteLine(x); 
            x = suma(4, 5, 6, 7, 8);
            Console.WriteLine(x);

        }


    }

}

