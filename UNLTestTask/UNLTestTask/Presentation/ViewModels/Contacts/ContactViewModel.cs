using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UNLTestTask.Helpers;
using UNLTestTask.Models;

namespace UNLTestTask.Presentation.ViewModels.Contacts
{
	public class ContactViewModel
	{
		public ContactViewModel(IContactsViewModel contactsViewModel)
		{
			EditContactCommand = contactsViewModel.EditContactCommand;
			RemoveContactCommand = contactsViewModel.RemoveContactCommand;
		}

		public Contact Contact{ get; set; }
		public ICommand EditContactCommand { get; set; }
		public ICommand RemoveContactCommand { get; set; }
	}
}
