using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    class Ejercicio12 : Ejercicio
    {
        /**
         * 
         * <summary>Crea una pirámide de asteriscos del tamaño que se le pida</summary>
         * <returns>la pirámide</returns>
         * 
         */
        public override void ejecutar()
        {

            Console.WriteLine("Escribe cuántas filas quieres que tenga la pirámide");
            int a = LeerDato.LeerEntero();
            //Ejecutamos el ejercicio 12
            ejercicio12(a);
        }

        private void ejercicio12(int a)
        {
            //Creamos un array bidimensional de tamaño del número que se nos ha dado
            String[,] piramide = new String[a,a];
            //Crearemos un doble bucle, uno que nos dibuje cada fila, y otro que nos pase de fila
            for (int i = 0; i < piramide.GetLength(0); i++)
            {
                //Primero hay que dibujar los espacios a la izquierda de la pirámide
                //Con un bucle for hacemos que vaya ponga tantos espacios como la lonjitud del array
                //Cada vez que se baje de fila tendrá que escribir un espacio menos
                for (int j = 0; j < piramide.GetLength(1)-i; j++)
                {
                    Console.Write(" ");
                }

                //Ahora hacemos la pirámide de asteríscos. 
                //Gracias a la forma de los espacios tenemos la forma de escalera. 
                //Hacemos lo mismo a la inversa. Empezar con un asterisco y subir el número de asteriscos por fila bajada
                //Es importante multiplicar por 2 para hacer 1 pirámide en vez de un triangulo rectángulo.
                for (int j = piramide.GetLength(0); j >= piramide.GetLength(1) - (i*2); j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
