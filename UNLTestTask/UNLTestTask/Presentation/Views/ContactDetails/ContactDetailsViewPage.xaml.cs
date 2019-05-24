using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UNLTestTask.DataCore;
using UNLTestTask.Presentation.ViewModels.ContactDetails;
using UNLTestTask.Presentation.Views.EditContact;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.ContactDetails
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsViewPage
	{
	    public ContactDetailsViewPage(IContactDetailsViewModel viewModel) : base(viewModel)
        {
	        InitializeComponent();
		}
    }
}