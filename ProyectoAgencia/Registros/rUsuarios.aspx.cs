using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Services.Description;

namespace ProyectoAgencia.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
                EliminarButton.Visible = false;
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

        public void ValidacionLimpiar()
        {
            UsuarioIdDiv.Attributes.Remove("class");
            UsuarioIdDiv.Attributes.Add("class", "col-md-8");

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

        public void Limpiar()
        {
            UsuarioIdTextBox.Text = "";
            NombreUsuarioTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            FechaNacimientoTextBox.Text = "";
            ValidacionLimpiar();
            GuardarButton.Text = "Guardar";
            EliminarButton.Visible = false;
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

            if (NombreUsuarioTextBox.Text.Length > 0 && UsuarioIdTextBox.Text.Length == 0)
            {
                if (Usuario.Comprobar())
                {
                    Mensajes.ShowToastr(this.Page, "Ya existe ese Usuario Eliga otro", "Atencion", "Error");
                    NombreUsuarioTextBox.Text = "";
                }
            }

            if (ContrasenaTextBox.Text.Length < 6)
            {
                Mensajes.ShowToastr(this, "Contraseña Mayor de 6 digitos", "Contraseña Invalido", "Error");
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
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Usuario.UsuarioId = Seguridad.ValidarEntero(UsuarioIdTextBox.Text);

                    if (Usuario.Editar())
                    {
                        Mensajes.ShowToastr(this.Page,"Se Modifico","Informacion","Success");
                        Limpiar();
                    }
                    else
                    {
                        Mensajes.ShowToastr(this.Page, "No Se Modifico", "Error", "Error");
                    }

                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "Faltan Datos", "Error", "Error");
                }
            }
            else
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
                    Mensajes.ShowToastr(this.Page, "Faltan Datos", "Error", "Error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(UsuarioIdTextBox.Text) > 0)
                {
                    Usuario.UsuarioId = Seguridad.ValidarEntero(UsuarioIdTextBox.Text);

                    if (Usuario.Eliminar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Elimino", "Informacion", "Success");
                        Limpiar();
                    }
                    else
                    {
                        Mensajes.ShowToastr(this.Page, "No Se Elimino", "Error", "Error");
                    }
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "Error");
                    Limpiar();
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Ingrese un Id valido primero", "Error", "Error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int Id = 0;
            bool retorno = true;

            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(UsuarioIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Usuario Invalido", "Error");
                UsuarioIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(UsuarioIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (Usuario.Buscar(Id))
                {
                    NombreUsuarioTextBox.Text = Usuario.NombreUsuario;
                    NombreTextBox.Text = Usuario.Nombre;
                    ApellidoTextBox.Text = Usuario.Apellido;
                    EmailTextBox.Text = Usuario.Email;
                    TelefonoTextBox.Text = Usuario.Telefono;
                    FechaNacimientoTextBox.Text = Usuario.FechaNacimiento.ToString("dd-MM-yyyy");
                    TipoUsuarioDropDownList.SelectedValue = Usuario.TipoUsuarioId.ToString();
                    EliminarButton.Visible = true;
                    GuardarButton.Text = "Modificar";
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Informacion", "info");
                    Limpiar();
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Ingrese un Id valido primero", "Error", "Error");
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}