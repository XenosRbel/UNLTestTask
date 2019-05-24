using System;
using UNLTestTask.DataCore;
using Xamarin.Forms;

namespace UNLTestTask.Services
{
	internal class Container : IContainer
	{
		private readonly Application _application;
		private readonly IRepository _repository;
		private readonly INavigationService _navigationService;
		private readonly IDialogService _dialogService;
		private readonly IToastNotificationService _toastNotificationService;

		public Container(Application application)
		{
			//var liteDbRepositoryFactory = new LiteDbRepositoryFactory("contact.db");
			//var repository = new LiteDbRepository(liteDbRepositoryFactory.GetRepository());
			var repository = new MemoryRepository();

			_application = application;
			_repository = repository;
			_navigationService = new NavigationService(_application, this);
			_dialogService = new DialogService(_application);
			_toastNotificationService = DependencyService.Get<IToastNotificationService>();
		}

		public IRepository GetRepository()
		{
			return _repository;
		}

		public INavigationService GetNavigationService()
		{
			return _navigationService;
		}

		public IDialogService GetDialogService()
		{
			return _dialogService;
		}

		public IToastNotificationService GetToastNotificationService()
		{
			return _toastNotificationService;
		}
	}
}