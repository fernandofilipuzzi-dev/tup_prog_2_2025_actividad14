

namespace Ejercicio1_Models;

public class Bus:Transporte
{
    public string Patente { get; set; } 
    public int  Clase { get; set; }


    override public double CalcularPrecioFinal()
    {
        double precio = base.CalcularPrecioFinal();
        double iva = precio * 21.5 / 100;
        return precio + iva;
    }
}
