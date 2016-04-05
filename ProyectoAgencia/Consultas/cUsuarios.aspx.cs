using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProyectoAgencia.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
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

        public void ValidacionLimpiar()
        {
            CodigoDiv.Attributes.Remove("class");
            CodigoDiv.Attributes.Add("class", "col-lg-4 col-md-4");
        }

        void LlenarGrid(string Condicion)
        {
            Usuarios Usuario = new Usuarios();

            ConsultaGridView.DataSource = Usuario.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            ValidacionLimpiar();
            string Condiciones = "";
            bool retorno = true;

            if (CodigoTextBox.Text.Length > 0)
            {
                if (UsuarioDropDownList.SelectedIndex == 0)
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
                            Condiciones = UsuarioDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                        }
                    }
                }

                if (UsuarioDropDownList.SelectedIndex == 1)
                {
                    if (!Seguridad.ValidarNombre(CodigoTextBox.Text))
                    {
                        Mensajes.ShowToastr(this, "Error", "Consulta Invalida", "Error");
                        CodigoDiv.Attributes.Add("class", " col-lg-4 col-md-4 has-error ");
                        retorno = false;
                    }

                    if (retorno)
                    {
                        Condiciones = UsuarioDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                    }
                }

                if (UsuarioDropDownList.SelectedIndex == 2)
                {
                    if (!Seguridad.ValidarNombre(CodigoTextBox.Text))
                    {
                        Mensajes.ShowToastr(this, "Error", "Consulta Invalida", "Error");
                        CodigoDiv.Attributes.Add("class", " col-lg-4 col-md-4 has-error ");
                        retorno = false;
                    }

                    if (retorno)
                    {
                        Condiciones = UsuarioDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                    }
                }

                if (UsuarioDropDownList.SelectedIndex == 3)
                {
                    Condiciones = UsuarioDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (UsuarioDropDownList.SelectedIndex == 4)
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
                            Condiciones = UsuarioDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
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