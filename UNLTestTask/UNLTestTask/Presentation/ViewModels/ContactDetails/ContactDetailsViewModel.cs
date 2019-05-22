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

namespace UNLTestTask.Presentation.ViewModels.ContactDetails
{
	public class ContactDetailsViewModel : IContactDetailsViewModel
	{
		private readonly INavigationService _navigationService;
		private readonly IRepository _repository;

		public ContactDetailsViewModel(INavigationService navigationService, IRepository repository, Contact contact)
		{
			_navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));

			Contact = new ObservableObject<Contact> { Property = contact ?? throw new ArgumentNullException(nameof(contact))};

			Contact.Property.PhotoPath = Contact.Property.PhoneType == ContactType.None ? "tom.png" : "jerry.png";

			CallCommand = new Command(OnCall);
		}

		public ObservableObject<Contact> Contact { get; set; }
		public ICommand CallCommand { get; set; }
		
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
