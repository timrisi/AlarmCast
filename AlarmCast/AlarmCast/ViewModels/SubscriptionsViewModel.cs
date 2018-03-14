using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using AlarmCast.Models;
using AlarmCast.Views;
using AlarmCast.Services;

namespace AlarmCast.ViewModels
{
	public class SubscriptionsViewModel : BaseViewModel
	{
		public ObservableCollection<Podcast> Podcasts { get; set; }
		public Command LoadItemsCommand { get; set; }

		public SubscriptionsViewModel()
		{
			Title = "Subscriptions";
			Podcasts = new ObservableCollection<Podcast>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

			MessagingCenter.Subscribe<NewItemViewModel, Item>(this, "AddItem", async (obj, item) =>
			{
				//var _item = item as Item;
				//Podcasts.Add(null);
				//await DataStore.AddItemAsync(_item);
			});
		}

		Item selectedItem;
		public Item SelectedItem {
			get {
				return selectedItem;
			}
			set {
				SetProperty (ref selectedItem, value);

				if (selectedItem == null)
					return;

				NavigationService.PushAsync(new ItemDetailViewModel(selectedItem)).ContinueWith((result) =>
			       {
				       selectedItem = null;
			       }); ;
			}
		}

		Command addPodcast;
		public Command AddPodcast {
			get {
				if (addPodcast == null)
				{
					addPodcast = new Command(async () =>
				       {
					       await NavigationService.PushAsync(new SearchViewModel());
				       });
				}

				return addPodcast;
			}
		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Podcasts.Clear();
				var podcasts = await Database.Main.Table <Podcast>().ToListAsync ();
				Podcasts = new ObservableCollection<Podcast>(podcasts);

				foreach (var podcast in Podcasts)
				{
					podcast.Episodes = await Database.Main.Table<Episode>().Where(e => e.PodcastId == podcast.Id).ToListAsync();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public override void OnViewAppearing()
		{
			base.OnViewAppearing();

			if (Podcasts.Count == 0)
				LoadItemsCommand.Execute(null);
		}
	}
}