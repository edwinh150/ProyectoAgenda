using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Consultas
{
    public partial class cSolicitudes : System.Web.UI.Page
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
            Solicitudes Solicitud = new Solicitudes();

            ConsultaGridView.DataSource = Solicitud.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Condiciones = "";

            if (CodigoTextBox.Text.Length > 0)
            {
                if (SolicitudesDropDownList.SelectedIndex == 0)
                {
                    if (Seguro.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = SolicitudesDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                    }

                }

                if (SolicitudesDropDownList.SelectedIndex == 1)
                {
                    Condiciones = SolicitudesDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (SolicitudesDropDownList.SelectedIndex == 2)
                {
                    Condiciones = SolicitudesDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (SolicitudesDropDownList.SelectedIndex == 3)
                {
                    if (Seguro.ValidarEntero(CodigoTextBox.Text) == 0)
                    {
                        Condiciones = " 1=1 ";
                    }
                    else
                    {
                        Condiciones = SolicitudesDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
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