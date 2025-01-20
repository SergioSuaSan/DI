using System;
using System.Collections.Generic;
using System.Data;
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
        public UClienteWindow(Controlador controlador, DataTable cliente)
        {
            this.controlador = controlador;
            DataColumnCollection columnas = cliente.Columns;

            InitializeComponent();

            this.tbIdCliente.Text = cliente.Rows[0][columnas[0].ColumnName].ToString();
            this.tbNombre.Text = cliente.Rows[0][columnas[1].ColumnName].ToString();
            this.tbDireccion.Text = cliente.Rows[0][columnas[2].ColumnName].ToString();
            this.tbPoblacion.Text = cliente.Rows[0][columnas[3].ColumnName].ToString();
            this.tbTelefono.Text = cliente.Rows[0][columnas[4].ColumnName].ToString();
        }

        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void bActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Vas a actualizar un Cliente");


            string[] cliente = new string[5];
            cliente[0] = tbIdCliente.Text;
            cliente[1] = tbNombre.Text;
            cliente[2] = tbDireccion.Text;
            cliente[3] = tbPoblacion.Text;
            cliente[4] = tbTelefono.Text;
            string error = controlador.actualizarCliente(cliente);

            if (error != null)
            {
                MessageBox.Show("Ha sucedido un error y no se puede actualizar  \n" + error);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha sido actualizado con exito");
                this.Close();
            }
            

          
            


        }

     
    }
}
