using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari
{
    public class Controlador
    {
        private Safari miSafari;
        public Controlador() { 
            this.miSafari = new Safari();

        }
        public Controlador(Safari misafari) {
            this.miSafari = misafari;
        }
    }
}
