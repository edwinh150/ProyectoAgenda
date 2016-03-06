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
        Seguridad Seguro = new Seguridad();
        
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
        }

        void LlenarGrid(string Condicion)
        {
            Usuarios Usuario = new Usuarios();

            ConsultaGridView.DataSource = Usuario.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Condiciones = "";

            if (CodigoTextBox.Text.Length > 0)
            {
                if (IngresoDropDownList.SelectedIndex == 0 || IngresoDropDownList.SelectedIndex == 1 || IngresoDropDownList.SelectedIndex == 2 || IngresoDropDownList.SelectedIndex == 3 || IngresoDropDownList.SelectedIndex == 4)
                {
                    if (Seguro.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = IngresoDropDownList.SelectedItem.Text + " = " + CodigoTextBox.Text;
                    }

                }

                if (IngresoDropDownList.SelectedIndex == 1)
                {
                    Condiciones = IngresoDropDownList.SelectedItem.Text + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (IngresoDropDownList.SelectedIndex == 2)
                {
                    Condiciones = IngresoDropDownList.SelectedItem.Text + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (IngresoDropDownList.SelectedIndex == 3)
                {
                    Condiciones = IngresoDropDownList.SelectedItem.Text + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (IngresoDropDownList.SelectedIndex == 4)
                {
                    if (Seguro.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = IngresoDropDownList.SelectedItem.Text + " = " + CodigoTextBox.Text;
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