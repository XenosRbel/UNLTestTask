using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Core.Services;
using UNLTestTask.Presentation.ViewModels.Contacts;
using Xamarin.Forms;

namespace UNLTestTask.Forms.Presentation.ViewModels.Contacts
{
	public class ContactsViewModel : BaseViewModel, IContactsViewModel
	{
		private readonly IRepository _repository;
		private readonly INavigationService _navigationService;
		private readonly IDialogService _dialogService;
		private readonly IToastNotificationService _toastNotificationService;
		private bool _isCommandActive;

		public ContactsViewModel(IRepository repository,
			INavigationService navigationService,
			IDialogService dialogService,
			IToastNotificationService toastNotificationService)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
			_dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
			_toastNotificationService = toastNotificationService ?? throw new ArgumentNullException(nameof(toastNotificationService));

			LoadCommand = new Command(async () => await LoadContacts());

			ShowContactDetailsCommand = new Command(OnItemTapped);

			AddContactCommand = new Command(OnAddContact, (o) => _isCommandActive);
			EditContactCommand = new Command(OnEditContact);
			RemoveContactCommand = new Command(OnRemoved);

			ContactViewModelsItems = new ObservableCollection<IContactViewModel>();

			IsCommandActive = true;
		}

		public ObservableCollection<IContactViewModel> ContactViewModelsItems { get; set; }
		public ICommand LoadCommand { get; private set; }
		public ICommand ShowContactDetailsCommand { get; private set; }
		public ICommand AddContactCommand { get; private set; }
		public ICommand EditContactCommand { get; set; }
		public ICommand RemoveContactCommand { get; set; }
		public bool IsCommandActive
		{
			get => _isCommandActive;
			set
			{
				SetProperty(ref _isCommandActive, value);
				((Command)AddContactCommand).ChangeCanExecute();
			}
		}

		private async void OnItemTapped(object obj)
		{
			var contact = (ContactViewModel)obj;

			await _navigationService.PushContactDetailsPageAsync(contact.Contact);
		}

		private async void OnAddContact(object obj = null)
		{
			IsCommandActive = false;

			await _navigationService.PushEditContactAsync();

			IsCommandActive = true;
		}

		private async void OnRemoved(object obj)
		{
			var contactViewModel = (ContactViewModel)obj;
			var objContact = contactViewModel.Contact;

			var dialogResult = await _dialogService.DisplayAlertAsync("Remove contact",
				$"Are you sure you want to remove {objContact.Name} ?",
				"Yes", "No");

			if (!dialogResult) return;

			var contacts = await _repository.GetAllAsync<Contact>();
			var contact = contacts.First(item => item.Id == objContact.Id);
			contacts.Remove(contact);

			await _repository.RemoveAllAsync<Contact>();
			await _repository.AddAllAsync(contacts);

			LoadContacts();

			_toastNotificationService.LongAlert("Contact successfully removed!");
		}

		private void OnEditContact(object obj)
		{
			var contactViewModel = (IContactViewModel)obj;
			var objContact = contactViewModel.Contact;
			_navigationService.PushEditContactAsync(objContact);
		}

		public async Task LoadContacts()
		{
			IsBusy = true;

			try
			{
				ContactViewModelsItems.Clear();

				var repositoryContacts = await _repository.GetAllAsync<Contact>();
				var contactVModels = new List<IContactViewModel>();

				foreach (var contact in repositoryContacts)
				{
					contactVModels.Add(new ContactViewModel(this)
					{
						Contact = contact
					});
				}

				contactVModels.ToList().ForEach(item => ContactViewModelsItems.Add(item));
				//ContactViewModelsItems.AddRange(contactVModels);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
