using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFFinanceManager.Enums;
using XFFinanceManager.Resources;

namespace XFFinanceManager.Converters
{
    public class IncomeCategoryEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = (int)value;

            string result = string.Empty;

            switch(enumVal)
            {
                case 0:
                    result = AppResources.Salary;
                    break;
                case 1:
                    result = AppResources.Bonus;
                    break;
                case 2:
                    result = AppResources.Subsidize;
                    break;
                case 3:
                    result = AppResources.Gift;
                    break;
                case 4:
                    result = AppResources.Overtime;
                    break;
                case 5:
                    result = AppResources.Business;
                    break;
                case 6:
                    result = AppResources.Share;
                    break;
                case 7:
                    result = AppResources.RealEstate;
                    break;
                case 8:
                    result = AppResources.DebtRepayment;
                    break;
                case 9:
                    result = AppResources.Interest;
                    break;
                case 10:
                    result = AppResources.Loan;
                    break;
                case 11:
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
