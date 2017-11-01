using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Enums;
using XFFinanceManager.Models;
using XFFinanceManager.Resources;
using static XFFinanceManager.Enums.CategoryEnum;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewFinanceManager : ContentPage
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

        public NewFinanceManager(int type)
        {
            InitializeComponent();

            if (type == 1)
            {
                Title = AppResources.NewIncome;
                pickerCategory.ItemsSource = incomeList;
                //pickerCategory.ItemsSource = Enum.GetValues(typeof(IncomeCategory));
            }
            else if (type == 2)
            {
                Title = AppResources.NewExpense;
                pickerCategory.ItemsSource = ExpenseList;
                //pickerCategory.ItemsSource = Enum.GetValues(typeof(ExpenseCategory));
            }
        }

        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(entryName.Text))
            {
                if (!string.IsNullOrEmpty(entryMoney.Text))
                {
                    var financeManagerItem = (FinanceManager)BindingContext;
                    App.Database.SaveFinanceManagerAsync(financeManagerItem);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("", AppResources.MessageMoney, AppResources.Close);
                }
            }
            else
            {
                await DisplayAlert("", AppResources.MessageName, AppResources.Close);
            }
        }

        private void ResetData_Clicked(object sender, EventArgs e)
        {
            entryMoney.Text = "";
            entryName.Text = "";
            entryNote.Text = "";
            datePicker.Date = DateTime.Now.Date;
            entryMoney.Focus();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            entryMoney.Focus();
        }
    }
}