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
            CategoriaIdDiv.Attributes.Remove("class");
            CategoriaIdDiv.Attributes.Add("class", "col-md-8");

            DescripcionDiv.Attributes.Remove("class");
            DescripcionDiv.Attributes.Add("class", "col-md-8");
        }

        public void Limpiar()
        {
            CategoriaIdTextBox.Text = "";
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
                Categoria.Descripcion = DescripcionTextBox.Text;
                Categoria.TipoCategoriaId = Seguridad.ValidarEntero(TipoCategoriaIdDropDownList.SelectedValue);
                retorno = true;
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (CategoriaIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Categoria.CategoriaId = Seguridad.ValidarEntero(CategoriaIdTextBox.Text);

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
                if (Seguridad.ValidarEntero(CategoriaIdTextBox.Text) > 0)
                {
                    Categoria.CategoriaId = Seguridad.ValidarEntero(CategoriaIdTextBox.Text);

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
            int Id = 0;
            bool retorno = true;

            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(CategoriaIdTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Id de Categoria Invalido", "Error");
                CategoriaIdDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Id = Seguridad.ValidarEntero(CategoriaIdTextBox.Text);
            }

            if (Id > 0)
            {
                if (Categoria.Buscar(Id))
                {
                    GuardarButton.Text = "Modificar";
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