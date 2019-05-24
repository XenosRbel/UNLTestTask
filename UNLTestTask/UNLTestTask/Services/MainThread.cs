using System;
using Xamarin.Forms;

namespace UNLTestTask.Services
{
	internal class MainThreadService : IMainThreadService
	{
		public void BeginInvokeOnMainThread(Action action)
		{
			Device.BeginInvokeOnMainThread(action.Invoke);
		}
	}
}