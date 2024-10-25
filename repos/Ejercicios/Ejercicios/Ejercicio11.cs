using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{

    internal class Ejercicio11: Ejercicio
    {
        /**
         * 
         * <summary>Averigua si un número es perfecto</summary>
         * <returns>Indica si el número es perfecto o no</returns>
         * 
         */

        public override void ejecutar()
        {
            Console.WriteLine("Escribe un numero para comprobar si es perfecto");
            int a = LeerDato.LeerEntero();
            ejercicio11(a);
        }

        void ejercicio11(int num)
        {
            //Compruebo que el número sea positivo
            if (num >= 0)
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
                    Console.WriteLine("El número es perfecto");
                }
                else
                {
                    Console.WriteLine("El número NO es perfecto");
                }
            }
            //Si es negativo, lo indico y termino el ejercicio volviendo al menú principal
            else
            {
                Console.WriteLine("El número no puede ser negativo");
            }

        }
    }
}
