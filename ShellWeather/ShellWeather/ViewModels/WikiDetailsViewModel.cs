using System;
using Xamarin.Forms;

namespace ShellWeather.ViewModels
{
    [QueryProperty("Url", "url")]
    public class WikiDetailsViewModel : BaseViewModel 
    {
        private string _url { get; set; }
        public string Url
        {
            get => _url;
            set
            {
                // set the title & our webview source using the passed url parameter
                this.Title = Uri.UnescapeDataString(value).Replace("/wiki/", string.Empty);
                _url = $"https://en.wikipedia.org{value}";
                OnPropertyChanged(nameof(Url));
                OnPropertyChanged(nameof(Title));
            }
        }

        public Command OpenInExternalBrowserCommand { get; set; }

        public WikiDetailsViewModel()
        {
            OpenInExternalBrowserCommand = new Command(async () => await Xamarin.Essentials.Browser.OpenAsync(new Uri(Url), Xamarin.Essentials.BrowserLaunchMode.External));
        }
    }
}