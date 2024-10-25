using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios.Ejercicios
{
    internal class Ejercicio9:Ejercicio
    {

        /**
         * 
         * <summary>Metodo que te da un toroide y puedes cambiarlo de dirección tantos pasos como quieras</summary>
         * <returns>El toroide modificado con los pasos que hayas indicado en la direccion que quieras</returns>
         * 
         */

        public override void ejecutar()
        {
            Console.WriteLine("Escribe la dirección en la que se moverá la matriz: \n 0 = arriba \n 1 = derecha \n 2 = abajo \n 3 = izquierda");
            int a = LeerDato.LeerEntero();
            ejercicio9(a);
        }
        void ejercicio9(int direccion)
        {

            //Creamos la matriz
            int[][] matriz =
            {
                new int []{10,11,12,13,14 },
                new int []{20,21,22,23,24 },
                new int []{30,31,32,33,34 },
                new int []{40,41,42,43,44 },
                new int []{50,51,52,53,54 }
            };

            //Creamos método imprimir para no copiar tanto código
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
            //Pedímos cuanto se va a mover el toroide
            Console.WriteLine("Escribe cuánto se quiere mover");
            int num = LeerDato.LeerEntero();
            switch (direccion)
            {
                case 0: //arriba
                   
                    //El formato es el mismo para todas las direcciones, así que solo lo voy a explicar esta vez
                    //Creamos un bucle que vaya por filas.
                    for (int v = 0; v < num; v++)
                    {
                        //Copiamos la fila que se va a perder
                        int[] array = matriz[0];
                        //Usamos un bucle para sustituir el resto de filas por la nueva
                        for (int i = 0; i < matriz.Length - 1; i++)
                        {
                            matriz[i] = matriz[i + 1];
                        }
                        //Finalmente ponemos en la fila que resta la que habíamos copiado con anterioridad
                        matriz[matriz.Length - 1] = array;
                    }
                    print();
                    break;
                case 1: //Derecha
                  
                  
                    //La única diferencia es que en vez de coger la columna directamente, al ir por filas,
                    //de cada fila solo copia el número que le interesa y lo pone al principio o final de
                    //la fila según es necesario. AL final el resultado es que toda la columna se desplaza
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
