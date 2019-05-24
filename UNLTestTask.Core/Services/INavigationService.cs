using System.Threading.Tasks;
using UNLTestTask.Core.Models;

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
