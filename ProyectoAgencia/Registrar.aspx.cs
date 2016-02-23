using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia
{
    public partial class Registrar : System.Web.UI.Page
    {
        Usuarios Usuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyyMMdd");
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
                Usuario.TipoUsuarioId = 2;
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
    }
}