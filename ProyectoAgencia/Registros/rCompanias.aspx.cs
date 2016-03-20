using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rCompanias : System.Web.UI.Page
    {
        Companias Compania = new Companias();
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
            TipoCompanias TipoCompania = new TipoCompanias();

            TipoCompaniaDropDownList.DataSource = TipoCompania.Listado(" * ", " 1=1 ", "");
            TipoCompaniaDropDownList.DataTextField = "Descripcion";
            TipoCompaniaDropDownList.DataValueField = "TipoCompaniaId";
            TipoCompaniaDropDownList.DataBind();
        }

        public void ValidacionLimpiar()
        {
            RequiredFieldValidator1.IsValid = true;
        }

        public void Limpiar()
        {
            CompaniaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            EmailTextBox.Text = "";
            ValidacionLimpiar();
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (DescripcionTextBox.Text.Length > 0 && EmailTextBox.Text.Length > 0)
            {
                Compania.Descripcion = DescripcionTextBox.Text;
                Compania.Email = EmailTextBox.Text;
                Compania.TipoCompaniaId = Seguro.ValidarEntero(TipoCompaniaDropDownList.SelectedValue);
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
            if (CompaniaIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Compania.CompaniaId = Seguro.ValidarEntero(CompaniaIdTextBox.Text);

                    if (Compania.Editar())
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
                    if (Compania.Insertar())
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
            if (CompaniaIdTextBox.Text.Length > 0)
            {
                if (Seguro.ValidarEntero(CompaniaIdTextBox.Text) > 0)
                {
                    Compania.CompaniaId = Seguro.ValidarEntero(CompaniaIdTextBox.Text);

                    if (Compania.Eliminar())
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
            int Id = Seguro.ValidarEntero(CompaniaIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (Compania.Buscar(Id))
                {
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = Compania.Descripcion;
                    EmailTextBox.Text = Compania.Email;
                    TipoCompaniaDropDownList.SelectedValue = Compania.TipoCompaniaId.ToString();
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