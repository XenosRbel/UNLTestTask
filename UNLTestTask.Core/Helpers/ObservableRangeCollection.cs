using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UNLTestTask.Core.Helpers
{
	public class ObservableRangeCollection<T> : ObservableCollection<T>
	{
		public ObservableRangeCollection() : base()
		{
		}

		public ObservableRangeCollection(IEnumerable<T> collection) : base(collection)
		{
		}

		public void AddRange(IEnumerable<T> collection, [CallerMemberName] string propertyName = "")
		{
			if (collection == null)
				throw new ArgumentNullException(nameof(collection));

			CheckReentrancy();

			var startIndex = Count;
			var changedItems = collection is List<T> list ? list : new List<T>(collection);
			foreach (var i in changedItems)
				Items.Add(i);

			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));

			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startIndex));
		}
	}
}
