using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UNLTestTask.Models;

namespace UNLTestTask.Services
{
	public interface INavigationService
	{
		Task PopAsync();
		Task PushContactDetailsPageAsync(Contact contact);
		Task PushContactsPageAsync();
		Task PushEditContactAsync();
		Task PushEditContactAsync(Contact contact);
	}
}
