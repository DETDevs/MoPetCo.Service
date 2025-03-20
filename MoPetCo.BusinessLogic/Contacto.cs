using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;

namespace MoPetCo.BusinessLogic
{
    public class Contacto : IContacto
    {
        private readonly DataAccess.Interfaces.IContacto? contacto;
        private readonly MoPetCo.BusinessLogic.EmailService? emailService;
        public Contacto(DataAccess.Interfaces.IContacto? contacto, BusinessLogic.EmailService? emailService)
        {
            this.contacto = contacto;
            this.emailService = emailService;
        }

        public async Task<Response<Models.Contacto>> EnviarEmailAsync(Models.Contacto contacto)
        {
            var emailService = new EmailService();
            await emailService.EnviarCorreoAsync(
                "at2899743@gmail.com",
                "MoPetCo",
                "De: " + contacto.Correo +" "+
                "Mensaje: " + contacto.Mensaje
            );

            return await this.contacto.GuardarContactoAsync(contacto);
        }
    }
}
