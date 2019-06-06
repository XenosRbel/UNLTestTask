using Foundation;
using UIKit;
using UNLTestTask.Native.iOS.Services;

namespace UNLTestTask.Native.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
	    public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
	        Window = new UIWindow(UIScreen.MainScreen.Bounds);

			var container = new ServiceContainer(Window);
			var navigationService = new NavigationService(container,Window);
			navigationService.PushContactsPageAsync();

			Window.MakeKeyAndVisible();

			return true;
		}
    }
}

