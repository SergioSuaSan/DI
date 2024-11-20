using System.Drawing;

namespace Safari
{
    public partial class VentanaP : Form
    {
        private Controlador controlador;

        public VentanaP(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
             
            
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

            controlador.iniciarSafari();


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

        }
    }
}
