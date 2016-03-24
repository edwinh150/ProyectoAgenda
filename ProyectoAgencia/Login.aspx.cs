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
            NombreValidacion.IsValid = true;
            ContrasenaValidacion.IsValid = true;
        }

        protected void IniciarButton_Click(object sender, EventArgs e)
        {
            Usuario.NombreUsuario = NombreTextBox.Text;
            Usuario.Contrasena = ContrasenaTextBox.Text;

            if (Usuario.IniciarSesion())
            {
                FormsAuthentication.RedirectFromLoginPage(NombreTextBox.Text, true);
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