using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Resources;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            emailEntry.Focus();
        }

        private async void OnLogin_Clicked(object sender, EventArgs e)
        {
            bool loginInfoIsGood = await CheckLoginInfo(emailEntry.Text, passwordEntry.Text);
            if (loginInfoIsGood)
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }

        private async Task<bool> CheckLoginInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("", AppResources.PleaseEnterUsernameAndPassword, AppResources.Close);
                return false;
            }
            if (email != "imoney" || password != "imoney")
            {
                await DisplayAlert("", AppResources.UsernameOrPasswordIsInvalid, AppResources.Close);
                return false;
            }
            return true;
        }
    }
}