using System;
using Android.App;
using Android.Runtime;
using UNLTestTask.Core.Services;
using UNLTestTask.Droid.Helpers;
using UNLTestTask.Droid.Services;

namespace UNLTestTask.Droid
{
	[Application]
	internal class App : Application
	{
		public static IServiceContainer Container { get; private set; }
		public static INavigationService NavigationService { get; private set; }

		public App(IntPtr handle, JniHandleOwnership ownership) : base(handle, ownership)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			CurrentActivityHelper.Current.Init(this);

			Container = new ServiceContainer();
			NavigationService = new NavigationService(Container);
		}
	}
}