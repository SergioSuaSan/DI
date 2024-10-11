using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio2
    {
        internal void ejecutar()
        {
            Console.WriteLine("Escribe un numero");
            string? teclado = Console.ReadLine();
            int a = int.Parse(teclado);
            Console.WriteLine("Escribe un numero");
            teclado = Console.ReadLine();
            int b = int.Parse(teclado);
            Console.WriteLine("Escribe un numero");
            teclado = Console.ReadLine();
            int c = int.Parse(teclado);
            ejercicio2(a, b, c);
        }

        void ejercicio2(int num1, int num2, int num3)
        {
            int a, b, c;

            //Comparo los lados para saber cuál es la hipotenusa. Los catetos son indiferentes.
            if (num1 > num3 && num1 > num2)
            {
                a = num1;
                b = num2;
                c = num3;
            }

            else if (num2 > num3 && num2 > num1)
            {
                a = num2;
                b = num1;
                c = num3;

            }
            else
            {
                a = num3;
                b = num1;
                c = num2;
            }

            if (a >= b + c)
            {
                Console.WriteLine("No es un triángulo");
            }
            else
            //Usamos la fórmula de Pitágoras sabiendo cuál es la hipotenusa
            if (a * a == b * b + c * c)
            {
                Console.WriteLine("Es un triangulo rectángulo");
            }
            else if (a * a >= b * b + c * c)
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
