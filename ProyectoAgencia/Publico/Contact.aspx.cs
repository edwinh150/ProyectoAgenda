using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProyectoAgencia
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MensajeButton_Click(object sender, EventArgs e)
        {

            if (true)
            {
                if (EnvioCorreo.EnviarCorreo("Usuario", NombreTextBox.Text + TelefonoTextBox.Text, EmailTextBox.Text, NombreTextBox.Text, "", MensajeTextBox.Text))
                {
                    Mensajes.ShowToastr(this.Page, "Se Envio su Mensaje", "Felicidades", "Success");
                }
            }
        }
    }
}