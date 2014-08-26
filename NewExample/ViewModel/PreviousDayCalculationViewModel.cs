using System;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows;


namespace NewExample.ViewModel
{
    public class PreviousDayCalculationViewModel : ReactiveObject
    {
        public static ObservableCollection<listOfItems> _listItems;
        public ObservableCollection<listOfItems> listItems
        {
            get { return _listItems; }
            set { this.RaiseAndSetIfChanged(x => x.listItems, value); }
        }

        public int _selectedDay = -1;
        public int selectedDay
        {
            get { return _selectedDay; }
            set
            {
                this.RaiseAndSetIfChanged(x => x.selectedDay, value);
                dayCalculation(selectedDay);
            }
        }

        string[] items = { "All", "Last 1 Day", "Last 2 Days", "Last 1 Week", "Last 2 Weeks", "Last 1 Month", "Last 3 Months", "Last 6 Months", "Last 1 Year" };
        listOfItems lst;
        public PreviousDayCalculationViewModel()
        {
            listItems = new ObservableCollection<listOfItems>();
            lst = new listOfItems();
            for (int i = 0; i < items.Length; i++)
            {
                lst.dropDownItems = items[i];
                listItems.Add(lst);
                lst = new listOfItems();
            }
        }

        void dayCalculation(int selected)
        {
            switch (selected)
            {
                case 0:
                   
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddHours(-2.30).ToString("s")));
                    break;
                case 1:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddDays(-1).ToString("s")));
                    break;
                case 2:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddDays(-2).ToString("s")));
                    break;
                case 3:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddDays(-7).ToString("s")));
                    break;
                case 4:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddDays(-14).ToString("s")));
                    break;
                case 5:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddMonths(-1).ToString("s")));
                    break;
                case 6:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddMonths(-3).ToString("s")));
                    break;
                case 7:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddMonths(-6).ToString("s")));
                    break;
                case 8:
                    MessageBox.Show("Selected Index==>" + (DateTime.Now.AddYears(-1).ToString("s")));
                    break;
                default:
                    break;
            }
        }
    }

    public class listOfItems
    {
        public string dropDownItems { get; set; }
    }
}
