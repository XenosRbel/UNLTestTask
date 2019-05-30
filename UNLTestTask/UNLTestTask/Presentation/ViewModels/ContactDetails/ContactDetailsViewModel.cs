using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Core.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UNLTestTask.Forms.Presentation.ViewModels.ContactDetails
{
	public class ContactDetailsViewModel : IContactDetailsViewModel
	{

		public ContactDetailsViewModel(
			Contact contact)
		{
			Contact = new ObservableObject<Contact> { Property = contact ?? throw new ArgumentNullException(nameof(contact)) };

			Contact.Property.PhotoPath = Contact.Property.PhoneType == ContactType.None ? "tom.png" : "jerry.png";

			CallCommand = new Command(OnCall);
		}

		public ObservableObject<Contact> Contact { get; set; }
		public ICommand CallCommand { get; set; }

		private void OnCall()
		{
			var phoneNumber = Contact.Property.PhoneNumber;

			//Need to run in main thead
			Call(phoneNumber);
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
