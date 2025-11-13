
namespace Ejercicio1_Models;

public abstract class Transporte
{
    public double PrecioBase { get; set; }
    public string Destino { get; set; }


    virtual public double CalcularPrecioFinal()
    {
        return PrecioBase;
    }
}
