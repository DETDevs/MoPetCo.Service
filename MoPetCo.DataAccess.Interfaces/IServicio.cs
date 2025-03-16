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
        Task<Response<IEnumerable<Models.Servicio>>> GuardarServioAsync(Models.Servicio servicio);
        Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosAsync();
    }
}
