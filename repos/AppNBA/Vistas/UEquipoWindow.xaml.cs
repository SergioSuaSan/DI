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

namespace AppNBA.Vistas
{
    /// <summary>
    /// Lógica de interacción para UEquipoWindow.xaml
    /// </summary>
    public partial class UEquipoWindow : Window
    {
        //Propiedades de clase necesarias
        Controlador control;
        public UEquipoWindow(Controlador control, DataTable equipo)
        {
            this.control = control;
            DataColumnCollection columnas = equipo.Columns;
            InitializeComponent();

            //De esta forma podemos escribir los datos del equipo en la nueva ventana
            this.tbIdEquipo.Text = equipo.Rows[0][columnas[0].ColumnName].ToString();
            this.tbNombre.Text = equipo.Rows[0][columnas[1].ColumnName].ToString();
            this.tbConferencia.Text = equipo.Rows[0][columnas[2].ColumnName].ToString();
            this.tbRecord.Text = equipo.Rows[0][columnas[3].ColumnName].ToString();
        }


        /// <summary>
        /// CLICKS DE LOS BOTONES DE LA VENTANA
        /// </summary>
        
        private void bActualizarEquipo_Click(object sender, RoutedEventArgs e)
        {
            //Creamos un string con los datos que vamos a insertar
            string[] equipo = new string[4];
            equipo[0] = this.tbIdEquipo.Text;
            equipo[1] = this.tbNombre.Text;
            equipo[2] = this.tbConferencia.Text;
            equipo[3] = this.tbRecord.Text;

            //Hacemos la inserción y notificamos si habido un error
            string error = control.actualizarEquipo(equipo);

            if (error is null)
            {
                MessageBox.Show("El equipo ha sido actualizado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha habido un error al actualizar el equipo: \n" + error);
                this.Close();
            }
        }
        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();



        }
    }
}
