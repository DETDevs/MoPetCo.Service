using Microsoft.AspNetCore.Mvc;
using MoPetCo.BusinessLogic.Interfaces;

namespace MoPetCo.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PromocionesController : Controller
    {
        private readonly IPromociones promociones;

        public PromocionesController(IPromociones promociones)
        {
            this.promociones = promociones;
        }

        [HttpGet(Name = "ObtenerPromocionesHome")]
        public IActionResult ObtenerPromocionesHome()
        {
            try
            {
                var resultado = promociones.GetPromotionsForHomePage();

                if (!resultado.Result.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Result.Content);

                return Ok(resultado.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(Name = "ObtenerPromociones")]
        public IActionResult ObtenerPromociones()
        {
            try
            {
                var resultado = promociones.GetPromotionsForPromotionsPage();

                if (!resultado.Result.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Result.Content);

                return Ok(resultado.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
