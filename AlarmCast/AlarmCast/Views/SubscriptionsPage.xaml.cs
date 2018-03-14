using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AlarmCast.Models;
using AlarmCast.Views;
using AlarmCast.ViewModels;

namespace AlarmCast.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubscriptionsPage : BasePage
	{
		public SubscriptionsPage()
		{
			InitializeComponent();
			//BindingContext = new SubscriptionsViewModel();
		}
	}
}