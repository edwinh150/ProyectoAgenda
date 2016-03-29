using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Consultas
{
    public partial class cCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid(" 1=1 ");

            if (ConsultaGridView.Rows.Count == 0)
            {
                Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "Error");
            }
        }

        public void Limpiar()
        {
            CodigoTextBox.Text = "";
            ConsultaGridView.DataSource = string.Empty;
        }

        void LlenarGrid(string Condicion)
        {
            Categorias Categoria = new Categorias();

            ConsultaGridView.DataSource = Categoria.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Condiciones = "";

            if (CodigoTextBox.Text.Length > 0)
            {
                if (CategoriaDropDownList.SelectedIndex == 0)
                {
                    if (Seguridad.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = CategoriaDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                    }
                }

                if (CategoriaDropDownList.SelectedIndex == 1)
                {
                    Condiciones = CategoriaDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (CategoriaDropDownList.SelectedIndex == 2)
                {
                    if (Seguridad.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = CategoriaDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                    }
                }

                LlenarGrid(Condiciones);

                if (ConsultaGridView.Rows.Count == 0)
                {
                    Mensajes.ShowToastr(this.Page, "No hay Registro", "Error", "Error");
                    LlenarGrid(" 1=1 ");
                }

                Limpiar();
            }
            else
            {
                Mensajes.ShowToastr(this.Page, "Ingrese un Caracter Valido", "Error", "Error");
                Limpiar();
            }
        }
    }
}