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
        public bool movido { get; set; }
        public Animal(int fila, int colum) : base(fila, colum)
        {


        }
        public abstract void alimentarse();
        public abstract void morirDeHambre();
        public abstract void moverse();
    }
}
