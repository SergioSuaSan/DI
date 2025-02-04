using AppNBA.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppNBA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controlador control;
        public MainWindow( )
        {
            control = new Controlador();
            InitializeComponent();
            this.muestraEquipos();
            
        }



        /// <summary>
        /// MOSTRAR LOS DATOS EN LA VENTANA
        /// </summary>
        private void muestraEquipos()
        {
            DataTable equiposTabla = control.muestraEquipos();

            if (equiposTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");
            }
            else
            {
                LBEquipos.ItemsSource = equiposTabla.DefaultView;
                LBEquipos.SelectedValuePath = control.getPKEquipo();
                LBEquipos.DisplayMemberPath = control.getNombreEquipo();
               

            }


                //MUY PROVISIONAL PORQUE NO SÉ CÓMO SE HACE
                LBEquipos.SelectedIndex = 0;
      
                cargarImagenEquipo(control.getURLEquipo(LBEquipos.SelectedValue.ToString()));


        }
        private void cargarImagenEquipo(string url)
        {
            BitmapImage imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.UriSource = new Uri(url);
            imagen.EndInit();
            ImagenEquipo.Source = imagen;
        }
        private void cargarImagenPlantilla(string url)
        {
            if (url != "")
            {
                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(url);
                imagen.EndInit();
                ImagenPlantillaJugador.Source = imagen;
                ImagenJugador.Source = imagen;
            } else
            {

                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri("../img/ImagenNotFound.ico", UriKind.Relative);
                imagen.EndInit();
                ImagenPlantillaJugador.Source = imagen;
                ImagenJugador.Source = imagen;



            }
        }
        private void muestraPlantilla()
        {
            DataTable plantillaTabla = control.muestraPlantilla(LBEquipos.SelectedValue.ToString());

            if (plantillaTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de la Plantilla");
            }
            else
            {
                LBPlantilla.ItemsSource = plantillaTabla.DefaultView;
                LBPlantilla.SelectedValuePath = control.getPKJugador();
                LBPlantilla.DisplayMemberPath = control.getDatosJugador();

            }



            //MUY PROVISIONAL PORQUE NO SÉ CÓMO SE HACE
            LBPlantilla.SelectedIndex = 0;

            cargarImagenPlantilla(control.getURLJugador(LBPlantilla.SelectedValue.ToString()));

        }





        /// <summary>
        /// NOTIFICAR EL CAMBIO DE VALOR DE LAS LIST BOX
        /// </summary>

        private void LBEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null)
            {
                cargarImagenEquipo(control.getURLEquipo(LBEquipos.SelectedValue.ToString()));
                muestraPlantilla();
            }

        }


        private void LBPlantilla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBPlantilla.SelectedValue != null)
            {
                cargarImagenPlantilla(control.getURLJugador(LBPlantilla.SelectedValue.ToString()));

            }
        }



        /// <summary>
        /// CLICK DE LOS BOTONES
        /// </summary>
        private void bActualizaEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null)
            {
                DataTable equipo = control.getEquipo(LBEquipos.SelectedValue.ToString());

                if (equipo != null)
                {
                    UEquipoWindow equipoWindow = new UEquipoWindow(control, equipo);

                    equipoWindow.ShowDialog();
                    this.muestraEquipos();
                }
                else
                {
                    MessageBox.Show("Ha sucedido un error en la carga del Equipo.");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un equipo");
            }
        }

        private void bInsertaJugador_Click(object sender, RoutedEventArgs e)
        {
            NJugadorWindow nJugadorWindow = new NJugadorWindow(control, LBEquipos.SelectedValue.ToString());

            nJugadorWindow.ShowDialog();
            this.muestraPlantilla();
        }

        private void bActualizaJugador_Click(object sender, RoutedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null)
            {
                DataTable jugador = control.getJugador(LBPlantilla.SelectedValue.ToString());

                if (jugador != null)
                {
                    UJugadorWindow uJugador  = new UJugadorWindow(control, LBPlantilla.SelectedValue.ToString(),jugador);

                    uJugador.ShowDialog();
                    this.muestraEquipos();
                }
                else
                {
                    MessageBox.Show("Ha sucedido un error en la carga del Equipo.");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un equipo");
            }
        }

        private void bEliminaJugador_Click(object sender, RoutedEventArgs e)
        {

            if (LBPlantilla.SelectedValue is null)
            {
                MessageBox.Show("Debes seleccionar un Jugador");

            }
            else
            {
                string error = control.eliminarJugador(LBPlantilla.SelectedValue.ToString());

                if (error != null)
                {
                    MessageBox.Show("Ha habído un error: \n" + error);
                }
                else
                {
                    MessageBox.Show("Jugador eliminado con éxito");
                    this.muestraPlantilla(); //Volvemos a mostrar la lista de pedidos
                }
            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.ShowDialog();
        }
    }
}
