using System;

namespace Ejercicios
{
    internal static class LeerDato
    {
        internal static int LeerEntero()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No has introducido nada. Debes introducir algún número entero");
                return -1;
            }
            catch (FormatException)
            {
                Console.WriteLine("El tipo de dato es incorrecto. Debe ser un número entero");
                return -2;
            }
            catch (OverflowException) 
            {
                Console.WriteLine("El valor introducido es mayor que el máximo permitido. Introduce un número menor");
                return -3;
            }
        }



        internal static float LeerDecimal()
        {
            try
            {
                return float.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No has introducido nada. Debes introducir algún número decimal");
                return -1;
            }
            catch (FormatException)
            {
                Console.WriteLine("El tipo de dato es incorrecto. Debe ser un número entero");
                return -2;
            }
            catch (OverflowException)
            {
                Console.WriteLine("El valor introducido es mayor que el máximo permitido. Introduce un número menor");
                return -3;
            }
        }
        internal static double LeerDouble()
        {
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No has introducido nada. Debes introducir algún número decimal");
                return -1;
            }
            catch (FormatException)
            {
                Console.WriteLine("El tipo de dato es incorrecto. Debe ser un número entero");
                return -2;
            }
            catch (OverflowException)
            {
                Console.WriteLine("El valor introducido es mayor que el máximo permitido. Introduce un número menor");
                return -3;
            }
        }

    }
}
