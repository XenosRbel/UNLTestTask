using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Core.Services;
using UNLTestTask.Core.Validations;
using UNLTestTask.Core.Validations.Rules;
using Xamarin.Forms;

namespace UNLTestTask.Forms.Presentation.ViewModels.EditContact
{
	public class EditContactViewModel : BaseViewModel, IEditContactViewModel
	{
		private readonly IRepository _repository;
		private readonly INavigationService _navigationService;
		private readonly IToastNotificationService _toastNotificationService;
		private readonly ValidableObject<Contact> _validableContact;
		private readonly int _contactId;
		private string _nameErrorMessage;
		private string _phoneErrorMessage;
		private string _name;
		private string _phoneNumber;
		private string _phoneType;
		private string[] _phoneTypes;
		private bool _isValid;

		public EditContactViewModel(IRepository repository,
			INavigationService navigationService,
			IToastNotificationService toastNotificationService,
			Contact contact = null)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
			_toastNotificationService = toastNotificationService ?? throw new ArgumentNullException(nameof(toastNotificationService));

			var rules = BuildValidationRules();
			_validableContact = new ValidableObject<Contact>(rules);

			SubmitCommand = new Command(OnSubmit, () => IsValid);

			_name = contact?.Name ?? string.Empty;
			_phoneNumber = contact?.PhoneNumber ?? string.Empty;
			_phoneType = contact?.PhoneType.ToString() ?? string.Empty;
			PhoneTypes = Enum.GetNames(typeof(ContactType));
			_contactId = contact?.Id ?? -1;

			_nameErrorMessage = string.Empty;
			_phoneErrorMessage = string.Empty;
		}

		public ICommand SubmitCommand { get; set; }

		public string Name
		{
			get => _name;
			set
			{
				SetProperty(ref _name, value);
				Validate();
			}
		}

		public string PhoneNumber
		{
			get => _phoneNumber;
			set
			{
				SetProperty(ref _phoneNumber, value);
				Validate();
			}
		}

		public string PhoneType
		{
			get => _phoneType;
			set
			{
				SetProperty(ref _phoneType, value);
				Validate();
			}
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

		public string PhoneErrorMessage
		{
			get => _phoneErrorMessage;
			set => SetProperty(ref _phoneErrorMessage, value);
		}

		public string NameErrorMessage
		{
			get => _nameErrorMessage;
			set => SetProperty(ref _nameErrorMessage, value);
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

			await _repository.AddAllAsync(contacts);

			_toastNotificationService.LongAlert($"Contact successfully updated!");

			await _navigationService.PopAsync();
		}

		private void Validate()
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

			var result = _validableContact.Validate(contact);
			IsValid = result.IsValid;

			DisplayErrorMessages(result);
		}

		private void DisplayErrorMessages(ValidationResult result)
		{
			NameErrorMessage = PhoneErrorMessage = string.Empty;
			foreach (var itemError in result.Errors)
			{
				foreach (var propertyName in itemError.Key)
				{
					switch (propertyName)
					{
						case nameof(Contact.Name):
							NameErrorMessage += $"{itemError.Value}";
							break;
						case nameof(Contact.PhoneNumber):
							PhoneErrorMessage += $"{itemError.Value}";
							break;
						default:
							break;
					}
				}
			}
		}

		private IReadOnlyList<IBaseValidationRule<Contact>> BuildValidationRules()
		{
			return new List<IBaseValidationRule<Contact>>
			{
				new IsNameNotNullOrWhiteSpace()
				{
					ValidationMessage = "Name isn't valid"
				},
				new IsPhoneNumberNotNullOrWhiteSpace()
				{
					ValidationMessage = "Phone isn't confirmed"
				}
			};
		}
	}
}
