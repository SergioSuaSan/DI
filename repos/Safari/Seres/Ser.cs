namespace Safari.Seres
{
    internal abstract class Ser
    {
        protected int nacimiento;
        protected int tiempoVida;
        protected int posicionx;
        protected int posiciony;

        public int posibles;

        public Ser()
        {
            nacimiento = 0;
            tiempoVida = 0;
            posicionx = 0;
            posiciony = 0;

        }
        public Ser(int nacimiento, int tiempoVida, int posicionx, int posiciony)
        {
            this.nacimiento = nacimiento;
            this.tiempoVida = tiempoVida;
            this.posicionx = posicionx;
            this.posiciony = posiciony;

        }
        public abstract void reproduccion();
        public abstract void morir();
        public  void comprobarCasillas()
        {
            if (posiciony == 0 && posicionx == 0)
            {

            }

        }
    }
}