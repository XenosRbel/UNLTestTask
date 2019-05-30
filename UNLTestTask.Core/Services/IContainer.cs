using UNLTestTask.Core.DataCore;

namespace UNLTestTask.Core.Services
{
	public interface IServiceContainer
	{
		IRepository GetRepository();
		IDialogService GetDialogService();
		IToastNotificationService GetToastNotificationService();
		IMainThreadService GetMainThreadService();
	}
}