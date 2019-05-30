using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace UNLTestTask.Droid.Helpers
{
	public interface ICurrentActivity
	{
		Activity Activity { get; set; }
		Context AppContext { get; }
		event CurrentActivity.StateChangedHandler ActivityStateChanged;
		void Init(Application application);
		void Init(Activity activity);
	}
}