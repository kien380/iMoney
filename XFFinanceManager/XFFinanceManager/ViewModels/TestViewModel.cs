using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFFinanceManager.Models;

namespace XFFinanceManager.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Test> items;
        public ObservableCollection<Test> Items
        {
            get { return items; }
            set { items = value; }
        }

        public TestViewModel()
        {
            Items = new ObservableCollection<Test>()
            {
                new Test()
                {
                    Title = "Title 1",
                    Detail = "Detail 1",
                    Number = 0
                },
                new Test()
                {
                    Title = "Title 2",
                    Detail = "Detail 2",
                    Number = 1
                },
                new Test()
                {
                    Title = "Title 3",
                    Detail = "Detail 3",
                    Number = 2
                },
                new Test()
                {
                    Title = "Title 4",
                    Detail = "Detail 4",
                    Number = 3
                },
                new Test()
                {
                    Title = "Title 5",
                    Detail = "Detail 5",
                    Number = 4
                },
                new Test()
                {
                    Title = "Title 6",
                    Detail = "Detail 6",
                    Number = 5
                },
                new Test()
                {
                    Title = "Title 7",
                    Detail = "Detail 7",
                    Number = 6
                },
                new Test()
                {
                    Title = "Title 8",
                    Detail = "Detail 8",
                    Number = 7
                },
                new Test()
                {
                    Title = "Title 6",
                    Detail = "Detail 6",
                    Number = 8
                },
                new Test()
                {
                    Title = "Title 7",
                    Detail = "Detail 7",
                    Number = 9
                },
                new Test()
                {
                    Title = "Title 8",
                    Detail = "Detail 8",
                    Number = 10
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
