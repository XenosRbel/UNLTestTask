using System.Windows.Input;
using UNLTestTask.Core.Helpers;

namespace UNLTestTask.Core.Presentation.ViewModels
{
	public interface IContactsViewModel
	{
		ObservableRangeCollection<IContactViewModel> ContactViewModelsItems { get; set; }
		ICommand AddContactCommand { get; }
		ICommand LoadCommand { get; }
		ICommand TappedCommand { get; }
		ICommand EditContactCommand { get; set; }
		ICommand RemoveContactCommand { get; set; }
		//RelayCommand<object> ContactCommand { get; set; }
	}
}