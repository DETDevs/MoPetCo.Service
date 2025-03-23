using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace MoPetCo.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleMapsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public GoogleMapsController(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        [HttpGet("reviews")]
        public async Task<IActionResult> GetReviews([FromQuery] string placeId)
        {
            string apiKey = _config["GoogleMaps:ApiKey"];
            string url = $"https://maps.googleapis.com/maps/api/place/details/json?place_id={placeId}&fields=name,rating,reviews&key={apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al consumir la API de Google");

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }
    }
}
