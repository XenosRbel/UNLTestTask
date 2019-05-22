using System.Windows.Input;
using UNLTestTask.Helpers;
using UNLTestTask.Models;

namespace UNLTestTask.Presentation.ViewModels.ContactDetails
{
	public interface IContactDetailsViewModel
	{
		ICommand CallCommand { get; set; }
		ObservableObject<Contact> Contact { get; set; }
		ICommand EditContactCommand { get; set; }
		ICommand RemoveContactCommand { get; set; }
	}
}