using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rCategorias : System.Web.UI.Page
    {
        Categorias Categoria = new Categorias();
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
            TipoCategorias TipoCategoria = new TipoCategorias();


            TipoCategoriaIdDropDownList.DataSource = TipoCategoria.Listado(" * ", " 1=1 ", "");
            TipoCategoriaIdDropDownList.DataTextField = "Descripcion";
            TipoCategoriaIdDropDownList.DataValueField = "TipoCategoriaId";
            TipoCategoriaIdDropDownList.DataBind();
        }

        public void ValidacionLimpiar()
        {
            RequiredFieldValidator1.IsValid = true;
        }

        public void Limpiar()
        {
            CategoriaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            ValidacionLimpiar();

        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (DescripcionTextBox.Text.Length > 0)
            {
                Categoria.Descripcion = DescripcionTextBox.Text;
                Categoria.TipoCategoriaId = Seguro.ValidarEntero(TipoCategoriaIdDropDownList.SelectedValue);
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
            if (CategoriaIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Categoria.CategoriaId = Seguro.ValidarEntero(CategoriaIdTextBox.Text);

                    if (Categoria.Editar())
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
                    if (Categoria.Insertar())
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
            if (CategoriaIdTextBox.Text.Length > 0)
            {
                if (Seguro.ValidarEntero(CategoriaIdTextBox.Text) > 0)
                {
                    Categoria.CategoriaId = Seguro.ValidarEntero(CategoriaIdTextBox.Text);

                    if (Categoria.Eliminar())
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
            int Id = Seguro.ValidarEntero(CategoriaIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (Categoria.Buscar(Id))
                {
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = Categoria.Descripcion;
                    TipoCategoriaIdDropDownList.SelectedValue = Categoria.TipoCategoriaId.ToString();
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