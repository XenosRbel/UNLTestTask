using Cirrious.FluentLayouts.Touch;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using UNLTestTask.Core.Presentation.ViewModels;
using Xamarin.Forms.Internals;

namespace UNLTestTask.Native.iOS.Views
{
	[Register("EditContactUIViewController")]
	public class EditContactUiViewController : BaseUiViewController<IEditContactViewModel>, IUIPickerViewDelegate
	{
		private const int imageSize = 25;

		private UILabel _phoneErrorLabel;
		private UITextField _phoneField;
		private UITextField _nameField;
		private UILabel _nameLabel;
		private UILabel _phoneLabel;
		private UILabel _nameErrorLabel;
		private UIButton _submitBtn;
		private UIImageView _contactImage;
		private UIImageView _phoneImage;
		private UIPickerView _phoneTypePicker;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.LightGray;

			_phoneField = new UITextField { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
			_nameField = new UITextField { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };

			_nameLabel = new UILabel { Text = "Name" };
			_phoneLabel = new UILabel { Text = "Phone" };

			_nameErrorLabel = new UILabel { Text = "Isn't valid", TextColor = UIColor.Red };
			_phoneErrorLabel = new UILabel { Text = "Isn't valid", TextColor = UIColor.Red };

			_submitBtn = new UIButton();
			_submitBtn.SetTitle("Add Contact", UIControlState.Normal);

			_contactImage = new UIImageView { Image = UIImage.FromBundle("person_outline.png") };
			_phoneImage = new UIImageView { Image = UIImage.FromBundle("phone_black.png") };

			_phoneTypePicker = new UIPickerView();
			_phoneTypePicker.Model = new PhoneTypesPickerModel(ViewModel.PhoneTypes);
			_phoneTypePicker.Delegate = this;

			View.AddSubviews(
				_nameErrorLabel,
				_phoneErrorLabel,
				_phoneLabel,
				_phoneField,
				_nameLabel,
				_nameField,
				_submitBtn,
				_contactImage,
				_phoneImage,
				_phoneTypePicker);

			NavigationController.NavigationBar.Translucent = false;

			View.AddConstraints(
				_nameLabel.AtTopOf(View),
				_nameLabel.AtTrailingOf(View),
				_nameLabel.ToTrailingOf(_contactImage),

				_contactImage.Below(_nameLabel),
				_contactImage.AtLeadingOf(View),
				_contactImage.Width().EqualTo(imageSize),
				_contactImage.Height().EqualTo(imageSize),

				_nameField.Below(_nameLabel),
				_nameField.ToTrailingOf(_contactImage),
				_nameField.AtTrailingOf(View),

				_phoneLabel.Below(_nameErrorLabel),
				_phoneLabel.AtTrailingOf(View),
				_phoneLabel.ToTrailingOf(_contactImage),

				_phoneImage.Below(_phoneTypePicker),
				_phoneImage.AtLeadingOf(View),
				_phoneImage.Width().EqualTo(imageSize),
				_phoneImage.Height().EqualTo(imageSize),

				_phoneField.Below(_phoneTypePicker),
				_phoneField.ToTrailingOf(_phoneImage),
				_phoneField.AtTrailingOf(View),

				_phoneTypePicker.Below(_phoneLabel),
				_phoneTypePicker.AtLeadingOf(View),
				_phoneTypePicker.Height().EqualTo(80),

				_nameErrorLabel.Below(_nameField),
				_nameErrorLabel.AtTrailingOf(View),
				_nameErrorLabel.AtLeadingOf(View),

				_phoneErrorLabel.Below(_phoneField),
				_phoneErrorLabel.AtTrailingOf(View),
				_phoneErrorLabel.AtLeadingOf(View),
					
				_submitBtn.AtBottomOf(View),
				_submitBtn.AtLeadingOf(View),
				_submitBtn.AtTrailingOf(View));

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			_submitBtn.SetCommand("TouchUpInside", ViewModel.SubmitCommand);

			this.SetBinding(() => ViewModel.PhoneErrorMessage,
				() =>_phoneErrorLabel.Text, BindingMode.OneWay);

			this.SetBinding(() => ViewModel.NameErrorMessage,
				() => _nameErrorLabel.Text, BindingMode.OneWay);

			this.SetBinding(() => ViewModel.Name,
				() => _nameField.Text, BindingMode.TwoWay);

			this.SetBinding(() => ViewModel.PhoneNumber,
				() => _phoneField.Text, BindingMode.TwoWay);

			this.SetBinding(() => ViewModel.IsValid,
				() => _submitBtn.Enabled, BindingMode.OneWay);

			this.SetBinding(() => ViewModel.PhoneType, BindingMode.OneWay)
				.WhenSourceChanges(() =>
					{
						_phoneTypePicker.Select(ViewModel.PhoneTypes.IndexOf(ViewModel.PhoneType), 0, true);
					});
		}

		[Export("pickerView:didSelectRow:inComponent:")]
		private void Selected(UIPickerView pickerView, int row, int component)
		{
			var phoneType = ViewModel.PhoneTypes[row == -1 ? 0 : row];
			ViewModel.PhoneType = phoneType;
		}

		protected internal EditContactUiViewController(IEditContactViewModel viewModel) : base(viewModel)
		{
		}
	}
}