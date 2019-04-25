using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;
using UNLTestTask.Modules;
using Xamarin.Forms;

[assembly: Dependency(typeof(UNLTestTask.iOS.Modules.CallService))]
namespace UNLTestTask.iOS.Modules
{
    public class CallService : ICallService
    {
        public Task CallNumber(string phoneNumber)
        {
            var phoneUrl = new Uri($"tel:{phoneNumber}");
            var phoneNSUrl = new NSUrl(phoneUrl.AbsoluteUri);

            if (!string.IsNullOrWhiteSpace(phoneNumber) &&
                UIApplication.SharedApplication.CanOpenUrl(phoneNSUrl))
            {
                UIApplication.SharedApplication.OpenUrl(phoneNSUrl);
            }
            return Task.FromResult(true);
        }
    }
}