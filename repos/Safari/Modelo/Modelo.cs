

//Este Modelo la verdad es que no recuerdo por qué está aquí!
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







