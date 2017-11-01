using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFinanceManager.Enums
{
    public class CategoryEnum
    {
        public enum IncomeCategory
        {
            Salary,
            Bonus,
            Subsidize,
            Gift,
            Overtime,
            Business,
            Share,
            Real_estate,
            Debt_repayment,
            Interest,
            Loan,
            Other
        }

        public enum ExpenseCategory
        {
            Food_and_Dining,
            Gift,
            Party,
            Entertainment,
            Medical,
            Travel,
            Shopping,
            Mobile,
            Transport,
            Appliances,
            Electricity_Home,
            Tuition,
            Loan,
            Pay,
            Other
        }
    }
}
