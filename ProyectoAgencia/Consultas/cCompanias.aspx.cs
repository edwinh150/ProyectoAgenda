using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Consultas
{
    public partial class cCompanias : System.Web.UI.Page
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
            ValidacionLimpiar();
        }

        void LlenarGrid(string Condicion)
        {
            Companias Compania = new Companias();

            ConsultaGridView.DataSource = Compania.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();
        }

        public void ValidacionLimpiar()
        {
            CodigoDiv.Attributes.Remove("class");
            CodigoDiv.Attributes.Add("class", "col-lg-4 col-md-4");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            ValidacionLimpiar();
            bool retorno = true;
            string Condiciones = "";

            if (CodigoTextBox.Text.Length > 0)
            {
                if (CompaniaDropDownList.SelectedIndex == 0)
                {
                    if (!Seguridad.ValidarSoloNumero(CodigoTextBox.Text))
                    {
                        Mensajes.ShowToastr(this, "Error", "Consulta Invalida", "Error");
                        CodigoDiv.Attributes.Add("class", " col-lg-4 col-md-4 has-error ");
                        retorno = false;
                    }

                    if (retorno)
                    {
                        if (Seguridad.ValidarEntero(CodigoTextBox.Text) == 0)
                        {
                            Condiciones = " 1=1 ";
                        }
                        else
                        {
                            Condiciones = CompaniaDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                        }
                    }
                }

                if (CompaniaDropDownList.SelectedIndex == 1)
                {
                    if (!Seguridad.ValidarNombre(CodigoTextBox.Text))
                    {
                        Mensajes.ShowToastr(this, "Error", "Consulta Invalida", "Error");
                        CodigoDiv.Attributes.Add("class", " col-lg-4 col-md-4 has-error ");
                        retorno = false;
                    }

                    if (retorno)
                    {
                        Condiciones = CompaniaDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                    }
                }

                if (CompaniaDropDownList.SelectedIndex == 2)
                {
                    if (!Seguridad.ValidarSoloNumero(CodigoTextBox.Text))
                    {
                        Mensajes.ShowToastr(this, "Error", "Consulta Invalida", "Error");
                        CodigoDiv.Attributes.Add("class", " col-lg-4 col-md-4 has-error ");
                        retorno = false;
                    }

                    if (retorno)
                    {
                        if (Seguridad.ValidarEntero(CodigoTextBox.Text) == 0)
                        {
                            Condiciones = " 1=1 ";
                        }
                        else
                        {
                            Condiciones = CompaniaDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                        }
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