using System;
using Android.OS;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Core.Services;
using UNLTestTask.Forms.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Forms.Presentation.ViewModels.Contacts;
using UNLTestTask.Forms.Presentation.ViewModels.EditContact;
using INavigationService = GalaSoft.MvvmLight.Views.INavigationService;

namespace UNLTestTask.Droid.Services
{
	public class ViewModelLocator
	{
		private readonly IServiceContainer _container;

		public ViewModelLocator(IServiceContainer container)
		{
			_container = container ?? throw new ArgumentNullException(nameof(container));

			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			//SimpleIoc.Default?.Register(ContactsViewModelFactory);
			//SimpleIoc.Default?.Register(() => EditContactViewModelFactory());
			//SimpleIoc.Default?.Register(() => ContactDetailsViewModelFactory());
		}

		//public IContactsViewModel ContactsViewModel => ServiceLocator.Current.GetInstance<IContactsViewModel>();

		//public IContactDetailsViewModel ContactDetailsViewModel =>
		//	ServiceLocator.Current.GetInstance<IContactDetailsViewModel>();

		//public IEditContactViewModel EditContactViewModel =>
		//	ServiceLocator.Current.GetInstance<IEditContactViewModel>();

		//public void RegisterEditContact(Contact contact)
		//{
		//	SimpleIoc.Default.Unregister<IEditContactViewModel>();

		//	SimpleIoc.Default?.Register(() => EditContactViewModelFactory(contact));
		//}

		//public void RegisterContactDetails(Contact contact)
		//{
		//	SimpleIoc.Default.Unregister<IContactDetailsViewModel>();

		//	SimpleIoc.Default?.Register(() => ContactDetailsViewModelFactory(contact));
		//}

		//private IContactsViewModel ContactsViewModelFactory()
		//{
		//	return new ContactsViewModel(_container.GetRepository(),
		//		_container.GetNavigationService(),
		//		_container.GetDialogService(),
		//		_container.GetToastNotificationService(),
		//		_container.GetMainThreadService());
		//}

		//private IEditContactViewModel EditContactViewModelFactory(Contact contact = null)
		//{
		//	return new EditContactViewModel(_container.GetRepository(),
		//		_container.GetNavigationService(),
		//		_container.GetToastNotificationService(),
		//		_container.GetMainThreadService(),
		//		contact);
		//}

		//private IContactDetailsViewModel ContactDetailsViewModelFactory(Contact contact = null)
		//{
		//	return new ContactDetailsViewModel(_container.GetMainThreadService(),
		//		contact);
		//}
	}
}

