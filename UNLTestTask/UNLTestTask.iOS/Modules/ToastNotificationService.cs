using Foundation;
using UIKit;
using UNLTestTask.Core.Services;
using UNLTestTask.iOS.Modules;

[assembly: Xamarin.Forms.Dependency(typeof(ToastNotificationService))]
namespace UNLTestTask.iOS.Modules
{
	internal class ToastNotificationService : IToastNotificationService
	{
		private const double LongDelay = 3.5;
		private const double ShortDelay = 2.0;

		private NSTimer _alertDelay;
		private UIAlertController _alert;

		public void LongAlert(string message)
		{
			UIApplication.SharedApplication.InvokeOnMainThread(() => ShowAlert(message, LongDelay));
		}
		public void ShortAlert(string message)
		{
			UIApplication.SharedApplication.InvokeOnMainThread(() => ShowAlert(message, ShortDelay));
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