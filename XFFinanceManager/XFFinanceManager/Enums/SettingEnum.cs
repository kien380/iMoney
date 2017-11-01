using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFinanceManager.Enums
{
    public class SettingEnum
    {
        public enum Sort
        {
            Date_increase,
            Date_decrease,
            Money_increase,
            Money_decrease
        }

        public enum Filter
        {
            None,
            Day,
            Week,
            Month,
            Category,
            Money       // From X to Y
        }

        public enum Language
        {
            English,
            Vietnam
        }
    }
}
