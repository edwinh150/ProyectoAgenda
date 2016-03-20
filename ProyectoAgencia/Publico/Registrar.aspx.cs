using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia
{
    public partial class Registrar : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();
        Seguridad Seguro = new Seguridad();

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
            FechaNacimientoTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            RequiredFieldValidator1.IsValid = true;
            RequiredFieldValidator2.IsValid = true;
            RequiredFieldValidator3.IsValid = true;
            RequiredFieldValidator4.IsValid = true;
            RequiredFieldValidator5.IsValid = true;
            RequiredFieldValidator7.IsValid = true;
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (NombreUsuarioTextBox.Text.Length > 0 && ContrasenaTextBox.Text.Length > 0 && NombreTextBox.Text.Length > 0 && ApellidoTextBox.Text.Length > 0 && EmailTextBox.Text.Length > 0 && TelefonoTextBox.Text.Length > 0)
            {
                    Usuario.NombreUsuario = NombreUsuarioTextBox.Text;

                if (Usuario.Comprobar())
                {
                    Mensajes.ShowToastr(this.Page, "Ya existe ese Usuario Eliga otro", "Atencion", "Error");
                    NombreUsuarioTextBox.Text = "";
                }
                else
                {
                    Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
                    Usuario.Contrasena = ContrasenaTextBox.Text;
                    Usuario.Nombre = NombreTextBox.Text;
                    Usuario.Apellido = ApellidoTextBox.Text;
                    Usuario.Email = EmailTextBox.Text;
                    Usuario.Telefono = TelefonoTextBox.Text;
                    Usuario.FechaNacimiento = Seguro.ValidarDateTime(FechaNacimientoTextBox.Text);
                    Usuario.TipoUsuarioId = 2;
                }

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
                    Mensajes.ShowToastr(this.Page, "Se Registro", "Felicidades", "Success");
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