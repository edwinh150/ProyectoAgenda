using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rTipoCategorias : System.Web.UI.Page
    {
        TipoCategorias TipoCategoria = new TipoCategorias();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EliminarButton.Visible = false;
            }
        }

        public void ValidacionLimpiar()
        {
            RequiredFieldValidator1.IsValid = true;
        }

        public void Limpiar()
        {
            TipoCategoriaIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            ValidacionLimpiar();
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (DescripcionTextBox.Text.Length > 0)
            {
                TipoCategoria.Descripcion = DescripcionTextBox.Text;
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
            if (TipoCategoriaIdTextBox.Text.Length > 0)
            { 
                if (LLenarDatos())
                {
                    TipoCategoria.TipoCategoriaId = Seguridad.ValidarEntero(TipoCategoriaIdTextBox.Text);

                    if (TipoCategoria.Editar())
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
                    if (TipoCategoria.Insertar())
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
            if (TipoCategoriaIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(TipoCategoriaIdTextBox.Text) > 0)
                {
                    TipoCategoria.TipoCategoriaId = Seguridad.ValidarEntero(TipoCategoriaIdTextBox.Text);

                    if (TipoCategoria.Eliminar())
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
            int Id = Seguridad.ValidarEntero(TipoCategoriaIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (TipoCategoria.Buscar(Id))
                {
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = TipoCategoria.Descripcion;
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