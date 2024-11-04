namespace PruebassWinform
{
    public partial class Form1 : Form
    {
        List<string> miLista;
        BindingSource misDatos;

        public Form1()
        {
            InitializeComponent();
            // Configuraci�n de la posici�n inicial en el centro de la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
            // Configuraci�n del estado maximizado en c�digo
            //this.WindowState = FormWindowState.Maximized;
            miLista = new List<String>();
            miLista.Add("Elemento 1");
            miLista.Add("Elemento 2");
            miLista.Add("Elemento 3");
            miLista.Add("Elemento 4");
            miLista.Add("Elemento 5");
            misDatos = new BindingSource();
            misDatos.DataSource = miLista;
            listBox1.Items.Add(misDatos);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                MessageBox.Show("Has seleccionado la opcion 2");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
                MessageBox.Show("Has seleccionado la opcion 1");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked)
                MessageBox.Show("Has seleccionado la opcion 3");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"Has seleccionado la opcion {listBox1.SelectedItem}");
        }
    }
}
