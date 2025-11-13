using Ejercicio3.Models;

namespace Ejercicio3;

public partial class FormPrincipal : Form
{
    Sistema miEmpresa = new Sistema();


    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {

    }

    private void btnGenerarTicket_Click(object sender, EventArgs e)
    {
        if (cmbDestino.SelectedIndex == -1)
        {
            MessageBox.Show("Seleccione un destino");
            return;
        }

        int nroDestino = cmbDestino.SelectedIndex;
        string cuit = "32432432";
        string nombre = "fernando";
        string telefono = "123343";
        string nroTarjeta = "23432424";

        try
        {
            Ticket ticketActual = miEmpresa.GenerarTicket(nroDestino, cuit, nombre, telefono, nroTarjeta);

            FormVer fVer = new FormVer();
            fVer.listBox1.Items.AddRange(ticketActual.VerDescripcion());
            fVer.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }

    private void btnResumen_Click(object sender, EventArgs e)
    {

    }

    private void btnImportarEjemplo_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            string path = openFileDialog1.FileName;

            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                miEmpresa.ImportarTransportes(fs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { fs.Close(); }

            VerTransportes();
        }
    }

    private void VerTransportes()
    {
        cmbDestino.Items.Clear();

        for (int n = 0; n < miEmpresa.VerCantidadTiposPasaje(); n++)
        {
            cmbDestino.Items.Add(miEmpresa.VerTipoPasaje(n));
        }
    }

    private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
    {

    }

    private void cmbDestino_SelectedIndexChanged(object sender, EventArgs e)
    {

        Transporte seleccionado = cmbDestino.SelectedItem as Transporte;

        if (seleccionado != null)
        {
            lbPrecio.Text = $"{seleccionado.CalcularPrecioFinal():f2}";
            lbTransporte.Text = "";
        }
        else
        {
            lbPrecio.Text = "";
        }
    }
}
