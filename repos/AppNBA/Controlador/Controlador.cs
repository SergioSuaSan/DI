using System;
using System.Data;

namespace AppNBA
{
    public class Controlador
    {
        Modelo modelo;
        public Controlador() {
            modelo = new Modelo();
        }


        /// <summary>
        /// MÉTODOS PARA PINTAR EN LA VENTANA
        /// </summary>
        internal DataTable muestraEquipos()
        {
            return modelo.muestraEquipos();
        }
        internal DataTable muestraJugador(string id)
        {
            return modelo.muestraJugador(id);
        }
        internal DataTable muestraPlantilla(string getPKEquipo)
        {
            return modelo.muestraPlantillaDeEquipo(getPKEquipo);
        }

        //EXAMEN 3
        //Metodo para buscar un jugador
        internal DataTable buscaJugador(string apellido)
        {
            return modelo.buscaJugador(apellido);
        }


        /// <summary>
        /// GETTERS
        /// METODOS PARA OBTENER DATOS EN EL MODELO Y DEVOLVERLOS EN LA VENTANA
        /// </summary>

        //TABLA EQUIPOS
        internal DataTable getEquipo(string v)
        {
            return modelo.getEquipo(v);
        }
        internal string getURLEquipo(string id)
        {
            return modelo.getURLEquipo(id);
        }
        internal string getNombreEquipo()
        {
            return modelo.getNombreEquipo();
        }
        internal string getPKEquipo()
        {
            return modelo.getPKEquipo();
        }

        //TABLA JUGADORES
        internal string getDatosJugador()
        {
            return modelo.getDatosJugador();
        } 
        internal DataTable getJugador(string id)
        {
            return modelo.getJugador(id);
        }
        internal string getPKJugador()
        {
            return modelo.getPKJugador();
        }
        internal string getURLJugador(string idJugador)
        {
            return modelo.getURLJugador(idJugador);
        }



        /// <summary>
        /// OPERACIONES CRUD
        /// </summary>

        //Metodos para insertar
        internal string insertarJugador(string[] jugador)
        {
            return modelo.insertaJugador(jugador);
        }

        //Metodos para actualizar
        internal string actualizarEquipo(string[] equipo)
        {
           return modelo.actualizarEquipo(equipo);
        }
        internal string actualizarJugador(string[] jugador)
        {
            return modelo.actualizarJugador(jugador);   
        }

        //Metodos para eliminar
        internal string eliminarJugador(string idJugador)
        {
            return modelo.eliminarJugador(idJugador);
        }

      
    }
}
