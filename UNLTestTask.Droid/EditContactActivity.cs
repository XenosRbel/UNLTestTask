using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using UNLTestTask.Core.Presentation.ViewModels;
using Xamarin.Forms.Internals;

namespace UNLTestTask.Droid
{
	[Activity(Label = "EditContact")]
	public class EditContactActivity : BaseActivity<IEditContactViewModel>
	{
		private Spinner _phoneTypeSpinner;
		private Button _submitButton;
		private TextView _errorName;
		private TextView _errorPhone;
		private EditText _phoneEditText;
		private EditText _nameEditText;
		private ArrayAdapter<string> _phoneTypesAdapter;
		
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

			this.SetBinding(() => ViewModel.PhoneType, BindingMode.OneWay)
				.WhenSourceChanges(() => { _phoneTypeSpinner.SetSelection(ViewModel.PhoneTypes.IndexOf(ViewModel.PhoneType)); });

			this.SetBinding(() => _phoneTypeSpinner.SelectedItemPosition, BindingMode.OneWay)
				.ObserveSourceEvent<AdapterView.ItemSelectedEventArgs>("ItemSelected")
				.WhenSourceChanges(() =>
					ViewModel.PhoneType = ViewModel.PhoneTypes[_phoneTypeSpinner.SelectedItemPosition == -1 ? 0 : _phoneTypeSpinner.SelectedItemPosition]);

			_submitButton.SetCommand("Click", ViewModel.SubmitCommand);
		}
	}
}