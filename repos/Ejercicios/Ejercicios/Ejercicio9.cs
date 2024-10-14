using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio9:Ejercicio
    {
        private string? teclado;

        public override void ejecutar()
        {
            Console.WriteLine("Escribe la dirección en la que se moverá la matriz: \n 0 = arriba \n 1 = derecha \n 2 = abajo \n 3 = izquierda");
            teclado = Console.ReadLine();
            int a = int.Parse(teclado);
            ejercicio9(a);
        }
        void ejercicio9(int direccion)
        {


            int[][] matriz =
            {
                new int []{10,11,12,13,14 },
                new int []{20,21,22,23,24 },
                new int []{30,31,32,33,34 },
                new int []{40,41,42,43,44 },
                new int []{50,51,52,53,54 }
            };


            void print()
            {
                for (int i = 0; i < matriz.Length; i++)
                {
                    for (int j = 0; j < matriz[i].Length; j++)
                    {
                        Console.Write(matriz[i][j] + ", ");
                    }
                    Console.WriteLine();
                }
            }
            print();

            switch (direccion)
            {
                case 0: //arriba
                    Console.WriteLine("Escribe cuánto se quiere mover");
                    String teclado = Console.ReadLine();
                    int num = int.Parse(teclado);

                    for (int v = 0; v < num; v++)
                    {
                        int[] array = matriz[0];
                        for (int i = 0; i < matriz.Length - 1; i++)
                        {
                            matriz[i] = matriz[i + 1];
                        }
                        matriz[matriz.Length - 1] = array;
                    }
                    print();
                    break;
                case 1: //Derecha
                    Console.WriteLine("Escribe cuánto se quiere mover");
                    teclado = Console.ReadLine();
                    num = int.Parse(teclado);

                    for (int v = 0; v < num; v++)
                    {
                        int guardado;
                        for (int i = 0; i < matriz.Length; i++)
                        {
                            guardado = matriz[i][matriz.Length - 1];
                            for (int j = matriz[i].Length - 2; j >= 0; j--)
                            {
                                matriz[i][j + 1] = matriz[i][j];
                            }
                            matriz[i][0] = guardado;
                        }
                    }

                    print();
                    break;
                case 2: //abajo
                    Console.WriteLine("Escribe cuánto se quiere mover");
                    teclado = Console.ReadLine();
                    num = int.Parse(teclado);

                    for (int v = 0; v < num; v++)
                    {
                        int[] array = matriz[matriz.Length - 1];
                        for (int i = matriz.Length - 2; i >= 0; i--)
                        {
                            matriz[i + 1] = matriz[i];
                        }
                        matriz[0] = array;
                    }
                    print();
                    break;
                case 3: //Izquierda
                    Console.WriteLine("Escribe cuánto se quiere mover");
                    teclado = Console.ReadLine();
                    num = int.Parse(teclado);

                    for (int v = 0; v < num; v++)
                    {
                        int guardado;
                        for (int i = 0; i < matriz.Length; i++)
                        {
                            guardado = matriz[i][0];
                            for (int j = 0; j < matriz[i].Length - 1; j++)
                            {
                                matriz[i][j] = matriz[i][j + 1];
                            }
                            matriz[i][matriz.Length - 1] = guardado;
                        }
                    }

                    print();
                    break;

            }
        }
    }
}
