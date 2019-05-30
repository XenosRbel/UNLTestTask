using System;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Droid
{
	[Activity(Label = "ContactsPage")]
	public class ContactsActivity : BaseActivity<IContactsViewModel>	
	{
		private Button _addContactButton;
		private ListView _contactsListView;
		private SwipeRefreshLayout _refreshLayout;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.contacts_page);

			_contactsListView = FindViewById<ListView>(Resource.Id.contacts_list);
			_contactsListView.Adapter = ViewModel.ContactViewModelsItems.GetAdapter(GetTemplateDelegate);
			_contactsListView.ItemClick += OnContactClicked;
			
			_addContactButton = FindViewById<Button>(Resource.Id.add_contact);
			_addContactButton.SetCommand("Click", ViewModel.AddContactCommand);

			_refreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swiperefresh);

			RegisterForContextMenu(_contactsListView);

			this.SetBinding(() => ViewModel.IsCommandActive,
				() => _addContactButton.Enabled, BindingMode.OneWay);

			this.SetBinding(() => ViewModel.IsBusy,
				() => _refreshLayout.Refreshing, BindingMode.OneWay);

			this.SetBinding(() => _refreshLayout.Refreshing)
				.ObserveSourceEvent("Refresh")
				.WhenSourceChanges(async () =>
				{
					await ViewModel.LoadContacts();

					_contactsListView.InvalidateViews();
					_contactsListView.RefreshDrawableState();
				});
		}

		private View GetTemplateDelegate(int arg1, IContactViewModel arg2, View arg3)
		{
			if (arg2.Contact.PhoneType == ContactType.None)
			{
				arg3 = LayoutInflater.Inflate(Resource.Layout.item_contact, null);
			}
			else
			{
				arg3 = LayoutInflater.Inflate(Resource.Layout.item_contact_work, null);
			}
			
			var name = arg3.FindViewById<TextView>(Resource.Id.contact_name);
			name.Text = arg2.Contact.Name;

			var phone = arg3.FindViewById<TextView>(Resource.Id.contact_phone);
			phone.Text = arg2.Contact.PhoneNumber;

			var image = arg3.FindViewById<ImageView>(Resource.Id.contact_image);

			return arg3;
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