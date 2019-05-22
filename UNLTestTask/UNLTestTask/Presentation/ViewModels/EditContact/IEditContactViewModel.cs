using System.Windows.Input;

namespace UNLTestTask.Presentation.ViewModels.EditContact
{
	public interface IEditContactViewModel
	{
		bool IsValid { get; set; }
		string Name { get; set; }
		string PhoneNumber { get; set; }
		string PhoneType { get; set; }
		string PhoneErrorMessage { get; set; }
		string NameErrorMessage { get; set; }
		string[] PhoneTypes { get; set; }
		ICommand SubmitCommand { get; set; }
	}
}