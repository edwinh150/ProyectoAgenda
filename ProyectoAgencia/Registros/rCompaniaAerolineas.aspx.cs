using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rCompaniaAerolineas : System.Web.UI.Page
    {
        CompaniaAerolineas CompaniaAerolinea = new CompaniaAerolineas();
        Seguridad Seguro = new Seguridad();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ValidacionLimpiar()
        {
            RequiredFieldValidator1.IsValid = true;
        }

        public void Limpiar()
        {
            DescripcionTextBox.Text = "";
            ValidacionLimpiar();

        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (DescripcionTextBox.Text.Length > 0)
            {
                CompaniaAerolinea.Descripcion = DescripcionTextBox.Text;
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
            if (CompaniaAerolineaIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    CompaniaAerolinea.CompaniaAerolineaId = Seguro.ValidarEntero(CompaniaAerolineaIdTextBox.Text);

                    if (CompaniaAerolinea.Editar())
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
                    if (CompaniaAerolinea.Insertar())
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
            if (CompaniaAerolineaIdTextBox.Text.Length > 0)
            {
                if (Seguro.ValidarEntero(CompaniaAerolineaIdTextBox.Text) > 0)
                {
                    CompaniaAerolinea.CompaniaAerolineaId = Seguro.ValidarEntero(CompaniaAerolineaIdTextBox.Text);

                    if (CompaniaAerolinea.Eliminar())
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
            int Id = Seguro.ValidarEntero(CompaniaAerolineaIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (CompaniaAerolinea.Buscar(Id))
                {
                    DescripcionTextBox.Text = CompaniaAerolinea.Descripcion;
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