using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    internal class Planta : Ser
    {
        public Planta(int v, int v1, int posicionposible) : base() { }

       

        public override void morir()
        {
            throw new NotImplementedException();
        }

        public override void reproduccion()
        {
            comprobarCasillas();

            if (base.posibles >= 1)
            {
                int posicionposible = base.posibles;
                

                new Planta(0, 0, posicionposible);
            }


        }

        public override void comprobarCasillas()
        {
            
        }

     
    }
}
