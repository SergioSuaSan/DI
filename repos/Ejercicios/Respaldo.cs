﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class ProgramasinCLases

    {
        //--MAIN

        //ejercicio10();

        /*
        Console.WriteLine("Estos son los resultados de los ejercicios");
        Console.WriteLine("Ejercicio 1:");
        if (ejercicio1(7))
        {
            Console.WriteLine("El numero es primo");

        }
        else
        {
            Console.WriteLine("El número no es primo");
        }

        Console.WriteLine("Ejercicio 2:");
        ejercicio2(4, 3, 4);

        Console.WriteLine("Ejercicio 3:");
        Console.WriteLine(ejercicio3(10));

        Console.WriteLine("Ejercicio 4:");
        ejercicio4(2, 2);

        Console.WriteLine();
        Console.WriteLine("Ejercicio 5:");
        ejercicio5("Me llamo Sergio");

        Console.WriteLine("Ejercicio 6:");
        ejercicio6(101010101);

        Console.WriteLine("Ejercicio 7:");
        Console.WriteLine(ejercicio7("Hola, me llamo Sergio."));

        Console.WriteLine("Ejercicio 8:");
        Console.WriteLine( ejercicio8(1.78, 55));
        */

    }
    /*
    static bool ejercicio1(int num)
    {

         //Voy a crear un bucle negativo por el cual si el resto de la división de el numero/ i es 0, retorna falso y sale del 
         //bucle. Si el bucle termina, no se ha podido dividir por ninguno, por lo que será primo (true)

        for (int i = num - 1; i >= 2; i--)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;

    }
    static void ejercicio2(int num1, int num2, int num3)
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


    static int ejercicio3(int n)
    {
        //Creamos 2 casos base para para poder sumarlos ya que la formula utiliza 2 recursivas.
        if (n == 1)
        {
            return 1;
        }
        if (n == 2)
        {
            return 1;

        }
        return ejercicio3(n - 1) + ejercicio3(n - 2);
    }



    static void ejercicio4(int x, int y)
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

    static void ejercicio5(String cadena)
    {
        //Creamos un array de char del tamaño al menos de la cadena
        char[] arr = new char[cadena.Length];
        //Creamos un bucle que ponga en el array los caracteres distintos de ' '
        for (int i = 0; i < cadena.Length; i++)
        {
            if (cadena[i] != ' ')
            {
                arr[i] = cadena[i];
            }
        }
        //Escribimos el array
        Console.WriteLine(arr);
    }

    static void ejercicio6(int num)
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
    static String ejercicio7(String cadena)
    {

        //String reves = "";
        //StringBuilder sb = new StringBuilder(reves);

        //for (int i = 0;i < cadena.Length;i++)
        //{
        //    sb.Append( cadena[(cadena.Length-1) - (i)]);
        //}


        //Console.WriteLine(sb);


        //Creamos un String que va a tener el resultado que vamos a mostrar
        String reves = "";
        //Damos los casos base, incluimos la cadena vacía para evitar errores
        if (cadena.Length == 0) { return "No has escrito nada"; }
        if (cadena.Length == 1)
        {
            //cogemos el último caracter aunque sea uno, nos ayuda a la hora de la recursividad
            reves += cadena.Substring(cadena.Length - 1, cadena.Length);
            return reves;
        }
        reves += cadena.Substring(cadena.Length - 1);
        //Al último caracter le añadimos el recursivo de la misma cadena sin el último caracter
        reves += ejercicio7(cadena.Substring(0, cadena.Length - 1));
        return reves;


    }

    static string ejercicio8(double bote, double cantidad)
    {
        //declaro las variables
        double cambio;
        int e2 = 0, e1 = 0, c50 = 0, c20 = 0, c10 = 0, c5 = 0, c2 = 0, c1 = 0;

        if (cantidad < bote)
        {
            //Si la cantidad es menor a lo que se pide, salta un error
            throw new Exception("No hay suficiente pasta");
        }
        else
        {
            //calculamos el cambio
            cambio = cantidad - bote;
            //Calculamos cuantas monedas se tienen que devolver
            e2 = (int)(cambio / 2);
            //Luego se restará la cantidad correspondiente a lo que cuesten ese numero de monedas
            cambio -= 2 * e2;
            e1 = (int)(cambio / 1);
            cambio -= 1 * e1;
            c50 = (int)(cambio / 0.5);
            cambio -= 0.5 * c50;
            c20 = (int)(cambio / 0.2);
            cambio -= 0.2 * c20;
            c10 = (int)(cambio / 0.1);
            cambio -= 0.1 * c10;
            c5 = (int)(cambio / 0.05);
            cambio -= 0.05 * c5;
            c2 = (int)(cambio / 0.02);
            cambio -= 0.02 * c2;
            c1 = (int)(cambio / 0.01);
            cambio -= 0.01 * c1;

            //Sin embargo, las restas por algñun motivo deja decimales periódicos, por lo que hay una moneda de 1c que se acaba perdiendo, no entiendo por qué.
            return ("Recibes " + e2 + " monedas de 2€, " + e1 + " monedas de 1€, " + c50 + " monedas de 50c, " + c20 + " monedas de 20c, " +
                c10 + " monedas de 10c, " + c5 + " monedas de 5c, " + c2 + " monedas de 2c y " + c1 + " monedas de 1c");

        }


    }


    static void ejercicio9(int direccion)
    {


        int[][] matriz =
        {
            new int []{10,11,12,13,14 },
            new int []{20,21,22,23,24 },
            new int []{30,31,32,33,34 },
            new int []{40,41,42,43,44 },
            new int []{50,51,52,53,54 }
        };


        void print() {
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
                    for (int i = 0; i < matriz.Length-1; i++)
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
                        for (int j = matriz[i].Length-2; j >=0; j--)
                        {
                            matriz[i][j+1] = matriz[i][j];
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
                    int[] array = matriz[matriz.Length-1];
                    for (int i = matriz.Length-2; i >= 0; i--)
                    {
                        matriz[i+1] = matriz[i];
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
                        for (int j = 0; j < matriz[i].Length-1; j++)
                        {
                            matriz[i][j] = matriz[i][j+1];
                        }
                        matriz[i][matriz.Length-1] = guardado;
                    }
                }

                print();
                break;

        }
    }

        static void ejercicio10()
        {
            Console.WriteLine("Qué función queres hacer? \n 1: numero primo \n 2: triangulo \n 3: fibonacci \n 4: submatriz \n 5: Sin espacios \n 6: binario \n 7: palindromos \n 8: cambio monedas \n 9: toroide \n 10: opcional perfecto");
            String teclado = Console.ReadLine();
            int num = int.Parse(teclado);
            switch (num)
            {
                case 1:
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    num = int.Parse(teclado);
                    if (ejercicio1(num))
                    {
                        Console.WriteLine("El numero es primo");

                    }
                    else
                    {
                        Console.WriteLine("El número no es primo");
                    }
                    break;
                case 2:
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    int a = int.Parse(teclado);
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    int b = int.Parse(teclado);
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    int c = int.Parse(teclado);
                    ejercicio2(a, b, c); break;
                case 3:
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    a = int.Parse(teclado);
                    Console.WriteLine(ejercicio3(a));
                    break;
                case 4:
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    a = int.Parse(teclado);
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    b = int.Parse(teclado);
                    ejercicio4(a, b);
                    break;
                case 5:
                    Console.WriteLine("Escribe una cadena");
                    String cadena = Console.ReadLine();
                    ejercicio5(cadena);
                    break;
                case 6:
                    Console.WriteLine("Escribe un numero");
                    teclado = Console.ReadLine();
                    a = int.Parse(teclado);
                    ejercicio6(a);
                    break;
                case 7:
                    Console.WriteLine("Escribe una cadena");
                    cadena = Console.ReadLine();
                    Console.WriteLine(ejercicio7(cadena));
                    break;
                case 8:
                    Console.WriteLine("Escribe el bote");
                    teclado = Console.ReadLine();
                    double d = double.Parse(teclado);
                    Console.WriteLine("Escribe la cantidad");
                    teclado = Console.ReadLine();
                    double e = double.Parse(teclado);
                    Console.WriteLine(ejercicio8(d, e));
                    break;
                case 9:
                Console.WriteLine("Escribe la dirección en la que se moverá la matriz: \n 0 = arriba \n 1 = derecha \n 2 = abajo \n 3 = izquierda");
                teclado = Console.ReadLine();
                a = int.Parse(teclado);
                ejercicio9(a);
                    break;
                case 10:
                Console.WriteLine("Escribe un numero");
                teclado = Console.ReadLine();
                a = int.Parse(teclado);
                ejercicio11(a);
                break;


            default: Console.WriteLine("Esta opción no existe");
                ejercicio10();
                break;

            }
        }

    static void ejercicio11(int num)
    {
        int acumulador = 0;
        //Buscamos todos los números por los que se pueda dividir el parámetro y se suma en el acumulador.
        for (int i = num - 1; i >= 1; i--)
        {
            if (num % i == 0)
            {
                acumulador += i;
            }
        }
        //Comparación final
        if (acumulador == num) {
            Console.WriteLine("EL número es perfecto");
        }
        else {
            Console.WriteLine("El número NO es perfecto");
        }

    }

    */

}
