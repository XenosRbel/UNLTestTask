using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UNLTestTask.Services
{
	public interface IDialogService
	{
		Task DisplayAlertAsync(string title, string message, string cancel);
		Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel);
	}
}
