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
            Console.WriteLine("Escribe el número binario que quieres pasar a decimal");
            long a = LeerDato.LeerEnteroLargo();
            ejercicio6(a);
        }
        void ejercicio6(long num)
        {
            //Creamos las variables necesarias para el ejercico
            long deci = 0, usado, potencia = 0;
            bool error = false;

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
                    num = 0;
                    error = true ;
                }
              


            }
            if (error)
            {
                Console.WriteLine("El formato del binario es incorrecto");
            } else
            {
            Console.WriteLine(deci);

            }

        }
    }
}
