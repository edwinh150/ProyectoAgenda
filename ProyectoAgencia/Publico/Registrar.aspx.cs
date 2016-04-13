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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
            }
        }

        public void LlenarDropDownList()
        {
            TipoUsuarios TipoUsuario = new TipoUsuarios();
            TipoUsuarioDropDownList.DataSource = TipoUsuario.Listado(" * ", " 1=1 ", "");
            TipoUsuarioDropDownList.DataTextField = "Descripcion";
            TipoUsuarioDropDownList.DataValueField = "TipoUsuarioId";
            TipoUsuarioDropDownList.DataBind();
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
            ValidacionLimpiar();
        }

        public void ValidacionLimpiar()
        {

            NombreUsuarioDiv.Attributes.Remove("class");
            NombreUsuarioDiv.Attributes.Add("class", "col-md-8");

            NombreDiv.Attributes.Remove("class");
            NombreDiv.Attributes.Add("class", "col-md-8");

            ApellidoDiv.Attributes.Remove("class");
            ApellidoDiv.Attributes.Add("class", "col-md-8");

            ContrasenaDiv.Attributes.Remove("class");
            ContrasenaDiv.Attributes.Add("class", "col-md-8");

            EmailDiv.Attributes.Remove("class");
            EmailDiv.Attributes.Add("class", "col-md-8");

            TelefonoDiv.Attributes.Remove("class");
            TelefonoDiv.Attributes.Add("class", "col-md-8");
        }

        bool LLenarDatos()
        {
            bool retorno = true;
            ValidacionLimpiar();
            
            if (!Seguridad.ValidarNombre(NombreUsuarioTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Nombre de Usuario Invalido", "Error");
                NombreUsuarioDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
            }

            if (NombreUsuarioTextBox.Text.Length > 0)
            {
                if (Usuario.Comprobar())
                {
                    Mensajes.ShowToastr(this.Page, "Ya existe ese Usuario Eliga otro", "Atencion", "Error");
                    NombreUsuarioTextBox.Text = "";
                }
            }

            if (ContrasenaTextBox.Text.Length < 6)
            {
                Mensajes.ShowToastr(this, "Error", "Contraseña Invalido Mayor que 6", "Error");
                NombreDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.Contrasena = ContrasenaTextBox.Text;
            }

            if (!Seguridad.ValidarNombre(NombreTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Nombre Invalido", "Error");
                ContrasenaDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.Nombre = NombreTextBox.Text;
            }

            if (!Seguridad.ValidarNombre(ApellidoTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Apellido Invalido", "Error");
                ApellidoDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.Apellido = ApellidoTextBox.Text;
            }

            if (!Seguridad.ValidarEmail(EmailTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Email Invalido", "Error");
                EmailDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.Email = EmailTextBox.Text;
            }

            if (!Seguridad.ValidarTelefono(TelefonoTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Telefono Invalido", "Error");
                TelefonoDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.Telefono = TelefonoTextBox.Text;
            }

            if (FechaNacimientoTextBox.Text.Length == 0)
            {
                Mensajes.ShowToastr(this, "Error", "Fecha Invalido", "Error");
                TelefonoDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                Usuario.FechaNacimiento = Seguridad.ValidarDateTime(FechaNacimientoTextBox.Text);
            }

            Usuario.TipoUsuarioId = Seguridad.ValidarEntero(TipoUsuarioDropDownList.SelectedValue);

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (LLenarDatos())
            {
                if (Usuario.Insertar())
                {
                    Mensajes.ShowToastr(this.Page, "Se Registro", "Felicidades", "Success");
                    Usuario.IniciarSesion();
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