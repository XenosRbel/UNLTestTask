using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UNLTestTask.Core.Helpers
{
	public class AsyncDelegateCommand : ICommand
	{
		protected readonly Predicate<object> _canExecute;
		protected readonly Func<object, Task> _asyncExecute;

		public event EventHandler CanExecuteChanged;

		public AsyncDelegateCommand(Func<object, Task> asyncExecute,
			Predicate<object> canExecute = null)
		{
			_asyncExecute = asyncExecute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecute == null)
			{
				return true;
			}

			return _canExecute(parameter);
		}

		public async void Execute(object parameter)
		{
			await ExecuteAsync(parameter);
		}

		protected virtual async Task ExecuteAsync(object parameter)
		{
			await _asyncExecute(parameter);
		}
	}
}
