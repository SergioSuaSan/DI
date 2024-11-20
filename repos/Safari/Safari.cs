using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Seres;

namespace Safari
{
    public class Safari
    {
        private Ser[] seres {  get; set; }
        private int filas {  get; set; }
        private int columnas { get; set; }
        private int leones { get; set; }
        private int gacelas { get; set; }
        private int plantas { get; set; }
        private int pasos { get; set; }
        private bool pausado { get; set; }

        public Safari()
        {
            this.filas = 10;
            this.columnas = 10;
            this.leones = (filas * columnas) * 2 / 9;
            this.gacelas = (filas * columnas) * 4 / 9;
            this.plantas = (filas * columnas) / 3;
            this.pasos = 0;
            this.seres = new Ser[100];
            this.pausado = false;



        }
        public Safari(int filas, int columnas)
        {
            this.seres = new Ser[filas*columnas];
            this.filas = filas;
            this.columnas = columnas;
            this.leones = (filas * columnas) * 2 / 9;
            this.gacelas = (filas * columnas) * 4 / 9;
            this.plantas = (filas * columnas) / 3;
            this.pasos = 0;
            this.pausado = false;



        }
        public void avanzar() 
        {
            pausado = false;
            pasos++;

            
        }
        public void pausar() {
            pausado = true;
        }
        public void resetear() { }
        public void autoplay() 
        {
            while (!pausado)
            {
                avanzar();
                System.Threading.Thread.Sleep(3000);
            }
        }
        public void terminar() {
            
        }

       
        public void iniciarSafari()
        {
          



            // Rellenar las celdas con texto de ejemplo
           
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                   
                    

                }
            }
        }


    }
}