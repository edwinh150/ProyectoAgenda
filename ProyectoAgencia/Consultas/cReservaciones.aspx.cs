using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Consultas
{
    public partial class cReservaciones : System.Web.UI.Page
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
            Reservaciones Reservacion = new Reservaciones();
            ReservacionDetalleText DetalleText = new ReservacionDetalleText();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            string CondicionDetalle = "";

            ConsultaGridView.DataSource = Reservacion.Listado(" * ", Condicion, "");
            ConsultaGridView.DataBind();

            if (Condicion == " 1=1 ")
            {
                CondicionDetalle = Condicion;
            }
            else
            {
                dt2 = Reservacion.Listado(" * ", Condicion, "");

                if (dt2.Rows.Count > 0)
                {
                    Reservacion.SolicitudId = (int)dt2.Rows[0]["ReservacionId"];

                    CondicionDetalle = " r.ReservacionId = " + Reservacion.SolicitudId;
                }
            }

            dt = DetalleText.Listado(CondicionDetalle);

            if (dt.Rows.Count > 0)
            {
                ConsultaDetalleGridView.DataSource = DetalleText.Listado(CondicionDetalle);
                ConsultaDetalleGridView.DataBind();
            }
            else
            {
                ConsultaDetalleGridView.DataSource = string.Empty;
                ConsultaDetalleGridView.DataBind();
            }
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
                if (ReservacionDropDownList.SelectedIndex == 0)
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
                            Condiciones = ReservacionDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                        }
                    }

                }

                if (ReservacionDropDownList.SelectedIndex == 1)
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
                            Condiciones = ReservacionDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
                        }
                    }
                }

                if (ReservacionDropDownList.SelectedIndex == 2)
                {
                    Condiciones = ReservacionDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                }

                if (ReservacionDropDownList.SelectedIndex == 3)
                {
                    if (!Seguridad.ValidarNombre(CodigoTextBox.Text))
                    {
                        Mensajes.ShowToastr(this, "Error", "Consulta Invalida", "Error");
                        CodigoDiv.Attributes.Add("class", " col-lg-4 col-md-4 has-error ");
                        retorno = false;
                    }

                    if (retorno)
                    {
                        Condiciones = ReservacionDropDownList.SelectedItem.Value + " like '%" + CodigoTextBox.Text + "%' ";
                    }
                }

                if (ReservacionDropDownList.SelectedIndex == 4)
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
                            Condiciones = ReservacionDropDownList.SelectedItem.Value + " = " + CodigoTextBox.Text;
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