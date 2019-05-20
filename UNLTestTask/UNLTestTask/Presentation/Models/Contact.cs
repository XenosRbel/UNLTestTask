using System;
using System.Collections.Generic;
using System.Text;

namespace UNLTestTask.Presentation.Models
{
    public class Contact
    {
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
		public ContactType PhoneType { get; set; }
    }

    public enum ContactType
    {
		None,
		WorkPhone
    }
}
