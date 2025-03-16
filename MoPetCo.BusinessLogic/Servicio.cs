using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.DataAccess.Interfaces;
using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoPetCo.BusinessLogic
{
    public class Servicio : Interfaces.IServicio
    {
        private readonly DataAccess.Interfaces.IServicio? servicio;

        public Servicio(DataAccess.Interfaces.IServicio? servicio)
        {
            this.servicio = servicio;
        }

        public async Task<Response<IEnumerable<Models.Servicio>>> GuardarServioAsync(Models.Servicio servicio)
        {
            return await this.servicio.GuardarServioAsync(servicio);
        }

        public async Task<Response<IEnumerable<Models.Servicio>>> ObtenerServiciosAsync()
        {
            return await this.servicio.ObtenerServiciosAsync();
        }
    }
}
