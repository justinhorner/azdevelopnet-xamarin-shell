using System;
using System.Collections.Generic;
using ShellWeather.Views;
using Xamarin.Forms;

namespace ShellWeather
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }
        
        private void RegisterRoutes()
        {
            routes.Add("wikidetails", typeof(WikiDetailsPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
