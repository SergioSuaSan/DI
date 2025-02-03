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
        /// MOSTRAR LOS DATOS
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
        }
        private string getURLLogo(int idEquipo)
        {
            return null;

        }




        /// <summary>
        /// NOTIFICAR EL CAMBIO DE VALOR DE LAS LIST BOX
        /// </summary>

        private void LBEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null)
            {
                muestraPlantilla();
            }

        }


        private void LBPlantilla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
