using System;
using System.Collections.Generic;
using System.Text;
using UNLTestTask.Presentation.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UNLTestTask.Helpers
{
	public class ContactDataSelector : DataTemplateSelector
	{
		public DataTemplate DefaultTemplate { get; set; }
		public DataTemplate WorkTemplate { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var obj = (Contact) item;

			return obj.PhoneType == ContactType.None ? DefaultTemplate : WorkTemplate;
		}
	}
}
