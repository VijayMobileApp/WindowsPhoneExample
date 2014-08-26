

using System.Windows;
using System;
using ReactiveUI.Xaml;
namespace NewExample.ViewModel
{
    public class MessageBoxExampleViewModel
    {
        public ReactiveAsyncCommand messageBoxOKCancelButton { get; set; }
        public MessageBoxExampleViewModel()
        {

            messageBoxOKCancelButton = new ReactiveAsyncCommand();
            messageBoxOKCancelButton.Subscribe(x => {
                MessageBoxResult m = MessageBox.Show("Heading", "What do want to say to user so that he/she can press ok or cancel", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.Cancel)
                {
                    Console.WriteLine("I pressed Cancel");
                }
                else if (m == MessageBoxResult.OK)
                {
                    Console.WriteLine("I pressed OK");
                }
            
            });

           
        }
    }
}
