using System.Net;
using MimeKit;
using System.Net.Mail;
using SystemSmtpClient = System.Net.Mail.SmtpClient;
using MailKitSmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace MoPetCo.BusinessLogic.Extensions
{
    public class EmailService
    {
        private readonly MoPetCo.Extensions.CustomValuesConfiguration _customValuesConfiguration;

        public EmailService(MoPetCo.Extensions.CustomValuesConfiguration? customValuesConfiguration)
        {
            _customValuesConfiguration = customValuesConfiguration;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string mensaje)
        {
            var EmailConfig = _customValuesConfiguration.GetCustomValueByName("EmailConfiguration");

            var smtpServer = EmailConfig.Values["smtpServer"];
            var smtpPort = EmailConfig.Values["smtpPort"];
            var smtpUser = EmailConfig.Values["smtpUser"];
            var smtpPass = EmailConfig.Values["smtpPass"];


            using (var client = new SystemSmtpClient(smtpServer, Convert.ToInt32(smtpPort)))
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
            }
        }

        public async Task EnviarCorreoConMailKitAsync(string destinatario, string asunto, string mensaje)
        {
            var EmailConfig = _customValuesConfiguration.GetCustomValueByName("MailKit");

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("MoPetCo", EmailConfig.Values["smtpUser"]));
            email.To.Add(MailboxAddress.Parse(destinatario));
            email.Subject = asunto;

            var builder = new BodyBuilder
            {
                HtmlBody = mensaje
            };
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKitSmtpClient();
            await smtp.ConnectAsync(EmailConfig.Values["smtpServer"], Convert.ToInt32(EmailConfig.Values["smtpPort"]), MailKit.Security.SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync(EmailConfig.Values["smtpUser"], EmailConfig.Values["smtpPass"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
