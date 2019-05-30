using System;
using Xamarin.Forms;

namespace UNLTestTask.Forms.Presentation.Views
{
	public abstract class ContentPageBase<TViewModel> : ContentPage where TViewModel : class
	{
		protected ContentPageBase(TViewModel viewModel)
		{
			ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
		}

		public TViewModel ViewModel
		{
			get => BindingContext as TViewModel;
			set => BindingContext = value;
		}
	}
}