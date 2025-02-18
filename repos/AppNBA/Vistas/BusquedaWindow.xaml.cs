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
    /// Lógica de interacción para BusquedaWindow.xaml
    /// </summary>
    public partial class BusquedaWindow : Window
    {
        //EXAMEM 3
        Controlador control;
        DataGrid dataGridJugador;
        Image imagenJugador;
        public BusquedaWindow(Controlador control, DataGrid dataGridJugador, Image imagenJugador)
        {
            this.imagenJugador = imagenJugador;
            this.dataGridJugador = dataGridJugador;
            this.control = control;
            InitializeComponent();
        }

        /// <summary>
        /// CLICKS DE LOS BOTONES DE LA VENTANA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //Botón para buscar un jugador
        private void bBuscarJugador_Click(object sender, RoutedEventArgs e)
        {
            
            
            DataTable jugador = control.buscaJugador(tbApellido.Text); //Obtenemos los datos de los Jugadores
            dataGridJugador.ItemsSource = jugador.DefaultView; //Mostramos los datos en el DataGrid

            this.Close();
            

          

        }

        //Botón cancelar
        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
