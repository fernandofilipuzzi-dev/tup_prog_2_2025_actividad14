

namespace Ejercicio3.Models;

public class Sistema
{
    List<Transporte> transportes=new List<Transporte>();
    List<Ticket> tickets = new List<Ticket>();

    public Sistema()
    {
    }

    public Ticket VerTicket(int idx)
    { 
        if(idx>=0 && idx<CantidadTickets())
            return tickets[idx];
        return null;
    }

    public int CantidadTickets()
    { 
        return tickets.Count;
    }

    public Ticket GenerarTicket(int destino, string cuit, string nombre, string telefono, string nroTarjeta)
    {
        Transporte medio = transportes[destino];
        Ticket ticket = new Ticket(nombre, cuit, telefono, nroTarjeta);
        ticket.Transporte = medio;
        return ticket;
    }

    public void ImportarTransportes(FileStream fs)
    {
        //Tipo Transporte;Destino;precio;patente;clase  (bus:Tipo=0)
        //Tipo Transporte;Destino;precio;identificador  (avion: Tipo = 1)

        StreamReader sr = new StreamReader(fs);

        sr.ReadLine();//descarto la primera cabecera
        sr.ReadLine();//descarto la segunda cabecera

        while (sr.EndOfStream == false)
        { 
            string linea= sr.ReadLine();

            string[] campos = linea.Split(';');

            string tipo = campos[0]; // discriminador: bus o avion
            string destino = campos[1];
            double precio = Convert.ToDouble( campos[2]) ;

            Transporte nuevo=null;
            if (tipo == "0")
            {
                string patente = campos[2];
                string categoria = campos[3];
                nuevo = new Bus(destino, precio, patente, categoria);
            }
            else if (tipo == "1")
            {
                string identificador = campos[2];
                nuevo = new Avion(destino,precio, identificador);
            }

            transportes.Add(nuevo);
        }

        sr.Close();
    }

    public Transporte VerTipoPasaje(int idx)
    {
        if (idx >= 0 && idx < transportes.Count)
            return transportes[idx];
        return null;
    }

    public int VerCantidadTiposPasaje()
    {
        return transportes.Count;
    }
}
