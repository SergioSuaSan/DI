using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppNBA
{
    internal class Modelo   

    {
        SqlConnection myConexionSQL;
        NBAContextDataContext dataNBA;
        DataTable dtJugador;
        DataTable dtEquipo;

        public Modelo() { 

            //Creamos la conexión usando la clave que nos da la bbdd
            string miConexion = ConfigurationManager.ConnectionStrings["AppNBA.Properties.Settings.nbadbConnectionString"].ConnectionString;

            //Se crea una conexion SQL como propiedad de clase
            myConexionSQL = new SqlConnection(miConexion);
            dataNBA = new NBAContextDataContext(miConexion);
            this.iniciaDataTables();

        }

        private void iniciaDataTables()
        {
            dtEquipo = new DataTable();
            Equipo e = new Equipo();
            foreach (var prop in e.GetType().GetProperties())
            {
                dtEquipo.Columns.Add(prop.Name);
            }
            dtJugador = new DataTable();
            Jugador j = new Jugador();
            foreach (var prop in j.GetType().GetProperties())
            {
                dtJugador.Columns.Add(prop.Name);
            }
          
        }

        internal string getNombreEquipo()
        {
            return "name";
        }

        internal string getPKEquipo()
        {
            return "id";
        }

        internal void getURLLogo(string idEquipo)
        {

            string consulta = "select teamLogoURL from team where id = @idEquipo";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("idEquipo", idEquipo); //Configuro el parámetro



        }

        internal DataTable muestraEquipos()
        {


            string consulta = "select * from Team";


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, myConexionSQL);

            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    //Contenedor
                    DataTable equiposTabla = new DataTable();
                    adaptador.Fill(equiposTabla);


                    return equiposTabla;

                }
            }
            catch (Exception)
            {

                return null;
            }
        }


        internal DataTable getDatosJugador(string idJugador)
        {
            try
            {
                Jugador player = dataNBA.Jugador.First(j => j.id == Convert.ToInt32(idJugador));

                dtJugador.Rows.Clear();
                dtJugador.Rows.Add(player.jerseyNumber, player.nombre, player.apellidos, player.position, player.age );



           

                return dtJugador;
            }
            catch {
                return null;
            }
        }

        internal void insertaJugador(List<string> datosJugador)
        {
            Jugador newJugador = new Jugador();
            newJugador.id = 1 + dataNBA.Jugador.Max(j => Convert.ToInt32(j.id));
            newJugador.jerseyNumber = datosJugador[0];
            newJugador.nombre = datosJugador[1];
            newJugador.apellidos = datosJugador[2];
            newJugador.position = datosJugador[3];
            newJugador.age = datosJugador[4];

            dataNBA.Jugador.InsertOnSubmit(newJugador);
            dataNBA.SubmitChanges();


        }

    }
}
