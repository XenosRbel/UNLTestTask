using System.Windows.Input;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Presentation.ViewModels.Contacts
{
	public class ContactViewModel : IContactViewModel
	{
		public ContactViewModel(IContactsViewModel contactsViewModel)
		{
			EditContactCommand = contactsViewModel.EditContactCommand;
			RemoveContactCommand = contactsViewModel.RemoveContactCommand;
		}

		public Contact Contact { get; set; }
		public ICommand EditContactCommand { get; set; }
		public ICommand RemoveContactCommand { get; set; }
	}
}
