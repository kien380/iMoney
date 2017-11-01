using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Resources;
using static XFFinanceManager.Enums.SettingEnum;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage
    {
        public SettingPage()
        {
            InitializeComponent();

            filterPicker.ItemsSource = Enum.GetValues(typeof(Filter));
            sortPicker.ItemsSource = Enum.GetNames(typeof(Sort));
            languagePicker.ItemsSource = Enum.GetNames(typeof(Language));

            filterPicker.SelectedIndexChanged += FilterPicker_SelectedIndexChanged;
            sortPicker.SelectedIndexChanged += SortPicker_SelectedIndexChanged;
            languagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;

            languagePicker.SelectedItem = CrossMultilingual.Current.CurrentCultureInfo.DisplayName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            filterPicker.SelectedIndex = App.Database.GetSettingValue("Filter");
            sortPicker.SelectedIndex = App.Database.GetSettingValue("Sort");
            languagePicker.SelectedIndex = App.Database.GetSettingValue("Language");
        }

        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.Database.UpdateSettingValue("Language", languagePicker.SelectedIndex);

            //CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.DisplayName.Contains(languagePicker.SelectedItem.ToString()));
            //AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
        }

        private void SortPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.Database.UpdateSettingValue("Sort", sortPicker.SelectedIndex);
        }

        private void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = filterPicker.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    ControlVisible(false, false, false, false, false);
                    break;
                case 1:
                    ControlVisible(true, false, false, false, false);
                    break;
                case 2:
                    ControlVisible(true, false, false, false, false);
                    break;
                case 3:
                    ControlVisible(true, false, false, false, false);
                    break;
                case 4:
                    ControlVisible(false, true, true, false, false);
                    break;
                case 5:
                    ControlVisible(false, false, false, true, true);
                    break;
            }
            App.Database.UpdateSettingValue("Filter", filterPicker.SelectedIndex);
        }

        private void ControlVisible(bool datePicker, bool typeFinancePicker, bool categoryPicker, bool moneyFromEntry, bool moneyToEntry)
        {
            datePickerFilter.IsVisible = datePicker;
            pickerTypeFinanceFilter.IsVisible = typeFinancePicker;
            pickerCategoryFilter.IsVisible = categoryPicker;
            entryMoneyFrom.IsVisible = moneyFromEntry;
            entryMoneyTo.IsVisible = moneyToEntry;
        }

    }
}