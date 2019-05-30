using System.Collections.ObjectModel;
using System.Windows.Input;
using UNLTestTask.Core.Helpers;

namespace UNLTestTask.Core.Presentation.ViewModels
{
	public interface IContactsViewModel
	{
		ObservableCollection<IContactViewModel> ContactViewModelsItems { get; set; }
		ICommand AddContactCommand { get; }
		ICommand LoadCommand { get; }
		ICommand ShowContactDetailsCommand{ get; }
		ICommand EditContactCommand { get; set; }
		ICommand RemoveContactCommand { get; set; }
		bool IsBusy { get; set; }
		bool IsCommandActive { get; set; }
	}
}