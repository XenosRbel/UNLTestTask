using System;
using System.Threading.Tasks;
using UIKit;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Native.iOS.Services
{
	internal class DialogService : IDialogService
	{
		private readonly IMainThreadService _mainThreadService;

		public DialogService(IMainThreadService mainThreadService)
		{
			_mainThreadService = mainThreadService ?? throw new ArgumentNullException(nameof(mainThreadService));
		}

		public Task DisplayAlertAsync(string title, string message, string cancel)
		{
			var completionSource = new TaskCompletionSource<bool>();
			var dialogResult = false;

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var alertViewDelegate = new AlertDelegate();
				alertViewDelegate.ButtonClicked += delegate (UIAlertView sender, int index)
				{
					dialogResult = index == 0;

					completionSource.SetResult(dialogResult);
				};

				UIAlertView alert = new UIAlertView(title, message, (IUIAlertViewDelegate)alertViewDelegate, cancel);

				alert.Delegate = alertViewDelegate;
				
				alert.Show();
			});

			return completionSource.Task;
		}

		public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
		{
			var completionSource = new TaskCompletionSource<bool>();
			var dialogResult = false;

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var alertViewDelegate = new AlertDelegate();
				alertViewDelegate.ButtonClicked += delegate(UIAlertView sender, int index)
				{
					dialogResult = index == 0;

					completionSource.SetResult(dialogResult);
				};

				UIAlertView alert = new UIAlertView(title, message, (IUIAlertViewDelegate)alertViewDelegate, accept, cancel);

				alert.Delegate = alertViewDelegate;

				alert.Show();
			});

			return completionSource.Task;
		}
	}

	public sealed class AlertDelegate : UIAlertViewDelegate
	{
		public delegate void ClickedEventHandler(UIAlertView sender, int index);
		public event ClickedEventHandler ButtonClicked;

		public override void Clicked(UIAlertView alertView, nint buttonIndex)
		{
			OnButtonClicked(alertView, (int)buttonIndex);
		}

		private void OnButtonClicked(UIAlertView sender, int index)
		{
			ButtonClicked?.Invoke(sender, index);
		}
	}
}