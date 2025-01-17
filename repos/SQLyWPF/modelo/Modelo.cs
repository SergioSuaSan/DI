using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//Paquetes necesarios para consultas sql y la conexion con la bbdd
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SQLyWPF
{
    internal class Modelo
    {
        SqlConnection myConexionSQL;

        public Modelo()
        {
            //Creamos la conexión usando la clave que nos da la bbdd
            string miConexion = ConfigurationManager.ConnectionStrings["SQLyWPF.Properties.Settings.PruebasWPFConnectionString"].ConnectionString;

            //Se crea una conexion SQL como propiedad de clase
             myConexionSQL = new SqlConnection(miConexion);


        }

        internal string eliminarCliente(string idCliente)
        {

            string consulta = "Delete from Cliente where idCliente = @ClienteID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@ClienteID", idCliente); //Configuro el parámetro

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

        internal string eliminarPedido(string idPedido)
        {
            string consulta = "Delete from Pedido where idPedido = @PedidoID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@PedidoID", idPedido); //Configuro el parámetro

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

        internal string getCampoCliente()
        {
            return "nombre";
        }

        internal string getCampoPedido()
        {
            return "InfoPedido";
        }

        internal string getPKCliente()
        {
            return "IdCliente";
        }

        internal string getPKPedido()
        {
            return "IdPedido";
        }

        internal string insertarCliente(string text)
        {
            string consulta = "Insert into Cliente (Nombre) Values (@nombreCliente)";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@nombreCliente", text); //Configuro el parámetro

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

        internal DataTable muestraClientes()
        {


            string consulta = "select * from Cliente";


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, myConexionSQL);

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

        internal DataTable muestraPedidos()
        {
            string consulta = "select IdPedido, concat (CodCliente, ' | ', FechaPedido, ' | ' , FormaPago) as InfoPedido from Pedido";


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, myConexionSQL);

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

        internal DataTable muestraPedidosPorCliente(string IdCliente)
        {
            string consulta = "select IdPedido, concat ( FechaPedido, ' | ' , FormaPago) as InfoPedido from Pedido " +
                "inner join Cliente on Cliente.IdCliente = Pedido.CodCliente where Cliente.IdCliente = @ClienteID";

            Console.WriteLine(consulta);

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    comando.Parameters.AddWithValue("@ClienteID", IdCliente);
                    //Contenedor
                    DataTable pedidosTabla = new DataTable();
                    adaptador.Fill(pedidosTabla);


                    return pedidosTabla;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
