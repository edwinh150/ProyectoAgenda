using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public static class Seguridad
    {
        public static int ValidarEntero(string Convertir)
        {
            int Id = 0;

            if (Convertir.Length > 0)
            {
                bool Resultado = Int32.TryParse(Convertir, out Id);

            }

            return Id;
        }

        public static double ValidarDouble(string Convertir)
        {
            double Id = 0;

            if (Convertir.Length > 0)
            {
                bool Resultado = double.TryParse(Convertir, out Id);

            }

            return Id;
        }

        public static DateTime ValidarDateTime(string Convertir)
        {
            DateTime fecha = DateTime.Now;

            if (Convertir.Length > 0)
            {
                bool Resultado = DateTime.TryParse(Convertir, out fecha);

            }

            return fecha;
        }

        public static int ValidarBit(string Convertir)
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

        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
