using MoPetCo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.BusinessLogic.Interfaces
{
    public interface IGoogleService
    {
        Task<Response<bool>> VerificarCaptchaAsync(string token);
        Task<Response<string>> ObtenerReviewsAsync(string placeId);
    }
}
