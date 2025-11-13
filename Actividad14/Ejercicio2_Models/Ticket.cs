

namespace Ejercicio3.Models;


[Serializable]
public class Ticket:IComparable<Ticket>
{
    public string Nombre { get; set; }
    public string CUIT { get; set; }
    public string Telefono { get; set; }
    public string Tarjeta { get; set; }

    public Transporte Transporte { get; set; }//el ticket esta asociado al pasaje 

    public Ticket(string nombre, string cuit, string telefono, string tarjeta)
    {
        if (ValidarCUITCUIL(cuit) == false)
        {
            throw new Exception("CUIT/CUIL incorrecto");
        }
        if (ValidarTarjeta(tarjeta) == false)
        {
            throw new Exception("Telefono tarjeta");
        }

        Nombre = nombre;
        CUIT = cuit;
        Telefono = telefono;
        Tarjeta = tarjeta;
    }

    protected bool ValidarTarjeta(string tarjeta)
    {
        return tarjeta.Trim().Length == 16;
    }

    private bool ValidarCUITCUIL(string cuit)
    {
        return cuit.Trim().Length == 11;
    }

    public int CompareTo(Ticket other)
    {
        if (other == null)
            return Transporte.Destino.CompareTo(other.Transporte.Destino);
        return -1;
    }

    public string[] VerDescripcion()
    {
        return new string[]
        {
            $"Nombre: {Nombre}",
            $"CUIT/CUIL: {CUIT}",
            $"Telefono: {Telefono}",
            $"Tarjeta: {Tarjeta}",
            $"Destino: {Transporte.Destino}",
        };
    }
}
