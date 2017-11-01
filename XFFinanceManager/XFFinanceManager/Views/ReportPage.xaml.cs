using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using XFFinanceManager.ViewModels;
using Entry = Microcharts.Entry;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage
    {
        public ReportPage()
        {
            InitializeComponent();

            BindingContext = new TestViewModel();
        }

        private async void IncomeDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailReportPage(1));
        }

        private async void ExpenseDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailReportPage(2));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtFinanceManagerId = -1;
            financeManagerListView.ItemsSource = App.Database.GetFinanceManagerAsync();

            List<Entry> entries = new List<Entry>
            {
                new Entry(App.Database.GetIncomeTotal())
                {
                    Color = SKColor.Parse("#77D353")
                },
                new Entry(App.Database.GetExpenseTotal())
                {
                    Color = SKColor.Parse("#F95F62")
                }
            };

            chartView.Chart = new DonutChart() { Entries = entries };

            incomeLabel.Text = App.Database.GetIncomeTotal().ToString("0,0");
            expenseLabel.Text = App.Database.GetExpenseTotal().ToString("0,0");
            balanceLabel.Text = (App.Database.GetIncomeTotal() - App.Database.GetExpenseTotal()).ToString("0,0");
        }
    }
}