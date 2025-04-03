using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;
using System.Net.Http;
using System.Text.Json;

namespace MoPetCo.BusinessLogic
{
    public class GoogleService : IGoogleService
    {
        private readonly MoPetCo.Extensions.CustomValuesConfiguration _customValuesConfiguration;
        private readonly HttpClient _httpClient;

        public GoogleService(MoPetCo.Extensions.CustomValuesConfiguration customValuesConfiguration, HttpClient httpClient)
        {
            _customValuesConfiguration = customValuesConfiguration;
            _httpClient = httpClient;
        }

        public async Task<Response<string>> ObtenerReviewsAsync(string placeId)
        {
            var configGoogleMaps = _customValuesConfiguration.GetCustomValueByName("GoogleMaps");
            
            var apiKey = configGoogleMaps.Values["apiKey"];
            var urlApi = configGoogleMaps.Values["apiUrl"];

            var response = await _httpClient.GetAsync($"{urlApi}{placeId}&fields=name,rating,reviews&key={apiKey}");

            if (!response.IsSuccessStatusCode)
                return new Response<string>
                {
                     IsSuccess = false,
                    Message = "Error al consumir la API de Google",
                    Content = null
                };

            var json = await response.Content.ReadAsStringAsync();
            
            return new Response<string>
            {
                IsSuccess = true,
                Message = "Reviews obtenidas correctamente",
                Content = json
            };
        }

        public async Task<Response<bool>> VerificarCaptchaAsync(string token)
        {
            var configCaptcha = _customValuesConfiguration.GetCustomValueByName("GoogleCaptcha");

            var secretKey = configCaptcha.Values["secretKey"];
            var apiUrl = configCaptcha.Values["apiUrl"];

            using var httpClient = new HttpClient();
            var response = await _httpClient.PostAsync($"{apiUrl}{secretKey}&response={token}", null);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var captchaResult = JsonSerializer.Deserialize<CaptchaResponse>(responseContent);
                if (captchaResult.success == true)
                    return new Response<bool>
                    {
                        IsSuccess = true,
                        Message = "Validacion exitosa",
                        Content = true
                    };
            }

            return new Response<bool>
            {
                IsSuccess = false,
                Message = $"Error al consumir la API de Google: {response.Content}",
                Content = false
            };
        }
    }
}
