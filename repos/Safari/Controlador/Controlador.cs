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
        public Controlador(Safari misafari) {this.miSafari = misafari; }

        //Todas las llamadas al Safari para llevarlo a la ventana
        public void iniciarSafari() { miSafari.iniciarSafari(); }
        public int getFilas() { return miSafari.getFilas(); }
        public void resetear() { miSafari.resetear(); }
        public int getColumnas() { return miSafari.getColumnas();}

        //Devuelve el nombre del Ser que está en esa posición
        public string getTipoSer(int fila, int columna) { return miSafari.getTipoSer(fila, columna); }
        public string getPasos() {  return miSafari.getPasos();}
        internal string getPlantas() { return miSafari.getPlantas(); }
        internal string getGacelas() { return miSafari.getGacelas(); }
        internal string getLeones(){ return miSafari.getLeones();  }
        internal void step() { miSafari.avanzar(); }
        internal void autoplay(VentanaP ventanaP){ miSafari.autoplay(ventanaP); }
        internal void pausar() { miSafari.pausar(); }
        internal void despausar() {miSafari.despausar();}

        //Examen 1
        internal string getElefantes()
        {
            return miSafari.getElefantes();
        }

        //Examen 2

        internal void steps10()
        {
            miSafari.avanzar10pasos();
        }

        //Examen 3
        internal int getTurnos()
        {
            return miSafari.getTurnos();
        }
    }
}
