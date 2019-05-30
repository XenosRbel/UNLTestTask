using Android.App;
using Android.OS;
using Android.Runtime;
using CommonServiceLocator;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Core.Services;
using UNLTestTask.Droid.Services;

namespace UNLTestTask.Droid
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity<BaseViewModel>
	{
	    private INavigationService _navigationService;

	    protected override void OnCreate(Bundle savedInstanceState)
        {
			base.OnCreate(savedInstanceState);

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            var container = new ServiceContainer();
			_navigationService = new NavigationService(container);
			_navigationService.PushContactsPageAsync();
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

