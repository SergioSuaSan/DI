using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Paquetes necesarios para consultas sql y la conexion con la bbdd
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SQLyWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Se crea una conexion SQL como propiedad de clase
        SqlConnection myConexionSQL;
        public MainWindow()
        {
            InitializeComponent();

            //Creamos la conexión usando la clave que nos da la bbdd
            string miConexion = ConfigurationManager.ConnectionStrings["SQLyWPF.Properties.Settings.PruebasWPFConnectionString"].ConnectionString;

            myConexionSQL = new SqlConnection(miConexion);

            this.muestraClientes();
            this.muestraPedidos();
          




        }

        private void muestraClientes()
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

                    lbClientes.ItemsSource = clientesTabla.DefaultView;
                    lbClientes.SelectedValuePath = "IdCliente";
                    lbClientes.DisplayMemberPath = "nombre";

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");
            }
        }

        private void lbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbClientes.SelectedValue != null)
            {
                muestraPedidosPorCliente();
            }
        }

        private void muestraPedidos()
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

                    lbPedidos.ItemsSource = clientesTabla.DefaultView;
                    lbPedidos.SelectedValuePath = "IdPedido";
                    lbPedidos.DisplayMemberPath = "InfoPedido";

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha sucedido un error en la carga de los datos de Pedido");
            }
        }


        private void muestraPedidosPorCliente()
        {

            string consulta = "select * from Pedido  inner join Cliente on Cliente.IdCliente = Pedido.CodCliente where" +
                " Cliente.IdCliente = @ClienteID";

            Console.WriteLine(consulta);

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    comando.Parameters.AddWithValue("@ClienteID", lbClientes.SelectedValue);
                    //Contenedor
                    DataTable pedidosTabla = new DataTable();
                    adaptador.Fill(pedidosTabla);

                    lbPedidoPorCliente.ItemsSource = pedidosTabla.DefaultView;
                    lbPedidoPorCliente.SelectedValuePath = "IdPedido";
                    lbPedidoPorCliente.DisplayMemberPath = "FechaPedido";

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha sucedido un error en la carga de Pedidos por Cliente");
            }
        }

        private void eliminarPedido()
        {
            MessageBox.Show("Vas a eliminar un Pedido");
            string consulta = "Delete from Pedido where idPedido = @PedidoID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@PedidoID", lbPedidos.SelectedValue); //Configuro el parámetro

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                comando.ExecuteNonQuery(); //Ejecutamos la sentencia de borrado
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }


            this.muestraPedidos(); //Volvemos a mostrar la lista de pedidos
        
        }

        private void eliminarCliente()
        {
            MessageBox.Show("Vas a eliminar un Cliente");
            string consulta = "Delete from Cliente where idCliente = @ClienteID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@ClienteID", lbClientes.SelectedValue); //Configuro el parámetro

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                comando.ExecuteNonQuery(); //Ejecutamos la sentencia de borrado
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }


            this.muestraClientes(); //Volvemos a mostrar la lista de Clientes
        }

        private void insertaCliente()
        {
            MessageBox.Show("Vas a insertar un Cliente");
            string consulta = "Insert into Cliente (Nombre) Values (@nombreCliente)";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("@nombreCliente", tbCliente.Text); //Configuro el parámetro

            try
            {
                myConexionSQL.Open(); //Abrimos la conexión para poder acceder a la base de Datos
                comando.ExecuteNonQuery(); //Ejecutamos la sentencia de Insertado
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConexionSQL.Close(); //Tenemos que cerrar la conexión despueés de usarlo
            }


            this.muestraClientes(); //Volvemos a mostrar la lista de Clientes
        }

        private void actualizarCliente()
        {
            UClienteWindow uClienteWindow = new UClienteWindow( myConexionSQL);



            string consulta = "select * from Cliente where IdCliente = @ClienteID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL); //La clase SqlCommand se usa cuando tenemos parámetros


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            comando.Parameters.AddWithValue("ClienteID", lbClientes.SelectedValue); //Configuro el parámetro


            try
            {
                //Crea un cuerpo en el que todo lo que utilizas aquí forma parte del adaptador
                using (adaptador)
                {
                    //Contenedor
                    DataTable clientesTabla = new DataTable();
                    adaptador.Fill(clientesTabla);

                    uClienteWindow.tbIdCliente.Text = clientesTabla.Rows[0]["IdCliente"].ToString();   
                    uClienteWindow.tbNombre.Text = clientesTabla.Rows[0]["Nombre"].ToString();   
                    uClienteWindow.tbDireccion.Text = clientesTabla.Rows[0]["DIreccion"].ToString();   
                    uClienteWindow.tbPoblacion.Text = clientesTabla.Rows[0]["Poblacion"].ToString();   
                    uClienteWindow.tbTelefono.Text = clientesTabla.Rows[0]["Telefono"].ToString();   

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");

            }
            uClienteWindow.ShowDialog();
            this.muestraClientes();
        }
            

        


        private void bBorrarPedidos_Click(object sender, RoutedEventArgs e)
        {
            if (lbPedidos.SelectedValue is null)
            {
                MessageBox.Show("Debes seleccionar un pedido");

            } else
            {
                this.eliminarPedido();
            }
        }

    

        private void bInsertaCliente_Click(object sender, RoutedEventArgs e)
        {
            if (tbCliente is null)
            {
                MessageBox.Show("Debes escribir un cliente");

            }
            else
            {
                this.insertaCliente();
            }
        }

  

        private void bEliminaCliente_Click(object sender, RoutedEventArgs e)
        {
            if (lbClientes.SelectedValue is null)
            {
                MessageBox.Show("Debes seleccionar un cliente");

            }
            else
            {
                lbPedidoPorCliente.SelectedValue = null;
                this.eliminarCliente();
            }

        }

        private void bActualizaCliente_Click(object sender, RoutedEventArgs e)

        {
            if (lbClientes.SelectedValue is null)
            {
                MessageBox.Show("Debes seleccionar un cliente");

            }
            else
            {

                lbPedidoPorCliente.SelectedValue = null;
                this.actualizarCliente();
            }

        }

        
    }
}
