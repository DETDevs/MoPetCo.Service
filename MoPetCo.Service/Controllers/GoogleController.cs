using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoPetCo.BusinessLogic;
using MoPetCo.Models;
using System.Net.Http;
using System.Text.Json;

namespace MoPetCo.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GoogleController : Controller
    {

        private readonly IConfiguration _config;
        private readonly GoogleService _googleService;

        public GoogleController(IConfiguration config, GoogleService googleService)
        {
            _config = config;
            _googleService = googleService;
        }

        [HttpPost("verificar-captcha")]
        public async Task<IActionResult> VerificarCaptcha([FromBody] string token)
        {
            var response = await _googleService.VerificarCaptchaAsync(token);

            if (!response.IsSuccess)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(response);
        }

        [HttpGet("reviews")]
        public async Task<IActionResult> GetReviews([FromQuery] string placeId)
        {
            var response = await _googleService.ObtenerReviewsAsync(placeId);

            if (!response.IsSuccess)
                return BadRequest(new { message = response.Message });

            return Ok(response);
        }
    }
}
