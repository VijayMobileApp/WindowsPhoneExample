using System;
using ReactiveUI;
using ReactiveUI.Xaml;
using System.Windows;
namespace NewExample.ViewModel
{
    public class CustomMessageBoxViewModel : ReactiveObject
    {
        public static Visibility _IsVisible = Visibility.Collapsed;
        public Visibility IsVisible
        {
            get { return _IsVisible; }
            set { this.RaiseAndSetIfChanged(x => x.IsVisible, value); }
        }

        public static string _messageBoxText;
        public string messageBoxText
        {
            get { return _messageBoxText; }
            set { this.RaiseAndSetIfChanged(x => x.messageBoxText, value); }
        }


        public ReactiveAsyncCommand okButton { get; set; }
        public ReactiveAsyncCommand CancelButton { get; set; }
        public ReactiveAsyncCommand showMessageBox { get; set; }

        public CustomMessageBoxViewModel()
        {
            showMessageBox = new ReactiveAsyncCommand();
            showMessageBox.Subscribe(x =>
            {
                messageBoxText = "";
                IsVisible = Visibility.Visible;
            });

            okButton = new ReactiveAsyncCommand();
            okButton.Subscribe(x =>
            {
                messageBoxText = "You Clicked OK";
                IsVisible = Visibility.Collapsed;

            });

            CancelButton = new ReactiveAsyncCommand();
            CancelButton.Subscribe(x =>
            {
                messageBoxText = "You Clicked Cancel";
                IsVisible = Visibility.Collapsed;
            });
        }

    }
}
