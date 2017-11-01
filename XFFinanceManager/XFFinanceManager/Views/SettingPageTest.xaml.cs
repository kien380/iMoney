using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static XFFinanceManager.Enums.SettingEnum;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPageTest : ContentPage
    {
        public SettingPageTest()
        {
            InitializeComponent();

            filterPicker.ItemsSource = Enum.GetValues(typeof(Filter));
            sortPicker.ItemsSource = Enum.GetNames(typeof(Sort));
            languagePicker.ItemsSource = Enum.GetNames(typeof(Language));

            filterPicker.SelectedIndex = App.Database.GetSettingValue("Filter");
            sortPicker.SelectedIndex = App.Database.GetSettingValue("Sort");
            languagePicker.SelectedIndex = App.Database.GetSettingValue("Language");
        }

        private void filterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oldIndex = App.Database.GetSettingValue("Filter");

            if (filterPicker.SelectedIndex != oldIndex)
                App.Database.UpdateSettingValue("Filter", filterPicker.SelectedIndex);
        }

        private void sortPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oldIndex = App.Database.GetSettingValue("Sort");

            if (filterPicker.SelectedIndex != oldIndex)
                App.Database.UpdateSettingValue("Sort", filterPicker.SelectedIndex);
        }

        private void languagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var oldIndex = App.Database.GetSettingValue("Language");

            if (filterPicker.SelectedIndex != oldIndex)
                App.Database.UpdateSettingValue("Language", filterPicker.SelectedIndex);
        }
    }
}