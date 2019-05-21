using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UNLTestTask.DataCore;
using UNLTestTask.Models;
using UNLTestTask.Services;
using Xamarin.Forms;
using static System.String;

namespace UNLTestTask.Presentation.ViewModels
{
	public class EditContactViewModel : BaseViewModel
	{
		private readonly IRepository _repository;
		private readonly INavigationService _navigationService;
		private string _name;
		private string _phoneNumber;
		private string _phoneType;
		private string[] _phoneTypes;
		private bool _isValid;
		private int _contactId;
		
		public EditContactViewModel(IRepository repository, INavigationService navigationService, Contact contact = null)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

			SubmitCommand = new Command(OnSubmit, () => IsValid);

			Name = contact?.Name;
			PhoneNumber = contact?.PhoneNumber;
			PhoneType = contact?.PhoneType.ToString();
			PhoneTypes = Enum.GetNames(typeof(ContactType));
			_contactId = contact?.Id ?? -1;

			IsValid = true;
		}

		public ICommand SubmitCommand { get; set; }
		public string Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}

		public string PhoneType
		{
			get => _phoneType;
			set => SetProperty(ref _phoneType, value);
		}

		public string[] PhoneTypes
		{
			get => _phoneTypes;
			set => SetProperty(ref _phoneTypes, value);
		}

		public bool IsValid
		{
			get => _isValid;
			set => SetProperty(ref _isValid, value);
		}

		private async void OnSubmit()
		{
			Enum.TryParse(PhoneType, out ContactType contactType);

			var contact = new Contact
			{
				PhoneType = contactType,
				Name = Name,
				PhoneNumber = PhoneNumber,
				PhotoPath = string.Empty,
				Id = _contactId
			};

			var contacts = await _repository.GetAllAsync<Contact>();
			if (contacts.Contains(contact, new ContactIdComparer()))
			{
				var entity = contacts.First(item => item.Id == contact.Id);
				entity.Id = contact.Id;
				entity.Name = contact.Name;
				entity.PhoneNumber = contact.PhoneNumber;
				entity.PhoneType = contact.PhoneType;
				entity.PhotoPath = contact.PhotoPath;
			}
			else
			{
				contacts.Add(contact);
			}

			await _repository.AddOrUpdateAllAsync(contacts);
		}
	}
}
