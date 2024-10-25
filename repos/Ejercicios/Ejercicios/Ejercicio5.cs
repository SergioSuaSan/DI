using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio5:Ejercicio
    {

        /**
         * 
         * <summary>Método que te quita los espacios de una cadena</summary>
         * <returns>La cadena sin espacios, la cantidad de espacios quitados y el número de caractéres de la nueva cadena</returns>
         * 
         */
        public override void ejecutar()
        {
            Console.WriteLine("Escribe la frase que quieres ver sin espacios");
            String cadena = Console.ReadLine();
            ejercicio5(cadena);
        }

        void ejercicio5(String cadena)
        {
            //Creamos un array de char del tamaño al menos de la cadena
            char[] arr = new char[cadena.Length];
            //Vamos a crear un contador que indique cuantos espacios hemos eliminado
            int espacios = 0;
            //Y otro que indique cuantos caracteres tiene la nueva cadena
            int contadorcadena = 0;
            //Creamos un bucle que ponga en el array los caracteres distintos de ' ' 
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] != ' ')
                {
                    arr[i] = cadena[i];
                    //Si es distinto de espacio, será un caracter más para la nueva cadena
                    contadorcadena++;
                }
                //Cuando sea un espacio, en vez de añadirse a la cadena, aumenta el contador.
                else
                {
                    espacios++;
                }
            }
            //Escribimos el array
            Console.WriteLine(arr);
            //Escribimos el número de espacios
            Console.WriteLine("El número de espacios es: " + espacios);
            //Escribimos la longitud de caracteres de la nueva cadena
            Console.WriteLine("El número de caracteres de la nueva cadena es: " + contadorcadena);
        }
    }
}
