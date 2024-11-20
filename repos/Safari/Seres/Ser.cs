namespace Safari.Seres
{
    public abstract class Ser
    {
        protected int nacimiento;
        protected int tiempoVida;
        protected int posicionindice;
    

        public Ser()
        {
            nacimiento = 0;
            tiempoVida = 0;
            posicionindice = 0;

        }
        public Ser(int nacimiento, int tiempoVida, int posicionx)
        {
            this.nacimiento = nacimiento;
            this.tiempoVida = tiempoVida;
            this.posicionindice = posicionx;

        }
        public abstract void reproduccion();
        public abstract void morir();
        public abstract void comprobarCasillas();
       
        
    }
}