using System;
using UNLTestTask.DataCore;
using UNLTestTask.Models;
using UNLTestTask.Presentation.ViewModels;
using UNLTestTask.Presentation.Views.ContactDetails;
using UNLTestTask.Presentation.Views.EditContact;
using UNLTestTask.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsViewPage : ContentPage
    {
        private readonly ContactsViewModel _viewModel;

		public ContactsViewPage(ContactsViewModel viewModel)
		{
			InitializeComponent();

			_viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
			BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadCommand.Execute(null);
        }
    }
}