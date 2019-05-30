using Android.Widget;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Droid.Services
{
	internal class ToastNotificationService : IToastNotificationService
	{
		private readonly IMainThreadService _mainThreadService;

		public ToastNotificationService(IMainThreadService mainThreadService)
		{
			_mainThreadService = mainThreadService;
		}

		public void LongAlert(string message)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
			});
		}

		public void ShortAlert(string message)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
			});
		}
	}
}