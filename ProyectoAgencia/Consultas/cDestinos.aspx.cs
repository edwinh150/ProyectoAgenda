using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Consultas
{
    public partial class cDestinos : System.Web.UI.Page
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
            ConsultaGridView.DataSource = string.Empty;
        }

        void LlenarGrid(string Condicion)
        {
            Destinos Destino = new Destinos();

            ConsultaGridView.DataSource = Destino.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Condiciones = "";

            if (CodigoTextBox.Text.Length > 0)
            {
                if (DestinoDropDownList.SelectedIndex == 0)
                {
                    if (Seguro.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = DestinoDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                    }
                }

                if (DestinoDropDownList.SelectedIndex == 1)
                {
                    Condiciones = DestinoDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (DestinoDropDownList.SelectedIndex == 2)
                {
                    if (Seguro.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = DestinoDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
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