using System;
using System.Collections.Generic;
using System.Text;

namespace UNLTestTask.Validations
{
	public interface IBaseValidationRule<in T>
	{
		IReadOnlyList<string> Properties { get; }
		string ValidationMessage { get; set; }
		bool Check(T value);
	}
}
