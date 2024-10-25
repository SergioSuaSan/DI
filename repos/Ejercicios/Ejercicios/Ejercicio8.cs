using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio8:Ejercicio
    {
        /**
         * 
         * <summary>Metodo al que le das una cantidad y te devuelve el resto en monedas</summary>
         * <returns>las cantidad de monedas que te devuelve la máquina </returns>
         * 
         */
        public override void ejecutar()
        {
            Console.WriteLine("Vamos a escribir cantidades.Los decimales se escriben con ','");

            Console.WriteLine("Escribe el bote");
            double d = LeerDato.LeerDouble();
            Console.WriteLine("Escribe la cantidad");
            double e = LeerDato.LeerDouble();
            Console.WriteLine(ejercicio8(d, e));
        }
        string ejercicio8(double bote, double cantidad)
        {
            //declaro las variables
            double cambio;
            int e5 = 0,  e2 = 0, e1 = 0, c50 = 0, c20 = 0, c10 = 0, c5 = 0, c2 = 0, c1 = 0;

            while(cantidad < bote)
            {
                //Si la cantidad es menor a lo que se pide, salta un error
                Console.WriteLine("No hay suficiente pasta, escribe la cantidad:");
                cantidad = LeerDato.LeerDouble();

            }
           
            //A partir de ahora vamos a ejecutar el Math.Round en todas las divisiones, para evitar
            //que haya decimales que se pierdan por el camino.
            //calculamos el cambio
            cambio = Math.Round( cantidad - bote, 2);
            //Calculamos cuantas monedas se tienen que devolver
            e5 = (int)(cambio / 5);
            //Luego se restará la cantidad correspondiente a lo que cuesten ese numero de monedas
            cambio = Math.Round(cambio - (5 * e5), 2);
            e2 = (int)(cambio / 2);
            cambio = Math.Round(cambio - (2 * e2), 2);
            e1 = (int)(cambio / 1);
            cambio = Math.Round(cambio - (1 * e1), 2);
            c50 = (int)(cambio / 0.5);
            cambio = Math.Round(cambio - (.5 * c50), 2);
            c20 = (int)(cambio / 0.2);
            cambio = Math.Round(cambio - (.2 * c20), 2);
            c10 = (int)(cambio / 0.1);
            cambio = Math.Round(cambio - (.1 * c10), 2);
            c5 = (int)(cambio / 0.05);
            cambio = Math.Round(cambio - (.05 * c5), 2);
            c2 = (int)(cambio / 0.02);
            cambio = Math.Round(cambio - (.02 * c2), 2);
            c1 = (int)(cambio / 0.01);
            cambio = Math.Round(cambio - (.01 * c1), 2);

            
            return ("Recibes \n" + e5 + " billetes de 5 euros, \n" + e2 + " monedas de 2 euros, \n" + e1 + " monedas de 1 euro \n" + c50 + " monedas de 50c, \n" + c20 + " monedas de 20c, \n" +
                    c10 + " monedas de 10c,\n" + c5 + " monedas de 5c, \n" + c2 + " monedas de 2c y \n" + c1 + " monedas de 1c");

            


        }
    }
}
