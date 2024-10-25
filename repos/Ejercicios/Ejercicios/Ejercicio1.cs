using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio1:Ejercicio
    {
        /**
         * 
         * <summary>Esta clase utiliza un bucle para averiguar si un número es primo o no</summary>
         * <returns>Si el número es primo o no</returns>
         * 
         */
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
            Console.WriteLine("Escribe un numero para saber si es primo");
            int num = LeerDato.LeerEntero();
            //Compruebo que el valor introducido es correcto indicando que no es positivo
            if (num >= 2)
            {  
                if (ejercicio1(num))
                {
                    Console.WriteLine("El numero es primo");
                }
                else
                {
                    Console.WriteLine("El número no es primo");
                }
            } else
            {
                //Si no es positivo, lo indico y termina el ejercicio, devolviendote al menú principal
                Console.WriteLine("El número no puede ser menor a 2");
            }
        }
    }
}
