﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio7: Ejercicio
    {
        /**
         * 
         * <summary>Metodo que te da la vuelta a la frase que le des y la compara con su original</summary>
         * <returns>Si la frase es palíndroma o no</returns>
         * 
         */
        public override void ejecutar()
        {
            Console.WriteLine("Escribe la frase que quieres escribir al revés");
            string? cadena = Console.ReadLine();

            if (cadena.Equals(ejercicio7(cadena))) {
                Console.WriteLine("Son palíndromos");
            }
            else {
                Console.WriteLine("NO son palíndromos");
            }
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
