using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace SQLyWPF
{
    /// <summary>
    /// Lógica de interacción para UClienteWindow.xaml
    /// </summary>
    public partial class UClienteWindow : Window
    {
        Controlador controlador;
        public UClienteWindow()
        {
            controlador = new Controlador();
            InitializeComponent();
        }

        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void bActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Vas a actualizar un Cliente");
            /*
            try
            {
                string consulta = $"Update Cliente SET nombre = '{tbNombre.Text}', direccion = '{tbDireccion.Text}', " +
                    $"poblacion = '{tbPoblacion.Text}', telefono = '{tbTelefono.Text}' " +
                    $"WHERE IdCliente = '{tbIdCliente.Text}' ";

                SqlCommand cmd = new SqlCommand(consulta, myConexionSQL);
                
                myConexionSQL.Open();

                cmd.ExecuteNonQuery();

                myConexionSQL.Close();

                MessageBox.Show("Ha sido actualizado con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha sucedido un error y no se puede actualizar  \n" + ex.Message);
                
            }
            */
            this.Close();


        }

     
    }
}
