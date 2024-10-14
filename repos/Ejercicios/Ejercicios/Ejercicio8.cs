using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio8:Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Escribe el bote");
            string? teclado = Console.ReadLine();
            double d = double.Parse(teclado);
            Console.WriteLine("Escribe la cantidad");
            teclado = Console.ReadLine();
            double e = double.Parse(teclado);
            Console.WriteLine(ejercicio8(d, e));
        }
        string ejercicio8(double bote, double cantidad)
        {
            //declaro las variables
            double cambio;
            int e2 = 0, e1 = 0, c50 = 0, c20 = 0, c10 = 0, c5 = 0, c2 = 0, c1 = 0;

            if (cantidad < bote)
            {
                //Si la cantidad es menor a lo que se pide, salta un error
                throw new Exception("No hay suficiente pasta");
            }
            else
            {
                //calculamos el cambio
                cambio = cantidad - bote;
                //Calculamos cuantas monedas se tienen que devolver
                e2 = (int)(cambio / 2);
                //Luego se restará la cantidad correspondiente a lo que cuesten ese numero de monedas
                cambio -= 2 * e2;
                e1 = (int)(cambio / 1);
                cambio -= 1 * e1;
                c50 = (int)(cambio / 0.5);
                cambio -= 0.5 * c50;
                c20 = (int)(cambio / 0.2);
                cambio -= 0.2 * c20;
                c10 = (int)(cambio / 0.1);
                cambio -= 0.1 * c10;
                c5 = (int)(cambio / 0.05);
                cambio -= 0.05 * c5;
                c2 = (int)(cambio / 0.02);
                cambio -= 0.02 * c2;
                c1 = (int)(cambio / 0.01);
                cambio -= 0.01 * c1;

                //Sin embargo, las restas por algñun motivo deja decimales periódicos, por lo que hay una moneda de 1c que se acaba perdiendo, no entiendo por qué.
                return ("Recibes " + e2 + " monedas de 2€, " + e1 + " monedas de 1€, " + c50 + " monedas de 50c, " + c20 + " monedas de 20c, " +
                    c10 + " monedas de 10c, " + c5 + " monedas de 5c, " + c2 + " monedas de 2c y " + c1 + " monedas de 1c");

            }


        }
    }
}
