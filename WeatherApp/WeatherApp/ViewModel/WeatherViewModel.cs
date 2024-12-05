using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using System.Windows.Input;
using WeatherApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace WeatherApp.ViewModel
{
    public partial class WeatherViewModel : ObservableObject
    {
        private readonly WeatherService _weatherService;

        public WeatherViewModel()
        {
            _weatherService = new WeatherService();
        }

        [ObservableProperty]
        private double _temperatura;
        [ObservableProperty]
        private double _sensacao;
        [ObservableProperty]
        private double _tempMax;
        [ObservableProperty]
        private double _tempMin;
        [ObservableProperty]
        private double _pressao;
        [ObservableProperty]
        private double _humidade;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private int _visibilidade;
        [ObservableProperty]
        private int _fuso;
        [ObservableProperty]
        private int _nebulosidade;
        [ObservableProperty]
        private int _chuva;
        [ObservableProperty]
        private string _pais;
        [ObservableProperty]
        private string _nSol;
        [ObservableProperty]
        private string _pSol;
        [ObservableProperty]
        private double _Vento;
        [ObservableProperty]
        private string _Direcao;
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _nuvens;
        [ObservableProperty]
        private string _descricao;
        [ObservableProperty]
        private string _icone;

        private string GetWindDirection(double degrees)
        {
            var directions = new Dictionary<(int, int), string>
            {
                {(0, 45), "Norte"},
                {(45, 90), "Nordeste"},
                {(90, 135), "Leste"},
                {(135, 180), "Sudeste"},
                {(180, 225), "Sul"},
                {(225, 270), "Sudoeste"},
                {(270, 315), "Oeste"},
                {(315, 360), "Noroeste"}
            };

            foreach (var direction in directions)
            {
                if (degrees >= direction.Key.Item1 && degrees < direction.Key.Item2)
                    return direction.Value;
            }

            return "?";
        }

        [RelayCommand]
        public async Task LoadCityWeather(string cityName)
        {
            try
            {
                var data = await _weatherService.GetWeatherResponse(cityName);

                if (data != null)
                {
                    Temperatura = data.main.temp - 273.15;
                    Sensacao = data.main.feels_like - 273.15;
                    TempMax = data.main.temp_max - 273.15;
                    TempMin = data.main.temp_min - 273.15;
                    Pressao = data.main.pressure;
                    Humidade = data.main.humidity;

                    Name = data.name;
                    Visibilidade = data.visibility / 1000;
                    Fuso = data.timezone / 3600;

                    Nebulosidade = data.clouds.all;

                    if (data.rain != null && data.rain.OneHour > 0)
                    {
                        Chuva = (int)data.rain.OneHour;
                    }
                    else
                    {
                        Chuva = 0;
                    }

                    Pais = data.sys.country;

                    int NascerH = (data.sys.sunrise / 3600) % 24;
                    int NascerM = (data.sys.sunrise % 3600) / 60;

                    int PorH = (data.sys.sunset / 3600) % 24;
                    int PorM = (data.sys.sunset % 3600) / 60;

                    NSol = $"{NascerH:D2}:{NascerM:D2}";
                    PSol = $"{PorH:D2}:{PorM:D2}";


                    Vento = data.wind.speed;
                    Direcao = GetWindDirection(data.wind.deg);

                    var clima = data.weather[0];

                    Id = clima.id;

                    Nuvens = clima.main;

                    Descricao = clima.description;

                    Icone = $"https://openweathermap.org/img/wn/{clima.icon}@2x.png";


                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Clima não encontrado", "ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Erro ao carregar dados: {ex.Message}", "ok");
            }
        }
    }
}
