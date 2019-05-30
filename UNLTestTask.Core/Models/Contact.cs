using System;
using System.Collections.Generic;
using System.Text;

namespace UNLTestTask.Core.Models
{
	[Serializable]
	public class Contact : IBaseEntity
	{
		public string PhotoPath { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public ContactType PhoneType { get; set; }
		public int Id { get; set; }
	}

	public class ContactIdComparer : IEqualityComparer<Contact>
	{
		public bool Equals(Contact x, Contact y)
		{
			return x.Id == y.Id;
		}

		public int GetHashCode(Contact obj)
		{
			return obj.GetHashCode();
		}
	}

	public enum ContactType
	{
		None,
		WorkPhone
	}
}
