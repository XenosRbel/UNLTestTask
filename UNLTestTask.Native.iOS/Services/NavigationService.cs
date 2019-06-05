using System;
using System.Threading.Tasks;
using UIKit;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Services;
using UNLTestTask.Forms.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Forms.Presentation.ViewModels.Contacts;
using UNLTestTask.Forms.Presentation.ViewModels.EditContact;
using UNLTestTask.Native.iOS.Views;

namespace UNLTestTask.Native.iOS.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly IServiceContainer _container;
		private readonly IMainThreadService _mainThreadService;
		private readonly UIWindow _uiWindow;
		private UINavigationController _navigationController;
		private const bool WithAnimation = true;

		public NavigationService(IServiceContainer container, UIWindow uiWindow)
		{
			_container = container ?? throw new ArgumentNullException(nameof(container));
			_mainThreadService = container.GetMainThreadService() ?? throw new ArgumentNullException(nameof(container));
			_uiWindow = uiWindow ?? throw new ArgumentNullException(nameof(uiWindow));
		}

		public Task PopAsync()
		{
			_mainThreadService.BeginInvokeOnMainThread(() => { _navigationController.PopViewController(WithAnimation); });
			return Task.FromResult(true);
		}

		public Task PushContactDetailsPageAsync(Contact contact)
		{
			var contactDetailViewModel = new ContactDetailsViewModel(contact);

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var contactDetails = new ContactDetailsUiViewController(contactDetailViewModel);

				_navigationController.PushViewController(contactDetails, WithAnimation);
			});
			return Task.FromResult(true);
		}

		public Task PushContactsPageAsync()
		{
			var contactsViewModel = new ContactsViewModel(
				_container.GetRepository(),
				this,
				_container.GetDialogService(),
				_container.GetToastNotificationService());

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var contactsView = new ContactsUiViewController(contactsViewModel);

				CreateNewNavigation(contactsView);
			});
			return Task.FromResult(true);
		}

		public Task PushEditContactAsync()
		{
			var editContactViewModel = new EditContactViewModel(
				_container.GetRepository(),
				this,
				_container.GetToastNotificationService());

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var editContact = new EditContactUiViewController(editContactViewModel);

				_navigationController.PushViewController(editContact, WithAnimation);
			});
			return Task.FromResult(true);
		}

		public Task PushEditContactAsync(Contact contact)
		{
			var editContactViewModel = new EditContactViewModel(
				_container.GetRepository(),
				this,
				_container.GetToastNotificationService(),
				contact);

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var editContact = new EditContactUiViewController(editContactViewModel);

				_navigationController.PushViewController(editContact, WithAnimation);
			});
			return Task.FromResult(true);
		}

		private void CreateNewNavigation(UIViewController viewController)
		{
			_navigationController = new UINavigationController(viewController);

			_uiWindow.RootViewController = _navigationController;
		}
	}
}