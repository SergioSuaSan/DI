
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Printing;

namespace EjemploLINQ
{
    class EjemLINQ
    {
        static void Main(string[] args)
        {
            /*
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Estos son los números pares: ");
            IEnumerable<int> nPares = from n in numeros where n % 2 == 0 select n;
            foreach (int n in nPares)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números pares: ");
            Console.WriteLine(nPares.Count());

            IEnumerable<int> nImpares = from n in numeros where n % 2 != 0 select n;
            Console.WriteLine("Estos son los números impares: ");
            foreach (int n in nImpares)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números impares: ");
            Console.WriteLine(nImpares.Count());

            IEnumerable<int> mult3 = from n in numeros where n % 3 == 0 select n;
            Console.WriteLine("Estos son los números múltiplos de 3: ");
            foreach (int n in mult3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números múltiplos de 3: ");
            Console.WriteLine(mult3.Count());




            IEnumerable<int> multi3 = from n in nPares where n % 3 == 0 select n;
            Console.WriteLine("Estos son los números pares múltiplos de 3: ");
            foreach (int n in multi3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("Este es el número de números pares múltiplos de 3: ");
            Console.WriteLine(multi3.Count());
            */

            Console.ww
            
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Primero configuramos la ruta del fichero de origen
            string filePath = "C:\\documentos\\nacho\\ejemplo.txt";
            // Leemos el contenido y lo almacenamos en un string
            string linea = System.IO.File.ReadAllText(filePath);
            // Creamos un objeto con el tipo de fuente que queremos usar
            Font font = new Font("Arial", 12);
            // Configuramos un area de impresión
            RectangleF area = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top,
            e.MarginBounds.Width, e.MarginBounds.Height);
            // Escribimos el contenido del fichero txt en el área definida de impresión usando la
            //fuente seleccionada y un pincel que podemos crear antes o usar el de por defecto
            e.Graphics.DrawString(line, font, Brushes.Black, area);
            // Marcamos el parámetro HasMorePages a false para indicar que no hay más
            //páginas para imprimir
            e.HasMorePages = false;
        }
    }
}