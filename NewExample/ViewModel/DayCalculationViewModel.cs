using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ReactiveUI;
using ReactiveUI.Xaml;
using System.Globalization;

namespace NewExample.ViewModel
{
    public class DayCalculationViewModel : ReactiveObject
    {
        public static string _result;
        public string result
        {
            get { return _result; }
            set { this.RaiseAndSetIfChanged(x => x.result, value); }
        }


        public static string _yourAge;
        public string yourAge
        {
            get { return _yourAge; }
            set { this.RaiseAndSetIfChanged(x => x.yourAge, value); }
        }

        public static string _dayText;
        public string dayText
        {
            get { return _dayText; }
            set { this.RaiseAndSetIfChanged(x => x.dayText, value); }
        }

        public static string _monthText;
        public string monthText
        {
            get { return _monthText; }
            set { this.RaiseAndSetIfChanged(x => x.monthText, value); }
        }

        public static string _yearText;
        public string yearText
        {
            get { return _yearText; }
            set { this.RaiseAndSetIfChanged(x => x.yearText, value); }
        }
        public static string _dateTime;
        public string dateTime
        {
            get { return _dateTime; }
            set { this.RaiseAndSetIfChanged(x => x.dateTime, value); }
        }

        public string _datePickerDate;
        public string datePickerDate
        {
            get { return _datePickerDate; }
            set { this.RaiseAndSetIfChanged(x => x.datePickerDate, value); }
        }

        public DateTime _testDate;
        public DateTime testDate
        {
            get { return _testDate; }
            set { this.RaiseAndSetIfChanged(x => x.testDate, value); }
        }



        public static DateTime wallPostDate { get; set; }
        public ReactiveAsyncCommand dayCalculate { get; set; }
        public ReactiveAsyncCommand checkDate { get; set; }

        public DayCalculationViewModel()
        {
            string givenDate = ("2013-03-05T08:28:18+0000");
            DateTime d = DateTime.Parse(givenDate, System.Globalization.CultureInfo.InvariantCulture);
            dateTime = d.ToUniversalTime().ToString("MMM d, yyyy h:m:s tt", System.Globalization.CultureInfo.InvariantCulture);

            testDate = DateTime.Today;
            dayCalculate = new ReactiveAsyncCommand();
            dayCalculate.Subscribe(x =>
            {
                //"1970-01-01T00:00:00+0000"
                //"1990-01-01T00:00:00+0000"
                // Console.WriteLine("Test Date==>" + date.ToString("yyyy-MM-dd") + "T00:00:00+0000");                
                string enterdDate = string.Format("{0},{1},{2}", yearText, monthText, dayText);
                //DateTime start = DateTime.Parse(date);
                //DateTime end = DateTime.Today;

                // //Example 1 Example 1 Example 1 Example 1 Example 1 Example 1
                // //DateTime start = new DateTime(2013, 07, 22);
                //// DateTime end = new DateTime(2014, 4, 22);
                // //DateTime end = DateTime.Today;

                // if (start > end)
                // {
                //     throw new ArgumentException();
                // }

                // // See comment at the end
                // int years = end.Year - start.Year - 2;
                // while (start.AddYears(years) <= end)
                // {
                //     years++;
                // }
                // years--;
                // //Console.WriteLine("{0} years", years);

                // start = start.AddYears(years);
                // int months = 0;
                // while (start.AddMonths(months) <= end)
                // {
                //     months++;
                // }
                // months--;
                // // Console.WriteLine("{0} months", months);

                // start = start.AddMonths(months);
                // int days = 0;
                // while (start.AddDays(days) <= end)
                // {
                //     days++;
                // }
                // days--;
                // //Console.WriteLine("{0} days", days);

                // if (years > 0)
                //     Console.WriteLine("{0}Y ago", years);
                // else if (months > 0)
                //     Console.WriteLine("{0}M ago", months);
                // else if (days > 0)
                //     Console.WriteLine("{0}D ago", days);



                DateTime dt1 = DateTime.Parse(enterdDate);
                DateTime dt2 = DateTime.Today;
                //var dt1 = new DateTime(2013, 12, 04);
                //var dt2 = new DateTime(2014, 4, 22);

                if (dt2.Year > dt1.Year)
                {
                    int days = dt2.Day - dt1.Day;
                    int months = dt2.Month - dt1.Month;
                    int years = dt2.Year - dt1.Year;

                    if (months < 0)
                    {
                        months += 12;
                        years -= 1;
                    }

                    if (days < 0)
                    {
                        Console.WriteLine("Before Add dt1 year ==> " + dt1.Year);
                        dt1.AddYears(years);
                        Console.WriteLine("After Add dt1 year ==> " + dt1.Year);


                        Console.WriteLine("Before Add dt1 month ==> " + dt1.Month);
                        dt1.AddMonths(months);
                        Console.WriteLine("After Add dt1 month ==> " + dt1.Month);

                        Console.WriteLine("Before  dt1 days==> " + days);
                        days = dt2.Subtract(dt1).Days;
                        Console.WriteLine("After  dt1 days==> " + days);
                        months -= 1;
                    }

                    if (years > 0)
                        Console.WriteLine("{0}Y ago", years);
                    else if (months > 0)
                        Console.WriteLine("{0}M ago", months);
                    else if (days > 0)
                        Console.WriteLine("{0}D ago", days);

                    //yourAge = string.Format("{0} Days - {1} Months - {2} Years", days, months, years);

                    yourAge = string.Format("{0} Years - {1} Months - {2} Days", years, months, days);
                    Console.WriteLine("{0} Days, {1} Months, {2} Years", days, months, years);
                }
            });

            checkDate = new ReactiveAsyncCommand();
            checkDate.Subscribe(x =>
            {
                Console.WriteLine("testDate==>" + testDate.ToString("MM/dd/yyyy"));
            });
        }
    }
}
