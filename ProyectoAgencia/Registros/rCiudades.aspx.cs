using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rCiudades : System.Web.UI.Page
    {
            Ciudades Ciudad = new Ciudades();

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
            Paises Pais = new Paises();

            PaisDropDownList.DataSource = Pais.Listado(" * ", " 1=1 ", "");
            PaisDropDownList.DataTextField = "Descripcion";
            PaisDropDownList.DataValueField = "PaisId";
            PaisDropDownList.DataBind();
        }

        public void ValidacionLimpiar()
        {
            CiudadIdDiv.Attributes.Remove("class");
            CiudadIdDiv.Attributes.Add("class", "col-md-8");

            DescripcionDiv.Attributes.Remove("class");
            DescripcionDiv.Attributes.Add("class", "col-md-8");
        }

        public void Limpiar()
        {
            CiudadIdTextBox.Text = "";
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
                Ciudad.Descripcion = DescripcionTextBox.Text;
                Ciudad.PaisId = Seguridad.ValidarEntero(PaisDropDownList.SelectedValue);
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (CiudadIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Ciudad.CiudadId = Seguridad.ValidarEntero(CiudadIdTextBox.Text);

                    if (Ciudad.Editar())
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
                    if (Ciudad.Insertar())
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
            if (CiudadIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(CiudadIdTextBox.Text) > 0)
                {
                    Ciudad.CiudadId = Seguridad.ValidarEntero(CiudadIdTextBox.Text);

                    if (Ciudad.Eliminar())
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

            if (!Seguridad.ValidarSoloNumero(CiudadIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Ciudad Invalido", "Error");
                CiudadIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(CiudadIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (Ciudad.Buscar(Id))
                {
                    GuardarButton.Text = "Modificar";
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = Ciudad.Descripcion;
                    PaisDropDownList.SelectedValue = Ciudad.PaisId.ToString();
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