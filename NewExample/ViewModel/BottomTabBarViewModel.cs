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
    
 public class BottomTabBarViewModel : ReactiveObject
    {
        public static SolidColorBrush _BackColor1 = new SolidColorBrush(Colors.Gray);
        public SolidColorBrush BackColor1
        {
            get { return _BackColor1; }
            set { this.RaiseAndSetIfChanged(x => x.BackColor1, value); }
        }

        public static SolidColorBrush _BackColor2;
        public SolidColorBrush BackColor2
        {
            get { return _BackColor2; }
            set { this.RaiseAndSetIfChanged(x => x.BackColor2, value); }
        }

        public static SolidColorBrush _BackColor3;
        public SolidColorBrush BackColor3
        {
            get { return _BackColor3; }
            set { this.RaiseAndSetIfChanged(x => x.BackColor3, value); }
        }

        public static SolidColorBrush _BackColor4;
        public SolidColorBrush BackColor4
        {
            get { return _BackColor4; }
            set { this.RaiseAndSetIfChanged(x => x.BackColor4, value); }
        }

        public ReactiveAsyncCommand Button1 { get; set; }
        public ReactiveAsyncCommand Button2 { get; set; }
        public ReactiveAsyncCommand Button3 { get; set; }
        public ReactiveAsyncCommand Button4 { get; set; }

        public BottomTabBarViewModel()
        {
            Button1 = new ReactiveAsyncCommand();
            Button1.Subscribe(x =>
            {
               
                BackColor1 = new SolidColorBrush(Colors.Gray);
                BackColor2 = new SolidColorBrush(Colors.Black);
                BackColor3 = new SolidColorBrush(Colors.Black);
                BackColor4 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            });

            Button2 = new ReactiveAsyncCommand();
            Button2.Subscribe(x =>
            {
                BackColor2 = new SolidColorBrush(Colors.Gray);
                BackColor1 = new SolidColorBrush(Colors.Black);
                BackColor3 = new SolidColorBrush(Colors.Black);
                BackColor4 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage2.xaml", UriKind.Relative));
            });

            Button3 = new ReactiveAsyncCommand();
            Button3.Subscribe(x =>
            {

                BackColor3 = new SolidColorBrush(Colors.Gray);
                BackColor2 = new SolidColorBrush(Colors.Black);
                BackColor1 = new SolidColorBrush(Colors.Black);
                BackColor4 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage3.xaml", UriKind.Relative));
            });

            Button4 = new ReactiveAsyncCommand();
            Button4.Subscribe(x =>
            {
                BackColor4 = new SolidColorBrush(Colors.Gray);
                BackColor3 = new SolidColorBrush(Colors.Black);
                BackColor2 = new SolidColorBrush(Colors.Black);
                BackColor1 = new SolidColorBrush(Colors.Black);
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Views/IndexPage4.xaml", UriKind.Relative));
            });

        }
    }
}
