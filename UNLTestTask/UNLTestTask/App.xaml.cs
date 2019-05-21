using LiteDB;
using UNLTestTask.DataCore;
using UNLTestTask.Presentation.Views.Contacts;
using UNLTestTask.Services;
using Xamarin.Forms;

namespace UNLTestTask
{
    public partial class App : Application
    {
	    private readonly IContainer _container;
	    private readonly INavigationService _navigationService;

		public App()
        {
            InitializeComponent();

			_container = new Container(this);
			_navigationService = _container.GetNavigationService();

			_navigationService.PushContactsPageAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
