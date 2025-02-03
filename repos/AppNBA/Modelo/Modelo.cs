using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

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

            //CLAVE DE CLASE
            //string miConexion = ConfigurationManager.ConnectionStrings["AppNBA.Properties.Settings.nbadbConnectionString"].ConnectionString;


            //CLAVE DE CASA
            string miConexion = ConfigurationManager.ConnectionStrings["AppNBA.Properties.Settings.nbadbConnectionString1"].ConnectionString;

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

        internal DataTable muestraPlantillaDeEquipo(String idEquipo)
        {


            string consulta = "select id, concat (position  ,  ' -> '  ,  lastName  ,    ', '   ,   firstName) as " +
                "Info from player where team in (select name from team where id = @idEquipo)";


            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@idEquipo", idEquipo); //Configuro el parámetro

            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    //Contenedor
                    DataTable plantillaTabla = new DataTable();
                    adaptador.Fill(plantillaTabla);


                    return plantillaTabla;

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

        internal string insertaJugador(string[] jugador)


        {

            string maxId = this.sacarMaxIdJugadores();
            string nombreEquipo = this.sacarNombreEquipo(jugador[4]);
            string consulta = $"Insert into player (id, firstName, lastName, position, jerseyNumber, team) Values ( {maxId}, '{jugador[0]}', '{jugador[1]}', '{jugador[2]}', '#{jugador[3]}', '{nombreEquipo}')";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
           

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                comando.ExecuteNonQuery(); //Ejecutamos la sentencia de Insertado
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }
            catch (Exception ex)
            {

                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
                return ex.Message;
            }
            return null;

        }

        private string sacarMaxIdJugadores()
        {
            string consulta = "select max(id)+1 as Maximo from player";

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            myConexionSQL.Open();
            string resultado = comando.ExecuteScalar().ToString();
            myConexionSQL.Close();

            return resultado;

        }  private string sacarNombreEquipo(string id)
        {
            string consulta = "select name from team where id = @id";

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("id", id); //Configuro el parámetro


            myConexionSQL.Open();
            string resultado = comando.ExecuteScalar().ToString();
            myConexionSQL.Close();

            return resultado;

        }

        internal string getPKJugador()
        {
            return "id";
        }


        internal DataTable getEquipo(string equipoID)
        {
            string consulta = "select * from team where id = @EquipoID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("equipoID", equipoID); //Configuro el parámetro


            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    //Contenedor
                    DataTable clientesTabla = new DataTable();
                    adaptador.Fill(clientesTabla);


                    return clientesTabla;

                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal string actualizarEquipo(string[] equipo)
        {
            try
            {
                string consulta = "UPDATE team SET name ='" + equipo[1] + "', " +
                    "conference='" + equipo[2] + "', " +
                    "record='" + equipo[3] + "' " +
                    "WHERE id = " + equipo[0];

                SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

                myConexionSQL.Open();
                comando.ExecuteNonQuery();
                myConexionSQL.Close();

                return null;
            }

            catch (Exception ex)
            {
                myConexionSQL.Close();
                return ex.ToString();
            }
        }

        internal string getDatosJugador()
        {
            return "Info";
        }
    }
}
