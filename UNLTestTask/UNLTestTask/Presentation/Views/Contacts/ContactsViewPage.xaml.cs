using System;
using UNLTestTask.DataCore;
using UNLTestTask.Models;
using UNLTestTask.Presentation.ViewModels.Contacts;
using UNLTestTask.Presentation.Views.ContactDetails;
using UNLTestTask.Presentation.Views.EditContact;
using UNLTestTask.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.Contacts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsViewPage
    {
	    public ContactsViewPage(IContactsViewModel viewModel) : base(viewModel)
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.LoadCommand.Execute(null);
        }
    }
}