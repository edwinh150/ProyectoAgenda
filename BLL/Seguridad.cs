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
            else
            {
                return 0;
            }

            return Id;
        }
    }
}
