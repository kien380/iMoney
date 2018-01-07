using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Models;
using static XFFinanceManager.Enums.CategoryEnum;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage
    {
        public ExpensePage()
        {
            InitializeComponent();

            var ExpenseList = Enum.GetValues(typeof(ExpenseCategory));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtFinanceManagerId = -1;
            var sortValue = App.Database.GetSettingValue("Sort");
            var filterValue = App.Database.GetSettingValue("Filter");

            financeManagerListView.ItemsSource = 
                App.Database.GetSortListFinance(filterValue, sortValue, 2, DateTime.Now, 0);
        }

        private async void AddNewItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewFinanceManager(2)
            {
                BindingContext = new FinanceManager()
                {
                    Type = 2
                }
            });
        }

        private async void financeManagerListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtFinanceManagerId =
                (e.SelectedItem as FinanceManager).Id;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetailFinanceManager(2)
                {
                    BindingContext = e.SelectedItem as FinanceManager
                });
            }
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = searchBar.Text;

            financeManagerListView.ItemsSource =
                App.Database.GetFinanceManagerSearchByName(keyword)
                    .Where(fm => fm.Type == 2).ToList();
        }
    }
}