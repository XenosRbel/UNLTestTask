using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Presentation.ViewModels.Contacts;
using UNLTestTask.Services;

namespace UNLTestTask
{
	internal class ViewModelLocator
    {
	    private readonly IContainer _container;

		public ViewModelLocator(IContainer container)
		{
			_container = container;

			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

		    SimpleIoc.Default.Register<IContactsViewModel>(ContactsViewModelFactory);
	    }

		public IContactsViewModel ContactsViewModel => ServiceLocator.Current.GetInstance<IContactsViewModel>();

		private IContactsViewModel ContactsViewModelFactory()
	    {
		    return new ContactsViewModel(_container.GetRepository(),
			    _container.GetNavigationService(),
			    _container.GetDialogService(),
			    _container.GetToastNotificationService(),
			    _container.GetMainThreadService());
	    }
	}
}
