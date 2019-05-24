using UNLTestTask.Core.DataCore;
using UNLTestTask.Core.Services;

namespace UNLTestTask.Services
{
	public interface IContainer
	{
		IRepository GetRepository();
		INavigationService GetNavigationService();
		IDialogService GetDialogService();
		IToastNotificationService GetToastNotificationService();
		IMainThreadService GetMainThreadService();
		ICommandService GetCommandService();
	}
}