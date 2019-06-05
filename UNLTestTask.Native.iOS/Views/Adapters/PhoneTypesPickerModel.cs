using System;
using System.Collections.Generic;
using UIKit;

namespace UNLTestTask.Native.iOS.Views
{
	public class PhoneTypesPickerModel : UIPickerViewModel
	{
		private readonly IList<string> _phoneTypes;

		public PhoneTypesPickerModel(IList<string> items)
		{
			_phoneTypes = items ?? throw new ArgumentNullException(nameof(items));
		}

		public override nint GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView picker, nint component)
		{
			return _phoneTypes.Count;
		}

		public override string GetTitle(UIPickerView picker, nint row, nint component)
		{
			return _phoneTypes[(int)row];
		}
	}
}