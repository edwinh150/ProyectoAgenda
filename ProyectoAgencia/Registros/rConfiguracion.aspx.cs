using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rConfiguracion : System.Web.UI.Page
    {
        Configuraciones Configuracion = new Configuraciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (!IsPostBack)
            {
                dt = Configuracion.Listado("*", " 1=1 ", "");

                if (dt.Rows.Count > 0)
                {
                    ConfiguracionTextBox.Text = dt.Rows[0]["Impuesto"].ToString();
                }
                else
                {
                    Mensajes.ShowToastr(this, "Error", "No hay Configuracion", "Error");
                }
            }
        }

        public int Comprobar()
        {
            DataTable dt = new DataTable();

            dt = Configuracion.Listado("*", " 1=1 ", "");

            return Seguridad.ValidarEntero(dt.Rows.Count.ToString());
        }

        public void ValidacionLimpiar()
        {
            ConfiguracionDiv.Attributes.Remove("class");
            ConfiguracionDiv.Attributes.Add("class", "col-md-8");
        }

        bool LLenarDatos()
        {
            bool retorno = true;
            ValidacionLimpiar();

            if (!Seguridad.ValidarSoloNumero(ConfiguracionTextBox.Text))
            {
                Mensajes.ShowToastr(this, "Error", "Descripcion Invalido", "Error");
                ConfiguracionDiv.Attributes.Add("class", " col-md-8 has-error ");
                retorno = false;
            }

            if (retorno)
            {
                Configuracion.Impuesto = Seguridad.ValidarDouble(ConfiguracionTextBox.Text);
            }

            return retorno;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Comprobar() > 0)
            {
                if (LLenarDatos())
                {
                    if (Configuracion.Editar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Modifico", "Informacion", "Success");
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
                    if (Configuracion.Insertar())
                    {
                        Mensajes.ShowToastr(this.Page, "Se Registro", "Felicidades", "Success");
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
    }
}