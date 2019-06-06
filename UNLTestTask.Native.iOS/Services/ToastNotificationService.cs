using System;
using Foundation;
using UIKit;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Native.iOS.Services
{
	internal class ToastNotificationService : IToastNotificationService
	{
		private const double LongDelay = 3.5;
		private const double ShortDelay = 2.0;

		private NSTimer _alertDelay;
		private UIAlertController _alert;

		private readonly IMainThreadService _mainThreadService;

		public ToastNotificationService(IMainThreadService mainThreadService)
		{
			_mainThreadService = mainThreadService ?? throw new ArgumentNullException(nameof(mainThreadService));
		}

		public void LongAlert(string message)
		{
			_mainThreadService.BeginInvokeOnMainThread(() => { ShowAlert(message, LongDelay); });
		}
		public void ShortAlert(string message)
		{
			_mainThreadService.BeginInvokeOnMainThread(() => { ShowAlert(message, ShortDelay); });
		}

		private void ShowAlert(string message, double seconds)
		{
			_alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
			{
				DismissMessage();
			});

			_alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
			UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(_alert, true, null);
		}

		private void DismissMessage()
		{
			_alert?.DismissViewController(true, null);

			_alertDelay?.Dispose();
		}
	}
}