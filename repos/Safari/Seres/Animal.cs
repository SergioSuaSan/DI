using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Safari.Seres
{
    internal abstract class Animal : Ser
    {  
        //ALEJANDRO //String comida;
        private bool movido;

        //Constructor parametrizado
        public Animal(int fila, int colum) : base(fila, colum)
        {
        }
        public bool getMovido() {return  this.movido; }
        public void setMovido(bool movido) { this.movido = movido; }
        public abstract void alimentarse();
        public abstract void morirDeHambre();
        public abstract void moverse();
    }
}
