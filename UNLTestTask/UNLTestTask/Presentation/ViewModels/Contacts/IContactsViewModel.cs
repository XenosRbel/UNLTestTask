using System.Windows.Input;
using UNLTestTask.Helpers;
using UNLTestTask.Models;

namespace UNLTestTask.Presentation.ViewModels.Contacts
{
	public interface IContactsViewModel
	{
		ICommand AddContactCommand { get; }
		ObservableRangeCollection<Contact> ContactItems { get; set; }
		ICommand LoadCommand { get; }
		ICommand TappedCommand { get; }
	}
}