using MoPetCo.Models;

namespace MoPetCo.BusinessLogic.Interfaces
{
    public interface IContacto
    {
        Task<Response<Contacto>> EnviarEmailAsync(Contacto contacto);
        Task SendValidationCodeAsync(string toEmail, string code);
        Task<ZippopotamResponse?> ValidateZipCodeAsync(string countryCode, string zipCode);
    }
}
