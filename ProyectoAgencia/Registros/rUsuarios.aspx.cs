﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ProyectoAgencia.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();
        Seguridad Seguro = new Seguridad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LlenarDropDownList();
                FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
            }        
        }

        public void LlenarDropDownList()
        {
            TipoUsuarios TipoUsuario = new TipoUsuarios();
            TipoUsuarioDropDownList.DataSource = TipoUsuario.Listado(" * ", "1=1", "TipoUsuarioId");
            TipoUsuarioDropDownList.DataTextField = "Descripcion";
            TipoUsuarioDropDownList.DataValueField = "TipoUsuarioId";
            TipoUsuarioDropDownList.DataBind();
        }

        public void Limpiar()
        {
            NombreTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
        }

        bool LLenarDatos()
        {
            bool retorno = false;

            if (NombreTextBox.Text.Length > 0 && ContrasenaTextBox.Text.Length > 0)
            {
                Usuario.Nombre = NombreTextBox.Text;
                Usuario.Contrasena = ContrasenaTextBox.Text;
                Usuario.FechaNacimiento = Convert.ToDateTime(FechaNacimientoTextBox.Text);
                Usuario.TipoUsuarioId = Seguro.ValidarEntero(TipoUsuarioDropDownList.SelectedValue);
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
            if (LLenarDatos())
            {
                if (Usuario.Insertar())
                {
                    Response.Write("<script> alert('Se Guardar'); </script>");
                }
                else
                {
                    Response.Write("<script> alert('Error al Guardar'); </script>");
                }
            }
            else
            {
                Response.Write("<script> alert('Faltan Datos'); </script>");
            }
        }

        protected void ModificarButton_Click(object sender, EventArgs e)
        {
            if (LLenarDatos())
            {
                if (Usuario.Editar(Seguro.ValidarEntero(UsuarioIdTextBox.Text)))
                {
                    Response.Write("<script> alert('Se Modifico'); </script>");
                }
                else
                {
                    Response.Write("<script> alert('Error al Modificar'); </script>");
                }

            }
            else
            {
                Response.Write("<script> alert('Faltan Datos'); </script>");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Seguro.ValidarEntero(UsuarioIdTextBox.Text) > 0)
            {
                if (Usuario.Buscar(Seguro.ValidarEntero(UsuarioIdTextBox.Text)))
                {
                    NombreTextBox.Text = Usuario.Nombre;
                    ContrasenaTextBox.Text = Usuario.Contrasena;
                }
                else
                {
                    Response.Write("<script> Alert('No hay Registro') </script>");
                }
            }
            else
            {
                Response.Write("<script> Alert('Error ingrese un dato valido') </script>");
            }
        }
    }
}