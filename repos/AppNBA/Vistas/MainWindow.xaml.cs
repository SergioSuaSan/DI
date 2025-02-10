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


            //Dejamos seleccionado el primer equipo por defecto
            LBEquipos.SelectedIndex = 0;
      
            cargarImagenEquipo(control.getURLEquipo(LBEquipos.SelectedValue.ToString()));


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



            //Dejamos seleccionado el primer jugador por defecto
            LBPlantilla.SelectedIndex = 0;

            cargarImagenPlantilla(control.getURLJugador(LBPlantilla.SelectedValue.ToString()));

        }
        private void muestraJugador()
        {
            DataTable jugadorTabla = control.muestraJugador(LBPlantilla.SelectedValue.ToString());

            if (jugadorTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de la Plantilla");
            }
            else
            {
                dataGridJugador.ItemsSource = jugadorTabla.DefaultView;
            }
        }

        //Métodos para cargar las imágenes con las url que hemos sacado previamente
        private void cargarImagenEquipo(string url)
        {
            BitmapImage imagen = new BitmapImage();
            imagen.BeginInit();
            imagen.UriSource = new Uri(url);
            imagen.EndInit();
            ImagenEquipo.Source = imagen;
            TabPlantilla.Source = imagen;
            //TabEquipo.Source = imagen;
        }
        private void cargarImagenPlantilla(string url)
        {
            if (url != "" && url != "null")
            {
                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri(url);
                imagen.EndInit();
                ImagenPlantillaJugador.Source = imagen;
                ImagenJugador.Source = imagen;
                TabJugador.Source = imagen;
                  
            } else
            {

                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                imagen.UriSource = new Uri("../img/ImagenNotFound.ico", UriKind.Relative);
                imagen.EndInit();
                ImagenPlantillaJugador.Source = imagen;
                ImagenJugador.Source = imagen;
                TabJugador.Source = imagen;



            }
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
                muestraJugador();
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
                    this.muestraPlantilla();
                    this.muestraJugador();
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
                //Creamos un Mensaje Box con opcion de Sí o No, de confirmación
                var result = MessageBox.Show("¿Estás seguro?", "", MessageBoxButton.YesNo);
                //Solamente si lo confirmamos, procedemos a la eliminación
                if (result == MessageBoxResult.Yes)
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


        }

        //Clicks exclusivos de los menús
        private void ayuda_Click(object sender, RoutedEventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.ShowDialog();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            acercaDe.ShowDialog();

        }



        /// <summary>
        /// ATAJOS DE TECLADO
        /// METODO QUE PERMITE UTILIZAR ATAJOS DE TECLADO EN LA VENTANA PRINCIPAL
        /// SI QUEREMOS QUE SIRVA PARA TODAS LAS VENTANAS, USAR EL MÉDOTO DE DEBAJO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.E:
                        bActualizaEquipo_Click(sender, e);
                        break;
                    case Key.N:
                        bInsertaJugador_Click(sender, e);
                        break;
                    case Key.J:
                        bActualizaJugador_Click(sender, e);
                        break;
                    case Key.R:
                        bEliminaJugador_Click(sender, e);
                        break;
                    case Key.H:
                        ayuda_Click(sender, e);
                        break;
                    case Key.I:
                        AcercaDe_Click(sender, e);
                        break;
                    case Key.Q:
                        Application.Current.Shutdown();
                        break;

                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
