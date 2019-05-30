using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UNLTestTask.Core.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;
using UNLTestTask.Presentation.ViewModels.Contacts;

namespace UNLTestTask.Droid.Adapters
{
	internal class ContactAdapter : BaseAdapter<IContactViewModel>
	{
		private ImageView _contactImageView;
		private TextView _nameTextView;
		private TextView _phoneTextView;
		private ObservableCollection<IContactViewModel> _contacts;
		private readonly Android.App.Activity _context;

		public ContactAdapter(Activity context)
		{
			_context = context;
		}

		public ContactAdapter(ObservableCollection<IContactViewModel> contacts, Activity context)
		{
			_contacts = contacts;
			_context = context;
		}

		public override int Count => _contacts?.Count ?? 0;

		public ObservableCollection<IContactViewModel> Contacts
		{
			get => _contacts;
			set
			{
				_contacts = value;
				this.NotifyDataSetChanged();
			}
		}

		public override IContactViewModel this[int position] => _contacts[position];

		public override Java.Lang.Object GetItem(int position)
		{
			return position;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = _contacts[position];

			View view;

			if (item.Contact.PhoneType == ContactType.None)
			{
				view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.item_contact, null);
				_contactImageView = view.FindViewById<ImageView>(Resource.Id.contact_image);
			}
			else
			{
				view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.item_contact_work, null);
				_contactImageView = view.FindViewById<ImageView>(Resource.Id.contact_image);
			}

			_nameTextView = view.FindViewById<TextView>(Resource.Id.contact_name);
			_nameTextView.Text = item.Contact.Name;

			_phoneTextView = view.FindViewById<TextView>(Resource.Id.contact_phone);
			_phoneTextView.Text = item.Contact.PhoneNumber;

			this.NotifyDataSetChanged();
			return view;
		}
	}
}