using Xamarin.Forms;

namespace ShellWeather.ViewModels
{
    //TODO: how to pass navigation params to the ViewModel, rather than the page 
    //[QueryProperty("Url", "url")]
    public class WikiDetailsViewModel : BaseViewModel
    {
        // private string _url { get; set; }
        // public string Url
        // {
        //     get => _url;
        //     set
        //     {
        //         _url = value;
        //         OnPropertyChanged(nameof(Url));
        //     }
        //
        // }
        
        public WikiDetailsViewModel()
        {
            //Url = url ?? "https://en.wikipedia.org/wiki/Xamarin";
        }
    }
}