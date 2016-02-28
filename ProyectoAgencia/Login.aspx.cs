﻿using System;
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
            }
        }

        protected void RegistrarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }
    }
}