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

        public double ValidarDouble(string Convertir)
        {
            double Id = 0;

            if (Convertir.Length > 0)
            {
                bool Resultado = double.TryParse(Convertir, out Id);

            }

            return Id;
        }

        public DateTime ValidarDateTime(string Convertir)
        {
            DateTime fecha = DateTime.Now;

            if (Convertir.Length > 0)
            {
                bool Resultado = DateTime.TryParse(Convertir, out fecha);

            }

            return fecha;
        }

        public int ValidarBit(string Convertir)
        {
            int bit = 0;

            if (Convertir.Length > 0)
            {
                if (Convertir == "true")
                {
                    bit = 1;
                }
            }

            return bit;
        }
    }
}
