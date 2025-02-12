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

        public Modelo() {

            //Creamos la conexión usando la clave que nos da la bbdd

            //CLAVE DE CLASE
            string miConexion = ConfigurationManager.ConnectionStrings["AppNBA.Properties.Settings.nbadbConnectionString"].ConnectionString;


            //CLAVE DE CASA
            //string miConexion = ConfigurationManager.ConnectionStrings["AppNBA.Properties.Settings.nbadbConnectionString1"].ConnectionString;

            //Se crea una conexion SQL como propiedad de clase
            myConexionSQL = new SqlConnection(miConexion);
         

        }

        /// <summary>
        /// GETTERS
        /// PETICIONES DE DATOS DESDE LA VISTA
        /// </summary>
        /// <returns>LOS DATOS PEDIDOS</returns>

        internal string getNombreEquipo()
        {
            return "name";
        }
        internal string getPKEquipo()
        {
            return "id";
        }

        //Para insertar un jugador necesitamos saber el idMáximo de jugadores y añadirle 1
        private string sacarMaxIdJugadores()
        {
            string consulta = "select max(id)+1 as Maximo from player";

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

            string resultado = "";

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                resultado = comando.ExecuteScalar().ToString(); //Ejecutamos la sentencia de  y la guardamos en un string
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }
            catch (Exception ex)
            {

                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
                
            }

         

            return resultado;

        }
        
        //Como las tablas no están relacionadas, el jugador no tiene el nombre del equipo, sino un código. 
        //Por tanto, este método permite sacar el nombre del equipo a partir del código.
        private string sacarNombreEquipo(string id)
        {
            string consulta = "select name from team where id = @id";

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("id", id); //Configuro el parámetro

            string resultado = "";

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                resultado = comando.ExecuteScalar().ToString(); //Ejecutamos la sentencia de  y la guardamos en un string
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }
            catch (Exception ex)
            {

                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo

            }

            return resultado;

        }

        internal string getPKJugador()
        {
            return "id";
        }
        internal string getDatosJugador()
        {
            return "Info";
        }

        //Para sacar las imágenes necesitamos las url, que están como string en la BBDD. Métodos para sacarlas.
        internal string getURLEquipo(string id)
        {
            string consulta = "select teamLogoUrl from team where id = @id";

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("id", id); //Configuro el parámetro


            string resultado = "";

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                resultado = comando.ExecuteScalar().ToString(); //Ejecutamos la sentencia de  y la guardamos en un string
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }
            catch (Exception ex)
            {

                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo

            }

            return resultado;
        }

        internal string getURLJugador(string idJugador)
        {
            string consulta = "select headShotUrl from player where id = @id";

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("id", idJugador); //Configuro el parámetro

            string resultado = "";

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                resultado = comando.ExecuteScalar().ToString(); //Ejecutamos la sentencia de  y la guardamos en un string
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }
            catch (Exception ex)
            {

                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo

            }

            return resultado;
        }


        //Método que se usa para obtener los datos del equipo que vamos a actualizar
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

        //Método que se usa para obtener los datos del jugador que vamos a actualizar
        internal DataTable getJugador(string id)
        {
            string consulta = "select id, firstName, lastName, position, jerseyNumber, team from player where id = @JugadorID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("JugadorID", id); //Configuro el parámetro


            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    //Contenedor
                    DataTable jugadorTabla = new DataTable();
                    adaptador.Fill(jugadorTabla);


                    return jugadorTabla;

                }
            }
            catch (Exception)
            {

                return null;
            }
        }







        /// <summary>
        /// MUESTRA
        /// LENA LAS TABLAS Y SE LAS DA A LAS VISTAS PARA QUE LAS PINTE
        /// </summary>
        /// <returns>LAS TABLAS PINTADAS</returns>

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
        internal DataTable muestraJugador(string id)
        {
            string consulta = "select id as Código, firstName as Nombre,lastname as Apellido, team as Equipo " +
                ", position as Posición, jerseyNumber as 'Nº Camiseta' from player where id = @id";


            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@id", id); //Configuro el parámetro

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




        /// <summary>
        /// MODIFICACIONES CRUD
        /// MODIFICA LOS DATOS DE LA BBDD
        /// </summary>
        /// <returns>LA MODIFICACIÓN REALIZADA EN LA BBDD</returns>

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
        internal string actualizarEquipo(string[] equipo)
        {
            try
            {
                //Vamos a guardar el antiguo nombre del equipo que vamos a actualizar
                //Esto servirá para actualizar el nombre del equipo de todos los jugadores también
                string nombreEquipo = sacarNombreEquipo(equipo[0]);
                string consulta = "UPDATE team SET name ='" + equipo[1] + "', " +
                    "conference='" + equipo[2] + "', " +
                    "record='" + equipo[3] + "' " +
                    "WHERE id = " + equipo[0];

                SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

                myConexionSQL.Open();
                comando.ExecuteNonQuery();
                myConexionSQL.Close();

                this.actualizarEquipoJugador(nombreEquipo, equipo[1]);

                return null;
            }

            catch (Exception ex)
            {
                myConexionSQL.Close();
                return ex.ToString();
            }
        }


        //Método dedicado a cambiar el nombre del equipo de todos los jugadores pertenecientes a ese equipo para que no crashee
        private void actualizarEquipoJugador(string nombreEquipo, string nuevoNombre)
        {
            try
            {
                string consulta = $"UPDATE player SET  team = '{nuevoNombre}' WHERE team = '{nombreEquipo}'";

                SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

                myConexionSQL.Open();
                comando.ExecuteNonQuery();
                myConexionSQL.Close();

               
            }

            catch (Exception ex)
            {
                myConexionSQL.Close();
               
            }

        }

        internal string actualizarJugador(string[] jugador)
        {
            try
            {
                string consulta = $"UPDATE player SET firstName ='{jugador[0]}', lastName ='{jugador[1]}', position='{jugador[2]}', jerseyNumber = '{jugador[3]}', team = '{jugador[4]}' WHERE id = {jugador[5]}";

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
        internal string eliminarJugador(string idJugador)
        {
            string consulta = "Delete from player where id = @JugadorID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("JugadorID", idJugador ); //Configuro el parámetro

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                comando.ExecuteNonQuery(); //Ejecutamos la sentencia de borrado
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo

            }
            catch (Exception ex)
            {

                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
                return ex.Message;
            }
            return null;
        }

     
    }
}
