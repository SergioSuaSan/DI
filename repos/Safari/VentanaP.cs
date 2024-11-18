using System.Drawing;

namespace Safari
{
    public partial class VentanaP : Form
    {
        public VentanaP(Controlador controlador)
        {
            InitializeComponent();
            Safari miSafari = new Safari(); //Creación e instanciación del Safari
            //Console.WriteLine(miSafari.ToString());
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

        }

        private void numeroPlantas_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 10);
            Pen pen = new Pen(Color.Black, 2);
            string texto;
            Icon iconoSer;
            Image imgSer; 
            int filas = 10;
            int columnas = 10;
            int anchoCelda = 50;
            int altoCelda = 40;
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
                    texto = $"({fila + 1}, {columna + 1})";
                    int xTexto = xInicial + (columna * anchoCelda);
                    int yTexto = yInicial + (fila * altoCelda);
                    g.DrawString(texto, fuente, pincel, xTexto, yTexto);
                    
                }
            }

        }
    }
}
