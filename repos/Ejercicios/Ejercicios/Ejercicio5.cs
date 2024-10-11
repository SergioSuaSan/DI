using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio5
    {
        internal void ejecutar()
        {
            Console.WriteLine("Escribe una cadena");
            String cadena = Console.ReadLine();
            ejercicio5(cadena);
        }

        void ejercicio5(String cadena)
        {
            //Creamos un array de char del tamaño al menos de la cadena
            char[] arr = new char[cadena.Length];
            //Creamos un bucle que ponga en el array los caracteres distintos de ' '
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] != ' ')
                {
                    arr[i] = cadena[i];
                }
            }
            //Escribimos el array
            Console.WriteLine(arr);
        }
    }
}
