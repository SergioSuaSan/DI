using AppNBA.Vistas;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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

        //Métodos para cargar los datos en las listas y en los grids
        private void muestraEquipos()
        {
            //Cargamos los datos de los equipos en la lista
            DataTable equiposTabla = control.muestraEquipos();

            //Si no se ha podido cargar los datos, mostramos un mensaje de error
            if (equiposTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de Cliente");
            }
            else
            {
                //Si se han cargado los datos, los mostramos en la lista
                LBEquipos.ItemsSource = equiposTabla.DefaultView;
                LBEquipos.SelectedValuePath = control.getPKEquipo();
                LBEquipos.DisplayMemberPath = control.getNombreEquipo();
               

            }


            //Dejamos seleccionado el primer equipo por defecto
            LBEquipos.SelectedIndex = 0;

            //Cargamos la imagen del equipo seleccionado
            cargarImagenEquipo(control.getURLEquipo(LBEquipos.SelectedValue.ToString()));


        }
        private void muestraPlantilla()
        {
            //Cargamos los datos de los jugadores en la lista
            DataTable plantillaTabla = control.muestraPlantilla(LBEquipos.SelectedValue.ToString());

            //Si no se ha podido cargar los datos, mostramos un mensaje de error
            if (plantillaTabla is null)
            {
                MessageBox.Show("Ha sucedido un error en la carga de los datos de la Plantilla");
            }
            else
            {
                //Si se han cargado los datos, los mostramos en la lista
                LBPlantilla.ItemsSource = plantillaTabla.DefaultView;
                LBPlantilla.SelectedValuePath = control.getPKJugador();
                LBPlantilla.DisplayMemberPath = control.getDatosJugador();



            }



            //Dejamos seleccionado el primer jugador por defecto
            LBPlantilla.SelectedIndex = 0;

            //Cargamos la imagen del jugador seleccionado
            cargarImagenPlantilla(control.getURLJugador(LBPlantilla.SelectedValue.ToString()));

        }
        private void muestraJugador()
        {
            //Cargamos los datos de los jugadores en la lista
            DataTable jugadorTabla = control.muestraJugador(LBPlantilla.SelectedValue.ToString());

            //Si no se ha podido cargar los datos, mostramos un mensaje de error
            if (jugadorTabla is null)
            {

                MessageBox.Show("Ha sucedido un error en la carga de los datos de la Plantilla");
            }
            else
            {
                //Si se han cargado los datos, los mostramos en el grid
                dataGridJugador.ItemsSource = jugadorTabla.DefaultView;

                //EXAMEN 3. Si hay datos, seleccionamos el primero
                if (jugadorTabla.Rows.Count > 0)
                {
                    dataGridJugador.SelectedIndex = 0;
                   
                }
            }
        }

        //Métodos para cargar las imágenes con las url que hemos sacado previamente
        private void cargarImagenEquipo(string url)
        {
            //Creamos un objeto BitmapImage para cargar la imagen
            BitmapImage imagen = new BitmapImage();
            imagen.BeginInit();
            //Le pasamos la url de la imagen
            imagen.UriSource = new Uri(url);
            imagen.EndInit();
            //Mostramos la imagen en el Image
            ImagenEquipo.Source = imagen;
            TabPlantilla.Source = imagen;
            //TabEquipo.Source = imagen;

        }
        private void cargarImagenPlantilla(string url)
        {
            //Si la url no es nula, cargamos la imagen
            if (url != "" && url != "null")
            {
                //Creamos un objeto BitmapImage para cargar la imagen
                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                //Le pasamos la url de la imagen
                imagen.UriSource = new Uri(url);
                imagen.EndInit();
                //Mostramos la imagen en el Image
                ImagenPlantillaJugador.Source = imagen;
                ImagenJugador.Source = imagen;
                TabJugador.Source = imagen;
                  
            } else
            {
                //Si la url es nula, cargamos una imagen por defecto
                //Creamos un objeto BitmapImage para cargar la imagen
                BitmapImage imagen = new BitmapImage();
                imagen.BeginInit();
                //Le pasamos la url de la imagen. En este caso, debe ser relativa
                imagen.UriSource = new Uri("../img/ImagenNotFound.ico", UriKind.Relative);
                imagen.EndInit();
                //Mostramos la imagen en el Image
                ImagenPlantillaJugador.Source = imagen;
                ImagenJugador.Source = imagen;
                TabJugador.Source = imagen;



            }
        }

        //Método para imprimir los grids
        private void imprimir(Grid grid)
        {
            PrintWindow printWindow = new PrintWindow(grid);
            printWindow.ShowDialog();
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

        //EXAMEN 3. Seleccionar un jugador del grid
        private void dataGridJugador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridJugador.SelectedIndex != -1) //Si hay un jugador seleccionado
            {
                //He intentado cargar la imagen del jugador seleccionado pero se me vuelve loco
               //cargarImagenPlantilla(control.getURLJugador(dataGridJugador.SelectedIndex.ToString())); //Cargamos la imagen del jugador seleccionado

            }

        }



        /// <summary>
        /// CLICK DE LOS BOTONES
        /// </summary>
        /// 

        //Actualización de los equipos
        private void bActualizaEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null) //Si hay un equipo seleccionado
            {
                DataTable equipo = control.getEquipo(LBEquipos.SelectedValue.ToString()); //Obtenemos los datos del equipo

                if (equipo != null) //Si se han obtenido los datos
                {
                    UEquipoWindow equipoWindow = new UEquipoWindow(control, equipo); //Creamos la ventana de actualización

                    equipoWindow.ShowDialog(); //Mostramos la ventana
                    this.muestraEquipos(); //Volvemos a mostrar la lista de equipos
                }
                else
                {

                    MessageBox.Show("Ha sucedido un error en la carga del Equipo."); //Si no se han obtenido los datos, mostramos un mensaje de error
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un equipo"); //Si no hay un equipo seleccionado, mostramos un mensaje de error
            }
        }

        //Inserción de jugadores
        private void bInsertaJugador_Click(object sender, RoutedEventArgs e)
        {
            NJugadorWindow nJugadorWindow = new NJugadorWindow(control, LBEquipos.SelectedValue.ToString()); //Creamos la ventana de inserción de jugador

            nJugadorWindow.ShowDialog(); //Mostramos la ventana
            this.muestraPlantilla(); //Volvemos a mostrar la lista de jugadores
        }
        
        //Actualización de jugadores
        private void bActualizaJugador_Click(object sender, RoutedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null) //Si hay un equipo seleccionado
            {
                DataTable jugador = control.getJugador(LBPlantilla.SelectedValue.ToString()); //Obtenemos los datos del jugador

                if (jugador != null) //Si se han obtenido los datos
                {
                    UJugadorWindow uJugador  = new UJugadorWindow(control, LBPlantilla.SelectedValue.ToString(),jugador); //Creamos la ventana de actualización

                    uJugador.ShowDialog(); //Mostramos la ventana
                    this.muestraEquipos(); //Volvemos a mostrar la lista de equipos
                    this.muestraPlantilla(); //Volvemos a mostrar la lista de jugadores
                    this.muestraJugador(); //Volvemos a mostrar los datos del jugador
                }
                else
                {
                    //Si no se han obtenido los datos, mostramos un mensaje de error
                    MessageBox.Show("Ha sucedido un error en la carga del Equipo.");
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un equipo"); //Si no hay un equipo seleccionado, mostramos un mensaje de error
            }
        }

        //Eliminación de jugadores
        private void bEliminaJugador_Click(object sender, RoutedEventArgs e)
        {

            if (LBPlantilla.SelectedValue is null) //Si no hay un jugador seleccionado, mostramos un mensaje de error
            {
                MessageBox.Show("Debes seleccionar un Jugador"); //Si no hay un equipo seleccionado, mostramos un mensaje de error

            }
            else
            {
                //Creamos un Mensaje Box con opcion de Sí o No, de confirmación
                var result = MessageBox.Show("¿Estás seguro?", "", MessageBoxButton.YesNo);
                //Solamente si lo confirmamos, procedemos a la eliminación
                if (result == MessageBoxResult.Yes)
                {
                    string error = control.eliminarJugador(LBPlantilla.SelectedValue.ToString()); //Eliminamos el jugador

                    if (error != null) //Si ha habido un error, mostramos un mensaje de error
                    {
                        MessageBox.Show("Ha habído un error: \n" + error); 
                    }
                    else
                    {
                        MessageBox.Show("Jugador eliminado con éxito"); //Si no ha habido errores, mostramos un mensaje de éxito
                        this.muestraPlantilla(); //Volvemos a mostrar la lista de pedidos
                    }
                }

              
            }


        }

        //Clicks exclusivos de los menús
        //Ayuda
        private void ayuda_Click(object sender, RoutedEventArgs e)
        {
            Ayuda ayuda = new Ayuda(); //Creamos la ventana de ayuda
            ayuda.ShowDialog(); //Mostramos la ventana
        }

        //Salir
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Acerca de
        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDe = new AcercaDe();
            acercaDe.ShowDialog();

        }

        //Imprimir plantilla
        private void bImprimir_Click(object sender, RoutedEventArgs e)
        {
            imprimir(visualPlantilla);
        }

        //Imprimir jugador
        private void bImprimirJugador_Click(object sender, RoutedEventArgs e)
        {
            imprimir(visualJugador);
        }

        //EXAMEN 1. Imprimir equipo
        private void bImprimirEquipo_Click(object sender, RoutedEventArgs e)
        {
            imprimir(visualEquipo);
        }

        //EXAMEN 3. Buscar
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            BusquedaWindow buscar = new BusquedaWindow(control, dataGridJugador, ref ImagenJugador); //Creamos la ventana de búsqueda
            buscar.ShowDialog(); //Mostramos la ventana
            if (dataGridJugador.SelectedIndex != -1) //Si hay un jugador seleccionado
            {
                cargarImagenPlantilla(control.getURLJugador(dataGridJugador.SelectedIndex.ToString())); //Cargamos la imagen del jugador seleccionado
            }
            TIJugadores.Focus(); //Hacemos focus en la pestaña de jugadores


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
                    //EXAMEN 3. Atajo de teclado para buscar
                    case Key.B:
                        Buscar_Click(sender, e);
                        break;

                    case Key.Q:
                        Application.Current.Shutdown();
                        break;
                   

                }
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.P:
                        bImprimir_Click(sender, e);
                        break;
                    case Key.L:
                        bImprimirJugador_Click(sender, e);
                        break;
                    //EXAMEN 1. Imprimir equipo. COloco otro atajo de teclado porque ya lo estaba usando para la plantilla
                    case Key.T:
                        bImprimirEquipo_Click(sender, e);
                        break;


                }
            }
        }

   
    }
}
