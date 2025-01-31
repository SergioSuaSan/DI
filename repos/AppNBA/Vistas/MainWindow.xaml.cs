﻿using System;
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

        private void LBEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBEquipos.SelectedValue != null)
            {
                //muestraDatosEquipo();
            }

        }

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



        }




    }
}
