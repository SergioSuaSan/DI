namespace PruebassWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Configuraci�n de la posici�n inicial en el centro de la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            // Configuraci�n del estado maximizado en c�digo
            //this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.MiFormulario_MouseMove(sender, (MouseEventArgs)e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.MiFormulario_MouseMove(sender, (MouseEventArgs)e);
        }

        private void MiFormulario_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MouseButtons botones = e.Button;
            // Pueden estar m�ltiples botones presionados simult�neamente
            int numeroDeClics = e.Clicks;
            string mensaje = $"Posici�n: X = {x}, Y = {y}\nBotones: {botones}\nN�mero de clics:{numeroDeClics}";
            label1.Text = mensaje;
            // Supongamos que hay un control Label llamado lblInformacion
        }

    }
}
