using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Presentation.ViewModels;

namespace UNLTestTask.Droid
{
	[Activity(Label = "EditContact")]
	public class EditContactPage : BaseActivity<IEditContactViewModel>
	{
		private Spinner _phoneTypeSpinner;
		private Button _submitButton;
		private TextView _errorName;
		private TextView _errorPhone;
		private EditText _phoneEditText;
		private EditText _nameEditText;
		private ArrayAdapter<string> _phoneTypesAdapter;
		public string PhoneType { get; set; }
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.edit_contact_page);

			_phoneTypesAdapter = new ArrayAdapter<string>(this, 
				Resource.Layout.support_simple_spinner_dropdown_item,
				ViewModel.PhoneTypes);

			_nameEditText = FindViewById<EditText>(Resource.Id.input_contact_name);
			_phoneEditText = FindViewById<EditText>(Resource.Id.input_contact_phone);
			_phoneTypeSpinner = FindViewById<Spinner>(Resource.Id.phone_types);
			_submitButton = FindViewById<Button>(Resource.Id.submit);
			_errorName = FindViewById<TextView>(Resource.Id.error_name);
			_errorPhone = FindViewById<TextView>(Resource.Id.error_phone);

			_phoneTypeSpinner.Adapter = _phoneTypesAdapter;

			this.SetBinding(() => ViewModel.PhoneErrorMessage,
				() => _errorPhone.Text, BindingMode.TwoWay);

			this.SetBinding(() => ViewModel.NameErrorMessage,
				() => _errorName.Text, BindingMode.TwoWay);

			this.SetBinding(() => ViewModel.Name, 
				() => _nameEditText.Text, BindingMode.TwoWay);

			this.SetBinding(() => ViewModel.PhoneNumber, 
				() => _phoneEditText.Text, BindingMode.TwoWay);

			this.SetBinding(() => ViewModel.IsValid,
				() => _submitButton.Enabled, BindingMode.OneWay);

			this.SetBinding(() => ViewModel.PhoneType,
				() => PhoneType, BindingMode.OneWay);

			_phoneTypeSpinner.ItemSelected += OnPhoneTypeSelected;
			
			_submitButton.SetCommand("Click", ViewModel.SubmitCommand);
		}

		private void OnPhoneTypeSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			PhoneType = ViewModel.PhoneTypes[e.Position];
		}
	}
}