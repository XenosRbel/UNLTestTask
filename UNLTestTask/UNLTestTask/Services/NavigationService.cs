using System;
using System.Threading.Tasks;
using UNLTestTask.Models;
using UNLTestTask.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Presentation.ViewModels.Contacts;
using UNLTestTask.Presentation.ViewModels.EditContact;
using UNLTestTask.Presentation.Views.ContactDetails;
using UNLTestTask.Presentation.Views.Contacts;
using UNLTestTask.Presentation.Views.EditContact;
using Xamarin.Forms;

namespace UNLTestTask.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly Application _application;
		private readonly IContainer _container;
		private INavigation Navigation => _application.MainPage.Navigation;

		public NavigationService(Application application, IContainer container)
		{
			_application = application ?? throw new ArgumentNullException(nameof(application));
			_container = container ?? throw new ArgumentNullException(nameof(container));

			var page = new MainPage();
			CreateNewNavigation(page);
		}

		public Task PopAsync()
		{
			return Navigation.PopModalAsync();
		}

		public Task PushContactDetailsPageAsync(Contact contact)
		{
			var viewModel = new ContactDetailsViewModel(_container.GetNavigationService(), 
				_container.GetRepository(),
				contact);
			var page = new ContactDetailsViewPage(viewModel);
			
			return Navigation.PushModalAsync(page);
		}

		public Task PushContactsPageAsync()
		{
			var viewModel = new ContactsViewModel(_container.GetRepository(), 
				_container.GetNavigationService(),
				_container.GetDialogService(),
				_container.GetToastNotificationService());
			var page = new ContactsViewPage(viewModel);

			return Navigation.PushModalAsync(page);
		}

		public Task PushEditContactAsync()
		{
			var viewModel = new EditContactViewModel(_container.GetRepository(), 
				_container.GetNavigationService(),
				_container.GetToastNotificationService());
			var page = new EditContactPage(viewModel);

			return Navigation.PushModalAsync(page);
		}

		public Task PushEditContactAsync(Contact contact)
		{
			var viewModel = new EditContactViewModel(_container.GetRepository(), 
				_container.GetNavigationService(), 
				_container.GetToastNotificationService(),
				contact);
			var page = new EditContactPage(viewModel);

			return Navigation.PushModalAsync(page);
		}

		private void CreateNewNavigation(Page page)
		{
			var navigationPage = new NavigationPage(page);

			_application.MainPage = navigationPage.RootPage;
		}
	}
}