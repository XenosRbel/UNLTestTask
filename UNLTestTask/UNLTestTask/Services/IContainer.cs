using UNLTestTask.DataCore;

namespace UNLTestTask.Services
{
	public interface IContainer
	{
		IRepository GetRepository();
		INavigationService GetNavigationService();
	}
}