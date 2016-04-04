using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            DateTime fecha = Convert.ToDateTime("01/01/0001 00:00:00");

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
                if (Convertir == "True")
                {
                    bit = 1;
                }

                if (Convertir == "False")
                {
                    bit = 0;
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

        public static bool ValidarEmail(string strMailAddress)
        {
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        public static bool ValidarTelefono(string Telefono)
        {
            return Regex.IsMatch(Telefono, @"^[+-]?\d+(\.\d+)?$");
        }

        public static bool ValidarNombre(string Nombre)
        {
            return Regex.IsMatch(Nombre, @"[a-zA-ZñÑ\s]{2,50}");
        }

        public static bool ValidarSoloNumero(string Numero)
        {
            return Regex.IsMatch(Numero, @"[0-9]{1,9}(\.[0-9]{0,2})?$");
        }
    }
}
