namespace UNLTestTask.Core.Services
{
	public interface IToastNotificationService
	{
		void LongAlert(string message);
		void ShortAlert(string message);
	}
}
