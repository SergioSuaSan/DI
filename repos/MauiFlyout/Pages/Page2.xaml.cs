namespace MauiFlyout.Pages
{
    public partial class Page2 : ContentPage
    {
        private bool _pulsado = false;
        public Page2()
        {
            Title = "Página 2";
            InitializeComponent();
           
        }

        private void Cambio_Clicked(object sender, EventArgs e)
        {
            if (_pulsado)
            {
                _pulsado = false;
                Cambio.Text = "→";
                Binario.IsReadOnly = false;
                Decimal.IsReadOnly = true;
                Decimal.Text = "";
            }
            else
            {
                _pulsado = true;
                Cambio.Text = "←";
                Binario.IsReadOnly = true;
                Decimal.IsReadOnly = false;
                Binario.Text = "";


            }
        }

        private void Calcular_Clicked(object sender, EventArgs e)
        {
            if (!_pulsado)
            {

            }
            else
            {

            }

        }
    }
}
