// See https://aka.ms/new-console-template for more information


namespace Ejercicios
{
    class Programa
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Estos son los resultados de los ejercicios");
            Console.WriteLine("Ejercicio 1:");
            if (ejercicio1(7))
            {
                Console.WriteLine("El numero es primo");

            }
            else
            {
                Console.WriteLine("El número no es primo");
            }

            Console.WriteLine("Ejercicio 2:");
            ejercicio2(4, 3, 4);

            Console.WriteLine("Ejercicio 3:");
            Console.WriteLine(ejercicio3(10));
            Console.WriteLine("Ejercicio 4:");
            ejercicio4(2, 2);




        }
        static bool ejercicio1(int num)
        {
            /*
             *Voy a crear un bucle negativo por el cual si el resto de la división de el numero/ i es 0, retorna falso y sale del 
             *bucle. Si el bucle termina, no se ha podido dividir por ninguno, por lo que será primo (true)
             */
            for (int i = num - 1; i >= 2; i--)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
        static void ejercicio2(int num1, int num2, int num3)
        {
            int a, b, c;
            if (num1 >= num2 + num3)
            {
                Console.WriteLine("No es un triángulo");
            }

            //Comparo los lados para saber cuál es la hipotenusa. Los catetos son indiferentes.
            if (num1 > num3 && num1 > num2)
            {
                a = num1;
                b = num2;
                c = num3;
            }

            else if (num2 > num3 && num2 > num1)
            {
                a = num2;
                b = num1;
                c = num3;

            }
            else
            {
                a = num3;
                b = num1;
                c = num2;
            }

            //Usamos la fórmula de Pitágoras sabiendo cuál es la hipotenusa
            if (a * a == b * b + c * c)
            {
                Console.WriteLine("Es un triangulo rectángulo");
            }
            else if (a * a >= b * b + c * c)
            {
                Console.WriteLine("Es un triángulo obtusángulo");
            }
            else
            {
                Console.WriteLine("Es un triángulo acutángulo");
            }
        }


        static int ejercicio3(int n)
        {
            //Creamos 2 casos base para para poder sumarlos ya que la formula utiliza 2 recursivas.
            if (n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 1;

            }
            return ejercicio3(n - 1) + ejercicio3(n - 2);
        }


        static void ejercicio4(int x, int y)
        {
            //Creamos un array bidimensional con la longitud de filas y columnas que le indicamos
            int filas = 4;
            int colum = 4;
            int[,] array=new int [filas, colum];

            //rellenamos el array
            for (int i = 0; i<filas;i++)
            {
                for (int j = 0; j < colum; j++)
                {
                    array[i,j] = i + j;
                }
            }
            
            //creamos un array unidimensional de la longitud que tenga la submatriz
            int[] array2 = new int[(filas-x) * (colum-y)];
            //Inicializamos un contador que nos indicará la posición en la que se tiene que poner el número del array
            int contador = 0;
            for (int i = x; i < filas; i++)
            {
                for (int j = y; j < colum; j++)
                {
                    array2[contador] = array[i, j];
                    Console.Write(array2[contador]+" ");
                    contador++;
                }
            }
        }
    
        public void ejercicio5()
        {

        }
    }
}