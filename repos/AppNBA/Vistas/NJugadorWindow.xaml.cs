using System.Windows;

namespace AppNBA.Vistas
{
    /// <summary>
    /// Lógica de interacción para NJugadorWindow.xaml
    /// </summary>
    public partial class NJugadorWindow : Window
    {
        //Propiedades de clase necesarias
        Controlador control;
        string equipo;
        public NJugadorWindow(Controlador control, string equipo)
        {
            this.control = control;
            this.equipo = equipo;
            InitializeComponent();
        }

        /// <summary>
        /// CLICKS DE LOS BOTONES DE LA VENTANA
        /// </summary>

        //Botón para insertar un jugador
        private void bInsertarJugador_Click(object sender, RoutedEventArgs e)
        {
            //Creamos un string con los datos que vamos a insertar
            string[] jugador = new string[5];
            jugador[0] = this.tbNombre.Text;
            jugador[1] = this.tbApellido.Text;
            jugador[2] = this.tbPosicion.Text;
            jugador[3] = this.tbCamiseta.Text;
            jugador[4] = equipo;

            //Hacemos la inserción y notificamos si habido un error
            string error = control.insertarJugador(jugador);

            if (error is null) //Si no ha habido error
            {
                MessageBox.Show("El jugador ha sido insertado"); //Notificamos
                this.Close(); 
            }
            else //Si ha habido error
            {
                MessageBox.Show("Ha habido un error al insertar el jugador: \n" + error); //Notificamos
                this.Close(); //Cerramos la ventana
            }
           
        }

        //Botón para cancelar la inserción
        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); //Cerramos la ventana
        }
    }
}
