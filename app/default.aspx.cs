using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPrestamosUNED.app
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            double saldo;
            int plazo;
            int cuotas;

            if (double.TryParse(txtMonto.Text, out saldo))
            {
                if (int.TryParse(txtPlazo.Text, out plazo))
                {
                    Prestamo Presta = new Prestamo(Convert.ToDouble(txtMonto.Text), Convert.ToDouble(txtTasa.Text),
                                                    Convert.ToInt32(txtPlazo.Text), Convert.ToInt32(ddlMoneda.SelectedValue));

                    Presta.Insertar_Prestamo();
                    txtCalculo.Text = Convert.ToString(Presta.Calculo_Cuota());
                }
                else
                {
                    lblMensaje.Text = "Digite un plazo Numerico";
                }
            }
            else
            {
                lblMensaje.Text = "Digite un Monto Numerico";
            }
        }
    }
}