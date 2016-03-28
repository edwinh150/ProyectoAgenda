using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace BLL
{
    public class EnvioCorreo
    {
        public static Boolean EnviarCorreo(string PersonaEnvia, string Asunto, string Email, string Nombre, string DireccionArchivo, string CuerpoBoby)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("proyectoagencia2410@gmail.com", "Proyecto Agencia de viajes", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = Asunto;
                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = CuerpoBoby;
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add(Email);
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                if (DireccionArchivo.Length > 0)
                {
                    mail.Attachments.Add(new Attachment(@"" + DireccionArchivo));
                }
                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("proyectoagencia2410@gmail.com", "24102410..");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }
    }
}
