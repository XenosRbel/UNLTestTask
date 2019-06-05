using System.Collections.Generic;
using UIKit;
using Foundation;
using Cirrious.FluentLayouts.Touch;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Native.iOS.Views.Adapters;

namespace UNLTestTask.Native.iOS.Views
{
	[Register("ContactsUIViewController")]
	public class ContactsUiViewController : BaseUiViewController<IContactsViewModel>, IUITableViewDelegate
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
			_contactsList.Source = new ContactCellSource(ViewModel.ContactViewModelsItems);
			_contactsList.Delegate = this;

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
		}

		[Export("tableView:didSelectRowAtIndexPath:")]
		private void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			ViewModel.ShowContactDetailsCommand.Execute(ViewModel.ContactViewModelsItems[indexPath.Row]);
		}

		[Export("tableView:editActionsForRowAtIndexPath:")]
		public UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
		{
			var rowActions = new List<UITableViewRowAction>();

			rowActions.Add(UITableViewRowAction.Create(UITableViewRowActionStyle.Normal,
				"Edit",
				(action, path) =>
				{
					var selectedItemRow = ViewModel.ContactViewModelsItems[indexPath.Row];
					selectedItemRow.EditContactCommand.Execute(selectedItemRow);
				}));

			rowActions.Add(UITableViewRowAction.Create(UITableViewRowActionStyle.Destructive,
				"Remove",
				(action, path) =>
				{
					var selectedItemRow = ViewModel.ContactViewModelsItems[indexPath.Row];
					selectedItemRow.RemoveContactCommand.Execute(selectedItemRow);
				}));

			return rowActions.ToArray();
		}

		protected internal ContactsUiViewController(IContactsViewModel viewModel) : base(viewModel)
		{
		}
	}
}