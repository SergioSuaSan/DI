using System.Threading.Tasks;

namespace MauiFlyout.Pages
{
    public partial class Page2 : ContentPage
    {
        private bool _pulsado = false;
        public Page2()
        {
            Title = "Transformador Binario-Decimal";
            InitializeComponent();

        }

        private async void Cambio_Clicked(object sender, EventArgs e)
        {
            await Cambio.RelScaleTo(-0.2,100,Easing.Linear);
            await Cambio.RelRotateTo(180, 200, Easing.Linear);
            await Cambio.RelScaleTo(0.2, 100, Easing.Linear);

            if (_pulsado) //Si está en decimal
            {
                _pulsado = false;
                //Cambio.Text = "→";
                Binario.IsReadOnly = false;
                Decimal.IsReadOnly = true;
                Decimal.Text = "";
                Binario.Text = "";

            }
            else //Si está en binario
            {
                
                _pulsado = true;
               // Cambio.Text = "←";
                Binario.IsReadOnly = true;
                Decimal.IsReadOnly = false;
                Binario.Text = "";
                Decimal.Text = "";


            }
        }

        private async void Calcular_Clicked(object sender, EventArgs e)
        {
            //Creamos las variables necesarias para el ejercico
            long deci = 0, bina = 0,  usado, potencia = 0, posicion = 1;
            bool error = false;
            long num = 0;

            //Transformación de binario a decimal
            if (!_pulsado)
            {
                //Comprobamos que el número binario sea correcto
                try
                {
                    num = long.Parse(Binario.Text);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "El número binario es incorrecto", "OK");

                }

                //Vamos a crear un bucle que transforme el binario a decimal, mientras el número sea mayor a 0
                while (num > 0)
                {
                    //Cogemos el número más a la derecha como resto
                    usado = num % 10;

                    if (usado == 0 || usado == 1)
                    {
                        //Le sumamos al número decimal el resultado de la operación
                        deci += usado * (int)Math.Pow(2, potencia);

                        //Eliminamos el último dígito del número binaro y aumentamos la potencia para el siguiente bucle
                        num = num / 10;
                        potencia++;
                    }
                    else
                    {
                        //Si el formato del binario incluye números distintos de 0 y 1, terminamos el bucle con
                        //el num por debajo de 0 y activamos el error
                        num = -1;
                        error = true;
                    }



                }
                //La función error  indica que el formato del binario es incorrecto y te devuelve al menú principal
                if (error)
                {
                    Console.WriteLine("El formato del binario es incorrecto");
                    Decimal.Text = "ERROR";
                }
                //Y si no hay error, solo si el numero restante es 0, escribirá el resultado. 
                //Esto evita que salga 0 si dejas en blanco el número binario
                else if (num == 0)
                {

                    Console.WriteLine(deci);
                    Decimal.Text = deci.ToString();

                }
            }
            else
            {
                //Transformacion de decimal a binario
                try
                {
                    num = long.Parse(Decimal.Text);
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Error", "Tiene que ser un Número", "OK");
                }

                // Si el número es 0, directamente asignamos "0"  
                if (num == 0)
                {
                    bina = 0;
                }
                else
                {
                    // Convertimos el número decimal a binario  
                    while (num > 0)
                    {
                        usado = num % 2; // Obtenemos el residuo (0 o 1)  
                        bina += usado * posicion; // Agregamos el dígito en la posición correcta  
                        num = num / 2; // Reducimos el número dividiéndolo por 2  
                        posicion *= 10; // Multiplicamos por 10 para desplazar el siguiente dígito  
                    }
                }

                Binario.Text = bina.ToString();



            }
               
            

        }
    }
}
