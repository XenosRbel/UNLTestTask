using UNLTestTask.Core.Presentation.ViewModels;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Forms.Presentation.Views.Contacts
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