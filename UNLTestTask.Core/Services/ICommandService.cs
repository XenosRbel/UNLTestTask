using System;

namespace UNLTestTask.Core.Services
{
	public interface ICommandService
	{
		event EventHandler CanExecuteChanged;

		bool CanExecute(object parameter);
		void ChangeCanExecute();
		void Execute(object parameter);
	}
}
