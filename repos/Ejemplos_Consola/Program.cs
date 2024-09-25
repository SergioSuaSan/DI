using System;
namespace EjemploColecciones
{
    class Program
    {


        static void mostrarLista (List<string> miLista)
        {
            Console.WriteLine("\n La lista es: \n");
            foreach (String iStr in miLista)
            {
                Console.WriteLine(iStr);

            }
        }
        static void Main(string[] args)
        {

            List<String> miLista = new List<String>();


            String entrada = "";
            bool seguir = true;
            while (seguir)
            {
                Console.WriteLine("Dame el siguiente valor de la lista o escribe FIN para terminar");
                entrada = Console.ReadLine();
                if (entrada.Equals("FIN")) {
                    seguir = false;

                }
                else
                {
                    miLista.Add(entrada);
                }

            }

            mostrarLista(miLista);

            Console.WriteLine("Dime el valor de la lista que quieres eliminar");
            entrada = Console.ReadLine();

            if (miLista.Contains(entrada))
            {
                miLista.Remove(entrada);
            }
            else
            {
                Console.WriteLine("No existe ese valor");
            }

            Console.WriteLine
                ();
            mostrarLista(miLista);
        }


    }
}

