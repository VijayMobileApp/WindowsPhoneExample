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

namespace NewExample.ViewModel
{
    public class SendDataToAnotherPageViewModel : ReactiveObject
    {
        public static string _sendTextBox;
        public string sendTextBox
        {
            get { return _sendTextBox; }
            set { this.RaiseAndSetIfChanged(x => x.sendTextBox, value); }
        }

        public ReactiveAsyncCommand sendButton { get; set; }

        public SendDataToAnotherPageViewModel()
        {
            sendButton = new ReactiveAsyncCommand();
            sendButton.Subscribe(x =>
            {
                if (!string.IsNullOrEmpty(sendTextBox))
                {
                   ////1st Way to send data to next Page
                   // PhoneApplicationService.Current.State["passingValue"] = sendTextBox;
                   // var rootFrame = (App.Current as App).RootFrame;
                   // rootFrame.Navigate(new Uri("/Views/ReceiveDataFromAnotherPage.xaml", UriKind.Relative));

                    //2nd Way to send data to next Page
                    //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));
                    var rootFrame = (App.Current as App).RootFrame;
                    rootFrame.Navigate(new Uri("/Views/ReceiveDataFromAnotherPage.xaml?passingValue=" + sendTextBox, UriKind.Relative));
                    
                   
                }
            });
          }

    }
}
