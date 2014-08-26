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
using NewExample.Const;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;

namespace NewExample.ViewModel
{
    public class MainPageViewModel : ReactiveObject
    {
        public ReactiveAsyncCommand listBoxButton { get; set; }
        public ReactiveAsyncCommand addToXmlButton { get; set; }
        public ReactiveAsyncCommand testPage { get; set; }
        public ReactiveAsyncCommand pivoteExampleButton { get; set; }
        public ReactiveAsyncCommand panoramaExampleButton { get; set; }
        public ReactiveAsyncCommand roughPageButton { get; set; }
        public ReactiveAsyncCommand xmlExtractionButton { get; set; }
        public ReactiveAsyncCommand isolatedStorageButton { get; set; }
        public ReactiveAsyncCommand starRatingButton { get; set; }
        public ReactiveAsyncCommand ezIsolatedStorageButton { get; set; }
        public ReactiveAsyncCommand emailPhoneButton { get; set; }
        public ReactiveAsyncCommand sendValueButton { get; set; }
        public ReactiveAsyncCommand loadPageButton { get; set; }
        public ReactiveAsyncCommand mapPage { get; set; }
        public ReactiveAsyncCommand webBrowser { get; set; }
        public ReactiveAsyncCommand listPickerButton { get; set; }
        public ReactiveAsyncCommand listBoxEventsButton { get; set; }
        public ReactiveAsyncCommand pivoteExample1Button { get; set; }
        public ReactiveAsyncCommand redirectPageButton { get; set; }
        public ReactiveAsyncCommand BackKeyPressCommand { get; set; }

        public RelayCommand<CancelEventArgs> BackKeyPressCommand1 { get; private set; }
        public MainPageViewModel()
        {
            BackKeyPressCommand = new ReactiveAsyncCommand();
            BackKeyPressCommand.Subscribe(x => {
                MessageBox.Show("Back key pressed");
            });
            
            BackKeyPressCommand1 = new RelayCommand<CancelEventArgs>(BackKeyPress); 

            AppConstant.getGeoLocation = new GetGeoLocation();
            listBoxButton = new ReactiveAsyncCommand();
            listBoxButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListBoxExample.xaml", UriKind.Relative));
            });

            addToXmlButton = new ReactiveAsyncCommand();
            addToXmlButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/AddToXML.xaml", UriKind.Relative));
            });

            testPage = new ReactiveAsyncCommand();
            testPage.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/Test.xaml", UriKind.Relative));
            });

            pivoteExampleButton = new ReactiveAsyncCommand();
            pivoteExampleButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/PivotExample.xaml", UriKind.Relative));
            });

            panoramaExampleButton = new ReactiveAsyncCommand();
            panoramaExampleButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/PanoramaPage1.xaml", UriKind.Relative));
            });

            roughPageButton = new ReactiveAsyncCommand();
            roughPageButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/RoughPage.xaml", UriKind.Relative));
            });

            xmlExtractionButton = new ReactiveAsyncCommand();
            xmlExtractionButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/XML_Extraction.xaml", UriKind.Relative));
            });

            isolatedStorageButton = new ReactiveAsyncCommand();
            isolatedStorageButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IsolatedStorageExample.xaml", UriKind.Relative));
            });

            starRatingButton = new ReactiveAsyncCommand();
            starRatingButton.Subscribe(x =>
            {

                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/StarRatingExample.xaml", UriKind.Relative));
            });

            emailPhoneButton = new ReactiveAsyncCommand();
            emailPhoneButton.Subscribe(x =>
            {

                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/EmailOrPhone.xaml", UriKind.Relative));
            });

            sendValueButton = new ReactiveAsyncCommand();
            sendValueButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/SendDataToAnotherPage.xaml", UriKind.Relative));
            });

            loadPageButton = new ReactiveAsyncCommand();
            loadPageButton.Subscribe(x =>
            {

                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/LoadTheSamePage.xaml", UriKind.Relative));
            });

            mapPage = new ReactiveAsyncCommand();
            mapPage.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/MapPage.xaml", UriKind.Relative));
            });

            webBrowser = new ReactiveAsyncCommand();
            webBrowser.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/WebBrowserExample.xaml", UriKind.Relative));
            });

            listPickerButton = new ReactiveAsyncCommand();
            listPickerButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListPickerExample.xaml", UriKind.Relative));
            });

            listBoxEventsButton = new ReactiveAsyncCommand();
            listBoxEventsButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/ListBoxEvents.xaml", UriKind.Relative));
            });

            pivoteExample1Button = new ReactiveAsyncCommand();
            pivoteExample1Button.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
            });

            redirectPageButton = new ReactiveAsyncCommand();
            redirectPageButton.Subscribe(x =>
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/BottomBarColorChange.xaml", UriKind.Relative));
            });
        }

        private void BackKeyPress(CancelEventArgs myItem)
        {
            myItem.Cancel = true;
            MessageBox.Show("Back Key Pressed");
            //if (null != myItem)
            //{
            //    MessageBox.Show("Back Key Pressed");
            //}
        }
    }
}
