using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFFinanceManager.Resources;

namespace XFFinanceManager
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            //ShowLoginPage();
        }

        private async void ShowLoginPage()
        {
            ToolbarItems.Clear();
            var page = new NavigationPage(new Views.LoginPage());
            await Navigation.PushAsync(page);
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage?.Title == AppResources.Income)
                Title = AppResources.IncomeList;
            else if (CurrentPage?.Title == AppResources.Expense)
                Title = AppResources.ExpenseList;
            else
                Title = CurrentPage?.Title;
        }
    }
}
