using System.Diagnostics;
using System.Drawing;

namespace Safari
{
    public partial class VentanaP : Form
    {
        private Controlador controlador;

        public VentanaP(Controlador controlador)
        {
            this.controlador = controlador;
            controlador.iniciarSafari();

            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = new Size(1100, 800);
            this.Refresh();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStep_Click(object sender, EventArgs e)
        {
            controlador.step();
            this.
               Refresh();
        }

        private void numeroPlantas_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void buttonPlay_Click(object sender, EventArgs e)
        {

        }

        private void buttonStop_click(object sender, EventArgs e)
        {

        }

        private void buttonPause_click(object sender, EventArgs e)
        {

        }

        private void buttonReset_click(object sender, EventArgs e)
        {
            controlador.resetear();
            this.Refresh();
        }

        private void panelSafari(object sender, PaintEventArgs e)
        {




        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador.resetear();
            this.Refresh();
        }

        private void numeroPasos_Click(object sender, EventArgs e)
        {

        }

        private void numeroPlantas_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador.step();
            this.Refresh();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            numeroLeones.Text = controlador.getLeones();
            numeroGacelas.Text = controlador.getGacelas();
            numeroPlantas.Text = controlador.getPlantas();
            numeroPasos.Text = controlador.getPasos();
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            // Configuraciones de la tabla
            int filas = controlador.getFilas();
            int columnas = controlador.getColumnas();
            int anchoCelda = 50;
            int altoCelda = 50;
            int xInicial = 50;
            int yInicial = 50;


            // Dibujar las líneas de la tabla
            for (int i = 0; i <= filas; i++)
            {
                // Dibujar las líneas horizontales
                g.DrawLine(pen, xInicial, yInicial + (i * altoCelda), xInicial + (columnas * anchoCelda), yInicial + (i * altoCelda));
            }

            for (int j = 0; j <= columnas; j++)
            {
                // Dibujar las líneas verticales
                g.DrawLine(pen, xInicial + (j * anchoCelda), yInicial, xInicial + (j * anchoCelda), yInicial + (filas * altoCelda));
            }

            // Rellenar las celdas con texto de ejemplo
            Font fuente = new Font("Arial", 12);
            Brush pincel = Brushes.Black;
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    var image = Image.FromFile($"..\\..\\..\\img\\{controlador.getNombre(controlador.getSer(fila, columna))}.ico");
                    var bitmap = new Bitmap(40, 40);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, (xInicial + (columna * anchoCelda)), (yInicial + (fila * altoCelda)), 40, 40);


                    /*
                                       string texto = $"{controlador.getNombre(controlador.getSer(fila, columna))}";
                                        int xTexto = xInicial + (columna * anchoCelda) + 10;
                                        int yTexto = yInicial + (fila * altoCelda) + 15;
                                        g.DrawString(texto, fuente, pincel, xTexto, yTexto);*/
                }
            }
        }
    }
}
