using System;
using System.Collections.Generic;
using UIKit;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Native.iOS.Views
{
	public class PhoneTypesPickerModel : UIPickerViewModel
	{
		private readonly IEditContactViewModel _contactViewModel;
		private readonly IReadOnlyList<string> _phoneTypes;

		public PhoneTypesPickerModel(IEditContactViewModel viewModel)
		{
			_contactViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
			_phoneTypes = _contactViewModel.PhoneTypes;
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

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			var phoneType = _contactViewModel.PhoneTypes[row == -1 ? 0 : row];
			_contactViewModel.PhoneType = phoneType;
		}
	}
}