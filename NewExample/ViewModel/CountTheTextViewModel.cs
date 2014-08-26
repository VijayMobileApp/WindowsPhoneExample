

using ReactiveUI;
using ReactiveUI.Xaml;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace NewExample.ViewModel
{
    public class CountTheTextViewModel : ReactiveObject
    {
        public string _listName = "";
        public string listName
        {
            get { return _listName; }
            set { this.RaiseAndSetIfChanged(x => x.listName, value); }
        }

        public Brush _borderBrush;
        public Brush borderBrush
        {
            get { return _borderBrush; }
            set { this.RaiseAndSetIfChanged(x => x.borderBrush, value); }
        }


        public string _totalChar = "";
        public string totalChar
        {
            get { return _totalChar; }
            set { this.RaiseAndSetIfChanged(x => x.totalChar, value); }
        }

        int total = 50;
        int rem = 0;

        public ReactiveAsyncCommand ExecuteSearch { get; set; }
        public ReactiveAsyncCommand ItemSelectedCommand { get; set; }

        public CountTheTextViewModel()
        {
            ItemSelectedCommand = new ReactiveAsyncCommand();
            ItemSelectedCommand.Subscribe(x =>
            {
               borderBrush= new  SolidColorBrush(Colors.Orange);
            });

            var canConfirm = this.WhenAny(x => x.listName, (search) => CountString(search.Value));
            ExecuteSearch = new ReactiveAsyncCommand(canConfirm, 0);
        }

        public Boolean CountString(String searchValue)
        {
            rem = total - listName.Length;
            totalChar = rem.ToString();
            return true;
        }
    }
}
