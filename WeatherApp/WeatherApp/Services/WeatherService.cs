using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        public string apiKey = "f40c0da49722fc1b0a22640e8425303d";
        private WeatherAppMainModel weatherResponse;
        public async Task<WeatherAppMainModel> GetWeatherResponse(string cityName)
        {
            Uri uri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={cityName}$appid={apiKey}");
            return weatherResponse;
        }
    }
}
