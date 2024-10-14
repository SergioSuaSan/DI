using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio6:Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Escribe un numero");
            string? teclado = Console.ReadLine();
            int a = int.Parse(teclado);
        }
        void ejercicio6(int num)
        {
            //Creamos las variables necesarias para el ejercico
            int deci = 0, usado, potencia = 0;

            while (num > 0)
            {
                //Cogemos el número más a la derecha como resto
                usado = num % 10;

                if (usado == 0 || usado == 1)
                {
                    //Le sumamos al número decimal el resultado de la operación
                    deci += usado * (int)Math.Pow(2, potencia);

                    //Eliminamos el último dígito del número binaro y aumentamos la potencia para el siguiente bucle
                    num = num / 10;
                    potencia++;
                }
                else
                {
                    throw new Exception("Formato incorrecto");
                }



            }
            Console.WriteLine(deci);

        }
    }
}
