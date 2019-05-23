namespace UNLTestTask.Services
{
	public interface IToastNotificationService
	{
		void LongAlert(string message);
		void ShortAlert(string message);
	}
}
