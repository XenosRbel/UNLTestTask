using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNLTestTask.Presentation.Models;
using UNLTestTask.Presentation.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.ContactDetails
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsViewPage : ContentPage
    {
        private readonly ContactDetailsViewModel _viewModel;
        public ContactDetailsViewPage(Contact contact)
        {
            InitializeComponent();
            _viewModel = new ContactDetailsViewModel(contact);
            BindingContext = _viewModel;
        }

        private void OnButtonOnClicked(object sender, EventArgs e)
        {
            var phoneNumber = _viewModel.Contact.Property.PhoneNumber;
            Device.BeginInvokeOnMainThread(async() => await Call(phoneNumber));
        }

        private async Task Call(string phoneNumber)
        {
            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}