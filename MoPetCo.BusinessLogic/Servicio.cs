using MoPetCo.Models;

namespace MoPetCo.BusinessLogic
{
    public class Servicio : Interfaces.IServicio
    {
        private readonly DataAccess.Interfaces.IServicio? servicio;

        public Servicio(DataAccess.Interfaces.IServicio? servicio)
        {
            this.servicio = servicio;
        }

        public async Task<Response<Models.Servicio>> GuardarServioAsync(Models.Servicio servicio)
        {
            return await this.servicio.GuardarServioAsync(servicio);
        }

        public async Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosAsync()
        {
            return await this.servicio.ObtenerServiciosAsync();
        }
        public Task<Response<RangoPeso>> GuardarRangoPesoAsync(RangoPeso rangoPeso)
        {
            return this.servicio.GuardarRangoPesoAsync(rangoPeso);
        }
        public Task<Response<Precio>> GuardarPrecioAsync(Precio precio)
        {
            return this.servicio.GuardarPrecioAsync(precio);
        }

        public Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosDetallesAsync()
        {
            var resultado = this.servicio.ObtenerServiciosDetallesAsync();

            // Agrupar los servicios para evitar duplicados en caso de que haya múltiples precios para el mismo servicio
            var serviciosAgrupados = resultado.Result.Content
                    .GroupBy(s => s.IdServicio)
                    .Select(g =>
                    {
                        var servicio = g.First();
                        servicio.Precio = g.Select(s => s.Precio).SelectMany(p => p).ToList(); // Aplanar la lista de precios
                        return servicio;
                    })
                    .ToList();

            resultado.Result.Content = serviciosAgrupados;

            return resultado;
        }
    }
}
