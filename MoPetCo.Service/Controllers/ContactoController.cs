using Microsoft.AspNetCore.Mvc;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;

namespace MoPetCo.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ContactoController : Controller
    {
        public readonly IContacto contacto;

        public ContactoController(IContacto contacto)
        {
            this.contacto = contacto;
        }

        [HttpPost(Name = "EnviarEmail")]
        public async Task<IActionResult> EnviarEmail([FromBody] Contacto contacto)
        {
            try
            {
                var resultado = await this.contacto.EnviarEmailAsync(contacto);

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
