﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rPaises : System.Web.UI.Page
    {
        Paises Pais = new Paises();

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
            PaisIdTextBox.Text = "";
            DescripcionTextBox.Text = "";
            ValidacionLimpiar();

        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (DescripcionTextBox.Text.Length > 0)
            {
                Pais.Descripcion = DescripcionTextBox.Text;
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
            if (PaisIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    Pais.PaisId = Seguridad.ValidarEntero(PaisIdTextBox.Text);

                    if (Pais.Editar())
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
                    if (Pais.Insertar())
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
            if (PaisIdTextBox.Text.Length > 0)
            {
                if (Seguridad.ValidarEntero(PaisIdTextBox.Text) > 0)
                {
                    Pais.PaisId = Seguridad.ValidarEntero(PaisIdTextBox.Text);

                    if (Pais.Eliminar())
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
            int Id = Seguridad.ValidarEntero(PaisIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (Pais.Buscar(Id))
                {
                    EliminarButton.Visible = true;
                    DescripcionTextBox.Text = Pais.Descripcion;
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