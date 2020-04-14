using System;
using System.Threading.Tasks;
using DarkSky.Models;
using Xamarin.Forms;

namespace ShellWeather.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private string apiKey = "";
        private DarkSky.Services.DarkSkyService darkSkyService;
        public Command GetForecastCommand { get; set; }
        
        public Forecast Forecast { get; set; }

        private string _currentTemp { get; set; }
        public string CurrentTemp
        {
            get => _currentTemp;
            set
            {
                _currentTemp = value;
                OnPropertyChanged(nameof(CurrentTemp));
            }
        }

        private string _lastUpdated { get; set; }
        public string LastUpdated
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                OnPropertyChanged(nameof(LastUpdated));
            }
        }
        
        private string _summary { get; set; }
        public string Summary
        {
            get => _summary;
            set
            {
                _summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }

        public WeatherViewModel()
        {
            Title = "Weather";
            darkSkyService = new DarkSky.Services.DarkSkyService(apiKey);
            GetForecastCommand = new Command(async () => await ExecuteGetForecastCommandAsync());
        }

        private async Task ExecuteGetForecastCommandAsync()
        {
            var coords = (0.0, 0.0);
            var result = await darkSkyService.GetForecast(coords.Item1, coords.Item2);

            if (result.IsSuccessStatus)
            {
                Forecast = result.Response;
                var fahrenheitTemp = Math.Round(Forecast?.Currently?.Temperature ?? 0);
                var celsiusTemp = Math.Round((fahrenheitTemp - 32) / 1.8);
                Summary = Forecast?.Minutely?.Summary ?? "Unknown";
                CurrentTemp = $"{fahrenheitTemp} ℉ ({celsiusTemp} ℃)";
                LastUpdated = $"Last updated: {Forecast?.Currently?.DateTime.ToString("G") ?? string.Empty}";
            }
        }
    }
}
