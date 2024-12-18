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

namespace Semaforo
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


        private void RB_Click(object sender, RoutedEventArgs e)
        {
            if (RBRed.IsFocused)
            {
                eRed.Visibility = Visibility.Visible;
                eOrange.Visibility = Visibility.Hidden;
                eGreen.Visibility = Visibility.Hidden;

            }
            else if (RBOrange.IsFocused)
            {
                eRed.Visibility = Visibility.Hidden;
                eOrange.Visibility = Visibility.Visible;
                eGreen.Visibility = Visibility.Hidden;

            }
            else if (RBGreen.IsFocused)
            {

                eRed.Visibility = Visibility.Hidden;
                eOrange.Visibility = Visibility.Hidden;
                eGreen.Visibility = Visibility.Visible;
            }
        }
    }
}
