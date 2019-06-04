using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Native.iOS.Services
{
	internal class ServiceContainer : IServiceContainer
	{
		private readonly IRepository _repository;
		private readonly IDialogService _dialogService;
		private readonly IToastNotificationService _toastNotificationService;
		private readonly IMainThreadService _mainThreadService;
		private readonly UIWindow _window;

		public ServiceContainer(UIWindow window)
		{
			_window = window ?? throw new ArgumentNullException(nameof(window));

			_repository = new MemoryRepository();
			_mainThreadService = new MainThreadService(_window);
			_dialogService = new DialogService(_mainThreadService, _window);
			_toastNotificationService = new ToastNotificationService(_mainThreadService);
		}

		public IRepository GetRepository()
		{
			return _repository;
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