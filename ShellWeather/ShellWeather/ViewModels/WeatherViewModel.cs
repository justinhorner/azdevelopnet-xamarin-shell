using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShellWeather.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private string apiKey = "";
        private DarkSky.Services.DarkSkyService darkSkyService;
        public Command GetForecastCommand { get; set; }

        public WeatherViewModel()
        {
            Title = "Weather";
            darkSkyService = new DarkSky.Services.DarkSkyService(apiKey);
            GetForecastCommand = new Command(async () => await ExecuteGetForecastCommandAsync());
        }

        private async Task ExecuteGetForecastCommandAsync()
        {
            var coords = (0.0, 0.0);
            var forecast = await darkSkyService.GetForecast(coords.Item1, coords.Item2);
        }
    }
}
