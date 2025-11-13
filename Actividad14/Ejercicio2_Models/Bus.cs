
namespace Ejercicio3.Models;

public class Bus:Transporte
{
    public string Patente { get; set; }
    public string Categoria { get; set; }

    public Bus(string destino, double precio, string patente, string categoria) : base(destino, precio)
    {
        Patente = patente;
        Categoria = categoria;
    }

    override public double CalcularPrecioFinal() 
    {

        double subtotal = precioBase;

        double iva = subtotal * 21 / 100;

        double total = subtotal + iva;

        return total;
    }

}
