using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UNLTestTask.Services
{
	internal class DialogService : IDialogService
	{
		private readonly Application _application;
		private readonly IContainer _container;

		public DialogService(Application application, IContainer container)
		{
			_application = application ?? throw new ArgumentNullException(nameof(application));
			_container = container ?? throw new ArgumentNullException(nameof(container));
		}
		public Task DisplayAlertAsync(string title, string message, string cancel)
		{
			return _application.MainPage.DisplayAlert(title, message, cancel);
		}

		public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
		{
			return _application.MainPage.DisplayAlert(title, message, accept, cancel);
		}
	}
}
