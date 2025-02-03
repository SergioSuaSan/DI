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

        internal string getNombreJugador()
        {
            return modelo.getNombreJugador();
        }

        internal string getPKEquipo()
        {
            return modelo.getPKEquipo();
        }

        internal string getPKJugador()
        {
            return modelo.getPKJugador();
        }

        internal DataTable muestraEquipos()
        {
           return  modelo.muestraEquipos();
        }

        internal DataTable muestraPlantilla(string getPKEquipo)
        {
            return modelo.muestraPlantillaDeEquipo( getPKEquipo);
        }
    }
}
