using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UNLTestTask.Presentation.ViewModels.ContactDetails
{
	public class ContactDetailsViewModel : IContactDetailsViewModel
	{
		private readonly IMainThreadService _mainThreadService;

		public ContactDetailsViewModel(
			IMainThreadService mainThreadService,
			Contact contact)
		{
			_mainThreadService = mainThreadService ?? throw new ArgumentNullException(nameof(mainThreadService));

			Contact = new ObservableObject<Contact> { Property = contact ?? throw new ArgumentNullException(nameof(contact))};

			Contact.Property.PhotoPath = Contact.Property.PhoneType == ContactType.None ? "tom.png" : "jerry.png";

			CallCommand = new Command(OnCall);
		}

		public ObservableObject<Contact> Contact { get; set; }
		public ICommand CallCommand { get; set; }
		
		private void OnCall()
		{
			var phoneNumber = Contact.Property.PhoneNumber;
			_mainThreadService.BeginInvokeOnMainThread(() => Call(phoneNumber));
		}

		private static void Call(string phoneNumber)
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
