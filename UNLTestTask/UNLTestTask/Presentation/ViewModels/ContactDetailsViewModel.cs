using UNLTestTask.Helpers;
using UNLTestTask.Presentation.Models;

namespace UNLTestTask.Presentation.ViewModels
{
    internal class ContactDetailsViewModel
    {
        public ObservableObject<Contact> Contact { get; set; }
        public ContactDetailsViewModel(Contact contact)
        {
            Contact = new ObservableObject<Contact> { Property = contact };
        }
    }
}
