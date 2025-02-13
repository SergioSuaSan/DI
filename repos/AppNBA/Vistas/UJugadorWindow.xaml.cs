using System.Data;
using System.Windows;

namespace AppNBA.Vistas
{
    /// <summary>
    /// Lógica de interacción para UJugadorWindow.xaml
    /// </summary>
    public partial class UJugadorWindow : Window
    {
        //Propiedades de clase necesarias
        Controlador control;
        string idJugador;
        public UJugadorWindow(Controlador control, string idJugador, DataTable jugador)
        {
            this.control = control;
            this.idJugador = idJugador;
            DataColumnCollection columnas = jugador.Columns;
            InitializeComponent();

            //De esta forma podemos escribir los datos del jugador en la nueva ventana
            this.tbNombre.Text = jugador.Rows[0][columnas[1].ColumnName].ToString();
            this.tbApellido.Text = jugador.Rows[0][columnas[2].ColumnName].ToString();
            this.tbPosicion.Text = jugador.Rows[0][columnas[3].ColumnName].ToString();
            this.tbCamiseta.Text = jugador.Rows[0][columnas[4].ColumnName].ToString();
            this.tbEquipo.Text = jugador.Rows[0][columnas[5].ColumnName].ToString();
        }


        /// <summary>
        /// CLICKS DE LOS BOTONES DE LA VENTANA
        /// </summary>

        //Botón para actualizar un jugador
        private void bActualizarJugador_Click(object sender, RoutedEventArgs e)
        {
            //Creamos un string con los datos que vamos a insertar
            string[] jugador = new string[6];
            jugador[0] = this.tbNombre.Text;
            jugador[1] = this.tbApellido.Text;
            jugador[2] = this.tbPosicion.Text;
            jugador[3] = this.tbCamiseta.Text;
            jugador[4] = this.tbEquipo.Text;
            jugador[5] = this.idJugador;


            //Hacemos la inserción y notificamos si habido un error
            string error = control.actualizarJugador(jugador);

            if (error is null)
            {
                MessageBox.Show("El equipo ha sido actualizado"); //Si no ha habido error damos un mensaje de éxito
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha habido un error al actualizar el equipo: \n" + error); //Si ha habido error lo notificamos
                this.Close();
            }
        }

        //Botón para cancelar la actualización
        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
