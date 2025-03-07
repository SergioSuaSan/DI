using System;

namespace MauiFlyout.Pages;

public partial class Change : ContentPage
{
	public Change()
	{
		InitializeComponent();

    }

    //Examen

    /// <summary>
    /// Función que se activa al pulsar el botón de calcular
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Calcular_Clicked(object sender, EventArgs e)
    {
        //Declaramos las variables
        double euros = 0, dolares, libras, yuanes, yenes, pesos ,rublos;

        //Comprobamos que el número binario sea correcto
        try
        {
            euros = double.Parse(Euros.Text); //Convertimos el número a decimal
        }
        catch (Exception ex) //Si no es un número
        {
            await DisplayAlert("Error", "El número es incorrecto", "OK"); 

        }

        //Calculamos el cambio
        dolares = euros * 1.07;
        libras = euros * 0.84;
        yenes = euros * 160.09;
        yuanes = euros * 7.77;
        pesos = euros * 1148.01;
        rublos = euros * 95.70;

        //Hacemos que los resultados tengan dos decimales
        dolares = Math.Round(dolares, 2);
        libras = Math.Round(libras, 2);
        yenes = Math.Round(yenes, 2);
        yuanes = Math.Round(yuanes, 2);
        pesos = Math.Round(pesos, 2);
        rublos = Math.Round(rublos, 2);


        //Mostramos el resultado
        Dolares.Text = dolares.ToString() + "$";
        Libras.Text = libras.ToString() + "£";
        Yenes.Text = yenes.ToString() + "¥";
        Yuanes.Text = yuanes.ToString() + "¥";
        Pesos.Text = "$" + pesos.ToString();
        Rublos.Text = rublos.ToString() + "₽";


    }
}