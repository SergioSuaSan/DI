using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNBA
{
    public class Controlador
    {
        Modelo modelo;
        public Controlador() {
            modelo = new Modelo();
        }

        internal string getNombreEquipo()
        {
            return modelo.getNombreEquipo();
        }

        internal string getPKEquipo()
        {
            return modelo.getPKEquipo();
        }

        internal DataTable muestraEquipos()
        {
           return  modelo.muestraEquipos();
        }
    }
}
