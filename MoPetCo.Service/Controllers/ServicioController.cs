using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;

namespace MoPetCo.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServicioController : Controller
    {
        private readonly IServicio servicio;

        public ServicioController(IServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost(Name = "GuardarServicio")]
        public async Task<IActionResult> Guardar([FromBody] Servicio servicio)
        {
            try
            {
                var resultado = await this.servicio.GuardarServioAsync(servicio);

                if (!resultado.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado.Message);

            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet(Name = "ObtenerServicio")]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                var resultado = await this.servicio.ObtenerServiciosAsync();

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost(Name = "GuardarRangoPeso")]
        public async Task<IActionResult> GuardarRangoPeso([FromBody] RangoPeso rangoPeso)
        {
            try
            {
                var resultado = await this.servicio.GuardarRangoPesoAsync(rangoPeso);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost(Name = "GuardarPrecio")]
        public async Task<IActionResult> GuardarPrecio([FromBody] Precio precio)
        {
            try
            {
                var resultado = await this.servicio.GuardarPrecioAsync(precio);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
