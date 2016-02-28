using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia
{
    public partial class Registrar1 : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
            NombreUsuarioTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (NombreUsuarioTextBox.Text.Length > 0 && ContrasenaTextBox.Text.Length > 0)
            {
                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
                Usuario.Contrasena = ContrasenaTextBox.Text;
                Usuario.Nombre = NombreTextBox.Text;
                Usuario.Apellido = ApellidoTextBox.Text;
                Usuario.Email = EmailTextBox.Text;
                Usuario.Telefono = TelefonoTextBox.Text;
                if (FechaNacimientoTextBox.Text.Length > 0)
                {
                    Usuario.FechaNacimiento = Convert.ToDateTime(FechaNacimientoTextBox.Text);
                }
                else
                {
                    retorno = false;
                }
                Usuario.TipoUsuarioId = 2;
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (LLenarDatos())
            {
                if (Usuario.Insertar())
                {
                    Mensajes.ShowToastr(this.Page, "Se Registro", "Felicidades", "success");
                    Limpiar();
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "No se pudo Registrar", "Error", "Error");
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Faltan Datos", "Atencion", "Error");
            }
        }
    }
}