﻿using System;
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
            Console.WriteLine("Escribe un numero");
            int a = LeerDato.LeerEntero();
            Console.WriteLine("Escribe un numero");
            int b = LeerDato.LeerEntero();
            ejercicio4(a, b);
        }

        void ejercicio4(int x, int y)
        {
            //Creamos un array bidimensional con la longitud de filas y columnas que le indicamos
            int filas = 4;
            int colum = 4;
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
                int[] array2 = new int[(filas - x) * (colum - y)];




                //Inicializamos un contador que nos indicará la posición en la que se tiene que poner el número del array
                int contador = 0;
                //Creamos un doble bucle que escriba en el array unidimensional los datos de la matriz en orden
                for (int i = x; i < filas; i++)
                {
                    for (int j = y; j < colum; j++)
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
    }
}
