

namespace Ejercicio3.Models;

[Serializable]
abstract public class Transporte
{
    protected double precioBase; //tiene un precio base sin impuesto
    public string Destino { get; set; } //tiene un destino

    public DateTime FechaCompra { get; set; }

    public Transporte(string destino, double precio)
    {
        precioBase=precio;
        this.Destino=destino;
    }

    abstract public double CalcularPrecioFinal();

    public override string ToString()
    {
        return $"{Destino}({CalcularPrecioFinal():f2})";
    }

}
