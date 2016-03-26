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
            RequiredFieldValidator1.IsValid = true;
            RequiredFieldValidator2.IsValid = true;
            RequiredFieldValidator3.IsValid = true;
            RequiredFieldValidator4.IsValid = true;
            RequiredFieldValidator5.IsValid = true;
            RequiredFieldValidator7.IsValid = true;
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
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (NombreUsuarioTextBox.Text.Length > 0 && ContrasenaTextBox.Text.Length > 0 && NombreTextBox.Text.Length > 0 && ApellidoTextBox.Text.Length > 0 && EmailTextBox.Text.Length > 0 && TelefonoTextBox.Text.Length > 0)
            {
                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
                if (UsuarioIdTextBox.Text.Length == 0)
                {
                    if (Usuario.Comprobar())
                    {
                        Mensajes.ShowToastr(this.Page, "Ya existe ese Usuario Eliga otro", "Atencion", "Error");
                        NombreUsuarioTextBox.Text = "";
                    }
                }

                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
                Usuario.Contrasena = ContrasenaTextBox.Text;
                Usuario.Nombre = NombreTextBox.Text;
                Usuario.Apellido = ApellidoTextBox.Text;
                Usuario.Email = EmailTextBox.Text;
                Usuario.Telefono = TelefonoTextBox.Text;
                Usuario.FechaNacimiento = Seguro.ValidarDateTime(FechaNacimientoTextBox.Text);
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
                if (Seguro.ValidarEntero(UsuarioIdTextBox.Text) > 0)
                {
                    Usuario.UsuarioId = Seguro.ValidarEntero(UsuarioIdTextBox.Text);

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
            int Id = Seguro.ValidarEntero(UsuarioIdTextBox.Text);
            ValidacionLimpiar();

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