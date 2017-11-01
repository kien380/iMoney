using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFFinanceManager.Models;

namespace XFFinanceManager.Data
{
    public class FinanceManagerDatabase
    {
        readonly SQLiteConnection database;

        public FinanceManagerDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath, true);
            database.CreateTable<FinanceManager>();
            database.CreateTable<Setting>();

            database.Insert(new Setting() { Name = "Filter", Value = 0 });
            database.Insert(new Setting() { Name = "Sort", Value = 0 });
            database.Insert(new Setting() { Name = "Language", Value = 0 });
        }

        public int GetSettingValue(string name)
        {
            var query = database.Table<Setting>().Where(x => x.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();

            return query.Value;
        }

        public int UpdateSettingValue(string name, int value)
        {
            var query = database.Table<Setting>().Where(x => x.Name.ToLower().Contains(name.ToLower())).FirstOrDefault();
            
            if(value != query.Value)
            {
                query.Value = value;
                return database.Update(query);
            }

            return 0;
        }

        // Get All
        public List<FinanceManager> GetFinanceManagerAsync()
        {
            return database.Table<FinanceManager>().OrderByDescending(x => x.Date).ToList();
        }

        // Get Income List
        public List<FinanceManager> GetFinanceManagerIncomeAsync()
        {
            return database.Table<FinanceManager>().Where(x=>x.Type == 1).OrderByDescending(x => x.Date).ToList();
        }

        // Get Expense List
        public List<FinanceManager> GetFinanceManagerExpenseAsync()
        {
            return database.Table<FinanceManager>().Where(x => x.Type == 2).OrderByDescending(x => x.Date).ToList();
        }

        // Get Finance List - Sort
        public List<FinanceManager> GetSortListFinance(int filterValue, int sortValue, int type, DateTime date, int category)
        {
            List<FinanceManager> listItems = new List<FinanceManager>();

            switch (sortValue)
            {
                case 0:
                    listItems = GetFilterFinanceList(filterValue, date, category).Where(x => x.Type == type).OrderByDescending(x => x.Date).ToList();
                    break;
                case 1:
                    listItems = GetFilterFinanceList(filterValue, date, category).Where(x => x.Type == type).OrderBy(x => x.Date).ToList();
                    break;
                case 2:
                    listItems = GetFilterFinanceList(filterValue, date, category).Where(x => x.Type == type).OrderByDescending(x => x.Money).ToList();
                    break;
                case 3:
                    listItems = GetFilterFinanceList(filterValue, date, category).Where(x => x.Type == type).OrderBy(x => x.Money).ToList();
                    break;
            }

            return listItems;
        }

        

        // Get Finance List
        public List<FinanceManager> GetFilterFinanceList(int filterValue, DateTime date, int category)
        {
            List<FinanceManager> listItems = new List<FinanceManager>();

            switch(filterValue)
            {
                case 0:
                    listItems = database.Table<FinanceManager>().ToList();
                    break;
                case 1:
                    listItems = FilterListFinanceByTime(date, 0);
                    break;
                case 2:
                    listItems = FilterListFinanceByTime(date, 1);
                    break;
                case 3:
                    listItems = FilterListFinanceByTime(date, 2);
                    break;
                case 4:
                    listItems = FilterListFinanceByCategory(category);
                    break;
                case 5:
                    listItems = FilterListFinanceByCategory(category);
                    break;
            }

            return listItems;
        }

        // Get Finance List - Filter by Time
        public List<FinanceManager> FilterListFinanceByTime(DateTime date, int caseDateTime)
        {
            List<FinanceManager> listItems = new List<FinanceManager>();
            var filtered = database.Table<FinanceManager>();

            switch(caseDateTime)
            {
                case 0:
                    foreach (var item in filtered)
                    {
                        if (item.Date.Day == date.Day && item.Date.Month == date.Month && item.Date.Year == date.Year)
                        {
                            listItems.Add(item);
                        }
                    }
                    break;
                case 1:
                    var thisWeekStart = date.AddDays(-(int)date.DayOfWeek);
                    var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

                    foreach (var item in filtered)
                    {
                        if (item.Date.Date >= thisWeekStart.Date && item.Date.Date < thisWeekEnd.Date)
                        {
                            listItems.Add(item);
                        }
                    }
                    break;
                case 2:
                    foreach (var item in filtered)
                    {
                        if (item.Date.Month == date.Month && item.Date.Year == date.Year)
                        {
                            listItems.Add(item);
                        }
                    }
                    break;
            }

            return listItems;
        }

        // Get Finance List - Filter by Category
        public List<FinanceManager> FilterListFinanceByCategory(int category)
        {
            return database.Table<FinanceManager>().Where(x =>x.Category == category).ToList();
        }

        // Get Finance List - Filter by Money
        public List<FinanceManager> FilterListFinanceByMoney(int moneyFrom, int moneyTo)
        {
            return database.Table<FinanceManager>().Where(x => x.Money >= moneyFrom && x.Money <= moneyTo).ToList();
        }

        // Get 1 by id
        public FinanceManager GetFinanceManagerAsync(int id)
        {
            return database.Table<FinanceManager>().Where(i => i.Id == id).FirstOrDefault();
        }

        // Get List Search by Name
        public List<FinanceManager> GetFinanceManagerSearchByName(string name)
        {
            return database.Table<FinanceManager>().Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        // Get List search by Note
        public List<FinanceManager> GetFinanceManagerSearchByNote(string note)
        {
            return database.Table<FinanceManager>().Where(i => i.Note.ToLower().Contains(note.ToLower())).ToList();
        }

        // Add new or Update
        public int SaveFinanceManagerAsync(FinanceManager financeManager)
        {
            if(financeManager.Id != 0)
            {
                return database.Update(financeManager);
            }
            else
            {
                return database.Insert(financeManager);
            }
        }

        // Delete
        public int DeleteFinanceManagerAsync(FinanceManager financeManager)
        {
            return database.Delete(financeManager);
        }

        // Income total
        public int GetIncomeTotal()
        {
            return database.Table<FinanceManager>().Where(x => x.Type == 1).Sum(x => x.Money);
        }

        // Expense total
        public int GetExpenseTotal()
        {
            return database.Table<FinanceManager>().Where(x => x.Type == 2).Sum(x => x.Money);
        }

        // Report by Category
        public int SumMoneyByCategory(int type, int category, DateTime dateTime, bool hasMonth)
        {
            //List<FinanceManager> listItems = new List<FinanceManager>();
            int sum = 0;
            var filtered = database.Table<FinanceManager>().Where(x => x.Type == type && x.Category == category);

            if(!hasMonth)
            {
                foreach (var item in filtered)
                {
                    if (item.Date.Day == dateTime.Day
                        && item.Date.Month == dateTime.Month
                        && item.Date.Year == dateTime.Year)
                    {
                        sum += item.Money;
                        //listItems.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in filtered)
                {
                    if (item.Date.Month == dateTime.Month && item.Date.Year == dateTime.Year)
                    {
                        sum += item.Money;
                    }
                }
            }

            return sum;

            //var query = from s in database.Table<FinanceManager>()
            //            //let convertedDate = (DateTime)s.Date
            //            where s.Date.Month == 9
            //            orderby s.Name
            //            select s;
            //return query.ToList();
        }

        // Report by Category
        public int SumMoneyByCategory(int type, int category, DateTime startDay, DateTime endDate)
        {
            int sum = 0;
            var filtered = database.Table<FinanceManager>().Where(x => x.Type == type && x.Category == category);

            foreach (var item in filtered)
            {
                if (item.Date.Date >= startDay.Date && item.Date.Date <= endDate.Date)
                {
                    sum += item.Money;
                }
            }

            return sum;
        }


        // Income Category

        // Expense Category - day
        public int GetExpenseCategoryTotal(int type, int category, DateTime dateTime, bool month)
        {
            List<FinanceManager> tmpList = new List<FinanceManager>();
            int sum = 0;

            database.RunInTransaction(() =>
            {
                var items = from s in database.Table<FinanceManager>()
                            let convertedDate = (DateTime)s.Date
                            where (convertedDate.Day == dateTime.Day)
                            select s;
                sum = items.Sum(x => x.Money);
            });

            return sum;                       
        }

        // Expense Category - day
        public int GetExpenseCategoryTotalMonth(int type, int category, DateTime date)
        {
            return database.Table<FinanceManager>().Where(x => x.Type == type && x.Category == category && x.Date.Month == date.Month && x.Date.Year == date.Year).Sum(x => x.Money);
        }
    }

    public class GetDateTime
    {
        public static DateTime baseDate = DateTime.Today;

        public static DateTime today = baseDate;
        public static DateTime thisWeekStart = baseDate.AddDays(-(int)baseDate.DayOfWeek);
        public static DateTime thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);
    }
}
