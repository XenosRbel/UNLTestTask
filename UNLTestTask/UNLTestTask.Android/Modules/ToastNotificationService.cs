using Android.Widget;
using UNLTestTask.Droid.Modules;
using UNLTestTask.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastNotificationService))]
namespace UNLTestTask.Droid.Modules
{
	public class ToastNotificationService : IToastNotificationService
	{
		public void LongAlert(string message)
		{
			Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
		}

		public void ShortAlert(string message)
		{
			Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
		}
	}
}