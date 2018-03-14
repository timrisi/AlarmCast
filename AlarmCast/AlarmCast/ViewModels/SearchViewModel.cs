using AlarmCast.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AlarmCast.ViewModels
{
	public class SearchViewModel : BaseViewModel
	{
		HttpClient client;

		public SearchViewModel ()
		{
			client = new HttpClient();
		}
		
		string searchText;
		public string SearchText {
			get {
				return searchText;
			}
			set {
				SetProperty(ref searchText, value);

				client.CancelPendingRequests();
				Podcasts.Clear();

				if (string.IsNullOrEmpty(searchText))
					return;

				var encodedText = WebUtility.UrlEncode(searchText);
				client.GetAsync($"https://itunes.apple.com/search?term={encodedText}&entity=podcast").ContinueWith(async (httpResponse) =>
			       {
				       var response = await httpResponse;
				       if (response.IsSuccessStatusCode)
				       {
					       var content = await response.Content.ReadAsStringAsync();
					       var json = JObject.Parse(content);
					       foreach (var result in json["results"])
					       {
						       await Task.Run(() =>
						      {
							      var url = result["feedUrl"]?.ToString();
							      if (string.IsNullOrEmpty(url))
								      return;

							      XDocument document = XDocument.Load (url);
							      var podcast = new Podcast(document.Descendants("channel").FirstOrDefault(), url);
							      podcasts.Add(podcast);
						      });

					       }

					       //var results = JsonConvert.DeserializeObject<List<iTunesResult>>(json["results"].ToString());
					       //Podcasts = new ObservableCollection<iTunesResult>(results);
				       }
			       });
			}
		}

		ObservableCollection<Podcast> podcasts = new ObservableCollection<Podcast>();
		public ObservableCollection<Podcast> Podcasts {
			get {
				return podcasts;
			}
			set {
				SetProperty(ref podcasts, value);
			}
		}

		Podcast selectedPodcast;
		public Podcast SelectedPodcast {
			get {
				return selectedPodcast;
			}
			set {
				SetProperty(ref selectedPodcast, value);

				if (selectedPodcast == null)
					return;

				client.CancelPendingRequests();

				NavigationService.PushAsync(new PodcastViewModel { Podcast = selectedPodcast });

				selectedPodcast = null;
			}
		}
	}
}
