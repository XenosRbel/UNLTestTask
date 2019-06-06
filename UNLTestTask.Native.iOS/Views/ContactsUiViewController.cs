using System.Threading.Tasks;
using UIKit;
using Foundation;
using Cirrious.FluentLayouts.Touch;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Native.iOS.Views.Adapters;

namespace UNLTestTask.Native.iOS.Views
{
	[Register("ContactsUIViewController")]
	public class ContactsUiViewController : BaseUiViewController<IContactsViewModel>
	{
		private UIButton _addContactUiButton;
		private UITableView _contactsList;
		private ContactCellSource _viewSource;
		private UIRefreshControl _refreshControl;

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.LightGray;

			_addContactUiButton = new UIButton(UIButtonType.RoundedRect);
			_addContactUiButton.BackgroundColor = UIColor.Cyan;
			_addContactUiButton.SetTitle("Add contact", UIControlState.Normal);

			_viewSource = new ContactCellSource(ViewModel.ContactViewModelsItems, ViewModel.ShowContactDetailsCommand);
			_refreshControl = new UIRefreshControl();

			_contactsList = new UITableView(View.Bounds);
			_contactsList.Source = _viewSource;
			_contactsList.RefreshControl = _refreshControl;

			View.AddSubviews(_addContactUiButton, _contactsList);

			NavigationController.NavigationBar.Translucent = false;

			View.AddConstraints(
				_addContactUiButton.AtBottomOf(View),
				_addContactUiButton.WithSameWidth(View),
				_addContactUiButton.Height().EqualTo(50),

				_contactsList.AtTopOf(View),
				_contactsList.AtTrailingOf(View),
				_contactsList.AtLeadingOf(View),
				_contactsList.Bottom().EqualTo().TopOf(_addContactUiButton));

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			_addContactUiButton.SetCommand("TouchUpInside", ViewModel.AddContactCommand);
			
			this.SetBinding(() => _contactsList.RefreshControl.Refreshing)
				.ObserveSourceEvent("ValueChanged")
				.WhenSourceChanges(RefreshContacts);

			ViewModel.ContactViewModelsItems.CollectionChanged += (sender, args) => RefreshContacts();
		}

		public override async void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			await ViewModel.LoadContacts();

			RefreshContacts();
		}

		private void RefreshContacts()
		{
			_contactsList?.ReloadData();
			_contactsList?.RefreshControl.EndRefreshing();
		}

		protected internal ContactsUiViewController(IContactsViewModel viewModel) : base(viewModel)
		{
		}
	}
}