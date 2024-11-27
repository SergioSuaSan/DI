using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    class Vacio : Ser
    {
        public Vacio(int posicioni, int posicionj) : base(posicioni, posicionj)
        {
        }

        public override void morir()
        {
            throw new NotImplementedException();
        }

        public override void reproduccion()
        {
            throw new NotImplementedException();
        }
    }
}
