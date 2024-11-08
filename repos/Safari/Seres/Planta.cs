using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    internal class Planta : Ser
    {
        public Planta(int v, int v1, int posicionposiblex, int posicionposibley) : base() { }

       

        public override void morir()
        {
            throw new NotImplementedException();
        }

        public override void reproduccion()
        {
            base.comprobarCasillas();
            if (base.posibles >= 1)
            {
                int posicionposiblex = base.posibles;
                int posicionposibley = base.posibles;

                new Planta(0, 0, posicionposiblex, posicionposibley);
            }


        }
    }
}
