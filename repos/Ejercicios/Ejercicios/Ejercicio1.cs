using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio1:Ejercicio
    {
        public override void ejecutar()
        {
            bool ejercicio1(int num)
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
            Console.WriteLine("Escribe un numero");
            string? teclado = Console.ReadLine();
            int num = int.Parse(teclado);
            if (ejercicio1(num))
            {
                Console.WriteLine("El numero es primo");

            }
            else
            {
                Console.WriteLine("El número no es primo");
            }
        }
    }
}
