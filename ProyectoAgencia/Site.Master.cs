using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia
{
    public partial class Site : System.Web.UI.MasterPage
    {
        Usuarios Usuario = new Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name.Length == 0)
            {
                UsuarioLabel.Text = Context.User.Identity.Name;
                RegistrarseLi.Visible = true;
                LoginUserLi.Visible = true;
                UsuarioLi.Visible = false;
                RegistroLi.Visible = false;
                ConsultaLi.Visible = false;
                
            }
            else
            {
                UsuarioLabel.Text = Context.User.Identity.Name;
                RegistrarseLi.Visible = false;
                LoginUserLi.Visible = false;
                UsuarioLi.Visible = true;
                RegistroLi.Visible = true;
                ConsultaLi.Visible = true;
            }

        }

        protected void IniciarSessionLinkButton_Click(object sender, EventArgs e)
        {
            RegistrarseLi.Visible = false;
            LoginUserLi.Visible = false;
            Response.RedirectPermanent("/Login.aspx");
        }

        protected void CerrarLinkButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            RegistrarseLi.Visible = true;
            LoginUserLi.Visible = true;
            Response.RedirectPermanent("/Login.aspx");
        }
    }
}