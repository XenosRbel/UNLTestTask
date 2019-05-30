using System;
using UNLTestTask.Core.Services;
using UNLTestTask.Droid.Helpers;

namespace UNLTestTask.Droid.Services
{
	internal class MainThreadService : IMainThreadService
	{
		public void BeginInvokeOnMainThread(Action action)
		{
			CurrentActivityHelper.Current.Activity.RunOnUiThread(action.Invoke);
		}
	}
}