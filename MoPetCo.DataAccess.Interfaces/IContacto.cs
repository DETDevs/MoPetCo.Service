using MoPetCo.Models;

namespace MoPetCo.DataAccess.Interfaces
{
    public interface IContacto
    {
        Task<Response<Models.Contacto>> GuardarContactoAsync(Models.Contacto contacto );

    }
}
