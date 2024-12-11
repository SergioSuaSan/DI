using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    internal class Gacela : Hervivoro
    {
        public Gacela(int i, int j) : base(i, j) { }


        //ToString necesario, no borrar
        public override string ToString() { return "Gacela"; }
    }
}
