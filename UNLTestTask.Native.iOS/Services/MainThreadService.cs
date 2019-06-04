using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Native.iOS.Services
{
	internal class MainThreadService : IMainThreadService
	{
		private readonly UIWindow _window;

		public MainThreadService(UIWindow window)
		{
			_window = window ?? throw new ArgumentNullException(nameof(window));
		}

		public void BeginInvokeOnMainThread(Action action)
		{
			_window.InvokeOnMainThread(action.Invoke);
		}
	}
}