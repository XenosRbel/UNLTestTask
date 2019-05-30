using UNLTestTask.Core.Presentation.ViewModels;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Forms.Presentation.Views.ContactDetails
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