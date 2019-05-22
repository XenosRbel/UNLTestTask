using System;
using UNLTestTask.DataCore;
using UNLTestTask.Models;
using UNLTestTask.Presentation.ViewModels.EditContact;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.EditContact
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditContactPage : ContentPage
	{
		public EditContactPage(IEditContactViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
		}
	}
}