using System;
using ReactiveUI;
using ReactiveUI.Xaml;
namespace NewExample.ViewModel
{
    public class IndexPage3ViewModel : ReactiveObject
    {
        public ReactiveAsyncCommand getPageStackButton { get; set; }
        public ReactiveAsyncCommand messageBoxExampleButton { get; set; }
        public ReactiveAsyncCommand orderDetailButton { get; set; }
        public ReactiveAsyncCommand customMessageButton { get; set; }

        public ReactiveAsyncCommand slideMenuButton { get; set; }
        public ReactiveAsyncCommand languageButton { get; set; }
        public ReactiveAsyncCommand listBoxButton { get; set; }
        public ReactiveAsyncCommand qrCodeButton { get; set; }
        public ReactiveAsyncCommand versionCheckButton { get; set; }
        public ReactiveAsyncCommand longListSelctorButton { get; set; }
        public ReactiveAsyncCommand previousDayButton { get; set; }
        public ReactiveAsyncCommand sortingButton { get; set; }
        public ReactiveAsyncCommand dateFormatButton { get; set; }
        public ReactiveAsyncCommand gifToPngButton { get; set; }
        

        public IndexPage3ViewModel()
        {
            getPageStackButton = new ReactiveAsyncCommand();
            getPageStackButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/GetPagesFromPageStack.xaml", UriKind.Relative));
            });

            messageBoxExampleButton = new ReactiveAsyncCommand();
            messageBoxExampleButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/MessageBoxExample.xaml", UriKind.Relative));
            });

            orderDetailButton = new ReactiveAsyncCommand();
            orderDetailButton.Subscribe(x =>
           {
               var rootFrame = (App.Current as App).RootFrame;
               rootFrame.Navigate(new Uri("/Views/OrderDetailPage.xaml", UriKind.Relative));
           });

            customMessageButton = new ReactiveAsyncCommand();
            customMessageButton.Subscribe(x =>
           {
               var rootFrame = (App.Current as App).RootFrame;
               rootFrame.Navigate(new Uri("/Views/CustomMessageBox.xaml", UriKind.Relative));
           });

            slideMenuButton = new ReactiveAsyncCommand();
            slideMenuButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/SlideExample.xaml", UriKind.Relative));
            });


            languageButton = new ReactiveAsyncCommand();
            languageButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/LanguageExample.xaml", UriKind.Relative));
            });

            listBoxButton = new ReactiveAsyncCommand();
            listBoxButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListBoxToChangeSelectedRow.xaml", UriKind.Relative));
            });

            qrCodeButton = new ReactiveAsyncCommand();
            qrCodeButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/QRCodeGenerator.xaml", UriKind.Relative));
            });

            versionCheckButton = new ReactiveAsyncCommand();
            versionCheckButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/AppVersionCheck.xaml", UriKind.Relative));
            });

            longListSelctorButton = new ReactiveAsyncCommand();
            longListSelctorButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/LongListSelcetorExample.xaml", UriKind.Relative));
            });

            previousDayButton = new ReactiveAsyncCommand();
            previousDayButton.Subscribe(x =>
           {
               var rootFrame = (App.Current as App).RootFrame;
               rootFrame.Navigate(new Uri("/Views/PreviousDayCalculation.xaml", UriKind.Relative));
           });

            sortingButton = new ReactiveAsyncCommand();
            sortingButton.Subscribe(x =>
           {
               var rootFrame = (App.Current as App).RootFrame;
               rootFrame.Navigate(new Uri("/Views/SortingExample.xaml", UriKind.Relative));
           });

            dateFormatButton = new ReactiveAsyncCommand();
            dateFormatButton.Subscribe(x =>
           {
               var rootFrame = (App.Current as App).RootFrame;
               rootFrame.Navigate(new Uri("/Views/DateFormatExample.xaml", UriKind.Relative));
           });

            gifToPngButton = new ReactiveAsyncCommand();
            gifToPngButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/GifToPngExample.xaml", UriKind.Relative));
            });

            

        }
    }
}
