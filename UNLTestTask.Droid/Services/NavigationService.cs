using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Services;
using UNLTestTask.Droid.Helpers;
using UNLTestTask.Forms.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Forms.Presentation.ViewModels.Contacts;
using UNLTestTask.Forms.Presentation.ViewModels.EditContact;

namespace UNLTestTask.Droid.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly IServiceContainer _container;
		private readonly IMainThreadService _mainThreadService;

		public NavigationService(IServiceContainer container)
		{
			_container = container ?? throw new ArgumentNullException(nameof(container));
			_mainThreadService = container.GetMainThreadService();
		}

		public Task PopAsync()
		{
			BaseActivity.Current.OnBackPressed();
			return Task.FromResult(true);
		}

		public Task PushContactDetailsPageAsync(Contact contact)
		{
			var contactDetailViewModel = new ContactDetailsViewModel(contact);

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var intent = new Intent(Application.Context, typeof(ContactDetailsPage));
				intent.PutNavigatedParam(contactDetailViewModel);

				Application.Context.StartActivity(intent);
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
				var intent = new Intent(Application.Context, typeof(ContactsPage));
				intent.PutNavigatedParam(contactsViewModel);

				Application.Context.StartActivity(intent);
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
				var intent = new Intent(Application.Context, typeof(EditContactPage));
				intent.SetFlags(ActivityFlags.SingleTop);
				intent.PutNavigatedParam(editContactViewModel);

				Application.Context.StartActivity(intent);
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
				var intent = new Intent(Application.Context, typeof(EditContactPage));
				intent.SetFlags(ActivityFlags.SingleTop);
				intent.PutNavigatedParam(editContactViewModel);

				Application.Context.StartActivity(intent);
			});

			return Task.FromResult(true);
		}
	}
}