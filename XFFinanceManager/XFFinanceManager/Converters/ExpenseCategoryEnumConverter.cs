using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFFinanceManager.Resources;

namespace XFFinanceManager.Converters
{
    public class ExpenseCategoryEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = (int)value;

            string result = string.Empty;

            switch (enumVal)
            {
                case 0:
                    result = AppResources.FoodAndDining;
                    break;
                case 1:
                    result = AppResources.Gift;
                    break;
                case 2:
                    result = AppResources.Party;
                    break;
                case 3:
                    result = AppResources.Entertainment;
                    break;
                case 4:
                    result = AppResources.Medical;
                    break;
                case 5:
                    result = AppResources.Travel;
                    break;
                case 6:
                    result = AppResources.Shopping;
                    break;
                case 7:
                    result = AppResources.Mobile;
                    break;
                case 8:
                    result = AppResources.Transport;
                    break;
                case 9:
                    result = AppResources.Appliances;
                    break;
                case 10:
                    result = AppResources.ElectricityHome;
                    break;
                case 11:
                    result = AppResources.Tuition;
                    break;
                case 12:
                    result = AppResources.LoanExpense;
                    break;
                case 13:
                    result = AppResources.Pay;
                    break;
                case 14:
                    result = AppResources.Other;
                    break;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = (int)value;

            return enumVal;
        }
    }
}
