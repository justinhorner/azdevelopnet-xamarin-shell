using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using DarkSky.Models;
using ShellWeather.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellWeather.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private string apiKey = "";
        private DarkSky.Services.DarkSkyService darkSkyService;
        public Command GetForecastCommand { get; set; }
        public Command GetLocationCommand { get; set; }
        
        #region Properties
        public Forecast Forecast { get; set; }
        
        public ObservableCollection<WeatherItemDaily> DailyItems { get; set; }

        
        private Location _location { get; set; } = new Location(43.6023614,-110.8444802);

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

        private string _currentGeo { get; set; }

        public string CurrentGeo
        {
            get => _currentGeo ?? $"Location: {_location.Latitude}, {_location.Longitude}";
            set
            {
                _currentGeo = value;
                OnPropertyChanged(nameof(CurrentGeo));
            }
        }

        #endregion

        public WeatherViewModel()
        {
            Title = "Weather";
            darkSkyService = new DarkSky.Services.DarkSkyService(apiKey);
            GetForecastCommand = new Command(async () => await ExecuteGetForecastCommandAsync());
            GetLocationCommand = new Command(async () => await ExecuteGetLocationCommandAsync());
            DailyItems = new ObservableCollection<WeatherItemDaily>();
        }

        private async Task ExecuteGetForecastCommandAsync()
        {
            var result = await darkSkyService.GetForecast(_location.Latitude, _location.Longitude);

            if (result.IsSuccessStatus)
            {
                Forecast = result.Response;
                
                //set properties for current info
                var fahrenheitTemp = Math.Round(Forecast?.Currently?.Temperature ?? 0);
                var celsiusTemp = Math.Round((fahrenheitTemp - 32) / 1.8);
                Summary = Forecast?.Minutely?.Summary ?? "Unknown";
                CurrentTemp = $"{fahrenheitTemp} ℉ ({celsiusTemp} ℃)";
                LastUpdated = $"Last updated: {Forecast?.Currently?.DateTime.ToString("MM/dd h:mm:ss tt zz") ?? string.Empty}";
                
                DailyItems.Clear();
                //set properties for forecastdaily
                Forecast.Daily.Data.ForEach(d => 
                    DailyItems.Add(new WeatherItemDaily
                    {
                        //we should be null checking these values...
                       Day = d.DateTime.Date.ToString("D"),
                       TemperatureHigh = Math.Round(d.ApparentTemperatureHigh.Value),
                       TemperatureLow = Math.Round(d.ApparentTemperatureLow.Value),
                       PrecipitationChance = Math.Round(d.PrecipProbability.Value),
                       WindSpeed = Math.Round(d.WindSpeed.Value),
                       Summary = d.Summary
                    }));
            }
        }

        private async Task ExecuteGetLocationCommandAsync()
        {
            _location = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync();
            await ExecuteGetForecastCommandAsync();
            CurrentGeo = $"Location: {_location.Latitude}, {_location.Longitude}";
        }
    }
}
