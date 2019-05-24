using System.Collections.Generic;

namespace UNLTestTask.Core.Validations
{
	public interface IBaseValidationRule<in T>
	{
		IReadOnlyList<string> Properties { get; }
		string ValidationMessage { get; set; }
		bool Check(T value);
	}
}
