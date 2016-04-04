using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rTipoCompanias : System.Web.UI.Page
    {
        TipoCompanias TipoCompania = new TipoCompanias();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EliminarButton.Visible = false;
            }
        }

        public void ValidacionLimpiar()
        {
            TipoCompaniaIdDiv.Attributes.Remove("class");
            TipoCompaniaIdDiv.Attributes.Add("class", "col-md-8");

            DescripcionDiv.Attributes.Remove("class");
            DescripcionDiv.Attributes.Add("class", "col-md-8");
        }

        public void Limpiar()
        {
            TipoCompaniaIdTextBox.Text = "";
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
                TipoCompania.Descripcion = DescripcionTextBox.Text;
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (TipoCompaniaIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    TipoCompania.TipoCompaniaId = Seguridad.ValidarEntero(TipoCompaniaIdTextBox.Text);

                    if (TipoCompania.Editar())
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
                    if (TipoCompania.Insertar())
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
            if (TipoCompaniaIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(TipoCompaniaIdTextBox.Text) > 0)
                {
                    TipoCompania.TipoCompaniaId = Seguridad.ValidarEntero(TipoCompaniaIdTextBox.Text);

                    if (TipoCompania.Eliminar())
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

            if (!Seguridad.ValidarSoloNumero(TipoCompaniaIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Compañia Invalido", "Error");
                TipoCompaniaIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(TipoCompaniaIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (TipoCompania.Buscar(Id))
                {
                    GuardarButton.Text = "Modificar";
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = TipoCompania.Descripcion;
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