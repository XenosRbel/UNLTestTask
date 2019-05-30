using System;

namespace UNLTestTask.Core.Services
{
	public interface IMainThreadService
	{
		void BeginInvokeOnMainThread(Action action);
	}
}