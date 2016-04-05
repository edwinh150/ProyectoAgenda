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

        public void ValidacionLimpiar()
        {
            NombreDiv.Attributes.Remove("class");
            NombreDiv.Attributes.Add("class", "controls");

            TelefonoDiv.Attributes.Remove("class");
            TelefonoDiv.Attributes.Add("class", "controls");

            EmailDiv.Attributes.Remove("class");
            EmailDiv.Attributes.Add("class", "controls");

            MensajeDiv.Attributes.Remove("class");
            MensajeDiv.Attributes.Add("class", "controls");
        }

        protected void MensajeButton_Click(object sender, EventArgs e)
        {
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarNombre(NombreTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Nombre Invalido", "Error");
                NombreDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (!Seguridad.ValidarTelefono(TelefonoTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Telefono Invalido", "Error");
                TelefonoDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (!Seguridad.ValidarEmail(EmailTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Email Invalido", "Error");
                EmailDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (!Seguridad.ValidarNombre(MensajeTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Mensaje Invalido", "Error");
                MensajeDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (retorno)
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
        }
    }
}