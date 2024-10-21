using Ejercicios.Ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios
{
    internal class Menu
    {


        private Ejercicio[] ejer;
        
        /*
        private Ejercicio1 ejer1;
        private Ejercicio2 ejer2;
        private Ejercicio3 ejer3;
        private Ejercicio4 ejer4;
        private Ejercicio5 ejer5;
        private Ejercicio6 ejer6;
        private Ejercicio7 ejer7;
        private Ejercicio8 ejer8;
        private Ejercicio9 ejer9;
        private Ejercicio11 ejer11;
        */

        public Menu() {
            ejer = new Ejercicio[12];
           
            ejer[1] = new Ejercicio1();
            ejer[2] = new Ejercicio2();
            ejer[3] = new Ejercicio3();
            ejer[4] = new Ejercicio4();
            ejer[5] = new Ejercicio5();
            ejer[6] = new Ejercicio6();
            ejer[7] = new Ejercicio7();
            ejer[8] = new Ejercicio8();
            ejer[9] = new Ejercicio9();
            ejer[10] = new Ejercicio11();
            ejer[11] = new Ejercicio11();
            /*
            ejer1 = new Ejercicio1();
            ejer2 = new Ejercicio2();
            ejer3 = new Ejercicio3();
            ejer4 = new Ejercicio4();
            ejer5 = new Ejercicio5();
            ejer6 = new Ejercicio6();
            ejer7 = new Ejercicio7();
            ejer8 = new Ejercicio8();
            ejer9 = new Ejercicio9();
            ejer11 = new Ejercicio11();
            */
        }

        

        public void ejercicio10()
        {
            Console.WriteLine("Qué función queres hacer? \n 0: Salir \n 1: numero primo \n 2: triangulo \n 3: fibonacci \n 4: submatriz \n 5: Sin espacios \n 6: binario \n 7: palindromos \n 8: cambio monedas \n 9: toroide \n 10: opcional perfecto");
            int num = LeerDato.LeerEntero();

            while (num != 0)
            {
                if (num > 0 && num <12)
                {
                    ejer[num].ejecutar();
                }
                if (num >= 12 || num <0)
                {
                    Console.WriteLine("No existe ese ejercicio");

                }
                Console.WriteLine("Pulsa INTRO para continuar");
                Console.ReadLine();
                Console.Clear();
                ejercicio10();
            }
            Console.WriteLine("Adios");
            Environment.Exit(0);
           
          

            /*
            switch (num)
            {
                case 1:
                    ejer1.ejecutar();
                    break;
                case 2:
                    ejer2.ejecutar(); 
                    break;
                case 3:
                    ejer3.ejecutar();
                    break;
                case 4:
                    ejer4.ejecutar();
                    break;
                case 5:
                    ejer5.ejecutar();

                    break;
                case 6:
                    ejer6.ejecutar();

                    break;
                case 7:
                    ejer7.ejecutar();

                    break;
                case 8:
                    ejer8.ejecutar();

                    break;
                case 9:
                    ejer9.ejecutar();

                    break;
                case 10:
                    ejer11.ejecutar();

                    break;


                default:
                    Console.WriteLine("Esta opción no existe");
                    ejercicio10();
                    break;

            }
            */

        }
    }
}
