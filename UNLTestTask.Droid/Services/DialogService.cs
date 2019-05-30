using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.App;
using UNLTestTask.Core.Services;
using UNLTestTask.Droid.Helpers;

namespace UNLTestTask.Droid.Services
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
			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var builder = new AlertDialog.Builder(CurrentActivityHelper.Current.Activity);
				builder.SetTitle(title)
					.SetMessage(message)
					.SetCancelable(true)
					.SetNeutralButton(cancel, (sender, args) => { Debug.WriteLine(args.Which); });
				builder.Create();
				builder.Show();
			});

			return Task.FromResult(true);
		}

		public Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
		{
			var completionSource = new TaskCompletionSource<bool>();
			var dialogResult = false;

			_mainThreadService.BeginInvokeOnMainThread(() =>
			{
				var builder = new AlertDialog.Builder(CurrentActivityHelper.Current.Activity);
				builder.SetTitle(title)
					.SetMessage(message)
					.SetPositiveButton(accept, (sender, args) =>
					{
						dialogResult = true;
						Debug.WriteLine(args.Which);

						completionSource.SetResult(dialogResult);
					})
					.SetNegativeButton(cancel, (sender, args) =>
					{
						dialogResult = false;
						Debug.WriteLine(args.Which);

						completionSource.SetResult(dialogResult);
					});
				builder.Create();

				builder.Show();
			});

			return completionSource.Task;
		}
	}
}