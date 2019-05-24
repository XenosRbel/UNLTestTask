using Android.Widget;
using UNLTestTask.Core.Services;
using UNLTestTask.Droid.Modules;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastNotificationService))]
namespace UNLTestTask.Droid.Modules
{
	internal class ToastNotificationService : IToastNotificationService
	{
		public void LongAlert(string message)
		{
			MainActivity.Current.RunOnUiThread(() =>
			{
				Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
			});
		}

		public void ShortAlert(string message)
		{
			MainActivity.Current.RunOnUiThread(() =>
			{
				Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
			});
		}
	}
}