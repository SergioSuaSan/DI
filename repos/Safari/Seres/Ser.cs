namespace Safari.Seres
{
    public abstract class Ser
    {
        protected int nacimiento;
        protected int tiempoVida;
        protected int posicioni;
        protected int posicionj;
    

        public Ser()
        {
            nacimiento = 0;
            tiempoVida = 0;
            posicioni = 0;
            posicionj = 0;

        }
        public Ser(int nacimiento, int tiempoVida, int posicioni, int posicionj)
        {
            this.nacimiento = nacimiento;
            this.tiempoVida = tiempoVida-nacimiento;
            this.posicioni = posicioni;
            this.posicionj= posicionj;

        }
     

        public abstract void reproduccion();
        public abstract void morir();
    

       
        
    }
}