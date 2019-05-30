using System;
using Android.App;
using Android.Content;

namespace UNLTestTask.Droid.Helpers
{
	public class CurrentActivity : ICurrentActivity
	{
		private Application _application;
		private Activity _activity;
		private ActivityLifecycleListener _lifecycleListener;
		
		public Activity Activity {
			get => _lifecycleListener?.Activity;
			set
			{
				if (_lifecycleListener == null)
				{
					Init(value);
				}
			}
		}
		public Context AppContext => Application.Context;

		public delegate void StateChangedHandler(object sender, ActivityEventArgs eventArgs);

		public event StateChangedHandler ActivityStateChanged;

		public void Init(Application application)
		{
			_application = application ?? throw new ArgumentNullException(nameof(application));

			if (_lifecycleListener != null) return;

			_lifecycleListener = new ActivityLifecycleListener();
			_application.RegisterActivityLifecycleCallbacks(_lifecycleListener);
		}

		public void Init(Activity activity)
		{
			_activity = activity ?? throw new ArgumentNullException(nameof(activity));

			Init(_activity.Application);
			_lifecycleListener.Activity = _activity;
		}

		internal void OnStateChanged(Activity activity, ActivityState ev)
		{
			var eventArgs = new ActivityEventArgs(activity, ev);

			ActivityStateChanged?.Invoke(this, eventArgs);
		}
	}
}