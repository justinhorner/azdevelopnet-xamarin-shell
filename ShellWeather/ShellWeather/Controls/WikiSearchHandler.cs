using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using WikipediaNet;
using WikipediaNet.Enums;
using WikipediaNet.Objects;
using Xamarin.Forms;

namespace ShellWeather.Controls
{
    public class WikiSearchHandler : SearchHandler
    {
        private Wikipedia _wikipedia = new Wikipedia() {Limit = 50};
        
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                var queryResult = _wikipedia.Search(Query);
                ItemsSource = queryResult.Search;
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            await Task.Delay(1000);

            // Shell doesn't seem to like absolute URLs, so just pass the path and we'll put the URL back 
            // together on the receiving end.
            var url = ((Search) item).Url.AbsolutePath;
            await Shell.Current.GoToAsync($"wikidetails?url={url}");
        }
    }
}