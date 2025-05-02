using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.BusinessLogic
{
    public class Promociones : IPromociones
    {
        private readonly DataAccess.Interfaces.IPromociones? promociones;

        public Promociones(DataAccess.Interfaces.IPromociones? promociones)
        {
            this.promociones = promociones;
        }

        public async Task<Response<IEnumerable<Models.Promociones>>> GetPromotionsForHomePage() => await promociones.GetPromotionsForHomePage();

        public async Task<Response<IEnumerable<Models.Promociones>>> GetPromotionsForPromotionsPage() => await promociones.GetPromotionsForPromotionsPage();
    }
}
