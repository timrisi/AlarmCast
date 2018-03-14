using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmCast.ViewModels
{
    public class PodcastViewModel : BaseViewModel
    {
		Podcast podcast;
		public Podcast Podcast {
			get {
				return podcast;
			}
			set {
				SetProperty(ref podcast, value);
			}
		}
    }
}
