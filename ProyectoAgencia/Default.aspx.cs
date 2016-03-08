using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAgencia
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CruceroButton_Click(object sender, EventArgs e)
        {

        }

        protected void VueloButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PeticionVuelos.aspx");
        }

        protected void HotelResortButton_Click(object sender, EventArgs e)
        {

        }
    }
}