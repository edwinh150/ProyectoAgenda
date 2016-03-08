using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rDestinos : System.Web.UI.Page
    {
        Destinos Destino = new Destinos();
        Seguridad Seguro = new Seguridad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropDownList();
            }
        }

        public void LlenarDropDownList()
        {
            TipoDestinos TipoDestino = new TipoDestinos();
            Ciudades Ciudad = new Ciudades();

            TipoDestinoDropDownList.DataSource = TipoDestino.Listado(" * ", " 1=1 ", "");
            TipoDestinoDropDownList.DataTextField = "Descripcion";
            TipoDestinoDropDownList.DataValueField = "TipoDestinoId";
            TipoDestinoDropDownList.DataBind();

            CiudadDropDownList.DataSource = Ciudad.Listado(" * ", " 1=1 ", "");
            CiudadDropDownList.DataTextField = "Descripcion";
            CiudadDropDownList.DataValueField = "CiudadId";
            CiudadDropDownList.DataBind();
        }

        public void ValidacionLimpiar()
        {
            RequiredFieldValidator1.IsValid = true;
        }

        public void Limpiar()
        {
            DescripcionTextBox.Text = "";
            ValidacionLimpiar();

        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (DescripcionTextBox.Text.Length > 0)
            {
                Destino.Descripcion = DescripcionTextBox.Text;
                Destino.TipoDestinoId = Seguro.ValidarEntero(TipoDestinoDropDownList.SelectedValue);
                Destino.CiudadId = Seguro.ValidarEntero(CiudadDropDownList.SelectedValue);
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
            if (DestinoIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Destino.DestinoId = Seguro.ValidarEntero(DestinoIdTextBox.Text);

                    if (Destino.Editar())
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
                    if (Destino.Insertar())
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
            if (DestinoIdTextBox.Text.Length > 0)
            {
                if (Seguro.ValidarEntero(DestinoIdTextBox.Text) > 0)
                {
                    Destino.DestinoId = Seguro.ValidarEntero(DestinoIdTextBox.Text);

                    if (Destino.Eliminar())
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
            int Id = Seguro.ValidarEntero(DestinoIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (Destino.Buscar(Id))
                {
                    DescripcionTextBox.Text = Destino.Descripcion;
                    TipoDestinoDropDownList.SelectedValue = Destino.TipoDestinoId.ToString();
                    CiudadDropDownList.SelectedValue = Destino.CiudadId.ToString();
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