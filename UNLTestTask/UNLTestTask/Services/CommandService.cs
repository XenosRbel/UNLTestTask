using System;
using UNLTestTask.Core.Services;
using Xamarin.Forms;

namespace UNLTestTask.Services
{
	internal class CommandService : ICommandService
	{
		private Command _command;

		public CommandService(Action action)
		{
			_command = new Command(action);
		}

		public Command Command { get => _command; set => _command = value; }

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _command.CanExecute(parameter);
		}

		public void ChangeCanExecute()
		{
			_command.ChangeCanExecute();
		}

		public void Execute(object parameter)
		{
			_command.Execute(parameter);
		}
	}
}
