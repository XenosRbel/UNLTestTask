using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UNLTestTask.Services
{
	internal class DialogService : IDialogService
	{
		private readonly Application _application;

		public DialogService(Application application)
		{
			_application = application ?? throw new ArgumentNullException(nameof(application));
		}
		public Task DisplayAlertAsync(string title, string message, string cancel)
		{
			return Task.Run(() => Device.BeginInvokeOnMainThread(() => _application.MainPage.DisplayAlert(title, message, cancel)));
		}

		public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
		{
			var completionSource = new TaskCompletionSource<bool>();
			var dialogResult = false;

			return Task.Run(() =>
			{
				Device.BeginInvokeOnMainThread(async () =>
				{
					dialogResult = await _application.MainPage.DisplayAlert(title, message, accept, cancel);

					completionSource.SetResult(dialogResult);
				});

				return completionSource.Task;
			});
		}
	}
}
