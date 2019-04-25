using System.Threading.Tasks;
using Android.App;
using Android.Content;
using UNLTestTask.Modules;
using Xamarin.Forms;

[assembly: Dependency(typeof(UNLTestTask.Droid.Modules.CallService))]
namespace UNLTestTask.Droid.Modules
{
    public class CallService : ICallService
    {
        public Task CallNumber(string phoneNumber)
        {
            var packageManager = Android.App.Application.Context.PackageManager;
            var telUri = Android.Net.Uri.Parse($"tel:{phoneNumber}");

            var intent = new Intent(Intent.ActionCall, telUri);

            intent.AddFlags(ActivityFlags.NewTask);

            var result = null != intent.ResolveActivity(packageManager);

            if (!string.IsNullOrWhiteSpace(phoneNumber) && result == true)
            {
                Android.App.Application.Context.StartActivity(intent);
            }

            return Task.FromResult(true);
        }
    }
}