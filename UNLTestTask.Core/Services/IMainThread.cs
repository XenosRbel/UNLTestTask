using System;

namespace UNLTestTask.Services
{
	public interface IMainThreadService
	{
		void BeginInvokeOnMainThread(Action action);
	}
}