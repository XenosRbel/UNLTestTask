using UIKit;
using Foundation;
using Cirrious.FluentLayouts.Touch;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Native.iOS.Views
{
	[Register("ContactsUIViewController")]
	public class ContactsUiViewController : BaseUiViewController<IContactsViewModel>
	{
		private UIButton _addContactUiButton;
		private UITableView _contactsList;

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.LightGray;
			await ViewModel.LoadContacts();

			_addContactUiButton = new UIButton(UIButtonType.RoundedRect);
			_addContactUiButton.BackgroundColor = UIColor.Cyan;
			_addContactUiButton.SetTitle("Add contact", UIControlState.Normal);

			_contactsList = new UITableView(View.Bounds);
			_contactsList.Source = new TableSource(ViewModel.ContactViewModelsItems);

			View.AddSubviews(_addContactUiButton, _contactsList);

			NavigationController.NavigationBar.Translucent = false;

			View.AddConstraints(
				_addContactUiButton.AtBottomOf(View),
				_addContactUiButton.WithSameWidth(View),
				_addContactUiButton.Height().EqualTo(50),

				_contactsList.AtTopOf(View),
				_contactsList.AtLeftOf(View),
				_contactsList.AtRightOf(View),
				_contactsList.Bottom().EqualTo().TopOf(_addContactUiButton));

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			_addContactUiButton.SetCommand("TouchUpInside", ViewModel.AddContactCommand);

			//_contactsList.Source = ViewModel.ContactViewModelsItems.GetTableViewSource(CreateCellDelegate);
		}

		private void CreateCellDelegate(UITableViewCell tableView, IContactViewModel viewModel, NSIndexPath indexPath)
		{
			var castedCell = (ContactUiTableViewCell)tableView;
			castedCell.Name.Text = viewModel.Contact.Name;
			castedCell.Phone.Text = viewModel.Contact.PhoneNumber;

			castedCell.Photo.Image = UIImage.FromBundle(viewModel.Contact.PhoneType == ContactType.None ? "tom.png" : "jerry.png");
		}

		protected internal ContactsUiViewController(IContactsViewModel viewModel) : base(viewModel)
		{
		}
	}
}