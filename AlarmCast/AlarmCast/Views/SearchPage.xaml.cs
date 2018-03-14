using AlarmCast.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlarmCast.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : BasePage
	{
		public SearchPage ()
		{
			InitializeComponent ();
		}


		//public void Podcast_Selected(object sender, SelectedItemChangedEventArgs e)
		//{
		//	Navigation.PushAsync(new PodcastPage
		//	{
		//		BindingContext = new PodcastViewModel { Podcast = e.SelectedItem as Podcast }
		//	});
		//}
	}
}