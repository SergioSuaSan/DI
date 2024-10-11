using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio3
    {
        internal void ejecutar()
        {
            Console.WriteLine("Escribe un numero");
            string? teclado = Console.ReadLine();
            int a = int.Parse(teclado);
            Console.WriteLine(ejercicio3(a));
        }

        int ejercicio3(int n)
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
    }
}
