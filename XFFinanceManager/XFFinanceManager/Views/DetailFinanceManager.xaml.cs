using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Models;
using XFFinanceManager.Resources;
using static XFFinanceManager.Enums.CategoryEnum;

namespace XFFinanceManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailFinanceManager : ContentPage
	{
        List<string> incomeList = new List<string>()
        {
            AppResources.Salary, AppResources.Bonus, AppResources.Subsidize, AppResources.Gift,
            AppResources.Overtime, AppResources.Business, AppResources.Share, AppResources.RealEstate,
            AppResources.DebtRepayment, AppResources.Interest, AppResources.Loan, AppResources.Other
        };

        List<string> ExpenseList = new List<string>()
        {
            AppResources.FoodAndDining, AppResources.Gift, AppResources.Party, AppResources.Entertainment,
            AppResources.Medical, AppResources.Travel, AppResources.Shopping, AppResources.Mobile,
            AppResources.Transport, AppResources.Appliances, AppResources.ElectricityHome, AppResources.Tuition,
            AppResources.LoanExpense, AppResources.Pay, AppResources.Other
        };

        public DetailFinanceManager (int type)
		{
			InitializeComponent ();

            if (type == 1)
            {
                Title = AppResources.IncomeDetail;
                pickerCategory.ItemsSource = incomeList;
            }
            else if (type == 2)
            {
                Title = AppResources.ExpenseDetail;
                pickerCategory.ItemsSource = ExpenseList;
            }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var financeManagerItem = (FinanceManager)BindingContext;
            App.Database.SaveFinanceManagerAsync(financeManagerItem);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButton_Clicked(object sender, EventArgs e)
        {
            var userClick = await DisplayAlert("", AppResources.MessageDelete, AppResources.Yes, AppResources.No);
            if(userClick)
            {
                var financeManagerItem = (FinanceManager)BindingContext;
                App.Database.DeleteFinanceManagerAsync(financeManagerItem);
                await Navigation.PopAsync();
            }
        }
    }
}