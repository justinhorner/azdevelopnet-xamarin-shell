using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShellWeather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace ShellWeather.Views
{
    [QueryProperty("Url", "url")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiDetailsPage : ContentPage
    {
        public WikiDetailsPage()
        {
            InitializeComponent();
            BindingContext = new WikiDetailsViewModel();
        }

        public string Url
        {
            set
            {
                // set the title & our webview source using the passed url parameter
                this.Title = Uri.UnescapeDataString(value).Replace("/wiki/", string.Empty);
                webView.Source = $"https://en.wikipedia.org{value}";
            }
        }
    }
}