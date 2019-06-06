using Cirrious.FluentLayouts.Touch;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Native.iOS.Views
{
	[Register("ContactDetailsUIViewController")]
	public class ContactDetailsUiViewController : BaseUiViewController<IContactDetailsViewModel>
	{
		private UIImageView _contactPhoto;
		private UILabel _nameContact;
		private UILabel _phoneContact;
		private UIButton _callToContact;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.LightGray;

			_contactPhoto = new UIImageView { Image = UIImage.FromBundle(ViewModel.Contact.Property.PhotoPath) };

			_nameContact = new UILabel { Text = ViewModel.Contact.Property.Name };
			_phoneContact = new UILabel { Text = ViewModel.Contact.Property.PhoneNumber };

			_callToContact = new UIButton(UIButtonType.RoundedRect);
			_callToContact.SetTitle("Call", UIControlState.Selected);

			View.AddSubviews(
				_contactPhoto,
				_callToContact,
				_phoneContact,
				_nameContact);

			NavigationController.NavigationBar.Translucent = false;
			View.AddConstraints(
				_contactPhoto.AtTopOf(View),
				_contactPhoto.Height().EqualTo(80),
				_contactPhoto.Width().EqualTo(80),
				_contactPhoto.CenterX().EqualTo().CenterXOf(View),

				_nameContact.Below(_contactPhoto),
				_nameContact.AtLeftOf(View),
				_nameContact.AtRightOf(View),

				_phoneContact.Below(_nameContact),
				_phoneContact.AtLeftOf(View),
				_phoneContact.AtRightOf(View),

				_callToContact.AtBottomOf(View),
				_callToContact.AtLeadingOf(View),
				_callToContact.AtTrailingOf(View));

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			_callToContact.SetCommand(ViewModel.CallCommand);
		}

		protected internal ContactDetailsUiViewController(IContactDetailsViewModel viewModel) : base(viewModel)
		{
		}
	}
}