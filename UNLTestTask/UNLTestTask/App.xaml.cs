using UNLTestTask.Services;
using Xamarin.Forms;

namespace UNLTestTask
{
	public partial class App : Application
    {
	    private readonly IContainer _container;
	    private readonly INavigationService _navigationService;

	    //private static ViewModelLocator Locator { get; private set; }

		public App()
        {
            InitializeComponent();

			_container = new Container(this);
			_navigationService = _container.GetNavigationService();
			_navigationService.PushContactsPageAsync();

			//Locator = new ViewModelLocator(_container);
		}
    }
}
