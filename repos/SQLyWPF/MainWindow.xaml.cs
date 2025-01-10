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

        private void muestraPedidos()
        {

            string consulta = "select concat (CodCliente, ' | ', FechaPedido, ' | ' , FormaPago) as InfoPedido from Pedido";

            
            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, myConexionSQL);

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


        private void muestraPedidosPorCliente()
        {

            string consulta = "select * from Pedido  inner join Cliente on Cliente.IdCliente = Pedido.CodCliente where" +
                " Cliente.IdCliente = @ClienteID";

            Console.WriteLine(consulta);

            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);

            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

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

        private void bEliminarPedido()
        {
            MessageBox.Show("Vas a eliminar un Pedido");
            string consulta = "Delete from Pedido where idPedido = @PedidoID";



            SqlCommand comando = new SqlCommand(consulta, myConexionSQL);


            //Hará de puente para dejar los datos en un contenedor
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

        
        }



        private void lbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            muestraPedidosPorCliente();
        }

        private void bBorrarPedidos_Click(object sender, RoutedEventArgs e)
        {
            if (lbPedidos.SelectedValue is null)
            {
                MessageBox.Show("Debes seleccionar un pedido");

            } else
            {
                this.bEliminarPedido();
            }
        }
    }
}
