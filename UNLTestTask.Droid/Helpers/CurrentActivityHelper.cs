using System;

namespace UNLTestTask.Droid.Helpers
{
	public static class CurrentActivityHelper
	{
		private static readonly ICurrentActivity _currentActivity;

		static CurrentActivityHelper()
		{
			_currentActivity = new CurrentActivity();
		}

		public static ICurrentActivity Current
		{
			get
			{
				var ret = _currentActivity ?? throw new NotImplementedException();
				return ret;
			}
		}
	}
}