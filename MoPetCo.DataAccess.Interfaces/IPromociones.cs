using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.DataAccess.Interfaces
{
    public interface IPromociones
    {
        Task<Response<IEnumerable<Promociones>>> GetPromotionsForHomePage();
        Task<Response<IEnumerable<Promociones>>> GetPromotionsForPromotionsPage();
    }
}
