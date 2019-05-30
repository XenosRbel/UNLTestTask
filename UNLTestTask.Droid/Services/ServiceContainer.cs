using System;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Droid.Services
{
	internal class ServiceContainer : IServiceContainer
	{
		private readonly IRepository _repository;
		private readonly IDialogService _dialogService;
		private readonly IToastNotificationService _toastNotificationService;
		private readonly IMainThreadService _mainThreadService;

		public ServiceContainer()
		{
			_repository = new MemoryRepository();
			_mainThreadService = new MainThreadService();
			_dialogService = new DialogService(_mainThreadService);
			_toastNotificationService = new ToastNotificationService(_mainThreadService);
		}

		public IRepository GetRepository()
		{
			return _repository;
		}

		public INavigationService GetNavigationService()
		{
			throw new NotImplementedException();
		}

		public IDialogService GetDialogService()
		{
			return _dialogService;
		}

		public IToastNotificationService GetToastNotificationService()
		{
			return _toastNotificationService;
		}

		public IMainThreadService GetMainThreadService()
		{
			return _mainThreadService;
		}
	}
}