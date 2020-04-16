# Xamrin Shell Presentation

*Created by: Justin Horner - mail@justinhorner.me - April 15, 2020*

This presentation hopes to explain to the [Arizona - Xamarin Mobile Development group](https://www.meetup.com/azxplatform/) some of the benefits (and drawbacks) to Xamarin Shell.  The presentation is in .odp format and can be read by [LibreOffice](https://www.libreoffice.org/).  The associated project was based off of the [example Xamarin Shell project included in Visual Studio](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/create) with modifications made to show how easily you can add new pages / features to a Shell application.  The project has been tested in Visual Studio 2019 for Mac on Android and iOS simulators and on Visual Studio 2019 for Windows on an Android simulator *(I had to unload the iOS project to get the solution to build on my Windows box)*.

## Helpful Links
	- Xamarin Shell Fundamentals
		- https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell/create
	- Telerik
		- https://www.telerik.com/blogs/an-introduction-to-xamarin-forms-shell
	- All Things Xamarin.Forms Shell - Shane Neuville
		- https://www.youtube.com/watch?v=QFNmLE7pVl4&t=6h43m45s
	- Xamarin Forms Shell
		- https://42interactive.com/xamarin-forms-shell/
	- 'My two cents on Xamarin Forms Shell'
		- https://15mgm15.blog/2019/07/05/my-two-cents-on-xamarin-forms-shell/
	- Samples:
		- Xaminals (Search)
			- https://github.com/xamarin/xamarin-forms-samples/tree/master/UserInterface/Xaminals
	- Design examples:
		- https://github.com/davidortinau/VisualChallenge/pulls
		- https://github.com/davidortinau/VisualChallenge/pulls
		- https://github.com/pauldipietro/CollectionViewChallenge/pulls

## Presentation / Project
	- Repo URL
		- https://github.com/justinhorner/azdevelopnet-xamarin-shell
	- Project Notes: 
		- darkSky API:
			- I used this API for the 'weather' portion of the project because it is a simple and fast weather API.  However, the API is going off-line in the future and the service is not generating new API keys.  If you wish to try out the project, I can provide you with my test API key (just contact the author).

## Project Notes
	- Styling / Market
		- added some colors and styles to app.xaml
		- added component top 
	- Weather
		- add simple API call to fetch weather
		- implement location fetching w/ 'Nearby' button
	- Wikipedia & Details
		- example of search delegate
		- more Xamarin.Essentials usage
		- example of navigation to viewModel