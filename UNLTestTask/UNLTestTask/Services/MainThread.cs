using System;
using UNLTestTask.Core.Services;
using Xamarin.Forms;

namespace UNLTestTask.Forms.Services
{
	internal class MainThreadService : IMainThreadService
	{
		public void BeginInvokeOnMainThread(Action action)
		{
			Device.BeginInvokeOnMainThread(action.Invoke);
		}
	}
}