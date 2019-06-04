using System;
using System.Collections.Generic;
using UIKit;

namespace UNLTestTask.Native.iOS.Views
{
	public class PhoneTypesPickerModel : UIPickerViewModel
	{
		private readonly IList<string> _phoneTypes;
		protected int _selectedIndex = 0;

		public PhoneTypesPickerModel(IList<string> items)
		{
			_phoneTypes = items ?? throw new ArgumentNullException(nameof(items));
		}

		public string SelectedItem => _phoneTypes[_selectedIndex];

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

		public override void Selected(UIPickerView picker, nint row, nint component)
		{
			_selectedIndex = (int)row;
		}
	}
}