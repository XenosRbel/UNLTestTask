using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace UNLTestTask.Droid.Helpers
{
	internal class ActivityLifecycleListener : Java.Lang.Object, Application.IActivityLifecycleCallbacks
	{
		private Context _context;

		public Context Context
		{
			get => _context ?? Application.Context;
			private set => _context = value;
		}

		public Activity Activity { get; set; }

		private static CurrentActivity CurrentActivity => (CurrentActivity) CurrentActivityHelper.Current;

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			Activity = activity;
			CurrentActivity.OnStateChanged(activity, ActivityState.Created);
		}

		public void OnActivityDestroyed(Activity activity)
		{
			CurrentActivity.OnStateChanged(activity, ActivityState.Destroyed);
		}

		public void OnActivityPaused(Activity activity)
		{
			Activity = activity;
			CurrentActivity.OnStateChanged(activity, ActivityState.Paused);
		}

		public void OnActivityResumed(Activity activity)
		{
			Activity = activity;
			CurrentActivity.OnStateChanged(activity, ActivityState.Resumed);
		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{
			CurrentActivity.OnStateChanged(activity, ActivityState.SaveInstanceState);
		}

		public void OnActivityStarted(Activity activity)
		{
			CurrentActivity.OnStateChanged(activity, ActivityState.Started);
		}

		public void OnActivityStopped(Activity activity)
		{
			CurrentActivity.OnStateChanged(activity, ActivityState.Stopped);
		}
	}
}	