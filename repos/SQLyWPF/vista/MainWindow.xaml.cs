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

        Controlador controlador;
   
        public MainWindow()
        {
            controlador = new Controlador();
            InitializeComponent();

          

            this.muestraClientes();
            this.muestraPedidos();
          




        }

        private void muestraClientes()
        {

            DataTable clientesTabla =  controlador.muestraClientes();

            if (clientesTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");
            }
            else
            {
                lbClientes.ItemsSource = clientesTabla.DefaultView;
                lbClientes.SelectedValuePath = controlador.getPKCliente();
                lbClientes.DisplayMemberPath = controlador.getCampoCliente();
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
            DataTable pedidosTabla = controlador.muestraPedidos();


            if (pedidosTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");
            }
            else
            {

                lbPedidos.ItemsSource = pedidosTabla.DefaultView;
                lbPedidos.SelectedValuePath = controlador.getPKPedido();
                lbPedidos.DisplayMemberPath = controlador.getCampoPedido();

            }

        }


        private void muestraPedidosPorCliente()
        {
            DataTable pedidosTabla = controlador.muestraPedidosPorCliente(lbClientes.SelectedValue.ToString());

            if (pedidosTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");
            }
            else
            {
                lbPedidoPorCliente.ItemsSource = pedidosTabla.DefaultView;
                lbPedidoPorCliente.SelectedValuePath = controlador.getPKPedido();
                lbPedidoPorCliente.DisplayMemberPath = controlador.getCampoPedido();

            }

        
        }

        private void eliminarPedido()
        {
            MessageBox.Show("Vas a eliminar un Pedido");
            string error = controlador.eliminarPedido(lbPedidos.SelectedValue.ToString());

            if (error != null)
            {
                MessageBox.Show("Ha habído un error: \n" + error);
            }
            else
            {
                MessageBox.Show("Pedido eliminado con éxito");
                this.muestraPedidos(); //Volvemos a mostrar la lista de pedidos
            }


        
        }

        private void eliminarCliente()
        {
            MessageBox.Show("Vas a eliminar un Cliente");

            string error = controlador.eliminarCliente(lbClientes.SelectedValue.ToString());

            if (error != null)
            {
                MessageBox.Show("Ha habído un error: \n" + error);
            }
            else
            {
                MessageBox.Show("Pedido eliminado con éxito");
                this.muestraClientes(); //Volvemos a mostrar la lista de Clientes
              
            }




        }

        private void insertaCliente()
        {
            MessageBox.Show("Vas a insertar un Cliente");

            string error = controlador.insertarCliente(tbCliente.Text);

            if (error != null)
            {
                MessageBox.Show("Ha habído un error: \n" + error);
            }
            else
            {
                MessageBox.Show("Pedido eliminado con éxito");
                this.muestraClientes(); //Volvemos a mostrar la lista de Clientes

            }



        }
        /*
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
        */
            

        


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
                //this.actualizarCliente();
            }

        }
        

        
    }
}
