using System.Windows.Input;
using UNLTestTask.Core.Models;

namespace UNLTestTask.Core.Presentation.ViewModels
{
	public interface IContactViewModel
	{
		Contact Contact { get; set; }
		ICommand EditContactCommand { get; set; }
		ICommand RemoveContactCommand { get; set; }
	}
}