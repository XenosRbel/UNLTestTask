using System;
using System.Collections.Generic;
using Android.Content;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Droid.Helpers
{
	internal static class NavigationParameterHelper
	{
		private const string ParameterKeyName = "ViewModelKey";
		private static readonly Dictionary<string, object> ViewModelDictionary = new Dictionary<string, object>();

		public static T TryGetViewModel<T>(this Intent intent)
		{
			return (T)TryGetViewModel(intent);
		}

		public static void PutNavigatedParam<TViewModel>(this Intent intent, TViewModel viewModel) where TViewModel : class
		{
			var key = Guid.NewGuid().ToString();
			ViewModelDictionary.Add(key, viewModel);
			intent.PutExtra(ParameterKeyName, key);
		}

		private static object TryGetViewModel(this Intent intent)
		{
			if (intent == null) throw new ArgumentNullException(nameof(intent));

			var stringExtra = intent.GetStringExtra(ParameterKeyName);

			intent.RemoveExtra(ParameterKeyName);

			if (string.IsNullOrEmpty(stringExtra)) return null;
			
			if (!ViewModelDictionary.ContainsKey(stringExtra)) return null;

			var obj = ViewModelDictionary[stringExtra];

			ViewModelDictionary.Remove(stringExtra);
			return obj;
		}
	}
}