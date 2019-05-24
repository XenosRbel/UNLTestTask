using UNLTestTask.Core.Models;
using UNLTestTask.Presentation.ViewModels.Contacts;
using Xamarin.Forms;

namespace UNLTestTask.ControlsBehavior
{
	internal class ContactDataSelector : DataTemplateSelector
	{
		public DataTemplate DefaultTemplate { get; set; }
		public DataTemplate WorkTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var obj = (ContactViewModel)item;

			return obj.Contact.PhoneType == ContactType.None ? DefaultTemplate : WorkTemplate;
		}
	}
}
