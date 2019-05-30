using System;
using Android.App;

namespace UNLTestTask.Droid.Helpers
{
	public class ActivityEventArgs : EventArgs
	{
		internal ActivityEventArgs(Activity activity, ActivityState activityState)
		{
			State = activityState;
			Activity = activity;
		}

		public ActivityState State { get; private set; }
		public Activity Activity { get; private set; }
	}
}