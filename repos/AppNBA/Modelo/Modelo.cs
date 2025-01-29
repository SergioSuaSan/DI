using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNBA
{
    internal class Modelo
    {
        SqlConnection myConexionSQL;

        public Modelo() { 

            //Creamos la conexión usando la clave que nos da la bbdd
            string miConexion = ConfigurationManager.ConnectionStrings["AppNBA.Properties.Settings.nbadbConnectionString"].ConnectionString;

            //Se crea una conexion SQL como propiedad de clase
            myConexionSQL = new SqlConnection(miConexion);
        }

        internal string getNombreEquipo()
        {
            return "name";
        }

        internal string getPKEquipo()
        {
            return "id";
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


    }
}
