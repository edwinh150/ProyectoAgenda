using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rTipoSolicitudes : System.Web.UI.Page
    {
        TipoSolicitudes TipoSolicitud = new TipoSolicitudes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EliminarButton.Visible = false;
            }
        }

        public void ValidacionLimpiar()
        {
            TipoSolicitudIdDiv.Attributes.Remove("class");
            TipoSolicitudIdDiv.Attributes.Add("class", "col-md-8");

            DescripcionDiv.Attributes.Remove("class");
            DescripcionDiv.Attributes.Add("class", "col-md-8");
        }

        public void Limpiar()
        {
            TipoSolicitudIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            ValidacionLimpiar();
            GuardarButton.Text = "Guardar";
            EliminarButton.Visible = false;
        }

        bool LLenarDatos()
        {
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarNombre(DescripcionTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Descripcion Invalido", "Error");
                DescripcionDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }
            if (retorno)
            {
                TipoSolicitud.Descripcion = DescripcionTextBox.Text;
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (TipoSolicitudIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    TipoSolicitud.TipoSolicitudId = Seguridad.ValidarEntero(TipoSolicitudIdTextBox.Text);

                    if (TipoSolicitud.Editar())
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
                    if (TipoSolicitud.Insertar())
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
            if (TipoSolicitudIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(TipoSolicitudIdTextBox.Text) > 0)
                {
                    TipoSolicitud.TipoSolicitudId = Seguridad.ValidarEntero(TipoSolicitudIdTextBox.Text);

                    if (TipoSolicitud.Eliminar())
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
            int Id = 0;
            bool retorno = true;

            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(TipoSolicitudIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Solicitud Invalido", "Error");
                TipoSolicitudIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(TipoSolicitudIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (TipoSolicitud.Buscar(Id))
                {
                    GuardarButton.Text = "Modificar";
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = TipoSolicitud.Descripcion;
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