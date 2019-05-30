using System;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Droid.Services
{
	internal class MainThreadService : IMainThreadService
	{
		public void BeginInvokeOnMainThread(Action action)
		{
			BaseActivity.Current.RunOnUiThread(action.Invoke);
		}
	}
}