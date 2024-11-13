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
            this.seres = new Ser[60];
            this.filas = 10;
            this.columnas = 10;
            this.leones = 20;
            this.gacelas = 20;
            this.plantas = 20;
            this.pasos = 0;
            this.pausado = false;



        }
        public Safari(int filas, int columnas)
        {
            this.seres = new Ser[60];
            this.filas = filas;
            this.columnas = columnas;
            this.leones = 20;
            this.gacelas = 20;
            this.plantas = 20;
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


    }
}