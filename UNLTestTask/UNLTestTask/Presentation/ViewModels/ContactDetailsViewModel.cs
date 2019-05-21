using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using UNLTestTask.DataCore;
using UNLTestTask.Helpers;
using UNLTestTask.Models;
using UNLTestTask.Presentation.Views.EditContact;
using UNLTestTask.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UNLTestTask.Presentation.ViewModels
{
	public class ContactDetailsViewModel
	{
		private readonly INavigationService _navigationService;
		private readonly IRepository _repository;

		public ContactDetailsViewModel(INavigationService navigationService, IRepository repository,Contact contact)
		{
			_navigationService = navigationService ?? throw  new ArgumentNullException(nameof(navigationService));
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));

			Contact = new ObservableObject<Contact> { Property = contact };

			CallCommand = new Command(OnCall);
			EditContactCommand = new Command(OnEditContact);
			RemoveContactCommand = new Command(OnRemoved);
        }

		private async void OnRemoved()
		{
			var contacts = await _repository.GetAllAsync<Contact>();
			var contact = contacts.First(item => item.Equals(Contact.Property));
			contacts.Remove(contact);

			await _repository.RemoveAllAsync<Contact>();

			await _repository.AddOrUpdateAllAsync(contacts);

			await _navigationService.PopAsync();
		}

		public ObservableObject<Contact> Contact { get; set; }
		public ICommand CallCommand { get; set; }
		public ICommand EditContactCommand { get; set; }
		public ICommand RemoveContactCommand { get; set; }

		private void OnEditContact()
		{
			var contact = Contact.Property;
			_navigationService.PushEditContactAsync(contact);
		}

		private void OnCall()
		{
			var phoneNumber = Contact.Property.PhoneNumber;
			Device.BeginInvokeOnMainThread(async () => await Call(phoneNumber));
		}

		private async Task Call(string phoneNumber)
		{
			try
			{
				PhoneDialer.Open(phoneNumber);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	}
}
