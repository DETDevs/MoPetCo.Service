using System.Net.Mail;
using System.Net;

namespace MoPetCo.BusinessLogic.Extensions
{
    public class EmailService
    {
        private readonly string smtpServer = "smtp.gmail.com"; // Servidor SMTP (Ej: Gmail)
        private readonly int smtpPort = 587; // Puerto SMTP (587 para TLS)
        private readonly string smtpUser = ""; // Correo remitente
        private readonly string smtpPass = ""; // Contraseña o App Password

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string mensaje)
        {
            try
            {
                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    client.EnableSsl = true;

                    var mail = new MailMessage
                    {
                        From = new MailAddress(smtpUser),
                        Subject = asunto,
                        Body = mensaje,
                        IsBodyHtml = true
                    };
                    mail.To.Add(destinatario);

                    await client.SendMailAsync(mail);
                    Console.WriteLine("Correo enviado correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
