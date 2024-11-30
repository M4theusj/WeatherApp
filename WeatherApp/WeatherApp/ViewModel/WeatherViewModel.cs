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
        private ObservableCollection<WeatherAppMainModel> _weather;
        [ObservableProperty]
        private MainModel _mainModel;
        [ObservableProperty]
        private WindModel _windModel;
        [ObservableProperty]
        private CloudsModel _cloudModel;
        [ObservableProperty]
        private RainModel _rainModel;
        [ObservableProperty]
        private SysModel _sysModel;
        [ObservableProperty]
        private WeatherModel _weatherModel;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string _visibility;

        [RelayCommand]
        public async Task LoadCityWeather(string cityName)
        {
            Debug.WriteLine($"Parâmetro recebido: {cityName}");
            try
            {
                var data = await _weatherService.GetWeatherResponse(cityName);

                if (data != null)
                {
                    MainModel = data.main;
                    WindModel = data.wind;
                    CloudModel = data.clouds;
                    Name = data.name;

                    await Application.Current.MainPage.DisplayAlert("Weather", $"Cidade: {data.name}, Clima: {data.weather.FirstOrDefault()?.description}", "ok");
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
