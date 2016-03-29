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
        string Persona = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.User.Identity.Name.Length > 0)
                {
                    Persona = Context.User.Identity.Name;
                }
            }
        }

        public void Limpiar()
        {
            NombreTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            MensajeTextBox.Text = "";
        }

        protected void MensajeButton_Click(object sender, EventArgs e)
        {

            if (NombreTextBox.Text.Length > 0 && EmailTextBox.Text.Length > 0 && TelefonoTextBox.Text.Length > 0 && MensajeTextBox.Text.Length > 0)
            {
                if (Persona.Length == 0)
                {
                    Persona = NombreTextBox.Text;
                }
                else
                {
                    Persona = Context.User.Identity.Name;
                }

                if (EnvioCorreo.EnviarCorreo("Usuario", "Buenas has recibido un mensaje de: " + Persona + " T: " + TelefonoTextBox.Text, EmailTextBox.Text, NombreTextBox.Text, "", MensajeTextBox.Text))
                {
                    Mensajes.ShowToastr(this.Page, "Se Envio su Mensaje", "Felicidades", "Success");
                    Limpiar();
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