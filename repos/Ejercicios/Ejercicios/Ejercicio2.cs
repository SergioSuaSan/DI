using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    /**
         * 
         * <summary>Averigua si con los tres datos que se le dan, se puede formar un triangulo
         * y cómo sería</summary>
         * <returns>Si es un triangulo, y el tipo de triángulo que es</returns>
         * 
         */
    internal class Ejercicio2: Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Escribe la longitud de un lado del triángulo");         
            int a = LeerDato.LeerEntero();
            Console.WriteLine("Escribe la longitud de otro lado del triángulo");
            int b = LeerDato.LeerEntero();
            Console.WriteLine("Escribe la longitud del último lado del triángulo");
            int c = LeerDato.LeerEntero();
            ejercicio2(a, b, c);
        }

        void ejercicio2(int num1, int num2, int num3)
        {
            int hipotenusa, Cateto1, Cateto2;

            //Comparo los lados para saber cuál es la hipotenusa. Los catetos son indiferentes.
            if (num1 > num3 && num1 > num2)
            {
                hipotenusa = num1;
                Cateto1 = num2;
                Cateto2 = num3;
            }

            else if (num2 > num3 && num2 > num1)
            {
                hipotenusa = num2;
                Cateto1 = num1;
                Cateto2 = num3;

            }
            else
            {
                hipotenusa = num3;
                Cateto1 = num1;
                Cateto2 = num2;
            }
            //Si la hipotenusa mide más que la suma de los catetos, no es un triangulo
            if (hipotenusa >= Cateto1 + Cateto2)
            {
                Console.WriteLine("No es un triángulo");
            }
            else
            //Usamos la fórmula de Pitágoras sabiendo cuál es la hipotenusa
            //De esta forma sabremos la forma del triángulo
            if (hipotenusa * hipotenusa == Cateto1 * Cateto1 + Cateto2 * Cateto2)
            {
                Console.WriteLine("Es un triangulo rectángulo");
            }
            else if (hipotenusa * hipotenusa >= Cateto1 * Cateto1 + Cateto2 * Cateto2)
            {
                Console.WriteLine("Es un triángulo obtusángulo");
            }
            else
            {
                Console.WriteLine("Es un triángulo acutángulo");
            }
        }
    }
}
