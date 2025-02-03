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

        internal string actualizarEquipo(string[] equipo)
        {
           return modelo.actualizarEquipo(equipo);
        }

        internal string getDatosJugador()
        {
            return modelo.getDatosJugador();
        }

        internal DataTable getEquipo(string v)
        {
            return modelo.getEquipo(v);
        }

        internal string getNombreEquipo()
        {
            return modelo.getNombreEquipo();
        }

     

        internal string getPKEquipo()
        {
            return modelo.getPKEquipo();
        }

        internal string getPKJugador()
        {
            return modelo.getPKJugador();
        }

        internal string insertarJugador(string[] jugador)
        {
            return modelo.insertaJugador(jugador);
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
