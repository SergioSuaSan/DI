using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Esta vista la verdad es que no recuerdo para qué está aquí!
public class Vista : Form
{
    private Label lblDatos;
    private Modelo modelo;

    public Vista(Modelo modelo)
    {
        this.modelo = modelo;
        lblDatos = new Label();
        this.Controls.Add(lblDatos);

        // Suscribirse al evento del modelo
        modelo.DatosChanged += Modelo_DatosChanged;

        // Inicializar la vista con los datos actuales, nuestro Paint del Panel
        ActualizarVista();
    }

    private void Modelo_DatosChanged(object sender, EventArgs e)
    {
        ActualizarVista();
    }

    private void ActualizarVista()
    {
        lblDatos.Text = modelo.Datos; // Actualiza la vista con los nuevos datos
    }
}
