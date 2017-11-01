using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFinanceManager.Converters
{
    public class IconExpenseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valueResult = (int)value;

            string imagePath = string.Empty;
            switch (valueResult)
            {
                case 0:
                    imagePath = "expense_food";
                    break;
                case 1:
                    imagePath = "expense_gift";
                    break;
                case 2:
                    imagePath = "expense_party";
                    break;
                case 3:
                    imagePath = "expense_entertainment";
                    break;
                case 4:
                    imagePath = "expense_medical";
                    break;
                case 5:
                    imagePath = "expense_travel";
                    break;
                case 6:
                    imagePath = "expense_shopping";
                    break;
                case 7:
                    imagePath = "expense_mobile";
                    break;
                case 8:
                    imagePath = "expense_transport";
                    break;
                case 9:
                    imagePath = "expense_appliances";
                    break;
                case 10:
                    imagePath = "expense_home";
                    break;
                case 11:
                    imagePath = "expense_tuition";
                    break;
                case 12:
                    imagePath = "income_loan";
                    break;
                case 13:
                    imagePath = "income_debt_repayment";
                    break;
                case 14:
                    imagePath = "other";
                    break;
            }

            return imagePath;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
