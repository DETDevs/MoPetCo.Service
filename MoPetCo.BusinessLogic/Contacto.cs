using MoPetCo.BusinessLogic.Extensions;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;

namespace MoPetCo.BusinessLogic
{
    public class Contacto : IContacto
    {
        private readonly DataAccess.Interfaces.IContacto? contacto;
        private readonly EmailService? emailService;
        public Contacto(DataAccess.Interfaces.IContacto? contacto, EmailService? emailService)
        {
            this.contacto = contacto;
            this.emailService = emailService;
        }

        public async Task<Response<Models.Contacto>> EnviarEmailAsync(Models.Contacto contacto)
        {
            string mensaje = $@"
             <div style='font-family: Arial, sans-serif; color: #4A004A;'>
                 <p>Una persona ha enviado la siguiente información:</p>

                 <p><strong>Email Address:</strong> {contacto.Correo}</p>
                 <p><strong>Your Question:</strong> {contacto.Mensaje}</p>
                 <p><strong>Address:</strong> {contacto.Direccion}</p>
                 <p><strong>City:</strong> {contacto.Ciudad}</p>
                 <p><strong>Zip Code:</strong> {contacto.CodigoPostal}</p>
                 <p><strong>Phone Number:</strong> {contacto.Number}</p>
             </div>";

            var emailService = new EmailService();
            await emailService.EnviarCorreoAsync(
                "at2899743@gmail.com",
                "MoPetCo",
                mensaje
            );

            return await this.contacto.GuardarContactoAsync(contacto);
        }
    }
}
