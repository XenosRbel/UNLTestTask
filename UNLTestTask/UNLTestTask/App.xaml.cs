using UNLTestTask.Core.Services;
using UNLTestTask.Forms.Services;
using Xamarin.Forms;

namespace UNLTestTask.Forms
{
	public partial class App : Application
    {
	    public App()
        {
	        InitializeComponent();

			IServiceContainer container = new Container(this);

			INavigationService navigationService = new NavigationService(this, container);
			navigationService.PushContactsPageAsync();
		}
    }
}
