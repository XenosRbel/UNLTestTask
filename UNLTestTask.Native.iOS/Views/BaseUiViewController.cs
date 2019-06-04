using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace UNLTestTask.Native.iOS.Views
{
	public class BaseUiViewController<TViewModel> : UIViewController where TViewModel : class
	{
		protected TViewModel ViewModel { get; }

		protected BaseUiViewController(TViewModel viewModel)
		{
			ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
		}
	}
}