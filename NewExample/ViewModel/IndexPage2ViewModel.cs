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
using ReactiveUI.Xaml;
using ReactiveUI;

namespace NewExample.ViewModel
{
    public class IndexPage2ViewModel : ReactiveObject
    {
        public ReactiveAsyncCommand htmlContentButton { get; set; }
        public ReactiveAsyncCommand dictionaryButton { get; set; }
        public ReactiveAsyncCommand dayCalculation { get; set; }
        public ReactiveAsyncCommand listBoxMVVM { get; set; }
        public ReactiveAsyncCommand userControl { get; set; }
        public ReactiveAsyncCommand listBoxButtonControl { get; set; }
        public ReactiveAsyncCommand contactsControl { get; set; }
        public ReactiveAsyncCommand latAndLongButton { get; set; }
        public ReactiveAsyncCommand incrementScrollerButton { get; set; }
        public ReactiveAsyncCommand listBoxItemsWithButton { get; set; }
        public ReactiveAsyncCommand imageListBoxButton { get; set; }
        public ReactiveAsyncCommand listBoxWithCheckBoxButton { get; set; }
        public ReactiveAsyncCommand countTheTextButton { get; set; }
        
        public IndexPage2ViewModel()
        {
            htmlContentButton = new ReactiveAsyncCommand();
            htmlContentButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/HtmlContent.xaml", UriKind.Relative));
            });

            dictionaryButton = new ReactiveAsyncCommand();
            dictionaryButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/DictionaryExample.xaml", UriKind.Relative));
            });

            dayCalculation = new ReactiveAsyncCommand();
            dayCalculation.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/DayCalculation.xaml", UriKind.Relative));
            });

            listBoxMVVM = new ReactiveAsyncCommand();
            listBoxMVVM.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/MVVMListBox.xaml", UriKind.Relative));

            });

            userControl = new ReactiveAsyncCommand();
            userControl.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/UserControlListbox.xaml", UriKind.Relative));
            });


            listBoxButtonControl = new ReactiveAsyncCommand();
            listBoxButtonControl.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListBoxWithButton.xaml", UriKind.Relative));
            });

            contactsControl = new ReactiveAsyncCommand();
            contactsControl.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/Contacts_list.xaml", UriKind.Relative));
            });

            latAndLongButton = new ReactiveAsyncCommand();
            latAndLongButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/LatitudeAndLogidtude.xaml", UriKind.Relative));
            });

            incrementScrollerButton = new ReactiveAsyncCommand();
            incrementScrollerButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IncrementScroller.xaml", UriKind.Relative));
            });

            listBoxItemsWithButton = new ReactiveAsyncCommand();
            listBoxItemsWithButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListBoxItemsWithButton.xaml", UriKind.Relative));
            });

            imageListBoxButton = new ReactiveAsyncCommand();
            imageListBoxButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ImageListBox.xaml", UriKind.Relative));
            });

            listBoxWithCheckBoxButton = new ReactiveAsyncCommand();
            listBoxWithCheckBoxButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListBoxWithCheckBox.xaml", UriKind.Relative));
            });

             countTheTextButton = new ReactiveAsyncCommand();
             countTheTextButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/CountTheText.xaml", UriKind.Relative));
            });

            

        }

    }
}
