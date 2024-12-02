
namespace Safari.Seres
{
    public abstract class Ser
    {
       
        protected int tiempoVida;
        protected int tiempoSinComer;
        protected int tiempoParaReproducirse;
        protected int posicioni;
        protected int posicionj;
    
        /*
        //Constructor vacio
        public Ser()
        {
            tiempoSinComer = 0;
            tiempoVida = 0;
            posicioni = 0;
            posicionj = 0;

        }
        //Constructor parametrizado entero. Posiblemente sin uso
        public Ser(int nacimiento, int tiempoVida, int posicioni, int posicionj)
        {
            this.tiempoSinComer = 0;
            this.tiempoVida = tiempoVida;
            this.posicioni = posicioni;
            this.posicionj= posicionj;

        }
        */

        //Constructor parametrizado con posición

        public Ser( int posicioni, int posicionj)
        {
            this.tiempoSinComer = 0;
            this.tiempoVida = 0;
            this.posicioni = posicioni;
            this.posicionj = posicionj;

        }


        public abstract void reproduccion();
        public abstract void morir();
        public int getTiempoVida() { return tiempoVida; }
        public int getPosicioni() { return posicioni; }
        public int getPosicionj() { return posicionj; }
        public int getTiempoSinComer() { return tiempoSinComer; }
        public int getTiempoParaReproducirse() { return  tiempoParaReproducirse;}
        public void setTiempoParaReproducirse(int v) { this.tiempoParaReproducirse = v; }
        public void setTiempoSinComer(int v) { this.tiempoSinComer=v; }
        public void setTiempoDeVida(int v ) { this.tiempoVida= v; }
        internal void setPosicioni(int v){this.posicioni = v; }
        internal void setPosicionj(int v){this.posicionj = v; }

    }
}