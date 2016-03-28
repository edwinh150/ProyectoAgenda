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

            if (NombreTextBox.Text.Length > 0 && EmailTextBox.Text.Length > 0 && TelefonoTextBox.Text.Length > 0 && MensajeTextBox.Text.Length > 0)
            {
                if (EnvioCorreo.EnviarCorreo("Usuario", "Buenas le mando un mensaje: " + NombreTextBox.Text + " " + TelefonoTextBox.Text, EmailTextBox.Text, NombreTextBox.Text, "", MensajeTextBox.Text))
                {
                    Mensajes.ShowToastr(this.Page, "Se Envio su Mensaje", "Felicidades", "Success");
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "Hay problemas para enviar", "Ups", "Error");
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Faltan Datos", "Error", "Error");
            }
        }
    }
}