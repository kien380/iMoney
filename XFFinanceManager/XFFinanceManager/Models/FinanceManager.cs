using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFinanceManager.Models
{
    public class FinanceManager
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public int Type { get; set; } // 1 - Income, 2 - Expense

        public int Money { get; set; }

        public string Note { get; set; }

        //public string Icon { get; set; }

        public DateTime Date { get; set; }
    }
}
