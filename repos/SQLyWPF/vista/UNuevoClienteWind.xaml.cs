using System;
using System.Collections.Generic;
using System.Data;
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

namespace SQLyWPF.vista
{
    /// <summary>
    /// Lógica de interacción para UNuevoClienteWind.xaml
    /// </summary>
    public partial class UNuevoClienteWind : Window
    {

        Controlador controlador;
        public UNuevoClienteWind(Controlador controlador, DataTable cliente)
        {
            this.controlador = controlador;
            DataColumnCollection columnas = cliente.Columns;


            InitializeComponent();

            //this.tbIdCliente.Text = cliente.Rows[0][columnas[0].ColumnName].ToString();
            //this.tbNombre.Text = cliente.Rows[0][columnas[1].ColumnName].ToString();
            //this.tbDireccion.Text = cliente.Rows[0][columnas[2].ColumnName].ToString();
            //this.tbPoblacion.Text = cliente.Rows[0][columnas[3].ColumnName].ToString();
            //this.tbTelefono.Text = cliente.Rows[0][columnas[4].ColumnName].ToString();
        }

        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void bInsertarCliente_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
