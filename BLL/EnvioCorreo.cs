using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace BLL
{
    public class EnvioCorreo
    {
        public static Boolean EnviarCorreo()
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("edwinh2410@gmail.com", "Edwin Hidalgo Agencia de viajes", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = "Prueba de Envío de Correo";
                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = "Prueba de Envío de Correo de Gmail desde CSharp";
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add("tj_razine@hotmail.es");
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                mail.Attachments.Add(new Attachment(@"E:\Diccionario de datos.docx"));

                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("edwinh2410@gmail.com", "contrasena");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
