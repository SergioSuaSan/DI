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
        private Ser[] seres;
        private int filas;
        private int columnas;
        private int[,] array;
        private int leones;
        private int gacelas;
        private int plantas;
        private int pasos;
        private bool pausado = false;

        public Safari()
        {
            this.seres = new Ser[60];
            this.filas = 10;
            this.columnas = 10;
            this.array[0,0] = array[filas, columnas];
            this.leones = 20;
            this.gacelas = 20;
            this.plantas = 20;
            this.pasos = 0;



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


    }
}