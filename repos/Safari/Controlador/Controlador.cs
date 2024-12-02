using Safari.Seres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari
{
    public class Controlador
    {
        private Safari miSafari;
        /*
        public Controlador() { 
            this.miSafari = new Safari();

        }
        */
        //Constructor parametrizado, el que voy a  usar
        public Controlador(Safari misafari) {
            this.miSafari = misafari;
        }

        //Todas las llamadas al Safari para llevarlo a la ventana
        public void iniciarSafari() { miSafari.iniciarSafari(); }
        public int getFilas() { return miSafari.getFilas(); }
        public void resetear() { miSafari.resetear(); }
        public int getColumnas() { return miSafari.getColumnas();}
        public Ser[,] getSeres() { return miSafari.getSeres(); }
        public Ser getSer(int fila, int columna) { return miSafari.getSer(fila, columna); }
        public String getNombre(Ser ser) { return ser.ToString(); }
        public String getPasos() {  return miSafari.getPasos();}
        internal String getPlantas() { return miSafari.getPlantas(); }
        internal string getGacelas() { return miSafari.getGacelas(); }
        internal string getLeones(){ return miSafari.getLeones();  }
        internal void step() { miSafari.avanzar(); }
    }
}
