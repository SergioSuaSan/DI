using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio6:Ejercicio
    {
        /**
         * 
         * <summary>Metodo que transforma un número binario en uno decimal</summary>
         * <returns>El número decimal</returns>
         * 
         */
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

            //Vamos a crear un bucle que transforme el binario a decimal, mientras el número sea mayor a 0
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
                    //Si el formato del binario incluye números distintos de 0 y 1, terminamos el bucle con
                    //el num por debajo de 0 y activamos el error
                    num = -1;
                    error = true ;
                }
              


            }
            //La función error  indica que el formato del binario es incorrecto y te devuelve al menú principal
            if (error)
            {
               Console.WriteLine("El formato del binario es incorrecto");
            } 
            //Y si no hay error, solo si el numero restante es 0, escribirá el resultado. 
            //Esto evita que salga 0 si dejas en blanco el número binario
            else if (num == 0) 
            {
            
            Console.WriteLine(deci);

            }

        }
    }
}
