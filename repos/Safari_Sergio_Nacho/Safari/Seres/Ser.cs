﻿namespace Safari.Seres
{
    public abstract class Ser
    {
        protected int nacimiento;
        protected int tiempoVida;
        protected int tiempoParaReproducirse;
        protected int posicioni {  get; set; }
        protected int posicionj {  get; set; }
    

        //Constructor vacio
        public Ser()
        {
            nacimiento = 0;
            tiempoVida = 0;
            posicioni = 0;
            posicionj = 0;

        }
        //Constructor parametrizado entero. Posiblemente sin uso
        public Ser(int nacimiento, int tiempoVida, int posicioni, int posicionj)
        {
            this.nacimiento = nacimiento;
            this.tiempoVida = tiempoVida-nacimiento;
            this.posicioni = posicioni;
            this.posicionj= posicionj;

        }
        //Constructor parametrizado con posición
        public Ser( int posicioni, int posicionj)
        {
            //this.nacimiento = 0;
            this.tiempoVida = 0;
            this.posicioni = posicioni;
            this.posicionj = posicionj;

        }


        public abstract void reproduccion();
        public abstract void morir();

        public int getNacimiento() { return nacimiento; }
        public int getTiempoVida() { return tiempoVida; }
        public int getPosicioni() { return posicioni; }
        public int getPosicionj() { return posicionj; }
        public void setPosicioni(int nuevai) { this.posicioni=nuevai; }
        public void setPosicionj(int nuevaj) { posicionj=nuevaj; }




    }
}