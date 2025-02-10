using System;
using System.Collections.Generic;
using System.Linq;


namespace Safari.Seres
{
    internal abstract class Animal : Ser
    {  
        
        private bool movido;

        //Constructor parametrizado
        public Animal(int fila, int colum) : base(fila, colum)
        {
        }
        //Métodos necesarios
        public bool getMovido() {return  this.movido; }
        public void setMovido(bool movido) { this.movido = movido; }

     

        
    }
}
