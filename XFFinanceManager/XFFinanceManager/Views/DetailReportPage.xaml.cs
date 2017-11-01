using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Resources;
using XFFinanceManager.ViewModels;
using static XFFinanceManager.Enums.CategoryEnum;
using Entry = Microcharts.Entry;

namespace XFFinanceManager.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailReportPage : ContentPage
	{
        int typeFinance = 1;
        List<Entry> entries;
        List<SKColor> chartColor = new List<SKColor>
        {
            SKColor.Parse("#E91E63"), SKColor.Parse("#9C27B0"), SKColor.Parse("#2196F3"), SKColor.Parse("#673AB7"), SKColor.Parse("#03A9F4"), SKColor.Parse("#009688"), SKColor.Parse("#00BCD4"),
            SKColor.Parse("#D500F9"), SKColor.Parse("#80D8FF"), SKColor.Parse("#9E9E9E"), SKColor.Parse("#FF9800"), SKColor.Parse("#FFEB3B"), SKColor.Parse("#4CAF50"), SKColor.Parse("#CDDC39"), SKColor.Parse("#8BC34A")
        };

        public DetailReportPage (int type)
		{
			InitializeComponent ();

            entries = new List<Entry>();

            BindingContext = new SegmentControlViewModel();

            if(type == 1)
            {
                typeFinance = 1;
                Title = AppResources.IncomeDetail;
                ((App)App.Current).ResumeAtFinanceManagerId = -1;
                financeManagerListView.ItemsSource = App.Database.GetFinanceManagerIncomeAsync();

                //ExcuteReport(type, GetDateTime.today, false);
            }
            else if(type == 2)
            {
                typeFinance = 2;
                Title = AppResources.ExpenseDetail;
                ((App)App.Current).ResumeAtFinanceManagerId = -1;
                financeManagerListView.ItemsSource = App.Database.GetFinanceManagerExpenseAsync();

                //ExcuteReport(type, GetDateTime.today, false);
            }

            SegControl.ValueChanged += SegControl_ValueChanged;
        }

        private void ExcuteReport(int type, DateTime dateTime, DateTime endDate, bool hasMonth, bool hasWeek)
        {
            if(type == 1)
            {
                entries.Clear();
                for (int i = 0; i < 12; i++)
                {
                    var sum = 0;
                    if (!hasWeek)
                        sum = App.Database.SumMoneyByCategory(type, i, dateTime, hasMonth);
                    else
                        sum = App.Database.SumMoneyByCategory(type, i, dateTime, endDate);

                    if (sum != 0)
                    {
                        entries.Add(new Entry(sum)
                        {
                            Color = chartColor[i],
                            Label = Enum.GetName(typeof(IncomeCategory), i),
                            ValueLabel = sum.ToString("0,0")
                        });
                    }
                }
            }
            else if(type == 2)
            {
                entries.Clear();
                for (int i = 0; i < 15; i++)
                {
                    var sum = 0;
                    if (!hasWeek)
                        sum = App.Database.SumMoneyByCategory(type, i, dateTime, hasMonth);
                    else
                        sum = App.Database.SumMoneyByCategory(type, i, dateTime, endDate);

                    if (sum != 0)
                    {
                        entries.Add(new Entry(sum)
                        {
                            Color = chartColor[i],
                            Label = Enum.GetName(typeof(ExpenseCategory), i),
                            ValueLabel = sum.ToString("0,0")
                        });
                    }
                }
            }
            
            chartView.Chart = new DonutChart() { Entries = entries };
        }

        private void SegControl_ValueChanged(object sender, EventArgs e)
        {
            switch (SegControl.SelectedSegment)
            {
                case 0:
                    timeLabel.Text = GetDateTime.today.ToString("dd/MM/yyyy");
                    //datePicker.Focus();
                    //var date = datePicker.Date;
                    ExcuteReport(typeFinance, GetDateTime.today, GetDateTime.today, false, false);
                    break;
                case 1:
                    timeLabel.Text = GetDateTime.thisWeekStart.ToString("dd/MM/yyyy") + " - " + GetDateTime.thisWeekEnd.ToString("dd/MM/yyyy");
                    ExcuteReport(typeFinance, GetDateTime.thisWeekStart, GetDateTime.thisWeekEnd, false, true);
                    break;
                case 2:
                    timeLabel.Text = GetDateTime.today.ToString("MM/yyyy");
                    ExcuteReport(typeFinance, GetDateTime.today, GetDateTime.today, true, false);
                    break;
                case 3:
                    timeLabel.Text = "Text";
                    
                    // show popup choose day start and day end
                    break;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SegControl.SelectedSegment = 0;

            //SegControl.TintColor = Color.Purple;

            //SegControl.IsEnabled = false;

            //SegControl.SelectedTextColor = Color.Red;
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