using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AlarmCast.ViewModels;

namespace AlarmCast.Views
{
	public class BasePage : ContentPage
	{
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			var vm = BindingContext as BaseViewModel;
			if (vm != null)
				vm.OnViewAppearing ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			var vm = BindingContext as BaseViewModel;
			if (vm != null)
				vm.OnViewDisappearing ();
		}
	}
}
