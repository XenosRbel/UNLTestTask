using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UNLTestTask.Droid.Helpers;
using UNLTestTask.Droid.Services;

namespace UNLTestTask.Droid
{
	[Activity(Label = "BaseActivity")]
	public class BaseActivity<TViewModel> :Activity where TViewModel : class
	{
		private TViewModel _viewModel;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			_viewModel = Intent.TryGetViewModel<TViewModel>();
		}

		protected TViewModel ViewModel => _viewModel;
	}
}