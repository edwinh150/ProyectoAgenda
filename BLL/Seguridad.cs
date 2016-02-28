using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Seguridad
    {
        public int ValidarEntero(string Convertir)
        {
            int Id = 0;

            if (Convertir.Length > 0)
            {
                bool Resultado = Int32.TryParse(Convertir, out Id);

            }

            return Id;
        }

        /*public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
        */
    }
}
