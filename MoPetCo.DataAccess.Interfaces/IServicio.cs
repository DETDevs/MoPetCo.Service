using MoPetCo.Models;

namespace MoPetCo.DataAccess.Interfaces
{
    public interface IServicio
    {
        Task<Response<Servicio>> GuardarServioAsync(Servicio servicio);
        Task<Response<RangoPeso>> GuardarRangoPesoAsync(RangoPeso rangoPeso);
        Task<Response<Precio>> GuardarPrecioAsync(Precio precio);
        Task<Response<IEnumerable<Servicio>>> ObtenerServiciosAsync();
        Task<Response<IEnumerable<Servicio>>> ObtenerServiciosDetallesAsync();
    }
}
