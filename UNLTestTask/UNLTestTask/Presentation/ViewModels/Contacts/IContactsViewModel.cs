using System.Windows.Input;
using UNLTestTask.Helpers;
using UNLTestTask.Models;

namespace UNLTestTask.Presentation.ViewModels.Contacts
{
	public interface IContactsViewModel
	{
		ObservableRangeCollection<ContactViewModel> ContactViewModelsItems { get; set; }
		ICommand AddContactCommand { get; }
		ICommand LoadCommand { get; }
		ICommand TappedCommand { get; }
		ICommand EditContactCommand { get; set; }
		ICommand RemoveContactCommand { get; set; }
	}
}