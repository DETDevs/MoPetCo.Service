using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoPetCo.BusinessLogic.Extensions;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;

namespace MoPetCo.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MediaController : Controller
    {
        private readonly IMedia _media;

        public MediaController(IMedia media)
        {
            _media = media;
        }

        [HttpPost]
        public async Task<IActionResult> GuardarImagen([FromForm] Imagen imagen)
        {
            try
            {
                var result = await _media.GuardarImagenAsync(imagen);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
