using System;
using System.Threading.Tasks;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Services;
using UNLTestTask.Forms.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Forms.Presentation.ViewModels.Contacts;
using UNLTestTask.Forms.Presentation.ViewModels.EditContact;
using UNLTestTask.Forms.Presentation.Views.ContactDetails;
using UNLTestTask.Forms.Presentation.Views.Contacts;
using UNLTestTask.Forms.Presentation.Views.EditContact;
using Xamarin.Forms;

namespace UNLTestTask.Forms.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly Application _application;
		private readonly IServiceContainer _container;
		private readonly IMainThreadService _mainThreadService;
		private INavigation Navigation => _application.MainPage.Navigation;

		public NavigationService(Application application, IServiceContainer container)
		{
			_application = application ?? throw new ArgumentNullException(nameof(application));
			_container = container ?? throw new ArgumentNullException(nameof(container));
			_mainThreadService = _container.GetMainThreadService();
		}

		public Task PopAsync()
		{
			return Navigation.PopModalAsync();
		}

		public Task PushContactDetailsPageAsync(Contact contact)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var viewModel = new ContactDetailsViewModel(contact);

				var page = new ContactDetailsViewPage(viewModel);

				Navigation.PushModalAsync(page);
			});

			return Task.FromResult(true);
		}

		public Task PushContactsPageAsync()
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var viewModel = new ContactsViewModel(_container.GetRepository(),
					this,
					_container.GetDialogService(),
					_container.GetToastNotificationService());

				var page = new ContactsViewPage(viewModel);

				CreateNewNavigation(page);
			});

			return Task.FromResult(true);
		}

		public Task PushEditContactAsync()
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var viewModel = new EditContactViewModel(_container.GetRepository(),
					this,
					_container.GetToastNotificationService());
				var page = new EditContactPage(viewModel);

				Navigation.PushModalAsync(page);
			});

			return Task.FromResult(true);
		}

		public Task PushEditContactAsync(Contact contact)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var viewModel = new EditContactViewModel(_container.GetRepository(),
					this,
					_container.GetToastNotificationService(),
					contact);
				var page = new EditContactPage(viewModel);

				Navigation.PushModalAsync(page);
			});

			return Task.FromResult(true);
		}

		private void CreateNewNavigation(Page page)
		{
			var navigationPage = new NavigationPage(page);

			_application.MainPage = navigationPage.RootPage;
		}
	}
}