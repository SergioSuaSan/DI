using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    internal class Leon : Carnivoro
    {
        //Constructor parametrizado por posición
        public Leon(int i, int j) : base(i, j) { }

        public override void alimentarse()
        {
           
        }

    

        public override void morir()
        {
            throw new NotImplementedException();
        }

        public override void morirDeHambre()
        {
            throw new NotImplementedException();
        }

        public override void moverse()
        {
            throw new NotImplementedException();
        }

        public override void reproduccion()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "León";
        }
    }
}
