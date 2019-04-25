using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNLTestTask.Presentation.Models;
using UNLTestTask.Presentation.ViewModels;
using UNLTestTask.Presentation.Views.ContactDetails;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UNLTestTask.Presentation.Views.Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsViewPage : ContentPage
    {
        private readonly ContactsViewModel _viewModel;
        public ContactsViewPage()
        {
            InitializeComponent();

            _viewModel = new ContactsViewModel();

            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_viewModel.ContactItems.Count == 0)
            {
                _viewModel.LoadCommand.Execute(null);
            }
        }

        private void OnListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;

            Device.BeginInvokeOnMainThread(async () => await this.Navigation.PushModalAsync(new ContactDetailsViewPage(contact)));
        }
    }
}