using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio7: Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Escribe una cadena");
            string? cadena = Console.ReadLine();
            Console.WriteLine(ejercicio7(cadena));
        }
        String ejercicio7(String cadena)
        {
            /*
            String reves = "";
            StringBuilder sb = new StringBuilder(reves);

            for (int i = 0;i < cadena.Length;i++)
            {
                sb.Append( cadena[(cadena.Length-1) - (i)]);
            }


            Console.WriteLine(sb);
            */

            //Creamos un String que va a tener el resultado que vamos a mostrar
            String reves = "";
            //Damos los casos base, incluimos la cadena vacía para evitar errores
            if (cadena.Length == 0) { return "No has escrito nada"; }
            if (cadena.Length == 1)
            {
                //cogemos el último caracter aunque sea uno, nos ayuda a la hora de la recursividad
                reves += cadena.Substring(cadena.Length - 1, cadena.Length);
                return reves;
            }
            reves += cadena.Substring(cadena.Length - 1);
            //Al último caracter le añadimos el recursivo de la misma cadena sin el último caracter
            reves += ejercicio7(cadena.Substring(0, cadena.Length - 1));
            return reves;


        }
    }
}
