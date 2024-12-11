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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EjercicioClase
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Enviar_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void NoEnviar_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void Op_Checked(Object sender, RoutedEventArgs e)
        {
            if ((Op1.IsChecked == true) && (Op2.IsChecked == true) && (Op3.IsChecked == true) && (Op4.IsChecked == true))
            {
                MarcarTodas.IsChecked = true;

            }
            else
            {
                MarcarTodas.IsChecked = null;
            }
          

        }

        private void Op_Unchecked(Object sender, RoutedEventArgs e)
        {
            if ((Op1.IsChecked == false) && (Op2.IsChecked == false) && (Op3.IsChecked == false) && (Op4.IsChecked == false))
            {
                MarcarTodas.IsChecked = false;

            }
            else
            {
                MarcarTodas.IsChecked = null;
            }
        
        }

        private void Panel_Click(Object sender, RoutedEventArgs e)
        {

        }

        private void MarcarTodas_Checked(Object sender, RoutedEventArgs e)
        {
            Op1.IsChecked = true;
            Op2.IsChecked = true;
            Op3.IsChecked = true;
            Op4.IsChecked = true;

        }

        private void MarcarTodas_Unchecked(Object sender, RoutedEventArgs e)
        {
            Op1.IsChecked = false;
            Op2.IsChecked = false;
            Op3.IsChecked = false;
            Op4.IsChecked = false;
        }


    }
}
