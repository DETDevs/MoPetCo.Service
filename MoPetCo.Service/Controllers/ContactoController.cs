using Microsoft.AspNetCore.Mvc;
using MoPetCo.BusinessLogic.Extensions;
using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;

namespace MoPetCo.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ContactoController : Controller
    {
        public readonly IContacto contacto;
        public readonly CodeStorage codeStorage;
        public ContactoController(IContacto contacto, CodeStorage codeStorage)
        {
            this.contacto = contacto;
            this.codeStorage = codeStorage;
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("send-code")]
        public async Task<IActionResult> SendCode([FromBody] string email)
        {
            var code = new Random().Next(100000, 999999).ToString();
            codeStorage.SaveCode(email, code);
            await contacto.SendValidationCodeAsync(email, code);
            return Ok("Código enviado.");
        }

        [HttpPost("validate-code")]
        public IActionResult ValidateCode([FromBody] ValidateRequest request)
        {
            if (codeStorage.ValidateCode(request.Email, request.Code))
                return Ok("Código válido.");
            else
                return BadRequest("Código inválido.");
        }
    }
    
    public record ValidateRequest(string Email, string Code);

}
