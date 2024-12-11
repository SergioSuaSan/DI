using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Seres
{
    class Vacio : Ser
    {
        /*
         * CLASE EXCLUSIVA POR COMODIDAD
         * Esta clase solo sirve para diferenciar los vacíos que YO quiero que estén respecto a los 
         * null que ocurran por fallos en el código.
         * El plan es no hacer nada aquí, solo que exista.
         */

        public Vacio(int posicioni, int posicionj) : base(posicioni, posicionj)
        {
            this.posicioni = posicioni;
            this.posicionj = posicionj;
        }

        public override void morir(){  throw new NotImplementedException(); }

        public override void reproduccion() { throw new NotImplementedException();}

        public override string ToString()
        {
            return "Vacio";
        }
    }
}
