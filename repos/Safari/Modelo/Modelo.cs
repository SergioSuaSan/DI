using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Modelo
{
    private string _datos;

    public string Datos
    {
        get { return _datos; }
        set
        {
            if (_datos != value)
            {
                _datos = value;
                OnDatosChanged(); // Notificar a los observadores
            }
        }
    }

    public event EventHandler DatosChanged;

    protected virtual void OnDatosChanged()
    {
        DatosChanged?.Invoke(this, EventArgs.Empty);
    }
}







