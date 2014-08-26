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

namespace NewExample.ViewModel
{
    public class StarRatingExampleViewModel : ReactiveObject
    {
        public static int _ratings;
        public int ratings
        {
            get { return _ratings; }
            set { this.RaiseAndSetIfChanged(x => x.ratings, value); }
        }

        public int count = 0;
        public ReactiveAsyncCommand starCheck { get; set; }


        public StarRatingExampleViewModel()
        {
            starCheck = new ReactiveAsyncCommand();
            starCheck.Subscribe(x =>
            {                
                if (ratings == 1 || ratings == 2)
                    count = 1;

                if (ratings == 3 || ratings == 4)
                    count = 2;

                if (ratings == 5 || ratings == 6)
                    count = 3;

                if (ratings == 7 || ratings == 8)
                    count = 4;

                if (ratings == 9 || ratings == 10)
                    count = 5;

                Console.WriteLine("Count==>"+count);

            });
        }
    }
}
