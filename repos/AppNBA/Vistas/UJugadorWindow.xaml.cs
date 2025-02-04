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
using System.Windows.Shapes;

namespace AppNBA.Vistas
{
    /// <summary>
    /// Lógica de interacción para UJugadorWindow.xaml
    /// </summary>
    public partial class UJugadorWindow : Window
    {
        public UJugadorWindow()
        {
            InitializeComponent();
        }

        private void bActualizarJugador_Click(object sender, RoutedEventArgs e)
        {

            string[] equipo = new string[4];
            equipo[0] = this.tbIdEquipo.Text;
            equipo[1] = this.tbNombre.Text;
            equipo[2] = this.tbConferencia.Text;
            equipo[3] = this.tbRecord.Text;

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
