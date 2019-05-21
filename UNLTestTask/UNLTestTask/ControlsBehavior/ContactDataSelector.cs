using UNLTestTask.Models;
using Xamarin.Forms;

namespace UNLTestTask.ControlsBehavior
{
	public class ContactDataSelector : DataTemplateSelector
	{
		public DataTemplate DefaultTemplate { get; set; }
		public DataTemplate WorkTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var obj = (Contact)item;

			return obj.PhoneType == ContactType.None ? DefaultTemplate : WorkTemplate;
		}
	}
}
