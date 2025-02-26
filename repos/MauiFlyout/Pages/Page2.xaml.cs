using System;

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
                long num = long.Parse(Binario.Text);
                //Creamos las variables necesarias para el ejercico
                long deci = 0, usado, potencia = 0;
                bool error = false;

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

            }

        }
    }
}
