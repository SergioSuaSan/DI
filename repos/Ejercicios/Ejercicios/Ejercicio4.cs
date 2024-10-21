using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio4: Ejercicio
    {
        public override void ejecutar()
        {
            Console.WriteLine("Escribe el número de filas del array");
            int a = LeerDato.LeerEntero();
            Console.WriteLine("Escribe el número de columnas del array");
            int b = LeerDato.LeerEntero();
            Console.WriteLine("Escribe un numero de la fila por la que comenzaremos a leer");
            int c = LeerDato.LeerEntero();
            Console.WriteLine("Escribe un numero de la columna por la que comenzaremos a leer");
            int d = LeerDato.LeerEntero();
            ejercicio4(a, b, c, d);
        }

        void ejercicio4(int a, int b, int c, int d)
        {
            if (a > c && b > d)
            {
                //Creamos un array bidimensional con la longitud de filas y columnas que le indicamos
                int filas = a;
                int colum = b;
                int[,] array = new int[filas, colum];

                //rellenamos el array
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < colum; j++)
                    {
                        array[i, j] = i + j;
                    }
                }

                //creamos un array unidimensional de la longitud que tenga la submatriz
                try
                {
                    int[] array2 = new int[(filas - c) * (colum - d)];




                    //Inicializamos un contador que nos indicará la posición en la que se tiene que poner el número del array
                    int contador = 0;
                    //Creamos un doble bucle que escriba en el array unidimensional los datos de la matriz en orden
                    for (int i = c; i < filas; i++)
                    {
                        for (int j = d; j < colum; j++)
                        {
                            array2[contador] = array[i, j];

                            //Escribimos el número que toca de forma ordenada en una sola línea
                            Console.Write(array2[contador] + " ");
                            contador++;
                        }
                    }
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Te has pasado");
                }
            }
            else
            {
                Console.WriteLine("El número que indica donde se empieza debe ser menor que el número de filas y/o columnas del array");
            }
        }
    }
}
