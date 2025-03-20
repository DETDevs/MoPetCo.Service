using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.DataAccess.Interfaces
{
    public interface IServicio
    {
        Task<Response<Models.Servicio>> GuardarServioAsync(Models.Servicio servicio);
        Task<Response<Models.RangoPeso>> GuardarRangoPesoAsync(Models.RangoPeso rangoPeso);
        Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosAsync();
    }
}
