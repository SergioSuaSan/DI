using System.Diagnostics;
using System.Drawing;

namespace Safari
{
    public partial class VentanaP : Form
    {

        private Controlador controlador;

        //Constructor con el controlador parametrizado
        public VentanaP(Controlador controlador)
        {
            this.controlador = controlador;
            //Iniciamos el Safari
            controlador.iniciarSafari();

            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = new Size(1100, 800);
            //Actualizamos la pantalla para que vea el resultado
            this.Refresh();

        }


        /*
         * Aquí tengo muchísimos metodos que se han formado sin darme cuenta, y no los puedo borrar
         * porque se vuelve loco.
         * ¿Cómo debería hacerlo para poder quitarlos y que esta página sea más legible?
         */
        //Método autoplay
        private void autoplay()
        {
            controlador.despausar();
            controlador.autoplay(this);
            buttonPause.Enabled = true;
            buttonPlay.Enabled = false;
            buttonStop.Enabled = true;
            buttonReset.Enabled = true;
            buttonStep.Enabled = false;
            //Examen 1
            button10Steps.Enabled = false;

        }

        //Método salir
        private void salir()
        {
            this.Close();
        }

        //Método step
        private void step()
        {
            controlador.step();
            buttonPause.Enabled = false;
            buttonPlay.Enabled = true;
            buttonStop.Enabled = true;
            buttonReset.Enabled = true;
            buttonStep.Enabled = true;
            //Examen 1
            button10Steps.Enabled = true;
            this.Refresh();
        }
        //Examen 2 Generado método 10 steps
        private void steps10()
        {
            controlador.steps10();
            buttonPause.Enabled = false;
            buttonPlay.Enabled = true;
            buttonStop.Enabled = true;
            buttonReset.Enabled = true;
            buttonStep.Enabled = true;
            //Examen 1
            button10Steps.Enabled = true;
            this.Refresh();
        }


        //Método pausar
        private void pausar()
        {
            controlador.pausar();
            buttonPause.Enabled = false;
            buttonPlay.Enabled = true;
            buttonStop.Enabled = true;
            buttonReset.Enabled = true;
            buttonStep.Enabled = true;
            //Examen 1
            button10Steps.Enabled = true;
        }

        //Metodo resetear
        private void reset()
        {
            controlador.resetear();
            buttonPause.Enabled = false;
            buttonPlay.Enabled = true;
            buttonStop.Enabled = true;
            buttonReset.Enabled = true;
            buttonStep.Enabled = true;

            //Examen 1
            button10Steps.Enabled = true;
            this.Refresh();
        }

        //Método que pinta toda la tabla
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //Muestro en las labels los Seres que tengo y el paso en el que estoy
            numeroLeones.Text = controlador.getLeones();
            numeroGacelas.Text = controlador.getGacelas();
            numeroPlantas.Text = controlador.getPlantas();
            numeroPasos.Text = controlador.getPasos();
            //Examen 1 Colocar el texto de la cantidad de Elefantes que hay
            numeroElefantes.Text = controlador.getElefantes();
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
            //Font fuente = new Font("Arial", 12);
            //Brush pincel = Brushes.Black;
            for (int fila = 0; fila < filas; fila++)
            {
                for (int columna = 0; columna < columnas; columna++)
                {
                    //Pintamos la imagen que se llama igual que el nombre del Ser que hemos asignado en el Safari
                    var image = Image.FromFile($".\\img\\{controlador.getTipoSer(fila, columna)}.ico");
                    var bitmap = new Bitmap(100, 100);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, (xInicial + (columna * anchoCelda)), (yInicial + (fila * altoCelda)), 50, 50);


                    /*
                    string texto = $"{controlador.getNombre(controlador.getSer(fila, columna))}";
                    int xTexto = xInicial + (columna * anchoCelda) + 10;
                    int yTexto = yInicial + (fila * altoCelda) + 15;
                    g.DrawString(texto, fuente, pincel, xTexto, yTexto);*/
                }
            }
        }
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoplay();

        }
        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salir();

        }
        private void buttonStep_Click(object sender, EventArgs e)
        {
            step();

        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            autoplay();
        }
        private void buttonStop_click(object sender, EventArgs e)
        {
            salir();
        }
        private void buttonPause_click(object sender, EventArgs e)
        {
            pausar();
        }
        private void buttonReset_click(object sender, EventArgs e)
        {
            reset();
        }
        private void panelSafari(object sender, PaintEventArgs e)
        {




        }
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void stepToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            step();
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pausar();
        }

        //Examen 2, Creado botón que haga 10 pasos
        private void steps10_Click(object sender, EventArgs e)
        {
            steps10();

        }


        //Examen 2 Generado boton en el menu
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            steps10();
        }

        private void PintarBotones(object sender, PaintEventArgs e)
        {


        }

        private void PintarPanel(object sender, PaintEventArgs e)
        {
           

        }

        
        private void PintarDia(object sender, PaintEventArgs e)
        {
            //Examen 3 VOy a intentar dibujar un sol y una luna para que sea más visiblw
            Graphics g = e.Graphics;
           
                //Examen 3, No lo he conseguido, pero la idea era que si el turno era
                //distinto de 2 (la noche) me dibujara un sol, y en el otro caso, la luna
            if ((controlador.getTurnos()+1) % 3 == 0)
            {

                var image = Image.FromFile($".\\img\\moon.ico");
                var bitmap = new Bitmap(100, 100);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 5, 5, 50, 50);

            }
            else
            {
                var image = Image.FromFile($".\\img\\Sol.ico");
                var bitmap = new Bitmap(100, 100);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 5, 5, 50, 50);

            }

        }
    }
}
