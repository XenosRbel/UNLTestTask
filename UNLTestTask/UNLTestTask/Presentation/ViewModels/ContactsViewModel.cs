using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UNLTestTask.Helpers;
using UNLTestTask.Presentation.Models;
using Xamarin.Forms;

namespace UNLTestTask.Presentation.ViewModels
{
    internal class ContactsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Contact> ContactItems { get; set; }
        public ICommand LoadCommand { get; set; }

        public ContactsViewModel()
        {
            LoadCommand = new Command(async () => await OnExecuteLoadCommand());

            ContactItems = new ObservableRangeCollection<Contact>();
        }

        private async Task OnExecuteLoadCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                ContactItems.Clear();

                var contacts = new List<Contact>
                {
                    new Contact
                    {
                        PhotoPath = "tom.png",
                        Name = "Tom",
                        PhoneNumber = "+375441234569",
						PhoneType = ContactType.WorkPhone
                    },

                    new Contact
                    {
                        PhotoPath = "jerry.png",
                        Name = "Jerry",
                        PhoneNumber = "+375252236548",
						PhoneType = ContactType.None
                    }
                };

                ContactItems.AddRange(contacts);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
