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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WikiDetailsPage : ContentPage
    {
        public WikiDetailsPage()
        {
            InitializeComponent();
            BindingContext = new WikiDetailsViewModel();
        }
    }
}