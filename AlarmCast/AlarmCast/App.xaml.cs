using System;
using AlarmCast.Services;
using AlarmCast.ViewModels;
using AlarmCast.Views;
using Xamarin.Forms;

namespace AlarmCast
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			RegisterViews();
			NavigationService.SetRoot(new SubscriptionsViewModel(), true);
			//MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		void RegisterViews ()
		{
			SimpleIoC.RegisterPage<MainViewModel, MainPage>();
			SimpleIoC.RegisterPage<SubscriptionsViewModel, SubscriptionsPage>();
			SimpleIoC.RegisterPage<ItemDetailViewModel, ItemDetailPage>();
			SimpleIoC.RegisterPage<NewItemViewModel, NewItemPage>();
			SimpleIoC.RegisterPage<SearchViewModel, SearchPage>();
			SimpleIoC.RegisterPage<PodcastViewModel, PodcastPage>();
		}
	}
}
