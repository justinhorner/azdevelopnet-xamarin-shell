using System;
using System.Collections.Generic;
using ShellWeather.ViewModels;
using Xamarin.Forms;

namespace ShellWeather.Views
{
    public partial class WeatherPage : ContentPage
    {
        WeatherViewModel viewModel;

        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new WeatherViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetForecastCommand.Execute(null);
        }
    }
}
