

namespace Safari.Seres
{
    internal class Planta : Ser
    {
        public Planta(int i, int j) : base(i, j) {   }



        //Métodos necesarios, no borrar
        public int getTiempoVida() { return tiempoVida; }
        public int getPosicioni() { return posicioni; }
        public int getPosicionj() { return posicionj; }
        public void setTiempoDeVida(int v) { this.tiempoVida = v; }
        internal void setPosicioni(int v) { this.posicioni = v; }
        internal void setPosicionj(int v) { this.posicionj = v; }
        public override string ToString()
        {
            return "Planta";
        }

    }
}
