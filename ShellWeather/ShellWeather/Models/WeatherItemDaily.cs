using System.Dynamic;

namespace ShellWeather.Models
{
    public class WeatherItemDaily
    {
        public string Day { get; set; }
        public double TemperatureHigh { get; set; }
        public double TemperatureLow { get; set; }
        public double PrecipitationChance { get; set; }
        public double WindSpeed { get; set; }
        public string Summary { get; set; }
    }
}