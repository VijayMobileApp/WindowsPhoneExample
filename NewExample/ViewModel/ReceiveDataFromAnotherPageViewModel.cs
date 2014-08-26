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
using Microsoft.Phone.Shell;
using System.Windows.Navigation;
using NewExample.Views;

namespace NewExample.ViewModel
{
    public class ReceiveDataFromAnotherPageViewModel : ReactiveObject
    {
        public static string _receiveText;
        public string receiveText
        {
            get { return _receiveText; }
            set { this.RaiseAndSetIfChanged(x => x.receiveText, value); }
        }

        //public ReactiveAsyncCommand sendButton { get; set; }

        public ReceiveDataFromAnotherPageViewModel()
        {
            ////1st way to receive the data from one page..
            //var k = PhoneApplicationService.Current.State["passingValue"];
            //receiveText = k.ToString();
        }

        public ReceiveDataFromAnotherPageViewModel(string value)
        {
            ////2nd way to receive the data from one page..

            receiveText = value;
        }

    }
}
