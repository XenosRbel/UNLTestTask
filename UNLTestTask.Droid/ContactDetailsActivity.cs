using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Models;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Droid
{
	[Activity(Label = "ContactDetailsPage")]
	public class ContactDetailsActivity : BaseActivity<IContactDetailsViewModel>
	{
		private TextView _nameTextView;
		private TextView _phoneTextView;
		private Button _callButton;
		private ImageView _contactImageView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.contact_details_page);

			_nameTextView = FindViewById<TextView>(Resource.Id.contact_name);
			_phoneTextView = FindViewById<TextView>(Resource.Id.contact_phone);
			_contactImageView = FindViewById<ImageView>(Resource.Id.contact_image);
			_callButton = FindViewById<Button>(Resource.Id.call_button);

			_callButton.SetCommand("Click", ViewModel.CallCommand);

			this.SetBinding(() => ViewModel.Contact.Property.Name,
				() => _nameTextView.Text,
				BindingMode.OneWay);

			this.SetBinding(() => ViewModel.Contact.Property.PhoneNumber,
				() => _phoneTextView.Text,
				BindingMode.OneWay);

			_contactImageView.SetImageResource(ViewModel.Contact.Property.PhoneType == ContactType.None
				? Resource.Drawable.tom
				: Resource.Drawable.jerry);
		}
	}
}