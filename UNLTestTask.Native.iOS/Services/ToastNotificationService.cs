using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Native.iOS.Services
{
	internal class ToastNotificationService : IToastNotificationService
	{
		private readonly IMainThreadService _mainThreadService;

		public ToastNotificationService(IMainThreadService mainThreadService)
		{
			_mainThreadService = mainThreadService ?? throw new ArgumentNullException(nameof(mainThreadService));
		}

		public void LongAlert(string message)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{

			});
		}

		public void ShortAlert(string message)
		{
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{

			});
		}
	}
}