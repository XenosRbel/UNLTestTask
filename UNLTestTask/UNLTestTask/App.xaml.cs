using UNLTestTask.Presentation.Views.Contacts;
using Xamarin.Forms;

namespace UNLTestTask
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navigation = new NavigationPage(new MainPage());
            MainPage = navigation.RootPage;

            MainPage.Navigation.PushModalAsync(new ContactsViewPage(), false);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
