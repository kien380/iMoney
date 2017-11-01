using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFinanceManager.Converters
{
    public class IconIncomeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valueResult = (int)value;

            string imagePath = string.Empty;
            switch (valueResult)
            {
                case 0:
                    imagePath = "income_salary";
                    break;
                case 1:
                    imagePath = "income_bonus";
                    break;
                case 2:
                    imagePath = "income_subsidize";
                    break;
                case 3:
                    imagePath = "income_gift";
                    break;
                case 4:
                    imagePath = "income_overtime";
                    break;
                case 5:
                    imagePath = "income_business";
                    break;
                case 6:
                    imagePath = "income_share";
                    break;
                case 7:
                    imagePath = "income_real_estate";
                    break;
                case 8:
                    imagePath = "income_debt_repayment";
                    break;
                case 9:
                    imagePath = "income_interest";
                    break;
                case 10:
                    imagePath = "income_loan";
                    break;
                case 11:
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
