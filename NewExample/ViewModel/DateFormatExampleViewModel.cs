using System;
using ReactiveUI;

namespace NewExample.ViewModel
{
    public class DateFormatExampleViewModel : ReactiveObject
    {
        public static string _dateFormates;
        public string dateFormates
        {
            get { return _dateFormates; }
            set { this.RaiseAndSetIfChanged(x => x.dateFormates, value); }
        }

        public DateFormatExampleViewModel()
        {
            DateTime date = DateTime.Now;
            string dateFormat1 = date.ToString("yyyy-MM-dd'T'HH:mm:ss");
            string dateFormat2 = date.ToString("s");
            dateFormates = "Date Format 1 ==> "+dateFormat1+"\nDate Format 2 ==>"+dateFormat2;
        }

    }
}
