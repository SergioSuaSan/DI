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
    /// Lógica de interacción para NJugadorWindow.xaml
    /// </summary>
    public partial class NJugadorWindow : Window
    {
        Controlador control;
        string equipo;
        public NJugadorWindow(Controlador control, string equipo)
        {
            this.control = control;
            this.equipo = equipo;
            InitializeComponent();
        }


        private void bInsertarJugador_Click(object sender, RoutedEventArgs e)
        {
            string[] jugador = new string[5];
            jugador[0] = this.tbNombre.Text;
            jugador[1] = this.tbApellido.Text;
            jugador[2] = this.tbPosicion.Text;
            jugador[3] = this.tbCamiseta.Text;
            jugador[4] = equipo;

            string error = control.insertarJugador(jugador);

            if (error is null)
            {
                MessageBox.Show("El jugador ha sido insertado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha habido un error al actualizar el equipo: \n" + error);
                this.Close();
            }

            this.Close();
        }

        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
