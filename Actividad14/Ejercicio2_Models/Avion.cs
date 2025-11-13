namespace Ejercicio3.Models;

[Serializable]
public class Avion : Transporte
{
    public string Identificador { get; set; }
    public Avion(string destino, double precio, string identificador) : base(destino,precio)
    {
        Identificador = identificador;
    }

    override public double CalcularPrecioFinal()
    {

        double impuesto = precioBase * 0.3;

        double subtotal = precioBase + impuesto;

        double iva = subtotal * 11.5 / 100;

        double total = subtotal + iva;

        return total;
    }

    
}
