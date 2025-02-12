using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppNBA.Vistas
{
    /// <summary>
    /// Lógica de interacción para PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        private Grid visualPlantilla;
        public PrintWindow(Grid visualPlantilla)
        {
            this.visualPlantilla = visualPlantilla;
            InitializeComponent();

            //Crear un fixedDocument
            FixedDocument fixedDocument = new FixedDocument();

            //Crear una página para el fixedDocument
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();

            //Capturar el contenido del TabControl o cualquier otro elemento visual
            var visualBrush = new VisualBrush(visualPlantilla);

            //Crear un rectángulo para mostrar el contenido del TabControl
            var rectangle = new Rectangle
            {
                Width = visualPlantilla.ActualWidth, //Ajusta el ancho del rectángulo al ancho del TabControl
                Height = visualPlantilla.ActualHeight, //Ajusta el alto del rectángulo al alto del TabControl
                Fill = visualBrush
            };

            //Agregar el Rectángulo a la FIXEDPAGE
            fixedPage.Children.Add(rectangle);
            ((IAddChild)pageContent).AddChild(fixedPage);
            pageContent.Width = visualPlantilla.ActualWidth;
            pageContent.Height = visualPlantilla.ActualHeight;

            //Agregar la página al FixedDocument
            fixedDocument.Pages.Add(pageContent);

            //Asignar el FixedDocument al visor de documentos
           //----------------------------------------- this.vistaPrealiminar.Document = fixedDocument;



        }

        private void bConfirmar_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
            // Configura el tamaño del papel y otras configuraciones si es necesario
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize
            (visualPlantilla.ActualWidth, visualPlantilla.ActualHeight);
            printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;

            // Imprime el Grid
            printDialog.PrintVisual(visualPlantilla, "Grid a PDF");

        }

        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
