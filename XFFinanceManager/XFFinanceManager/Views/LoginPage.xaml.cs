using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            emailLabel.Focus();
        }

        private void OnLogin_Clicked(object sender, EventArgs e)
        {
            bool loginInfoIsGood = CheckLoginInfo();
            if (loginInfoIsGood)
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
        }

        private async void Handle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }

        private bool CheckLoginInfo()
        {
            return true;
        }
    }
}