using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rSolicitudes : System.Web.UI.Page
    {
        Solicitudes Solicitud = new Solicitudes();
        Seguridad Seguro = new Seguridad();
        int Eleccion = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
                UsuarioIdLabel.Text = Context.User.Identity.Name;
                FechaCreacionLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        public void LlenarDropDownList()
        {
            TipoSolicitudes TipoSolicitud = new TipoSolicitudes();
            Destinos Destino = new Destinos();
            Usuarios Usuario = new Usuarios();

            TipoSolicitudIdDropDownList.DataSource = TipoSolicitud.Listado(" * ", " 1=1 ", "");
            TipoSolicitudIdDropDownList.DataTextField = "Descripcion";
            TipoSolicitudIdDropDownList.DataValueField = "TipoSolicitudId";
            TipoSolicitudIdDropDownList.DataBind();

            OrigenDropDownList.DataSource = Destino.Listado(" * ", " 1=1 ", "");
            OrigenDropDownList.DataTextField = "Descripcion";
            OrigenDropDownList.DataValueField = "DestinoId";
            OrigenDropDownList.DataBind();

            DestinoDropDownList.DataSource = Destino.Listado(" * ", " DestinoId <> " + OrigenDropDownList.SelectedValue, "");
            DestinoDropDownList.DataTextField = "Descripcion";
            DestinoDropDownList.DataValueField = "DestinoId";
            DestinoDropDownList.DataBind();
        }

        public void ValidacionLimpiar()
        {
            RequiredFieldValidator1.IsValid = true;
            RequiredFieldValidator2.IsValid = true;
            RequiredFieldValidator3.IsValid = true;
            RequiredFieldValidator4.IsValid = true;
            RequiredFieldValidator5.IsValid = true;
        }

        public void Limpiar()
        {
            SolicitudIdTextBox.Text = "";
            AsuntoTextBox.Text = "";
            FechaInicialTextBox.Text = "";
            FechaFinalTextBox.Text = "";
            PrecioInicialTextBox.Text = "";
            PrecioFinalTextBox.Text = "";
            ValidacionLimpiar();

        }

        bool LLenarDatos()
        {
            Usuarios Usuario = new Usuarios();

            bool retorno = false;

            if (AsuntoTextBox.Text.Length > 0)
            {
                Solicitud.Asunto = AsuntoTextBox.Text;
                Solicitud.FechaCreacion = DateTime.Now;
                Solicitud.UsuarioId = Usuario.UsuarioId;

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
            if (SolicitudIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Solicitud.SolicitudId = Seguro.ValidarEntero(SolicitudIdTextBox.Text);

                    if (Solicitud.Editar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Modifico", "Informacion", "Success");
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
                    if (Solicitud.Insertar())
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
            if (SolicitudIdTextBox.Text.Length > 0)
            {
                if (Seguro.ValidarEntero(SolicitudIdTextBox.Text) > 0)
                {
                    Solicitud.SolicitudId = Seguro.ValidarEntero(SolicitudIdTextBox.Text);

                    if (Solicitud.Eliminar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Guardo", "Informacion", "Success");
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
            int Id = Seguro.ValidarEntero(SolicitudIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (Solicitud.Buscar(Id))
                {
                    AsuntoTextBox.Text = Solicitud.Asunto;
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

        protected void AgregarDetalleButton_Click(object sender, EventArgs e)
        {
            Solicitudes SolicitudDetalle;

            if (EstadoRadioButtonList.SelectedIndex == 0)
            {
                Eleccion = 0;
            }
            else
            {
                Eleccion = 1;
            }

            if (Session["SolicitudSession"] == null)
            {
                Session["SolicitudSession"] = new Solicitudes();
            }

            SolicitudDetalle = (Solicitudes)Session["SolicitudSession"];

            SolicitudDetalle.AgregarSolicitud(Eleccion, Seguro.ValidarEntero(TipoSolicitudIdDropDownList.SelectedValue), Seguro.ValidarEntero(CompaniaIdDropDownList.SelectedValue), Seguro.ValidarEntero(CategoriaIdDropDownList.SelectedValue), Seguro.ValidarEntero(OrigenDropDownList.SelectedValue), Seguro.ValidarEntero(DestinoDropDownList.SelectedValue), Seguro.ValidarDateTime(FechaInicialTextBox.Text), Seguro.ValidarDateTime(FechaFinalTextBox.Text), Seguro.ValidarEntero(CantidadPersonaDropDownList.SelectedValue), Seguro.ValidarEntero(CantidadNinoDropDownList.SelectedValue), Seguro.ValidarEntero(CantidadBebeDropDownList.SelectedValue), Seguro.ValidarDouble(PrecioInicialTextBox.Text), Seguro.ValidarDouble(PrecioFinalTextBox.Text));

            Session["SolicitudSession"] = SolicitudDetalle;

            //DetalleGridView.DataSource=
        }

        protected void OrigenDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Destinos Destino = new Destinos();

            DestinoDropDownList.DataSource = Destino.Listado(" * ", " DestinoId <> " + OrigenDropDownList.SelectedValue, "");
            DestinoDropDownList.DataTextField = "Descripcion";
            DestinoDropDownList.DataValueField = "DestinoId";
            DestinoDropDownList.DataBind();
        }
    }
}