using System.Windows.Input;
using UNLTestTask.Core.Helpers;
using UNLTestTask.Core.Models;

namespace UNLTestTask.Core.Presentation.ViewModels
{
	public interface IContactDetailsViewModel
	{
		ICommand CallCommand { get; set; }
		ObservableObject<Contact> Contact { get; set; }
	}
}