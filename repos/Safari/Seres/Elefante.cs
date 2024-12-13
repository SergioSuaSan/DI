using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    //Examen 1: Creación de clase Elefante
    internal class Elefante : Hervivoro
    {
        public Elefante(int i, int j) : base(i, j) { }


        //ToString necesario, no borrar
        public override string ToString() { return "Elefante"; }
    }
}
