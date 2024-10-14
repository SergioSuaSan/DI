using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio11: Ejercicio
    {


        public override void ejecutar()
        {
            Console.WriteLine("Escribe un numero");
            string? teclado = Console.ReadLine();
            int a = int.Parse(teclado);
            ejercicio11(a);
        }

        void ejercicio11(int num)
        {
            int acumulador = 0;
            //Buscamos todos los números por los que se pueda dividir el parámetro y se suma en el acumulador.
            for (int i = num - 1; i >= 1; i--)
            {
                if (num % i == 0)
                {
                    acumulador += i;
                }
            }
            //Comparación final
            if (acumulador == num)
            {
                Console.WriteLine("EL número es perfecto");
            }
            else
            {
                Console.WriteLine("El número NO es perfecto");
            }

        }
    }
}
