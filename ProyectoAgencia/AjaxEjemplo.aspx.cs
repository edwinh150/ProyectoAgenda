using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace ProyectoAgencia
{
    public partial class AjaxEjemplo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CargarButton_Click(object sender, EventArgs e)
        {
            StreamReader myfile = new StreamReader(@"C:\\Users\\Darlenis Mora\\Desktop\\mi proyecto.txt");

            CargarTextBox.Text = myfile.ReadLine().ToString();
        }
        [WebMethod]
        public int Multiplicar(string Numero)
        {
            int numero = 0;
            numero = Convert.ToInt32(Numero);

            return numero * 10;
        }

        protected void OperacionButton_Click(object sender, EventArgs e)
        {
           MultiplicacionLabel.Text = Multiplicar(OperacionTextBox.Text).ToString();


        }
    }
}