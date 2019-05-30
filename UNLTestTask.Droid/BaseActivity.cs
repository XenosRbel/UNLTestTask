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
	public class BaseActivity<TViewModel> : BaseActivity where TViewModel : class
	{
		private TViewModel _viewModel;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Current = this;

			_viewModel = Intent.TryGetViewModel<TViewModel>();
		}

		protected TViewModel ViewModel => _viewModel;
	}

	public class BaseActivity : Activity
	{
		public static Activity Current { get; internal set; }
	}
}