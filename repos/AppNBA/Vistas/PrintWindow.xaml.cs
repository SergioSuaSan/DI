using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AppNBA.Vistas
{
    /// <summary>
    /// Lógica de interacción para PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {

        
        private Grid vistaJugador;
        public PrintWindow(Grid visualPlantilla)
        {
            // Se recibe el grid que se quiere imprimir
            this.vistaJugador = visualPlantilla;
            InitializeComponent();

            // Se crea un documento fijo
            FixedDocument fixedDocument = new FixedDocument();

            // Se crea una página de contenido para el documento fijo
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();

            // Se mide y se dispone el grid que se quiere imprimir. AYUDA CHATGPT
            this.vistaJugador.UpdateLayout();
            this.vistaJugador.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            this.vistaJugador.Arrange(new Rect(new Point(0, 0), this.vistaJugador.DesiredSize));

            // Se crea un visualBrush con el grid que se quiere imprimir
            var visualBrush = new VisualBrush(visualPlantilla);

            // Se crea un rectángulo con el visualBrush
            var rectangle = new Rectangle
            {
                Width = vistaJugador.ActualWidth,
                Height = vistaJugador.ActualHeight,
                Fill = visualBrush
            };

            // Se añade el rectángulo a la página de contenido
            fixedPage.Children.Add(rectangle);
            ((IAddChild)pageContent).AddChild(fixedPage);
            pageContent.Width = vistaJugador.ActualWidth;
            pageContent.Height = vistaJugador.ActualHeight;



            // Se añade la página de contenido al documento fijo
            fixedDocument.Pages.Add(pageContent);

            // Se asigna el documento fijo al visor de documentos
            printPlantilla.Document = fixedDocument;




        }

        /// <summary>
        /// BOTONES DE LA VENTANA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        // Botón de confirmar. Imprime el grid
        private void bConfirmar_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {

                printDialog.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");
                // Configura el tamaño del papel y otras configuraciones si es necesario
                printDialog.PrintTicket.PageMediaSize = new PageMediaSize
                (vistaJugador.ActualWidth, vistaJugador.ActualHeight);
                printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;

                // Imprime el Grid
                printDialog.PrintVisual(vistaJugador, "Grid a PDF");

            }
            this.Close();

        }

        // Botón de cancelar. Cierra la ventana
        private void bCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
