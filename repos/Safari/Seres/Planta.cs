using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    internal class Planta : Ser
    {
        public Planta(int i, int j) : base(i, j) { 
            
        }




        public override void morir()
        {
            
        }

        public override void reproduccion()
        {
   
        }
        public int getTiempoVida() { return tiempoVida; }
        public int getPosicioni() { return posicioni; }
        public int getPosicionj() { return posicionj; }
        public int getTiempoSinComer() { return tiempoSinComer; }
        public int getTiempoParaReproducirse() { return tiempoParaReproducirse; }
        public void setTiempoParaReproducirse(int v) { this.tiempoParaReproducirse = v; }
        public void setTiempoSinComer(int v) { this.tiempoSinComer = v; }
        public void setTiempoDeVida(int v) { this.tiempoVida = v; }
        internal void setPosicioni(int v) { this.posicioni = v; }
        internal void setPosicionj(int v) { this.posicionj = v; }
        public override string ToString()
        {
            return "Planta";
        }

    }
}
