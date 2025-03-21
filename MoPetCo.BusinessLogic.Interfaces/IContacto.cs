using MoPetCo.Models;

namespace MoPetCo.BusinessLogic.Interfaces
{
    public interface IContacto
    {
        Task<Response<Contacto>> EnviarEmailAsync(Contacto contacto);
    }
}
