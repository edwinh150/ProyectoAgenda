using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProyectoAgencia.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();
        Seguridad Seguro = new Seguridad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
                Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "error");
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
            UsuarioIdTextBox.Text = "";
            NombreUsuarioTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            NombreTextBox.Text = "";
            ApellidoTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";
            FechaNacimientoTextBox.Text = DateTime.Now.ToString();
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
                Usuario.TipoUsuarioId = Seguro.ValidarEntero(TipoUsuarioDropDownList.SelectedValue);
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
            if (UsuarioIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Usuario.UsuarioId = Seguro.ValidarEntero(UsuarioIdTextBox.Text);

                    if (Usuario.Editar())
                    {
                        Mensajes.ShowToastr(this.Page,"Se Modifico","Informacion","sucess");
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
                    Mensajes.ShowToastr(this.Page, "Faltan Datos", "Error", "Error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuarioIdTextBox.Text.Length > 0)
            {


                if (Seguro.ValidarEntero(UsuarioIdTextBox.Text) > 0)
                {
                    Usuario.UsuarioId = Seguro.ValidarEntero(UsuarioIdTextBox.Text);

                    if (Usuario.Eliminar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Guardo", "Informacion", "sucess");
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
                }
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Ingrese un Id valido primero", "Error", "Error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Seguro.ValidarEntero(UsuarioIdTextBox.Text) > 0)
            {
                if (Usuario.Buscar(Seguro.ValidarEntero(UsuarioIdTextBox.Text)))
                {
                    NombreUsuarioTextBox.Text = Usuario.NombreUsuario;
                    NombreTextBox.Text = Usuario.Nombre;
                    ApellidoTextBox.Text = Usuario.Apellido;
                    EmailTextBox.Text = Usuario.Email;
                    TelefonoTextBox.Text = Usuario.Telefono;
                    FechaNacimientoTextBox.Text = Usuario.FechaNacimiento.ToString();
                    TipoUsuarioDropDownList.SelectedValue = Usuario.TipoUsuarioId.ToString();
                }
                else
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Informacion", "info");
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