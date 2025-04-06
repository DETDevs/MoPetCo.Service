using MoPetCo.BusinessLogic.Interfaces;
using MoPetCo.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
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
            response.EnsureSuccessStatusCode();

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
            var configGoogleCaptcha = _customValuesConfiguration.GetCustomValueByName("GoogleCaptcha");

            var googleUrl = configGoogleCaptcha.Values["apiUrl"];
            var secretKey = configGoogleCaptcha.Values["secretKey"];

            if (string.IsNullOrEmpty(secretKey))
            {
                return new Response<bool>
                {
                    IsSuccess = false,
                    Message = "No se encontró la clave secreta de reCAPTCHA en la configuración",
                    Content = false
                };
            }

            var content = new FormUrlEncodedContent(new[]
            {
                  new KeyValuePair<string, string>("secret", secretKey),
                  new KeyValuePair<string, string>("response", token)
            });

            HttpResponseMessage response;
            response = await _httpClient.PostAsync(googleUrl, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var googleResponse = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(json);

            return new Response<bool>
            {
                IsSuccess = true,
                Message = "Verificación de reCAPTCHA completada correctamente.",
                Content = googleResponse.Success
            };
        }
    }
}
