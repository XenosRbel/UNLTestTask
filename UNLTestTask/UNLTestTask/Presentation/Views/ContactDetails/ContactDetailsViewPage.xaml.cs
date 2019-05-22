using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UNLTestTask.DataCore;
using UNLTestTask.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Presentation.Views.EditContact;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.ContactDetails
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsViewPage : ContentPage
    {
	    public ContactDetailsViewPage(IContactDetailsViewModel viewModel)
        {
	        InitializeComponent();

	        BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
		}
    }
}