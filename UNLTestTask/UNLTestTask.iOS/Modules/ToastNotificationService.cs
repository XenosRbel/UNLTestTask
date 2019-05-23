using Foundation;
using UIKit;
using UNLTestTask.iOS.Modules;
using UNLTestTask.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ToastNotificationService))]
namespace UNLTestTask.iOS.Modules
{
	public class ToastNotificationService : IToastNotificationService
	{
		private const double LongDelay = 3.5;
		private const double ShortDelay = 2.0;

		private NSTimer _alertDelay;
		private UIAlertController _alert;

		public void LongAlert(string message)
		{
			ShowAlert(message, LongDelay);
		}
		public void ShortAlert(string message)
		{
			ShowAlert(message, ShortDelay);
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