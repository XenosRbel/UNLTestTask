using System;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Droid.Adapters;
using UNLTestTask.Droid.Services;

namespace UNLTestTask.Droid
{
	[Activity(Label = "ContactsPage")]
	public class ContactsPage : BaseActivity<IContactsViewModel>	
	{
		private Button _addContactButton;
		private ListView _contactsListView;
		private ContactAdapter _contactAdapter;
		private SwipeRefreshLayout _refreshLayout;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			DispatcherHelper.Initialize();
			SetContentView(Resource.Layout.contacts_page);
			_contactAdapter = new ContactAdapter(this);
			this.SetBinding(() => ViewModel.ContactViewModelsItems,
				() => _contactAdapter.Contacts, BindingMode.OneWay);

			_contactsListView = FindViewById<ListView>(Resource.Id.contacts_list);
			_contactsListView.Adapter = _contactAdapter;
			_contactsListView.ItemClick += OnContactClicked;
			RegisterForContextMenu(_contactsListView);

			_addContactButton = FindViewById<Button>(Resource.Id.add_contact);
			_addContactButton.SetCommand("Click", ViewModel.AddContactCommand);
			this.SetBinding(() => ViewModel.IsCommandActive, 
				() => _addContactButton.Enabled, BindingMode.OneWay);

			_refreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swiperefresh);
			_refreshLayout.Refresh += delegate(object sender, EventArgs args) {  RefreshContactsViews();};
			_refreshLayout.SetCommand("Refresh", ViewModel.LoadCommand);
			this.SetBinding(() => ViewModel.IsBusy,
				() => _refreshLayout.Refreshing, BindingMode.OneWay);
		}

		protected override void OnResume()
		{
			base.OnResume();
			ViewModel.LoadCommand.Execute(null);

			RefreshContactsViews();
		}

		private void RefreshContactsViews()
		{
			_contactAdapter.NotifyDataSetChanged();
			_contactsListView.InvalidateViews();
			_contactsListView.RefreshDrawableState();
		}

		public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
		{
			base.OnCreateContextMenu(menu, v, menuInfo);
			MenuInflater inflater = MenuInflater;
			inflater.Inflate(Resource.Menu.contactsmenu, menu);
		}

		public override bool OnContextItemSelected(IMenuItem item)
		{
			var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
			IContactViewModel globalContact;

			switch (item.ItemId)
			{
				case Resource.Id.contact_edit:
					globalContact = ViewModel.ContactViewModelsItems[info.Position];
					ViewModel.EditContactCommand.Execute(globalContact);
					return true;
				case Resource.Id.contact_remove:
					globalContact = ViewModel.ContactViewModelsItems[info.Position];
					ViewModel.RemoveContactCommand.Execute(globalContact);
					return true;
				default:
					return base.OnContextItemSelected(item);
			}
		}

		private void OnContactClicked(object sender, AdapterView.ItemClickEventArgs e)
		{
			var contact = ViewModel.ContactViewModelsItems[e.Position];
			ViewModel.ShowContactDetailsCommand.Execute(contact);
		}
	}
}