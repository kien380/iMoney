using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.ViewModels;
using static XFFinanceManager.Enums.CategoryEnum;
using Entry = Microcharts.Entry;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        List<Entry> entries = new List<Entry>
        {
            new Entry(App.Database.GetIncomeTotal())
            {
                Color = SKColor.Parse("#77D353"),
                //Label = "Income",
                //ValueLabel = "" + App.Database.GetIncomeTotal()
            },
            new Entry(App.Database.GetExpenseTotal())
            {
                Color = SKColor.Parse("#F95F62"),
                //Label = "Expense",
                //ValueLabel = "" + App.Database.GetExpenseTotal()
            }
        };

        public TestPage()
        {
            InitializeComponent();

            chartView.Chart = new DonutChart() { Entries = entries };

            BindingContext = new TestViewModel();

            incomeLabel.Text = App.Database.GetIncomeTotal().ToString("0,0");
            expenseLabel.Text = App.Database.GetExpenseTotal().ToString("0,0");
            balanceLabel.Text = (App.Database.GetIncomeTotal() - App.Database.GetExpenseTotal()).ToString("0,0");

            var ExpenseList =  Enum.GetValues(typeof(ExpenseCategory));
            labelCategory.Text = Enum.GetName(typeof(ExpenseCategory), ExpenseList);
        }

        private async void IncomeDetail_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Income Tapped", "Ok");
        }

        private async void ExpenseDetail_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Expense Tapped", "Ok");
        }
    }
}