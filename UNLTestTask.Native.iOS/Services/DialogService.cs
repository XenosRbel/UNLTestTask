using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Native.iOS.Services
{
	internal class DialogService : IDialogService
	{
		private readonly IMainThreadService _mainThreadService;
		private readonly UIWindow _window;

		public DialogService(IMainThreadService mainThreadService, UIWindow window)
		{
			_mainThreadService = mainThreadService ?? throw new ArgumentNullException(nameof(mainThreadService));
			_window = window ?? throw new ArgumentNullException(nameof(window));
		}

		public Task DisplayAlertAsync(string title, string message, string cancel)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var b = new UIAlertViewDelegate();
				b.Clicked(new UIAlertView(title,message,null, cancel), 0);
			});

			return Task.FromResult(true);
		}

		public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{

			});

			return Task.FromResult(true);
		}
	}
}