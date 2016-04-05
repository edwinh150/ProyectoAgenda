using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;

namespace ProyectoAgencia
{
    public partial class Login : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            ContrasenaTextBox.Text = "";
            RecordarmeCheckBox.Checked = false;
            ValidacionLimpiar();
        }

        public void ValidacionLimpiar()
        {
            NombreDiv.Attributes.Remove("class");
            NombreDiv.Attributes.Add("class", "controls");

            ContrasenaDiv.Attributes.Remove("class");
            ContrasenaDiv.Attributes.Add("class", "controls");
        }

        protected void IniciarButton_Click(object sender, EventArgs e)
        {
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarNombre(NombreTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Nombre de Usuario Invalido", "Error");
                NombreDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.NombreUsuario = NombreTextBox.Text;
            }

            if (ContrasenaTextBox.Text.Length == 0)
            {
                Mensajes.ShowToastr(this, "Error", "Contraseña Invalido", "Error");
                ContrasenaDiv.Attributes.Add("class", " controls has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Usuario.Contrasena = ContrasenaTextBox.Text;
            }

            if (Usuario.IniciarSesion())
            {
                FormsAuthentication.RedirectFromLoginPage(NombreTextBox.Text, RecordarmeCheckBox.Checked);
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Error de Inicio", "Error", "Error");
                Limpiar();
            }
        }

        protected void RegistrarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            Response.Redirect("/Publico/Registrar.aspx");
        }
    }
}