using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNLTestTask.Modules;
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

        private async void OnButtonOnClicked(object sender, EventArgs e)
        {
            var phoneNumber = _viewModel.Contact.Property.PhoneNumber;
                        
            var status = await AskPermission();

            if (status == PermissionStatus.Granted)
                await DependencyService.Get<ICallService>()?.CallNumber(phoneNumber);
        }

        private async Task<PermissionStatus> AskPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Phone))
                    Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Need Phone Permission", "Need access to call yor phone number", "OK"));

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Phone);
                if (results.ContainsKey(Permission.Storage))
                    status = results[Permission.Storage];
            }

            return status;
        }
    }
}