﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia.Registros
{
    public partial class rCategoriaCruceros : System.Web.UI.Page
    {
        CategoriaCruceros CategoriaCrucero = new CategoriaCruceros();
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
                CategoriaCrucero.Descripcion = DescripcionTextBox.Text;
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
            if (CategoriaCruceroIdTextBox.Text.Length > 0)
            {
                if (LLenarDatos())
                {
                    CategoriaCrucero.CategoriaCruceroId = Seguro.ValidarEntero(CategoriaCruceroIdTextBox.Text);

                    if (CategoriaCrucero.Editar())
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
                    if (CategoriaCrucero.Insertar())
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
            if (CategoriaCruceroIdTextBox.Text.Length > 0)
            {
                if (Seguro.ValidarEntero(CategoriaCruceroIdTextBox.Text) > 0)
                {
                    CategoriaCrucero.CategoriaCruceroId = Seguro.ValidarEntero(CategoriaCruceroIdTextBox.Text);

                    if (CategoriaCrucero.Eliminar())
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
            int Id = Seguro.ValidarEntero(CategoriaCruceroIdTextBox.Text);
            ValidacionLimpiar();

            if (Id > 0)
            {
                if (CategoriaCrucero.Buscar(Id))
                {
                    DescripcionTextBox.Text = CategoriaCrucero.Descripcion;
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