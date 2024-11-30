using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private HttpClient _httpClient;
        public string apiKey = "f40c0da49722fc1b0a22640e8425303d";

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
        }

        public async Task<WeatherAppMainModel> GetWeatherResponse(string cityName)
        {
            try
            {
                string requestUrl = $"weather?q={cityName}&appid={apiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("Res:" + json);

                    var weatherResponse = JsonSerializer.Deserialize<WeatherAppMainModel>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (weatherResponse != null)
                    {
                        return weatherResponse;
                    }

                    throw new Exception("Null response");
                }

                throw new Exception($"Loading error:{response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new Exception("Request error", ex);
            }
        }
    }
}
