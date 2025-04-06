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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(Name = "Obtener Imaganes")]
        public async Task<IActionResult> ObtenerImagenes()
        {
            try
            {
                var resultado = await _media.ObtenerImagenesAsync();

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(Name = "Obtener Videos")]
        public async Task<IActionResult> ObtenerVideos()
        {
            try
            {
                var resultado = await _media.ObtenerVideoAsync();

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
